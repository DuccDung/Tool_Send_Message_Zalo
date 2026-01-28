using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolSendMessage.models;
using EpplusLicenseContext = OfficeOpenXml.LicenseContext;

namespace ToolSendMessage.view
{
    public partial class MainForm : Form
    {
        private List<Customer> _customers = new();
        private readonly IWebDriver _driver;
        private CancellationTokenSource? _cts;

        // ========= Config =========
        private const int DefaultWaitSeconds = 25;

        public IReadOnlyList<Customer> Customers => _customers;

        // NOTE: Giữ signature gần nhất có thể. Nếu bạn đang gọi MainForm(IWebDriver? driver, WebDriverWait wait)
        // thì bạn có thể sửa ctor call ở chỗ tạo form.
        public MainForm(IWebDriver? driver, WebDriverWait? wait = null)
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            _driver = driver;

            InitializeComponent();

            ExcelPackage.LicenseContext = EpplusLicenseContext.NonCommercial;

            btnAddCsv.Click += BtnAddCsv_Click;
            btnStart.Click += BtnStart_Click;

            Log("Ready.");
        }

        // ========= FORM LIFECYCLE =========
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                _cts?.Cancel();
                _cts?.Dispose();
                _cts = null;
            }
            catch { }

            base.OnFormClosing(e);
        }

        // ========= LOG =========
        public void Log(string message)
        {
            if (IsDisposed) return;

            void Append()
            {
                var line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                txtLog.AppendText(line + Environment.NewLine);
            }

            if (InvokeRequired) BeginInvoke((Action)Append);
            else Append();
        }

        // ========= EVENTS =========
        private void BtnAddCsv_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Select Excel file",
                Filter = "Excel (*.xlsx;*.xlsm)|*.xlsx;*.xlsm|All files (*.*)|*.*",
                Multiselect = false
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                _customers = ReadCustomersFromExcel(ofd.FileName);

                dgvPreview.AutoGenerateColumns = true;
                dgvPreview.DataSource = null;
                dgvPreview.DataSource = _customers;

                if (dgvPreview.Columns != null)
                {
                    if (dgvPreview.Columns.Contains(nameof(Customer.Total)))
                        dgvPreview.Columns[nameof(Customer.Total)].Visible = false;

                    if (dgvPreview.Columns.Contains(nameof(Customer.TotalVnd)))
                        dgvPreview.Columns[nameof(Customer.TotalVnd)].HeaderText = "ToTal";
                }

                Log($"Imported: {_customers.Count} customers");
            }
            catch (Exception ex)
            {
                Log("IMPORT ERROR: " + ex.Message);
                MessageBox.Show(ex.Message, "Import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnStart_Click(object? sender, EventArgs e)
        {
            if (_customers == null || _customers.Count == 0)
            {
                Log("Chưa có dữ liệu khách hàng.");
                return;
            }

            btnStart.Enabled = false;
            btnAddCsv.Enabled = false;

            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();

            try
            {
                Log("Start sending...");

                foreach (var cust in _customers)
                {
                    _cts.Token.ThrowIfCancellationRequested();

                    try
                    {
                        await SendMessageToCustomerAsync(cust, _cts.Token);
                    }
                    catch (AutomationAbortException ex)
                    {
                        // Lỗi nghiêm trọng => nhảy về login + dừng luôn
                        Log("ABORT: " + ex.Message);
                        GoToLogin("Phiên thao tác Selenium bị gián đoạn hoặc UI Zalo thay đổi.");
                        break;
                    }
                    catch (OperationCanceledException)
                    {
                        Log("Cancelled.");
                        break;
                    }
                    catch (Exception ex)
                    {
                        // 1 khách fail không dừng toàn bộ
                        Log($"ERROR {cust.CustomerName} ({cust.Phone}): {ex.Message}");
                    }
                }

                Log("Done.");
            }
            finally
            {
                btnStart.Enabled = true;
                btnAddCsv.Enabled = true;
            }
        }

        // ========= CORE AUTOMATION =========
        private async Task SendMessageToCustomerAsync(Customer customer, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var phone = customer.Phone?.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                Log($"Skip empty phone: {customer.CustomerName}");
                return;
            }

            var message =
                $"Agribank Hoa Lư xin thông báo lãi của khách hàng {customer.CustomerName} đến 31/01/2026 là: {customer.TotalVnd:N0} đồng. " +
                $"Xin trân trọng cảm ơn.";

            EnsureDriverAlive();

            // Tip: luôn về default content trước khi thao tác (nếu có iframe)
            SafeSwitchToDefaultContent();

            // 1) Click "Thêm bạn"
            await Delay(700, ct);
            ClickSafe(RequireVisible(By.XPath("//div[@data-id='btn_Main_AddFrd']"), DefaultWaitSeconds, "btn_Main_AddFrd"));

            // 2) Nhập số điện thoại
            await Delay(400, ct);
            TypePhoneNumber(phone, ct);

            // 3) Click Search
            await Delay(300, ct);
            ClickSafe(RequireVisible(By.XPath("//div[@data-id='btn_Main_AddFrd_Search']"), DefaultWaitSeconds, "btn_Main_AddFrd_Search"));

            // 4) Click Nhắn tin
            await Delay(500, ct);
            var inner = RequireVisible(By.CssSelector("div[data-translate-inner='STR_CHAT']"), 15, "STR_CHAT");
            var chatBtn = inner.FindElements(By.XPath("./ancestor::div[contains(@class,'z--btn--v2')]")).FirstOrDefault();
            if (chatBtn == null) throw new AutomationAbortException("Không tìm thấy nút Nhắn tin (ancestor z--btn--v2).");
            ClickSafe(chatBtn);

            // 5) Focus ô chat & nhập nội dung
            await Delay(400, ct);
            var inputBox = RequireVisible(By.CssSelector("#input_line_0"), 15, "input_line_0");
            SetChatText(inputBox, message);

            // 6) Gửi (ưu tiên click nút send; nếu không thấy thì Enter)
            await Delay(200, ct);
            var send = WaitVisible(By.CssSelector("div[data-translate-title='STR_SEND']"), 8);
            if (send != null)
            {
                ClickSafe(send);
            }
            else
            {
                // fallback Enter
                inputBox.SendKeys(OpenQA.Selenium.Keys.Enter);
            }

            await Delay(900, ct);
            Log($"Sent: {customer.CustomerName} ({customer.Phone})");
        }

        // ========= Selenium Helpers =========

        private void EnsureDriverAlive()
        {
            try
            {
                // bất kỳ call nào cũng được để check session
                _ = _driver.Title;
            }
            catch (WebDriverException ex)
            {
                throw new AutomationAbortException("WebDriver session đã chết: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new AutomationAbortException("Driver error: " + ex.Message);
            }
        }

        private void SafeSwitchToDefaultContent()
        {
            try { _driver.SwitchTo().DefaultContent(); }
            catch { }
        }

        private static async Task Delay(int ms, CancellationToken ct)
        {
            if (ms <= 0) return;
            await Task.Delay(ms, ct);
        }

        // WaitVisible trả IWebElement? (nullable) để caller quyết định.
        private IWebElement? WaitVisible(By by, int seconds)
        {
            try
            {
                var wait = new WebDriverWait(new SystemClock(), _driver, TimeSpan.FromSeconds(seconds), TimeSpan.FromMilliseconds(250));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));

                return wait.Until(d =>
                {
                    var el = d.FindElements(by).FirstOrDefault();
                    if (el == null) return null;
                    return el.Displayed ? el : null;
                });
            }
            catch (WebDriverTimeoutException)
            {
                MessageBox.Show("Bạn không được đóng trình duyệt hoặc ẩn khi đang chạy tool. (Tip: hãy đóng trình duyệt và làm lại bước)", "Lỗi Selenium", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebDriverException ex)
            {
                MessageBox.Show("Bạn không được đóng trình duyệt hoặc ẩn khi đang chạy tool. (Tip: hãy đóng trình duyệt và làm lại bước đầu)", "Lỗi Selenium", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new AutomationAbortException("WebDriverException: " + ex.Message);
            }
        }

        private IWebElement RequireVisible(By by, int seconds, string stepName)
        {
            var el = WaitVisible(by, seconds);
            if (el == null)
                throw new AutomationAbortException($"Timeout/NotFound at step: {stepName}");
            return el;
        }

        private void ClickSafe(IWebElement el)
        {
            try
            {
                el.Click();
                return;
            }
            catch (ElementClickInterceptedException) { }
            catch (StaleElementReferenceException)
            {
                throw new AutomationAbortException("Element bị stale khi click.");
            }
            catch { }

            // Try Actions click
            try
            {
                var act = new Actions(_driver);
                act.MoveToElement(el).Pause(TimeSpan.FromMilliseconds(80)).Click().Perform();
                return;
            }
            catch { }

            // JS click as last fallback
            try
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", el);
            }
            catch (Exception ex)
            {
                throw new AutomationAbortException("Không click được element: " + ex.Message);
            }
        }

        private void TypePhoneNumber(string phone, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var by = By.CssSelector("input[data-id='txt_Main_AddFrd_Phone']");
            var input = RequireVisible(by, 20, "txt_Main_AddFrd_Phone");

            // Scroll into view
            try
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", input);
            }
            catch { }

            // Clear & type
            try
            {
                input.Click();
                input.Clear();
                input.SendKeys(phone);
            }
            catch (StaleElementReferenceException)
            {
                // get fresh & try again
                input = RequireVisible(by, 20, "txt_Main_AddFrd_Phone (retry)");
                input.Click();
                input.Clear();
                input.SendKeys(phone);
            }
            catch (WebDriverException ex)
            {
                throw new AutomationAbortException("Không nhập được phone: " + ex.Message);
            }
        }

        /// <summary>
        /// Zalo chat input thường là div/contenteditable. Set text theo cách "an toàn":
        /// - click focus
        /// - SendKeys text
        /// - fallback JS set innerText + dispatch input event
        /// </summary>
        private void SetChatText(IWebElement inputBox, string message)
        {
            try
            {
                ClickSafe(inputBox);
                inputBox.SendKeys(message);
                return;
            }
            catch { }

            // fallback JS set text
            try
            {
                var js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript(@"
                    const el = arguments[0];
                    const text = arguments[1];
                    el.focus();
                    // clear existing
                    if (el.isContentEditable) {
                        el.innerText = '';
                        el.innerText = text;
                    } else if (el.value !== undefined) {
                        el.value = text;
                    } else {
                        el.textContent = text;
                    }
                    el.dispatchEvent(new Event('input', { bubbles: true }));
                    el.dispatchEvent(new Event('change', { bubbles: true }));
                ", inputBox, message);
            }
            catch (Exception ex)
            {
                throw new AutomationAbortException("Không set được nội dung chat: " + ex.Message);
            }
        }

        // ========= NAV BACK TO LOGIN =========
        private void GoToLogin(string reason)
        {
            Log("GO LOGIN: " + reason);

            void Act()
            {
                try
                {
                    var loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide(); // Hide để tránh app exit nếu MainForm là main window
                }
                catch (Exception ex)
                {
                    Log("GoToLogin error: " + ex.Message);
                }
            }

            if (IsDisposed) return;
            if (InvokeRequired) BeginInvoke((Action)Act);
            else Act();
        }

        // ========= EXCEL IMPORT =========
        private static List<Customer> ReadCustomersFromExcel(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found.", filePath);

            using var package = new ExcelPackage(new FileInfo(filePath));
            var ws = package.Workbook.Worksheets.FirstOrDefault();
            if (ws == null || ws.Dimension == null) return new List<Customer>();

            var startRow = ws.Dimension.Start.Row;
            var endRow = ws.Dimension.End.Row;
            var startCol = ws.Dimension.Start.Column;
            var endCol = ws.Dimension.End.Column;

            int headerRow = startRow;

            var headerMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            for (int col = startCol; col <= endCol; col++)
            {
                var header = (ws.Cells[headerRow, col].Text ?? "").Trim();
                if (!string.IsNullOrWhiteSpace(header) && !headerMap.ContainsKey(header))
                    headerMap[header] = col;
            }

            var required = new[] { "MKH", "Customer", "ToTal", "Phone" };
            var missing = required.Where(h => !headerMap.ContainsKey(h)).ToList();
            if (missing.Count > 0)
            {
                throw new InvalidOperationException(
                    "Missing required columns: " + string.Join(", ", missing) +
                    ". Expected headers: MKH, Customer, ToTal, Phone.");
            }

            int dataStartRow = headerRow + 1;
            var list = new List<Customer>();

            for (int row = dataStartRow; row <= endRow; row++)
            {
                string mkh = ws.Cells[row, headerMap["MKH"]].Text?.Trim() ?? "";
                string name = ws.Cells[row, headerMap["Customer"]].Text?.Trim() ?? "";
                string phone = ws.Cells[row, headerMap["Phone"]].Text?.Trim() ?? "";
                string totalText = ws.Cells[row, headerMap["ToTal"]].Text?.Trim() ?? "";

                bool allEmpty = string.IsNullOrWhiteSpace(mkh)
                                && string.IsNullOrWhiteSpace(name)
                                && string.IsNullOrWhiteSpace(phone)
                                && string.IsNullOrWhiteSpace(totalText);

                if (allEmpty) continue;

                var customer = new Customer
                {
                    MKH = mkh,
                    CustomerName = name,
                    Phone = phone,
                    Total = ParseDecimalSmart(totalText)
                };

                list.Add(customer);
            }

            return list;
        }

        private static decimal ParseDecimalSmart(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0m;

            var s = input.Trim().Replace(" ", "");

            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out var v))
                return v;

            if (decimal.TryParse(s, NumberStyles.Number, new CultureInfo("vi-VN"), out v))
                return v;

            s = s.Replace(",", "");
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out v))
                return v;

            return 0m;
        }
    }

    // ========= ABORT EXCEPTION =========
    public class AutomationAbortException : Exception
    {
        public AutomationAbortException(string message) : base(message) { }
    }
}

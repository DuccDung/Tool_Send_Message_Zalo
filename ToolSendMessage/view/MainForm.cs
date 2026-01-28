using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using ToolSendMessage.models;
using EpplusLicenseContext = OfficeOpenXml.LicenseContext;
using OpenQA.Selenium.Interactions;
namespace ToolSendMessage.view
{
    public partial class MainForm : Form
    {
        private List<Customer> _customers = new();
        private IWebDriver? _driver;
        private WebDriverWait? _wait;
        /// <summary>
        /// Bạn dùng list này để xử lý logic sau khi import.
        /// </summary>
        public IReadOnlyList<Customer> Customers => _customers;

        public MainForm(IWebDriver? driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            InitializeComponent();

            // EPPlus license context
            ExcelPackage.LicenseContext = EpplusLicenseContext.NonCommercial;

            // Wire events (logic chỉ ở .cs)
            btnAddCsv.Click += BtnAddCsv_Click;
            btnStart.Click += BtnStart_Click;

            Log("Ready.");
        }

        // ====== LOG HELPER ======
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

        // ====== EVENTS ======
        // ====== EVENTS ======
        private async void BtnStart_Click(object? sender, EventArgs e)
        {
            if (_customers == null || _customers.Count == 0)
            {
                Log("Chưa có dữ liệu khách hàng.");
                return;
            }

            btnStart.Enabled = false;
            btnAddCsv.Enabled = false;

            try
            {
                Log("Start clicked.");

                foreach (var cust in _customers)
                {
                    try
                    {
                        await SendMessageToCustomerAsync(cust);
                    }
                    catch (Exception ex)
                    {
                        // Không để 1 khách fail làm dừng toàn bộ
                        Log($"ERROR sending to {cust.CustomerName} ({cust.Phone}): {ex.Message}");
                    }
                }

                Log("Done sending.");
            }
            finally
            {
                btnStart.Enabled = true;
                btnAddCsv.Enabled = true;
            }
        }

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
                var customers = ReadCustomersFromExcel(ofd.FileName);

                _customers = customers;

                // Preview lên DataGridView
                dgvPreview.AutoGenerateColumns = true;
                dgvPreview.DataSource = null;
                dgvPreview.DataSource = _customers;

                // Ensure dgvPreview.Columns is not null before accessing it
                if (dgvPreview.Columns != null)
                {
                    dgvPreview.Columns[nameof(Customer.Total)].Visible = false;
                    dgvPreview.Columns[nameof(Customer.TotalVnd)].HeaderText = "ToTal";
                }

                foreach (var cust in _customers)
                {
                    Log("mã khách hàng" + cust.MKH);
                    Log("Tên khách hàng" + cust.CustomerName);
                    Log("Số nợ khách hàng" + FormatVnd(cust.Total, true));
                    Log("SDT khách hàng" + cust.Phone);
                }
            }
            catch (Exception ex)
            {
                Log("ERROR: " + ex.Message);
                MessageBox.Show(ex.Message, "Import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string FormatVnd(decimal amount, bool withSymbol = true)
        {
            var vi = new CultureInfo("vi-VN");
            // N0: không có phần thập phân, có phân tách nghìn theo culture
            var formatted = amount.ToString("N0", vi); // "8.153.425"

            return withSymbol ? $"{formatted} ₫" : formatted;
        }
        // ====== CORE: READ + MAP ======
        private static List<Customer> ReadCustomersFromExcel(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found.", filePath);

            using var package = new ExcelPackage(new FileInfo(filePath));
            var ws = package.Workbook.Worksheets.FirstOrDefault();
            if (ws == null || ws.Dimension == null)
                return new List<Customer>();

            var startRow = ws.Dimension.Start.Row;
            var endRow = ws.Dimension.End.Row;
            var startCol = ws.Dimension.Start.Column;
            var endCol = ws.Dimension.End.Column;

            // Header row = dòng đầu tiên (vùng bôi vàng)
            int headerRow = startRow;

            // Map header -> column index
            var headerMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            for (int col = startCol; col <= endCol; col++)
            {
                var header = (ws.Cells[headerRow, col].Text ?? "").Trim();
                if (!string.IsNullOrWhiteSpace(header) && !headerMap.ContainsKey(header))
                    headerMap[header] = col;
            }

            // Required headers theo ảnh: MKH, Customer, ToTal, Phone
            // (ToTal viết đúng như file bạn: "ToTal")
            var required = new[] { "MKH", "Customer", "ToTal", "Phone" };
            var missing = required.Where(h => !headerMap.ContainsKey(h)).ToList();
            if (missing.Count > 0)
            {
                throw new InvalidOperationException(
                    "Missing required columns: " + string.Join(", ", missing) +
                    ". Expected headers: MKH, Customer, ToTal, Phone (exact text on header row).");
            }

            int dataStartRow = headerRow + 1;
            var list = new List<Customer>(capacity: Math.Max(0, endRow - dataStartRow + 1));

            for (int row = dataStartRow; row <= endRow; row++)
            {
                string mkh = ws.Cells[row, headerMap["MKH"]].Text?.Trim() ?? "";
                string name = ws.Cells[row, headerMap["Customer"]].Text?.Trim() ?? "";
                string phone = ws.Cells[row, headerMap["Phone"]].Text?.Trim() ?? "";
                string totalText = ws.Cells[row, headerMap["ToTal"]].Text?.Trim() ?? "";

                // Bỏ qua dòng trống hoàn toàn
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

            // remove thousand separators common patterns (e.g. 8,153,425)
            // also handle spaces
            var s = input.Trim().Replace(" ", "");

            // Try: Invariant with commas as thousands
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out var v))
                return v;

            // Try: Vietnamese culture
            if (decimal.TryParse(s, NumberStyles.Number, new CultureInfo("vi-VN"), out v))
                return v;

            // Last resort: remove commas and try again
            s = s.Replace(",", "");
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out v))
                return v;

            return 0m;
        }

        // ====== CORE: Utils sender ======
        // ====== CORE: Utils sender ======
        private async Task SendMessageToCustomerAsync(Customer customer)
        {
            if (_driver == null || _wait == null)
            {
                Log("WebDriver not initialized.");
                return;
            }

            var phone = customer.Phone?.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                Log($"Empty phone for customer {customer.CustomerName}");
                return;
            }

            var message =
                 $"Agribank Hoa Lư xin thông báo lãi của khách hàng {customer.CustomerName} đến 31/01/2026 là: {customer.TotalVnd:N0} đồng. " +
                 $"Xin trân trọng cảm ơn.";



            // 1) Click nút Thêm bạn
            await Task.Delay(1000);
            var addBtn = WaitVisible(By.XPath("//div[@data-id='btn_Main_AddFrd']"), 25);
            ClickSafe(addBtn);

            // 2) Nhập số điện thoại
            await Task.Delay(600);
            TypePhoneNumber(phone);

            // 3) Click Tìm kiếm
            await Task.Delay(600);
            var searchBtn = WaitVisible(By.XPath("//div[@data-id='btn_Main_AddFrd_Search']"), 25);
            ClickSafe(searchBtn);

            // 4) Click Nhắn tin
            await Task.Delay(800);
            var inner = WaitVisible(By.CssSelector("div[data-translate-inner='STR_CHAT']"), 10);
            var btn = inner.FindElement(By.XPath("./ancestor::div[contains(@class,'z--btn--v2')]"));
            ClickSafe(btn);

            // 5) Focus ô chat và nhập nội dung
            await Task.Delay(500);
            var inputBox = WaitVisible(By.XPath("//div[@id='input_line_0']"), 10);
            inputBox.Click();
            inputBox.SendKeys(message);

            // 6) Click Gửi
            await Task.Delay(300);
            var sendBtn = WaitVisible(By.CssSelector("div[data-translate-title='STR_SEND']"), 10);
            ClickSafe(sendBtn);

            // Chờ UI gửi xong (tuỳ bạn chỉnh)
            await Task.Delay(1500);

            Log($"Sent message to {customer.CustomerName} ({customer.Phone})");
        }
        private IWebElement WaitVisible(By by, int seconds = 25)
        {
            try
            {
                var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                return wait.Until(d =>
                {
                    var el = d.FindElement(by);
                    return el.Displayed ? el : null;
                });
            }
            catch (Exception ex)
            {
                Log("Lỗi chỗ WaitVisible: " + ex.Message);
                DialogResult result = MessageBox.Show("Bạn không được đóng/ẩn trình duyệt đang mở. Bây giờ bạn hãy nhấn Ok để login lại nhé(lưu ý: đóng trình duyệt có zalo bạn vừa mở lúc nãy!!!)", "Error", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                }
                else this.Close();
                return null;
            }
        }
        private void ClickSafe(IWebElement el)
        {
            try { el.Click(); }
            catch
            {
                // nếu bị intercept/overlay thì click JS
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", el);
            }
        }
        private IWebElement WaitVisibleNoStale(By by, int seconds = 20)
        {
            var wait = new WebDriverWait(_driver!, TimeSpan.FromSeconds(seconds));
            return wait.Until(d =>
            {
                try
                {
                    var el = d.FindElement(by);
                    return (el.Displayed && el.Enabled) ? el : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null; // bắt stale -> thử lại
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }

        private void TypePhoneNumber(string phone)
        {
            var by = By.CssSelector("input[data-id='txt_Main_AddFrd_Phone']");

            // Lấy element "tươi"
            var input = WaitVisibleNoStale(by, 20);

            try
            {
                ((IJavaScriptExecutor)_driver!).ExecuteScript(
                    "arguments[0].scrollIntoView({block:'center'});", input);
            }
            catch (StaleElementReferenceException)
            {
                // stale ngay lúc scroll -> lấy lại lần nữa
                input = WaitVisibleNoStale(by, 20);
                ((IJavaScriptExecutor)_driver!).ExecuteScript(
                    "arguments[0].scrollIntoView({block:'center'});", input);
            }

            input.Click();          // thường đủ, không cần JS focus
            input.Clear();
            input.SendKeys(phone);
        }


    }
}

namespace ToolSendMessage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Drawing;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public partial class Form1 : Form
    {
        private IWebDriver? _driver;
        private WebDriverWait? _wait;

        public Form1()
        {
            InitializeComponent();
            btnSend.Enabled = false;
        }

        private void SetStatus(string s) => lblStatus.Text = s;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                SetStatus("Đang mở CocCoc...");

                var options = new ChromeOptions();
                options.BinaryLocation = @"C:\Program Files\CocCoc\Browser\Application\browser.exe";
                options.AddArgument("--start-maximized");

                //Profile riêng cho Selenium (bạn login 1 lần)
                options.AddArgument(@"--user-data-dir=C:\ZaloCocCocProfile");
                options.AddArgument("--profile-directory=Default"); // có thể bỏ nếu không cần

                _driver = new ChromeDriver(options);
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));

                _driver.Navigate().GoToUrl("https://chat.zalo.me/");
                SetStatus("Mở Zalo Web bằng profile riêng. Nếu lần đầu, hãy login 1 lần.");

                btnSend.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi mở Zalo");
                SetStatus("Lỗi.");
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (_driver == null || _wait == null) return;

            var phone = txtPhone.Text.Trim();
            var message = txtMessage.Text;

            if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Nhập SĐT và nội dung tin nhắn.");
                return;
            }

            try
            {
                btnSend.Enabled = false;
                SetStatus("Đang thao tác UI...");

                await Task.Run(() =>
                {
                    // 1) Click nút "Thêm bạn / Tìm kiếm / Add contact"
                    // XPath dưới đây dựa theo đoạn Python bạn chụp (có thể cần cập nhật nếu UI đổi)
                    // Ví dụ icon add friend: <i class="fa fa-outline-add-new-contact-2 pre"></i>
                    //< div icon = "outline-add-new-contact-2" data - id = "btn_Main_AddFrd" class="z--btn--v2 btn-tertiary-neutral medium  --rounded icon-only" data-disabled="" data-translate-title="STR_CONTACT_ADD_FRIEND" title="Thêm bạn"><i class="fa fa-outline-add-new-contact-2 pre"></i></div>
                    var addBtn = WaitVisible(By.XPath("//div[@data-id='btn_Main_AddFrd']"), 25);
                    ClickSafe(addBtn);

                    // 2) Nhập số điện thoại
                    // Ví dụ input: class contains 'phone-i-input'
                    //var searchInput = WaitVisible(By.Id("contact-search-input"), 25);
                    //searchInput.Click();
                    //searchInput.Clear();
                    //searchInput.SendKeys(phone + System.Windows.Forms.Keys.Enter);
                    TypePhoneNumber(phone);
                    // 3) Click "Tìm kiếm"
                    // Bạn cần inspect đúng nút. Dưới là hướng tiếp cận phổ biến:
                    // - Tìm button trong modal có text 'Tìm kiếm' hoặc class z-btn--v2...
                    var searchBtn = WaitVisible(By.XPath("//div[@data-id='btn_Main_AddFrd_Search']"), 25);
                    ClickSafe(searchBtn);

                    // 4) Click "Nhắn tin"
                    // Trong ảnh bạn có: //span[@class='btnpf-content' ...]
                    //var chatBtn = _wait.Until(d =>
                    //    d.FindElement(By.XPath("//span[contains(@class,'btnpf-content') and contains(.,'Nhắn tin')]")));
                    //chatBtn.Click();
                    var inner = WaitVisible(By.CssSelector("div[data-translate-inner='STR_CHAT']"), 10);
                    var btn = inner.FindElement(By.XPath("./ancestor::div[contains(@class,'z--btn--v2')]"));
                    ClickSafe(btn);



                    // 5) Focus vào ô nhập chat và gõ nội dung
                    // Trong ảnh bạn có div id='input_line_0'
                    var inputBox = _wait.Until(d =>
                        d.FindElement(By.XPath("//div[@id='input_line_0']")));
                    inputBox.Click();
                    inputBox.SendKeys(message);

                    // 6) Click nút Gửi
                    // Ảnh bạn có: //div[@data-translate-inner='STR_SEND']
                    var sendBtn = WaitVisible(By.CssSelector("div[data-translate-title='STR_SEND']"), 10);
                    ClickSafe(sendBtn);
                });

                SetStatus("Gửi xong ✅");
            }
            catch (WebDriverTimeoutException)
            {
                SetStatus("Timeout: không tìm thấy element (selector có thể đã đổi).");
                MessageBox.Show("Không tìm thấy element. Bạn cần inspect lại XPath/CSS selector theo UI hiện tại.");
            }
            catch (Exception ex)
            {
                SetStatus("Lỗi gửi.");
                MessageBox.Show(ex.ToString(), "Lỗi gửi tin");
            }
            finally
            {
                btnSend.Enabled = true;
            }
        }
        private IWebElement WaitVisible(By by, int seconds = 25)
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(d =>
            {
                var el = d.FindElement(by);
                return el.Displayed ? el : null;
            });
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
        private void TypePhoneNumber(string phone)
        {
            var by = By.CssSelector("input[data-id='txt_Main_AddFrd_Phone']");
            var input = WaitVisible(by, 20);

            ((IJavaScriptExecutor)_driver!).ExecuteScript(
                "arguments[0].scrollIntoView({block:'center'});", input);

            ((IJavaScriptExecutor)_driver!).ExecuteScript("arguments[0].focus();", input);

            input.Clear();
            input.SendKeys(phone);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { _driver?.Quit(); } catch { /* ignore */ }
        }
    }
}


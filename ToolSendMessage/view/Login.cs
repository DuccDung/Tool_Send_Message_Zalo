using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
namespace ToolSendMessage.view
{
    public partial class LoginForm : Form
    {
        private IWebDriver? _driver;
        private WebDriverWait? _wait;

        public LoginForm()
        {
            InitializeComponent();

            btnLoginZalo.Click += BtnLoginZalo_Click;
            btnAlreadyLoggedIn.Click += BtnAlreadyLoggedIn_Click;

            btnGuide.Click += BtnGuide_Click;

            Log("Ready.");
        }

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

        // (1) Login Zalo -> chỉ log theo yêu cầu
        private void BtnLoginZalo_Click(object? sender, EventArgs e)
        {
            try
            {
                Log("Đang mở CocCoc...");
                var options = new ChromeOptions();
                options.BinaryLocation = @"C:\Program Files\CocCoc\Browser\Application\browser.exe";
                options.AddArgument("--start-maximized");

                //Profile riêng cho Selenium (bạn login 1 lần)
                options.AddArgument(@"--user-data-dir=C:\ZaloCocCocProfile");
                options.AddArgument("--profile-directory=Default"); // có thể bỏ nếu không cần

                _driver = new ChromeDriver(options);
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));

                _driver.Navigate().GoToUrl("https://chat.zalo.me/");
                Log("Mở Zalo Web bằng profile riêng. Nếu lần đầu, hãy login 1 lần.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn cần đóng trình duyệt(coccoc || chrome) cũ lại nhé thì mới mở được!");
            }
        }

        // (2) Xem hướng dẫn -> mở Zalo
        private void BtnGuide_Click(object? sender, EventArgs e)
        {
            try
            {
                var url = "https://youtu.be/93ubx9OuU38";
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở link hướng dẫn. Vui lòng copy và mở thủ công:\nhttps://youtu.be/93ubx9OuU38");
            }
        }


        // (3) Đã login Zalo -> chỉ log theo yêu cầu
        private void BtnAlreadyLoggedIn_Click(object? sender, EventArgs e)
        {
            if (_driver == null || _wait == null)
            {
                MessageBox.Show("Vui lòng đăng nhập Zalo trước.", "Chưa đăng nhập");
                return;
            }

            MainForm mainForm = new MainForm(_driver, _wait);
            mainForm.Show();
            this.Hide();
        }


    }
}

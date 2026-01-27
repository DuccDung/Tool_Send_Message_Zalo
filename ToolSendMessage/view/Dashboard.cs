using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace ToolSendMessage.view
{
        public partial class Dashboard : Form
        {
            private bool _logVisible = true;

            public Dashboard()
            {
                InitializeComponent();
                Log("INFO", "Dashboard loaded.");
            }

            private void btnGuide_Click(object sender, EventArgs e)
            {
                // Mở video hướng dẫn bằng trình duyệt 
                var url = "https://www.youtube.com/"; 
                try
                {
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    Log("INFO", "Open guide video.");
                }
                catch (Exception ex)
                {
                    Log("ERROR", "Không mở được hướng dẫn: " + ex.Message);
                    MessageBox.Show("Không mở được hướng dẫn.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void btnStartTool_Click(object sender, EventArgs e)
            {
                // TODO: chỗ này bạn gắn flow start tool gửi tin nhắn Zalo
                Log("INFO", "Start Tool clicked.");
                MessageBox.Show("Bạn đã bấm Start Tool (chưa gắn logic).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void btnViewLog_Click(object sender, EventArgs e)
            {
                _logVisible = !_logVisible;
                grpLog.Visible = _logVisible;
                btnViewLog.Text = _logVisible ? "Hide Log" : "View Log";
                Log("INFO", _logVisible ? "Log shown." : "Log hidden.");
            }

            private void btnAddCsv_Click(object sender, EventArgs e)
            {
                if (openFileCsv.ShowDialog(this) != DialogResult.OK)
                    return;

                txtCsvPath.Text = openFileCsv.FileName;
                Log("INFO", "Selected CSV: " + openFileCsv.FileName);

                try
                {
                    var phones = ReadPhonesFromCsv(openFileCsv.FileName);
                    BindPhonesToGrid(phones);
                    Log("INFO", $"Loaded {phones.Count} phone(s) from CSV.");
                }
                catch (Exception ex)
                {
                    Log("ERROR", "Read CSV failed: " + ex.Message);
                    MessageBox.Show("Đọc CSV thất bại.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private List<string> ReadPhonesFromCsv(string path)
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException("File không tồn tại.", path);

                // Đọc CSV robust bằng TextFieldParser (hỗ trợ quoted field)
                var result = new List<string>();

                using (var parser = new TextFieldParser(path))
                {
                    parser.TextFieldType = FieldType.Delimited;

                    // thử cả "," và ";" (rất hay gặp ở CSV xuất từ Excel VN)
                    parser.SetDelimiters(",", ";", "\t");
                    parser.HasFieldsEnclosedInQuotes = true;

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (fields == null || fields.Length == 0) continue;

                        // Lấy số điện thoại từ cột đầu (bạn có thể đổi logic lấy theo tên cột)
                        var raw = (fields[0] ?? "").Trim();

                        if (string.IsNullOrWhiteSpace(raw))
                            continue;

                        // bỏ header kiểu "phone", "sdt", "so_dien_thoai"
                        if (IsHeaderLike(raw))
                            continue;

                        var normalized = NormalizePhone(raw);
                        if (string.IsNullOrEmpty(normalized))
                            continue;

                        result.Add(normalized);
                    }
                }

                // unique + giữ thứ tự
                return result
                    .Select((p, idx) => new { p, idx })
                    .GroupBy(x => x.p)
                    .Select(g => g.First())
                    .OrderBy(x => x.idx)
                    .Select(x => x.p)
                    .ToList();
            }

            private static bool IsHeaderLike(string s)
            {
                var t = s.Trim().ToLowerInvariant();
                return t == "phone" || t == "sdt" || t == "so_dien_thoai" || t == "số điện thoại" || t == "điện thoại";
            }

            private static string NormalizePhone(string input)
            {
                // Giữ số + dấu + đầu, bỏ khoảng trắng/ký tự lạ
                var t = input.Trim();

                // nếu kiểu "84 912..." hoặc "(+84)..." -> lọc chỉ + và digit
                t = Regex.Replace(t, @"[^\d\+]", "");

                // nếu có nhiều dấu +, giữ cái đầu
                if (t.Count(c => c == '+') > 1)
                {
                    t = "+" + new string(t.Where(char.IsDigit).ToArray());
                }

                // Nếu chuỗi rỗng sau normalize -> bỏ
                if (string.IsNullOrWhiteSpace(t)) return "";

                // Ví dụ normalize kiểu VN: 0xxxxxxxxx => +84xxxxxxxxx (tuỳ bạn)
                // Ở đây mình KHÔNG ép chuẩn cứng, chỉ trả về digits/+.
                return t;
            }

            private void BindPhonesToGrid(List<string> phones)
            {
                var dt = new DataTable();
                dt.Columns.Add("No", typeof(int));
                dt.Columns.Add("Phone", typeof(string));

                for (int i = 0; i < phones.Count; i++)
                {
                    dt.Rows.Add(i + 1, phones[i]);
                }

                dgvPhones.DataSource = dt;
            }

            private void Log(string level, string message)
            {
                var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var item = new ListViewItem(time);
                item.SubItems.Add(level);
                item.SubItems.Add(message);

                lvLog.Items.Add(item);
                lvLog.EnsureVisible(lvLog.Items.Count - 1);
            }
        }
}

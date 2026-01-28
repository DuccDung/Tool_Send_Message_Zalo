namespace ToolSendMessage.view
{
        partial class LoginForm
        {
            private System.ComponentModel.IContainer components = null;

            private System.Windows.Forms.TableLayoutPanel tlpRoot;
            private System.Windows.Forms.Panel pnlCard;
            private System.Windows.Forms.Label lblTitle;
            private System.Windows.Forms.Label lblSubTitle;

            private System.Windows.Forms.Button btnLoginZalo;
            private System.Windows.Forms.Button btnGuide;
            private System.Windows.Forms.Button btnAlreadyLoggedIn;

            private System.Windows.Forms.Panel pnlBottom;
            private System.Windows.Forms.Label lblLog;
            private System.Windows.Forms.TextBox txtLog;

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null)) components.Dispose();
                base.Dispose(disposing);
            }

            private void InitializeComponent()
            {
                this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
                this.pnlCard = new System.Windows.Forms.Panel();
                this.lblTitle = new System.Windows.Forms.Label();
                this.lblSubTitle = new System.Windows.Forms.Label();
                this.btnLoginZalo = new System.Windows.Forms.Button();
                this.btnGuide = new System.Windows.Forms.Button();
                this.btnAlreadyLoggedIn = new System.Windows.Forms.Button();
                this.pnlBottom = new System.Windows.Forms.Panel();
                this.lblLog = new System.Windows.Forms.Label();
                this.txtLog = new System.Windows.Forms.TextBox();

                this.tlpRoot.SuspendLayout();
                this.pnlCard.SuspendLayout();
                this.pnlBottom.SuspendLayout();
                this.SuspendLayout();

                // tlpRoot
                this.tlpRoot.ColumnCount = 1;
                this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                this.tlpRoot.RowCount = 2;
                this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
                this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
                this.tlpRoot.Padding = new System.Windows.Forms.Padding(16);
                this.tlpRoot.BackColor = System.Drawing.Color.White;

                // pnlCard
                this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
                this.pnlCard.Padding = new System.Windows.Forms.Padding(24);
                this.pnlCard.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
                this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                // lblTitle
                this.lblTitle.AutoSize = true;
                this.lblTitle.Text = "Đăng nhập";
                this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
                this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
                this.lblTitle.Location = new System.Drawing.Point(24, 20);

                // lblSubTitle
                this.lblSubTitle.AutoSize = true;
                this.lblSubTitle.Text = "Vui lòng đăng nhập bằng Zalo để tiếp tục.";
                this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
                this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(90, 98, 106);
                this.lblSubTitle.Location = new System.Drawing.Point(26, 62);

                // btnLoginZalo
                this.btnLoginZalo.Text = "Login Zalo";
                this.btnLoginZalo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
                this.btnLoginZalo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnLoginZalo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 122, 204);
                this.btnLoginZalo.BackColor = System.Drawing.Color.White;
                this.btnLoginZalo.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnLoginZalo.Size = new System.Drawing.Size(260, 44);
                this.btnLoginZalo.Location = new System.Drawing.Point(30, 110);
                this.btnLoginZalo.Name = "btnLoginZalo";

                // btnGuide
                this.btnGuide.Text = "Xem hướng dẫn";
                this.btnGuide.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
                this.btnGuide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnGuide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 214, 219);
                this.btnGuide.BackColor = System.Drawing.Color.White;
                this.btnGuide.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnGuide.Size = new System.Drawing.Size(260, 44);
                this.btnGuide.Location = new System.Drawing.Point(30, 165);
                this.btnGuide.Name = "btnGuide";

                // btnAlreadyLoggedIn
                this.btnAlreadyLoggedIn.Text = "Đã login Zalo";
                this.btnAlreadyLoggedIn.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
                this.btnAlreadyLoggedIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnAlreadyLoggedIn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(25, 135, 84);
                this.btnAlreadyLoggedIn.BackColor = System.Drawing.Color.White;
                this.btnAlreadyLoggedIn.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnAlreadyLoggedIn.Size = new System.Drawing.Size(260, 44);
                this.btnAlreadyLoggedIn.Location = new System.Drawing.Point(30, 220);
                this.btnAlreadyLoggedIn.Name = "btnAlreadyLoggedIn";

                // add controls to card
                this.pnlCard.Controls.Add(this.lblTitle);
                this.pnlCard.Controls.Add(this.lblSubTitle);
                this.pnlCard.Controls.Add(this.btnLoginZalo);
                this.pnlCard.Controls.Add(this.btnGuide);
                this.pnlCard.Controls.Add(this.btnAlreadyLoggedIn);

                // pnlBottom
                this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
                this.pnlBottom.Padding = new System.Windows.Forms.Padding(12);
                this.pnlBottom.BackColor = System.Drawing.Color.White;
                this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                // lblLog
                this.lblLog.Dock = System.Windows.Forms.DockStyle.Top;
                this.lblLog.Height = 22;
                this.lblLog.Text = "Log";
                this.lblLog.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                this.lblLog.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);

                // txtLog
                this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
                this.txtLog.Multiline = true;
                this.txtLog.ReadOnly = true;
                this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.txtLog.Font = new System.Drawing.Font("Consolas", 9.5F);
                this.txtLog.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
                this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.txtLog.Name = "txtLog";

                this.pnlBottom.Controls.Add(this.txtLog);
                this.pnlBottom.Controls.Add(this.lblLog);

                // place into root
                this.tlpRoot.Controls.Add(this.pnlCard, 0, 0);
                this.tlpRoot.Controls.Add(this.pnlBottom, 0, 1);

                // LoginForm
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.White;
                this.ClientSize = new System.Drawing.Size(520, 650);
                this.Controls.Add(this.tlpRoot);
                this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                this.MinimumSize = new System.Drawing.Size(500, 640);
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Login - Zalo";

                this.tlpRoot.ResumeLayout(false);
                this.pnlCard.ResumeLayout(false);
                this.pnlCard.PerformLayout();
                this.pnlBottom.ResumeLayout(false);
                this.pnlBottom.PerformLayout();
                this.ResumeLayout(false);
            }
        }
}
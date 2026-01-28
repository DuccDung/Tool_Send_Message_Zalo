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

            // ====== THEME COLORS ======
            System.Drawing.Color cBg = System.Drawing.Color.FromArgb(11, 15, 16);        // #0B0F10
            System.Drawing.Color cPanel = System.Drawing.Color.FromArgb(15, 21, 23);     // #0F1517
            System.Drawing.Color cPanel2 = System.Drawing.Color.FromArgb(9, 13, 14);     // darker input
            System.Drawing.Color cBorder = System.Drawing.Color.FromArgb(30, 42, 46);    // #1E2A2E
            System.Drawing.Color cNeon = System.Drawing.Color.FromArgb(0, 255, 156);     // #00FF9C
            System.Drawing.Color cText = System.Drawing.Color.FromArgb(199, 255, 223);   // #C7FFDF
            System.Drawing.Color cSubText = System.Drawing.Color.FromArgb(127, 255, 199);// #7FFFC7
            System.Drawing.Color cCardHeader = System.Drawing.Color.FromArgb(10, 30, 24);

            // tlpRoot
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.RowCount = 2;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Padding = new System.Windows.Forms.Padding(16);
            this.tlpRoot.BackColor = cBg;
            this.tlpRoot.Name = "tlpRoot";

            // pnlCard
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Padding = new System.Windows.Forms.Padding(24);
            this.pnlCard.BackColor = cPanel;
            this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard.Name = "pnlCard";

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Text = "Đăng nhập";
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = cNeon;
            this.lblTitle.Location = new System.Drawing.Point(24, 20);
            this.lblTitle.Name = "lblTitle";

            // lblSubTitle
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Text = "Vui lòng đăng nhập bằng Zalo để tiếp tục.";
            this.lblSubTitle.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular);
            this.lblSubTitle.ForeColor = cSubText;
            this.lblSubTitle.Location = new System.Drawing.Point(26, 66);
            this.lblSubTitle.Name = "lblSubTitle";

            // btnLoginZalo
            this.btnLoginZalo.Text = "> LOGIN ZALO";
            this.btnLoginZalo.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.btnLoginZalo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginZalo.FlatAppearance.BorderColor = cNeon;
            this.btnLoginZalo.FlatAppearance.BorderSize = 1;
            this.btnLoginZalo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 80, 55);
            this.btnLoginZalo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 200, 120);
            this.btnLoginZalo.BackColor = System.Drawing.Color.FromArgb(8, 28, 22);
            this.btnLoginZalo.ForeColor = cNeon;
            this.btnLoginZalo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoginZalo.Size = new System.Drawing.Size(300, 48);
            this.btnLoginZalo.Location = new System.Drawing.Point(30, 120);
            this.btnLoginZalo.Name = "btnLoginZalo";
            this.btnLoginZalo.UseVisualStyleBackColor = false;

            // btnGuide
            this.btnGuide.Text = "+ XEM HƯỚNG DẪN";
            this.btnGuide.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.btnGuide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuide.FlatAppearance.BorderColor = cBorder;
            this.btnGuide.FlatAppearance.BorderSize = 1;
            this.btnGuide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 60, 42);
            this.btnGuide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 200, 120);
            this.btnGuide.BackColor = System.Drawing.Color.FromArgb(10, 18, 20);
            this.btnGuide.ForeColor = cSubText;
            this.btnGuide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuide.Size = new System.Drawing.Size(300, 48);
            this.btnGuide.Location = new System.Drawing.Point(30, 180);
            this.btnGuide.Name = "btnGuide";
            this.btnGuide.UseVisualStyleBackColor = false;

            // btnAlreadyLoggedIn
            this.btnAlreadyLoggedIn.Text = "✓ ĐÃ LOGIN ZALO";
            this.btnAlreadyLoggedIn.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.btnAlreadyLoggedIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlreadyLoggedIn.FlatAppearance.BorderColor = cSubText;
            this.btnAlreadyLoggedIn.FlatAppearance.BorderSize = 1;
            this.btnAlreadyLoggedIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 50, 36);
            this.btnAlreadyLoggedIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 200, 120);
            this.btnAlreadyLoggedIn.BackColor = System.Drawing.Color.FromArgb(10, 18, 20);
            this.btnAlreadyLoggedIn.ForeColor = cText;
            this.btnAlreadyLoggedIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlreadyLoggedIn.Size = new System.Drawing.Size(300, 48);
            this.btnAlreadyLoggedIn.Location = new System.Drawing.Point(30, 240);
            this.btnAlreadyLoggedIn.Name = "btnAlreadyLoggedIn";
            this.btnAlreadyLoggedIn.UseVisualStyleBackColor = false;

            // add controls to card
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblSubTitle);
            this.pnlCard.Controls.Add(this.btnLoginZalo);
            this.pnlCard.Controls.Add(this.btnGuide);
            this.pnlCard.Controls.Add(this.btnAlreadyLoggedIn);

            // pnlBottom
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(14);
            this.pnlBottom.BackColor = cPanel;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Name = "pnlBottom";

            // lblLog
            this.lblLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLog.Height = 22;
            this.lblLog.Text = "[ LOG ]";
            this.lblLog.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lblLog.ForeColor = cNeon;
            this.lblLog.Name = "lblLog";

            // txtLog
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Multiline = true;
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtLog.BackColor = cPanel2;
            this.txtLog.ForeColor = cText;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Name = "txtLog";

            this.pnlBottom.Controls.Add(this.txtLog);
            this.pnlBottom.Controls.Add(this.lblLog);

            // place into root
            this.tlpRoot.Controls.Add(this.pnlCard, 0, 0);
            this.tlpRoot.Controls.Add(this.pnlBottom, 0, 1);

            // LoginForm
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = cBg;
            this.ClientSize = new System.Drawing.Size(520, 650);
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Consolas", 10F);
            this.ForeColor = cText;
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
namespace ToolSendMessage.view
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAddCsv;
        private System.Windows.Forms.Button btnValidatePhone;

        private System.Windows.Forms.DataGridView dgvPreview;

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;

        private System.Windows.Forms.Label lblScheduleDate;
        private System.Windows.Forms.DateTimePicker dtpScheduleDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tlpRoot = new TableLayoutPanel();
            dgvPreview = new DataGridView();
            pnlRight = new Panel();
            dtpScheduleDate = new DateTimePicker();
            lblScheduleDate = new Label();
            btnValidatePhone = new Button();
            btnAddCsv = new Button();
            btnStart = new Button();
            pnlBottom = new Panel();
            txtLog = new TextBox();
            lblLog = new Label();
            tlpRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).BeginInit();
            pnlRight.SuspendLayout();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // tlpRoot
            // 
            tlpRoot.BackColor = Color.FromArgb(11, 15, 16);
            tlpRoot.ColumnCount = 2;
            tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 240F));
            tlpRoot.Controls.Add(dgvPreview, 0, 0);
            tlpRoot.Controls.Add(pnlRight, 1, 0);
            tlpRoot.Controls.Add(pnlBottom, 0, 1);
            tlpRoot.Dock = DockStyle.Fill;
            tlpRoot.Location = new Point(0, 0);
            tlpRoot.Name = "tlpRoot";
            tlpRoot.Padding = new Padding(14);
            tlpRoot.RowCount = 2;
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 190F));
            tlpRoot.Size = new Size(1100, 720);
            tlpRoot.TabIndex = 0;
            // 
            // dgvPreview
            // 
            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.AllowUserToDeleteRows = false;
            dgvPreview.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(12, 20, 22);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(199, 255, 223);
            dgvPreview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPreview.BackgroundColor = Color.FromArgb(15, 21, 23);
            dgvPreview.BorderStyle = BorderStyle.None;
            dgvPreview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPreview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(10, 30, 24);
            dataGridViewCellStyle2.Font = new Font("Consolas", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(0, 255, 156);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(10, 30, 24);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(0, 255, 156);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPreview.ColumnHeadersHeight = 42;
            dgvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(15, 21, 23);
            dataGridViewCellStyle3.Font = new Font("Consolas", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(199, 255, 223);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 255, 156);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(11, 15, 16);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPreview.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPreview.Dock = DockStyle.Fill;
            dgvPreview.EnableHeadersVisualStyles = false;
            dgvPreview.GridColor = Color.FromArgb(30, 42, 46);
            dgvPreview.Location = new Point(17, 17);
            dgvPreview.MultiSelect = false;
            dgvPreview.Name = "dgvPreview";
            dgvPreview.ReadOnly = true;
            dgvPreview.RowHeadersVisible = false;
            dgvPreview.RowHeadersWidth = 51;
            dgvPreview.RowTemplate.Height = 32;
            dgvPreview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPreview.Size = new Size(826, 496);
            dgvPreview.TabIndex = 0;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(15, 21, 23);
            pnlRight.Controls.Add(dtpScheduleDate);
            pnlRight.Controls.Add(lblScheduleDate);
            pnlRight.Controls.Add(btnValidatePhone);
            pnlRight.Controls.Add(btnAddCsv);
            pnlRight.Controls.Add(btnStart);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(849, 17);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(14);
            pnlRight.Size = new Size(234, 496);
            pnlRight.TabIndex = 1;
            // 
            // dtpScheduleDate
            // 
            // dtpScheduleDate
            dtpScheduleDate.Dock = DockStyle.Top;
            dtpScheduleDate.Margin = new Padding(0, 0, 0, 0);
            dtpScheduleDate.Padding = new Padding(0);

            dtpScheduleDate.Format = DateTimePickerFormat.Custom;
            dtpScheduleDate.CustomFormat = "dd/MM/yyyy";

            dtpScheduleDate.Font = new Font("Consolas", 11F, FontStyle.Bold);
            dtpScheduleDate.CalendarFont = new Font("Consolas", 10F);

            // DateTimePicker WinForms không đảm bảo ăn BackColor/ForeColor trên mọi theme,
            // nhưng cứ set vẫn ok.
            dtpScheduleDate.BackColor = Color.FromArgb(10, 18, 20);
            dtpScheduleDate.ForeColor = Color.FromArgb(127, 255, 199);

            dtpScheduleDate.Height = 29;
            dtpScheduleDate.Value = DateTime.Today; // đừng hardcode 2026


            // 
            // lblScheduleDate
            // 
            lblScheduleDate.Dock = DockStyle.Top;
            lblScheduleDate.Font = new Font("Consolas", 10F, FontStyle.Bold);
            lblScheduleDate.ForeColor = Color.FromArgb(0, 255, 156);
            lblScheduleDate.Location = new Point(14, 152);
            lblScheduleDate.Name = "lblScheduleDate";
            lblScheduleDate.Padding = new Padding(0, 12, 0, 4);
            lblScheduleDate.Size = new Size(206, 43);
            lblScheduleDate.TabIndex = 4;
            lblScheduleDate.Text = "[ CHỌN NGÀY ]";
            // 
            // btnValidatePhone
            // 
            btnValidatePhone.BackColor = Color.FromArgb(10, 18, 20);
            btnValidatePhone.Cursor = Cursors.Hand;
            btnValidatePhone.Dock = DockStyle.Top;
            btnValidatePhone.FlatAppearance.BorderColor = Color.FromArgb(30, 42, 46);
            btnValidatePhone.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 200, 120);
            btnValidatePhone.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 60, 42);
            btnValidatePhone.FlatStyle = FlatStyle.Flat;
            btnValidatePhone.Font = new Font("Consolas", 11F, FontStyle.Bold);
            btnValidatePhone.ForeColor = Color.FromArgb(127, 255, 199);
            btnValidatePhone.Location = new Point(14, 106);
            btnValidatePhone.Name = "btnValidatePhone";
            btnValidatePhone.Size = new Size(206, 46);
            btnValidatePhone.TabIndex = 2;
            btnValidatePhone.Text = "✓ VALIDATE";
            btnValidatePhone.UseVisualStyleBackColor = false;
            // 
            // btnAddCsv
            // 
            btnAddCsv.BackColor = Color.FromArgb(10, 18, 20);
            btnAddCsv.Cursor = Cursors.Hand;
            btnAddCsv.Dock = DockStyle.Top;
            btnAddCsv.FlatAppearance.BorderColor = Color.FromArgb(30, 42, 46);
            btnAddCsv.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 200, 120);
            btnAddCsv.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 60, 42);
            btnAddCsv.FlatStyle = FlatStyle.Flat;
            btnAddCsv.Font = new Font("Consolas", 11F, FontStyle.Bold);
            btnAddCsv.ForeColor = Color.FromArgb(127, 255, 199);
            btnAddCsv.Location = new Point(14, 60);
            btnAddCsv.Name = "btnAddCsv";
            btnAddCsv.Size = new Size(206, 46);
            btnAddCsv.TabIndex = 0;
            btnAddCsv.Text = "+ ADD CSV";
            btnAddCsv.UseVisualStyleBackColor = false;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(8, 28, 22);
            btnStart.Cursor = Cursors.Hand;
            btnStart.Dock = DockStyle.Top;
            btnStart.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 156);
            btnStart.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 200, 120);
            btnStart.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 55);
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Consolas", 11F, FontStyle.Bold);
            btnStart.ForeColor = Color.FromArgb(0, 255, 156);
            btnStart.Location = new Point(14, 14);
            btnStart.Margin = new Padding(0, 0, 0, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(206, 46);
            btnStart.TabIndex = 1;
            btnStart.Text = "> START";
            btnStart.UseVisualStyleBackColor = false;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(15, 21, 23);
            pnlBottom.BorderStyle = BorderStyle.FixedSingle;
            tlpRoot.SetColumnSpan(pnlBottom, 2);
            pnlBottom.Controls.Add(txtLog);
            pnlBottom.Controls.Add(lblLog);
            pnlBottom.Dock = DockStyle.Fill;
            pnlBottom.Location = new Point(17, 519);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(14);
            pnlBottom.Size = new Size(1066, 184);
            pnlBottom.TabIndex = 2;
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.FromArgb(9, 13, 14);
            txtLog.BorderStyle = BorderStyle.FixedSingle;
            txtLog.Dock = DockStyle.Fill;
            txtLog.Font = new Font("Consolas", 10F);
            txtLog.ForeColor = Color.FromArgb(199, 255, 223);
            txtLog.Location = new Point(14, 36);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(1036, 132);
            txtLog.TabIndex = 0;
            // 
            // lblLog
            // 
            lblLog.Dock = DockStyle.Top;
            lblLog.Font = new Font("Consolas", 11F, FontStyle.Bold);
            lblLog.ForeColor = Color.FromArgb(0, 255, 156);
            lblLog.Location = new Point(14, 14);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(1036, 22);
            lblLog.TabIndex = 1;
            lblLog.Text = "[ LOG ]";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 16);
            ClientSize = new Size(1100, 720);
            Controls.Add(tlpRoot);
            Font = new Font("Consolas", 10F);
            ForeColor = Color.FromArgb(199, 255, 223);
            MinimumSize = new Size(980, 640);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Import";
            tlpRoot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPreview).EndInit();
            pnlRight.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            ResumeLayout(false);
        }

    }
}
namespace ToolSendMessage.view
{
        partial class Dashboard
        {
            private System.ComponentModel.IContainer components = null;

            private System.Windows.Forms.Panel pnlHeader;
            private System.Windows.Forms.Label lblTitle;
            private System.Windows.Forms.Button btnGuide;

            private System.Windows.Forms.TableLayoutPanel tlpMain;

            private System.Windows.Forms.GroupBox grpActions;
            private System.Windows.Forms.FlowLayoutPanel flpActions;
            private System.Windows.Forms.Button btnStartTool;
            private System.Windows.Forms.Button btnAddCsv;
            private System.Windows.Forms.Button btnViewLog;

            private System.Windows.Forms.GroupBox grpLog;
            private System.Windows.Forms.ListView lvLog;
            private System.Windows.Forms.ColumnHeader colTime;
            private System.Windows.Forms.ColumnHeader colLevel;
            private System.Windows.Forms.ColumnHeader colMessage;

            private System.Windows.Forms.GroupBox grpCsv;
            private System.Windows.Forms.Panel pnlCsvTop;
            private System.Windows.Forms.Label lblCsv;
            private System.Windows.Forms.TextBox txtCsvPath;
            private System.Windows.Forms.DataGridView dgvPhones;

            private System.Windows.Forms.OpenFileDialog openFileCsv;

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                    components.Dispose();
                base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnGuide = new Button();
            tlpMain = new TableLayoutPanel();
            grpActions = new GroupBox();
            flpActions = new FlowLayoutPanel();
            btnStartTool = new Button();
            btnAddCsv = new Button();
            btnViewLog = new Button();
            grpLog = new GroupBox();
            lvLog = new ListView();
            colTime = new ColumnHeader();
            colLevel = new ColumnHeader();
            colMessage = new ColumnHeader();
            grpCsv = new GroupBox();
            dgvPhones = new DataGridView();
            pnlCsvTop = new Panel();
            lblCsv = new Label();
            txtCsvPath = new TextBox();
            openFileCsv = new OpenFileDialog();
            pnlHeader.SuspendLayout();
            tlpMain.SuspendLayout();
            grpActions.SuspendLayout();
            flpActions.SuspendLayout();
            grpLog.SuspendLayout();
            grpCsv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhones).BeginInit();
            pnlCsvTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.WhiteSmoke;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnGuide);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(16, 12, 16, 12);
            pnlHeader.Size = new Size(1100, 64);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(16, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(361, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Zalo Auto Sender - Dashboard";
            // 
            // btnGuide
            // 
            btnGuide.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuide.Font = new Font("Segoe UI", 10F);
            btnGuide.Location = new Point(964, 16);
            btnGuide.Name = "btnGuide";
            btnGuide.Size = new Size(120, 32);
            btnGuide.TabIndex = 1;
            btnGuide.Text = "Hướng dẫn";
            btnGuide.UseVisualStyleBackColor = true;
            btnGuide.Click += btnGuide_Click;
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            tlpMain.Controls.Add(grpActions, 0, 0);
            tlpMain.Controls.Add(grpLog, 1, 0);
            tlpMain.Controls.Add(grpCsv, 0, 1);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 64);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(16);
            tlpMain.RowCount = 2;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 186F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1100, 529);
            tlpMain.TabIndex = 1;
            // 
            // grpActions
            // 
            grpActions.Controls.Add(flpActions);
            grpActions.Dock = DockStyle.Fill;
            grpActions.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpActions.Location = new Point(19, 19);
            grpActions.Name = "grpActions";
            grpActions.Padding = new Padding(12);
            grpActions.Size = new Size(549, 180);
            grpActions.TabIndex = 0;
            grpActions.TabStop = false;
            grpActions.Text = "Thao tác";
            // 
            // flpActions
            // 
            flpActions.AutoScroll = true;
            flpActions.Controls.Add(btnStartTool);
            flpActions.Controls.Add(btnAddCsv);
            flpActions.Controls.Add(btnViewLog);
            flpActions.Dock = DockStyle.Fill;
            flpActions.Location = new Point(12, 35);
            flpActions.Name = "flpActions";
            flpActions.Size = new Size(525, 133);
            flpActions.TabIndex = 0;
            // 
            // btnStartTool
            // 
            btnStartTool.Font = new Font("Segoe UI", 10F);
            btnStartTool.Location = new Point(0, 0);
            btnStartTool.Margin = new Padding(0, 0, 10, 10);
            btnStartTool.Name = "btnStartTool";
            btnStartTool.Size = new Size(140, 44);
            btnStartTool.TabIndex = 0;
            btnStartTool.Text = "Start Tool";
            btnStartTool.UseVisualStyleBackColor = true;
            btnStartTool.Click += btnStartTool_Click;
            // 
            // btnAddCsv
            // 
            btnAddCsv.Font = new Font("Segoe UI", 10F);
            btnAddCsv.Location = new Point(150, 0);
            btnAddCsv.Margin = new Padding(0, 0, 10, 10);
            btnAddCsv.Name = "btnAddCsv";
            btnAddCsv.Size = new Size(140, 44);
            btnAddCsv.TabIndex = 1;
            btnAddCsv.Text = "Add file CSV";
            btnAddCsv.UseVisualStyleBackColor = true;
            btnAddCsv.Click += btnAddCsv_Click;
            // 
            // btnViewLog
            // 
            btnViewLog.Font = new Font("Segoe UI", 10F);
            btnViewLog.Location = new Point(300, 0);
            btnViewLog.Margin = new Padding(0, 0, 10, 10);
            btnViewLog.Name = "btnViewLog";
            btnViewLog.Size = new Size(140, 44);
            btnViewLog.TabIndex = 2;
            btnViewLog.Text = "View Log";
            btnViewLog.UseVisualStyleBackColor = true;
            btnViewLog.Click += btnViewLog_Click;
            // 
            // grpLog
            // 
            grpLog.Controls.Add(lvLog);
            grpLog.Dock = DockStyle.Fill;
            grpLog.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpLog.Location = new Point(574, 19);
            grpLog.Name = "grpLog";
            grpLog.Padding = new Padding(12);
            grpLog.Size = new Size(507, 180);
            grpLog.TabIndex = 1;
            grpLog.TabStop = false;
            grpLog.Text = "Log";
            // 
            // lvLog
            // 
            lvLog.Columns.AddRange(new ColumnHeader[] { colTime, colLevel, colMessage });
            lvLog.Dock = DockStyle.Fill;
            lvLog.FullRowSelect = true;
            lvLog.GridLines = true;
            lvLog.Location = new Point(12, 35);
            lvLog.Name = "lvLog";
            lvLog.Size = new Size(483, 133);
            lvLog.TabIndex = 0;
            lvLog.UseCompatibleStateImageBehavior = false;
            lvLog.View = View.Details;
            // 
            // colTime
            // 
            colTime.Text = "Time";
            colTime.Width = 160;
            // 
            // colLevel
            // 
            colLevel.Text = "Level";
            colLevel.Width = 90;
            // 
            // colMessage
            // 
            colMessage.Text = "Message";
            colMessage.Width = 600;
            // 
            // grpCsv
            // 
            tlpMain.SetColumnSpan(grpCsv, 2);
            grpCsv.Controls.Add(dgvPhones);
            grpCsv.Controls.Add(pnlCsvTop);
            grpCsv.Dock = DockStyle.Fill;
            grpCsv.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpCsv.Location = new Point(19, 205);
            grpCsv.Name = "grpCsv";
            grpCsv.Padding = new Padding(12);
            grpCsv.Size = new Size(1062, 305);
            grpCsv.TabIndex = 2;
            grpCsv.TabStop = false;
            grpCsv.Text = "Dữ liệu CSV (Số điện thoại)";
            // 
            // dgvPhones
            // 
            dgvPhones.AllowUserToAddRows = false;
            dgvPhones.AllowUserToDeleteRows = false;
            dgvPhones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhones.Dock = DockStyle.Fill;
            dgvPhones.Location = new Point(12, 79);
            dgvPhones.MultiSelect = false;
            dgvPhones.Name = "dgvPhones";
            dgvPhones.ReadOnly = true;
            dgvPhones.RowHeadersWidth = 51;
            dgvPhones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhones.Size = new Size(1038, 214);
            dgvPhones.TabIndex = 1;
            // 
            // pnlCsvTop
            // 
            pnlCsvTop.Controls.Add(lblCsv);
            pnlCsvTop.Controls.Add(txtCsvPath);
            pnlCsvTop.Dock = DockStyle.Top;
            pnlCsvTop.Location = new Point(12, 35);
            pnlCsvTop.Name = "pnlCsvTop";
            pnlCsvTop.Size = new Size(1038, 44);
            pnlCsvTop.TabIndex = 0;
            // 
            // lblCsv
            // 
            lblCsv.AutoSize = true;
            lblCsv.Font = new Font("Segoe UI", 10F);
            lblCsv.Location = new Point(0, 12);
            lblCsv.Name = "lblCsv";
            lblCsv.Size = new Size(39, 23);
            lblCsv.TabIndex = 0;
            lblCsv.Text = "File:";
            // 
            // txtCsvPath
            // 
            txtCsvPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCsvPath.Font = new Font("Segoe UI", 10F);
            txtCsvPath.Location = new Point(40, 9);
            txtCsvPath.Name = "txtCsvPath";
            txtCsvPath.ReadOnly = true;
            txtCsvPath.Size = new Size(998, 30);
            txtCsvPath.TabIndex = 1;
            // 
            // openFileCsv
            // 
            openFileCsv.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileCsv.Title = "Chọn file CSV";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 593);
            Controls.Add(tlpMain);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimumSize = new Size(980, 640);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpMain.ResumeLayout(false);
            grpActions.ResumeLayout(false);
            flpActions.ResumeLayout(false);
            grpLog.ResumeLayout(false);
            grpCsv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPhones).EndInit();
            pnlCsvTop.ResumeLayout(false);
            pnlCsvTop.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
    }
}
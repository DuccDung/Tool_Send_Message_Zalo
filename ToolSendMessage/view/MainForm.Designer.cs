namespace ToolSendMessage.view
{
        partial class MainForm
        {
            private System.ComponentModel.IContainer components = null;

            private System.Windows.Forms.TableLayoutPanel tlpRoot;
            private System.Windows.Forms.Panel pnlRight;
            private System.Windows.Forms.Button btnStart;
            private System.Windows.Forms.Button btnAddCsv;

            private System.Windows.Forms.DataGridView dgvPreview;

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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            tlpRoot = new TableLayoutPanel();
            dgvPreview = new DataGridView();
            pnlRight = new Panel();
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
            tlpRoot.BackColor = Color.White;
            tlpRoot.ColumnCount = 2;
            tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tlpRoot.Controls.Add(dgvPreview, 0, 0);
            tlpRoot.Controls.Add(pnlRight, 1, 0);
            tlpRoot.Controls.Add(pnlBottom, 0, 1);
            tlpRoot.Dock = DockStyle.Fill;
            tlpRoot.Location = new Point(0, 0);
            tlpRoot.Name = "tlpRoot";
            tlpRoot.Padding = new Padding(12);
            tlpRoot.RowCount = 2;
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 170F));
            tlpRoot.Size = new Size(1100, 720);
            tlpRoot.TabIndex = 0;
            // 
            // dgvPreview
            // 
            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.AllowUserToDeleteRows = false;
            dgvPreview.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(250, 250, 252);
            dgvPreview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPreview.BackgroundColor = Color.White;
            dgvPreview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPreview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(245, 246, 248);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvPreview.ColumnHeadersHeight = 38;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvPreview.DefaultCellStyle = dataGridViewCellStyle6;
            dgvPreview.Dock = DockStyle.Fill;
            dgvPreview.Location = new Point(15, 15);
            dgvPreview.MultiSelect = false;
            dgvPreview.Name = "dgvPreview";
            dgvPreview.ReadOnly = true;
            dgvPreview.RowHeadersVisible = false;
            dgvPreview.RowHeadersWidth = 51;
            dgvPreview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPreview.Size = new Size(850, 520);
            dgvPreview.TabIndex = 0;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(248, 249, 250);
            pnlRight.Controls.Add(btnAddCsv);
            pnlRight.Controls.Add(btnStart);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(871, 15);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(12);
            pnlRight.Size = new Size(214, 520);
            pnlRight.TabIndex = 1;
            // 
            // btnAddCsv
            // 
            btnAddCsv.BackColor = Color.White;
            btnAddCsv.Cursor = Cursors.Hand;
            btnAddCsv.Dock = DockStyle.Top;
            btnAddCsv.FlatAppearance.BorderColor = Color.FromArgb(210, 214, 219);
            btnAddCsv.FlatStyle = FlatStyle.Flat;
            btnAddCsv.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddCsv.Location = new Point(12, 56);
            btnAddCsv.Name = "btnAddCsv";
            btnAddCsv.Size = new Size(190, 44);
            btnAddCsv.TabIndex = 0;
            btnAddCsv.Text = "Add CSV";
            btnAddCsv.UseVisualStyleBackColor = false;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.White;
            btnStart.Cursor = Cursors.Hand;
            btnStart.Dock = DockStyle.Top;
            btnStart.FlatAppearance.BorderColor = Color.FromArgb(210, 214, 219);
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnStart.Location = new Point(12, 12);
            btnStart.Margin = new Padding(0, 0, 0, 10);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(190, 44);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.White;
            pnlBottom.BorderStyle = BorderStyle.FixedSingle;
            tlpRoot.SetColumnSpan(pnlBottom, 2);
            pnlBottom.Controls.Add(txtLog);
            pnlBottom.Controls.Add(lblLog);
            pnlBottom.Dock = DockStyle.Fill;
            pnlBottom.Location = new Point(15, 541);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(12);
            pnlBottom.Size = new Size(1070, 164);
            pnlBottom.TabIndex = 2;
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.FromArgb(248, 249, 250);
            txtLog.BorderStyle = BorderStyle.FixedSingle;
            txtLog.Dock = DockStyle.Fill;
            txtLog.Font = new Font("Consolas", 9.5F);
            txtLog.Location = new Point(12, 34);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(1044, 116);
            txtLog.TabIndex = 0;
            // 
            // lblLog
            // 
            lblLog.Dock = DockStyle.Top;
            lblLog.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLog.ForeColor = Color.FromArgb(33, 37, 41);
            lblLog.Location = new Point(12, 12);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(1044, 22);
            lblLog.TabIndex = 1;
            lblLog.Text = "Log";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 720);
            Controls.Add(tlpRoot);
            Font = new Font("Segoe UI", 9.75F);
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
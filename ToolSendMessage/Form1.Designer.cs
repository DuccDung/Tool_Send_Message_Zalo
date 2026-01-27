namespace ToolSendMessage
{
        partial class Form1
        {
            private System.ComponentModel.IContainer components = null;

            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.TextBox txtPhone;
            private System.Windows.Forms.TextBox txtMessage;
            private System.Windows.Forms.Button btnOpen;
            private System.Windows.Forms.Button btnSend;
            private System.Windows.Forms.Label lblStatus;

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            private void InitializeComponent()
            {
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.txtPhone = new System.Windows.Forms.TextBox();
                this.txtMessage = new System.Windows.Forms.TextBox();
                this.btnOpen = new System.Windows.Forms.Button();
                this.btnSend = new System.Windows.Forms.Button();
                this.lblStatus = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(16, 18);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(95, 16);
                this.label1.TabIndex = 0;
                this.label1.Text = "Số điện thoại:";
                // 
                // txtPhone
                // 
                this.txtPhone.Location = new System.Drawing.Point(117, 15);
                this.txtPhone.Name = "txtPhone";
                this.txtPhone.Size = new System.Drawing.Size(260, 22);
                this.txtPhone.TabIndex = 1;
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(16, 55);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(64, 16);
                this.label2.TabIndex = 2;
                this.label2.Text = "Tin nhắn:";
                // 
                // txtMessage
                // 
                this.txtMessage.Location = new System.Drawing.Point(117, 52);
                this.txtMessage.Multiline = true;
                this.txtMessage.Name = "txtMessage";
                this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.txtMessage.Size = new System.Drawing.Size(520, 180);
                this.txtMessage.TabIndex = 3;
                // 
                // btnOpen
                // 
                this.btnOpen.Location = new System.Drawing.Point(117, 245);
                this.btnOpen.Name = "btnOpen";
                this.btnOpen.Size = new System.Drawing.Size(140, 32);
                this.btnOpen.TabIndex = 4;
                this.btnOpen.Text = "Mở Zalo Web";
                this.btnOpen.UseVisualStyleBackColor = true;
                this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
                // 
                // btnSend
                // 
                this.btnSend.Location = new System.Drawing.Point(270, 245);
                this.btnSend.Name = "btnSend";
                this.btnSend.Size = new System.Drawing.Size(140, 32);
                this.btnSend.TabIndex = 5;
                this.btnSend.Text = "Gửi tin nhắn";
                this.btnSend.UseVisualStyleBackColor = true;
                this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
                // 
                // lblStatus
                // 
                this.lblStatus.AutoSize = true;
                this.lblStatus.Location = new System.Drawing.Point(16, 295);
                this.lblStatus.Name = "lblStatus";
                this.lblStatus.Size = new System.Drawing.Size(71, 16);
                this.lblStatus.TabIndex = 6;
                this.lblStatus.Text = "Trạng thái:";
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(670, 330);
                this.Controls.Add(this.lblStatus);
                this.Controls.Add(this.btnSend);
                this.Controls.Add(this.btnOpen);
                this.Controls.Add(this.txtMessage);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.txtPhone);
                this.Controls.Add(this.label1);
                this.Name = "Form1";
                this.Text = "Zalo Auto Sender (Selenium)";
                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
                this.ResumeLayout(false);
                this.PerformLayout();
            }

            #endregion
        }
    }

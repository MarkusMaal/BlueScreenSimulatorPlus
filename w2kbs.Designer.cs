namespace UltimateBlueScreenSimulator
{
    partial class W2kbs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(W2kbs));
            this.errorCode = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.supportInfo = new System.Windows.Forms.Label();
            this.downMessage = new System.Windows.Forms.Label();
            this.waterMarkText = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorCode
            // 
            this.errorCode.AutoSize = true;
            this.errorCode.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Bold);
            this.errorCode.Location = new System.Drawing.Point(0, 10);
            this.errorCode.Margin = new System.Windows.Forms.Padding(0, 10, 3, 0);
            this.errorCode.Name = "errorCode";
            this.errorCode.Size = new System.Drawing.Size(557, 22);
            this.errorCode.TabIndex = 0;
            this.errorCode.Text = "*** STOP: 0xDEADDEAD (0x00000000, 0x00000000, 0x00000000, 0x00000000)\r\nINACCESSIB" +
    "LE_BOOT_DEVICE";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.errorCode);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.supportInfo);
            this.flowLayoutPanel1.Controls.Add(this.downMessage);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(640, 447);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(493, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "If this is the first time you\'ve seen this Stop error screen,\r\nrestart your compu" +
    "ter. If this screen appears again, follow\r\nthese steps:";
            // 
            // supportInfo
            // 
            this.supportInfo.AutoSize = true;
            this.supportInfo.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Bold);
            this.supportInfo.Location = new System.Drawing.Point(0, 85);
            this.supportInfo.Margin = new System.Windows.Forms.Padding(0, 10, 3, 0);
            this.supportInfo.Name = "supportInfo";
            this.supportInfo.Size = new System.Drawing.Size(501, 55);
            this.supportInfo.TabIndex = 2;
            this.supportInfo.Text = resources.GetString("supportInfo.Text");
            // 
            // downMessage
            // 
            this.downMessage.AutoSize = true;
            this.downMessage.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Bold);
            this.downMessage.Location = new System.Drawing.Point(0, 150);
            this.downMessage.Margin = new System.Windows.Forms.Padding(0, 10, 3, 0);
            this.downMessage.Name = "downMessage";
            this.downMessage.Size = new System.Drawing.Size(485, 22);
            this.downMessage.TabIndex = 3;
            this.downMessage.Text = "Refer to your Getting Started manual for more information on\r\ntroubleshooting Sto" +
    "p errors.";
            // 
            // waterMarkText
            // 
            this.waterMarkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.waterMarkText.AutoSize = true;
            this.waterMarkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.waterMarkText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.waterMarkText.Location = new System.Drawing.Point(5, 457);
            this.waterMarkText.Name = "waterMarkText";
            this.waterMarkText.Size = new System.Drawing.Size(188, 20);
            this.waterMarkText.TabIndex = 8;
            this.waterMarkText.Text = "bluescreen simulator plus";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // w2kbs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.waterMarkText);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "w2kbs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows 2000 blue screen simulator";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.W2kbs_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.W2kbs_FormClosed);
            this.Load += new System.EventHandler(this.W2kbs_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label supportInfo;
        private System.Windows.Forms.Label downMessage;
        public System.Windows.Forms.Label waterMarkText;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label errorCode;
    }
}
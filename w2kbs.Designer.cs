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
            this.bsFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.upMessage = new System.Windows.Forms.Label();
            this.supportInfo = new System.Windows.Forms.Label();
            this.downMessage = new System.Windows.Forms.Label();
            this.waterMarkText = new System.Windows.Forms.Label();
            this.screenUpdater = new System.Windows.Forms.Timer(this.components);
            this.rainBowScreen = new System.Windows.Forms.Timer(this.components);
            this.bsFlow.SuspendLayout();
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
            // bsFlow
            // 
            this.bsFlow.Controls.Add(this.errorCode);
            this.bsFlow.Controls.Add(this.upMessage);
            this.bsFlow.Controls.Add(this.supportInfo);
            this.bsFlow.Controls.Add(this.downMessage);
            this.bsFlow.Dock = System.Windows.Forms.DockStyle.Top;
            this.bsFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.bsFlow.Location = new System.Drawing.Point(0, 0);
            this.bsFlow.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.bsFlow.Name = "bsFlow";
            this.bsFlow.Size = new System.Drawing.Size(640, 447);
            this.bsFlow.TabIndex = 1;
            // 
            // upMessage
            // 
            this.upMessage.AutoSize = true;
            this.upMessage.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Bold);
            this.upMessage.Location = new System.Drawing.Point(0, 42);
            this.upMessage.Margin = new System.Windows.Forms.Padding(0, 10, 3, 0);
            this.upMessage.Name = "upMessage";
            this.upMessage.Size = new System.Drawing.Size(493, 33);
            this.upMessage.TabIndex = 1;
            this.upMessage.Text = "If this is the first time you\'ve seen this Stop error screen,\r\nrestart your compu" +
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
            this.waterMarkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.waterMarkText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.waterMarkText.Location = new System.Drawing.Point(1, 464);
            this.waterMarkText.Name = "waterMarkText";
            this.waterMarkText.Size = new System.Drawing.Size(148, 15);
            this.waterMarkText.TabIndex = 8;
            this.waterMarkText.Text = "bluescreen simulator plus";
            // 
            // screenUpdater
            // 
            this.screenUpdater.Enabled = true;
            this.screenUpdater.Interval = 500;
            this.screenUpdater.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // rainBowScreen
            // 
            this.rainBowScreen.Interval = 10;
            this.rainBowScreen.Tick += new System.EventHandler(this.rainBowScreen_Tick);
            // 
            // W2kbs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.waterMarkText);
            this.Controls.Add(this.bsFlow);
            this.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "W2kbs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows 2000 blue screen simulator";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.W2kbs_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.W2kbs_FormClosed);
            this.Load += new System.EventHandler(this.W2kbs_Load);
            this.bsFlow.ResumeLayout(false);
            this.bsFlow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel bsFlow;
        private System.Windows.Forms.Label upMessage;
        private System.Windows.Forms.Label supportInfo;
        private System.Windows.Forms.Label downMessage;
        public System.Windows.Forms.Label waterMarkText;
        private System.Windows.Forms.Timer screenUpdater;
        public System.Windows.Forms.Label errorCode;
        private System.Windows.Forms.Timer rainBowScreen;
    }
}
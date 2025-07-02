namespace UltimateBlueScreenSimulator.Forms.Simulators
{
    partial class SunValleyBSOD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SunValleyBSOD));
            this.yourPCranLabel = new System.Windows.Forms.Label();
            this.progressIndicator = new System.Windows.Forms.Label();
            this.errorCode = new System.Windows.Forms.Label();
            this.screenUpdater = new System.Windows.Forms.Timer(this.components);
            this.memCodes = new System.Windows.Forms.Label();
            this.waterMarkText = new System.Windows.Forms.Label();
            this.progressUpdater = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // yourPCranLabel
            // 
            this.yourPCranLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.yourPCranLabel.BackColor = System.Drawing.Color.Transparent;
            this.yourPCranLabel.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.yourPCranLabel.Location = new System.Drawing.Point(15, 277);
            this.yourPCranLabel.Name = "yourPCranLabel";
            this.yourPCranLabel.Size = new System.Drawing.Size(1000, 113);
            this.yourPCranLabel.TabIndex = 0;
            this.yourPCranLabel.Text = "Your device ran into a problem and needs to restart.";
            this.yourPCranLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // progressIndicator
            // 
            this.progressIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressIndicator.BackColor = System.Drawing.Color.Transparent;
            this.progressIndicator.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 20.25F);
            this.progressIndicator.Location = new System.Drawing.Point(16, 413);
            this.progressIndicator.Name = "progressIndicator";
            this.progressIndicator.Size = new System.Drawing.Size(1000, 41);
            this.progressIndicator.TabIndex = 0;
            this.progressIndicator.Text = "0% complete";
            this.progressIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorCode
            // 
            this.errorCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorCode.BackColor = System.Drawing.Color.Transparent;
            this.errorCode.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 10F);
            this.errorCode.Location = new System.Drawing.Point(14, 712);
            this.errorCode.Name = "errorCode";
            this.errorCode.Size = new System.Drawing.Size(1000, 41);
            this.errorCode.TabIndex = 0;
            this.errorCode.Text = "Stop code: CRITICAL_PROCESS_DIED (0xEF)\r\nWhat failed: tbd.sys";
            this.errorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // screenUpdater
            // 
            this.screenUpdater.Enabled = true;
            this.screenUpdater.Tick += new System.EventHandler(this.screenUpdater_Tick);
            // 
            // memCodes
            // 
            this.memCodes.AutoSize = true;
            this.memCodes.BackColor = System.Drawing.Color.Transparent;
            this.memCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.memCodes.Location = new System.Drawing.Point(0, 0);
            this.memCodes.Name = "memCodes";
            this.memCodes.Size = new System.Drawing.Size(132, 60);
            this.memCodes.TabIndex = 6;
            this.memCodes.Text = "0x0000000000000000\r\n0x0000000000000000\r\n0x0000000000000000\r\n0x0000000000000000";
            // 
            // waterMarkText
            // 
            this.waterMarkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.waterMarkText.AutoSize = true;
            this.waterMarkText.BackColor = System.Drawing.Color.Transparent;
            this.waterMarkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.waterMarkText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.waterMarkText.Location = new System.Drawing.Point(828, 8);
            this.waterMarkText.Name = "waterMarkText";
            this.waterMarkText.Size = new System.Drawing.Size(188, 20);
            this.waterMarkText.TabIndex = 7;
            this.waterMarkText.Text = "bluescreen simulator plus";
            // 
            // progressUpdater
            // 
            this.progressUpdater.Enabled = true;
            this.progressUpdater.Interval = 500;
            this.progressUpdater.Tick += new System.EventHandler(this.progressUpdater_Tick);
            // 
            // SunValleyBSOD
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.waterMarkText);
            this.Controls.Add(this.memCodes);
            this.Controls.Add(this.errorCode);
            this.Controls.Add(this.progressIndicator);
            this.Controls.Add(this.yourPCranLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SunValleyBSOD";
            this.Text = "Sun Valley Bugcheck Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SunValleyBSOD_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SunValleyBSOD_FormClosed);
            this.Load += new System.EventHandler(this.SunValleyBSOD_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SunValleyBSOD_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label yourPCranLabel;
        private System.Windows.Forms.Label progressIndicator;
        private System.Windows.Forms.Label errorCode;
        private System.Windows.Forms.Timer screenUpdater;
        internal System.Windows.Forms.Label memCodes;
        public System.Windows.Forms.Label waterMarkText;
        private System.Windows.Forms.Timer progressUpdater;
    }
}
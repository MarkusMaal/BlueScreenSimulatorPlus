namespace UltimateBlueScreenSimulator
{
    partial class WXBS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WXBS));
            this.verticalFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.emoticonLabel = new System.Windows.Forms.Label();
            this.yourPCranLabel = new System.Windows.Forms.Label();
            this.progressIndicator = new System.Windows.Forms.Label();
            this.horizontalFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.qrMargin = new System.Windows.Forms.Panel();
            this.qrCode = new System.Windows.Forms.PictureBox();
            this.supportContainer = new System.Windows.Forms.Panel();
            this.errorCode = new System.Windows.Forms.Label();
            this.supportInfo = new System.Windows.Forms.Label();
            this.progressUpdater = new System.Windows.Forms.Timer(this.components);
            this.waterMarkText = new System.Windows.Forms.Label();
            this.memCodes = new System.Windows.Forms.Label();
            this.screenUpdater = new System.Windows.Forms.Timer(this.components);
            this.windowsIcons = new System.Windows.Forms.ImageList(this.components);
            this.verticalFlowPanel.SuspendLayout();
            this.horizontalFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrCode)).BeginInit();
            this.supportContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // verticalFlowPanel
            // 
            this.verticalFlowPanel.BackColor = System.Drawing.Color.Transparent;
            this.verticalFlowPanel.Controls.Add(this.emoticonLabel);
            this.verticalFlowPanel.Controls.Add(this.yourPCranLabel);
            this.verticalFlowPanel.Controls.Add(this.progressIndicator);
            this.verticalFlowPanel.Controls.Add(this.horizontalFlowPanel);
            this.verticalFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.verticalFlowPanel.Location = new System.Drawing.Point(-13, 0);
            this.verticalFlowPanel.Name = "verticalFlowPanel";
            this.verticalFlowPanel.Size = new System.Drawing.Size(9999, 9999);
            this.verticalFlowPanel.TabIndex = 0;
            this.verticalFlowPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowLayoutPanel1_Paint);
            // 
            // emoticonLabel
            // 
            this.emoticonLabel.AutoSize = true;
            this.emoticonLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 102F);
            this.emoticonLabel.Location = new System.Drawing.Point(60, 0);
            this.emoticonLabel.Margin = new System.Windows.Forms.Padding(60, 0, 3, 0);
            this.emoticonLabel.Name = "emoticonLabel";
            this.emoticonLabel.Padding = new System.Windows.Forms.Padding(0, 80, 0, 0);
            this.emoticonLabel.Size = new System.Drawing.Size(145, 260);
            this.emoticonLabel.TabIndex = 0;
            this.emoticonLabel.Text = ":(";
            // 
            // yourPCranLabel
            // 
            this.yourPCranLabel.AutoSize = true;
            this.yourPCranLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 20F);
            this.yourPCranLabel.Location = new System.Drawing.Point(3, 280);
            this.yourPCranLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.yourPCranLabel.Name = "yourPCranLabel";
            this.yourPCranLabel.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.yourPCranLabel.Size = new System.Drawing.Size(779, 74);
            this.yourPCranLabel.TabIndex = 1;
            this.yourPCranLabel.Text = "Your PC ran into a problem and needs to restart. We\'re just\r\ncollecting some erro" +
    "r info, and then we\'ll restart for you.";
            // 
            // progressIndicator
            // 
            this.progressIndicator.AutoSize = true;
            this.progressIndicator.Font = new System.Drawing.Font("Segoe UI Semilight", 20F);
            this.progressIndicator.Location = new System.Drawing.Point(3, 394);
            this.progressIndicator.Margin = new System.Windows.Forms.Padding(3, 40, 3, 0);
            this.progressIndicator.Name = "progressIndicator";
            this.progressIndicator.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.progressIndicator.Size = new System.Drawing.Size(248, 37);
            this.progressIndicator.TabIndex = 2;
            this.progressIndicator.Text = "0% complete";
            // 
            // horizontalFlowPanel
            // 
            this.horizontalFlowPanel.Controls.Add(this.qrMargin);
            this.horizontalFlowPanel.Controls.Add(this.qrCode);
            this.horizontalFlowPanel.Controls.Add(this.supportContainer);
            this.horizontalFlowPanel.Location = new System.Drawing.Point(0, 471);
            this.horizontalFlowPanel.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.horizontalFlowPanel.Name = "horizontalFlowPanel";
            this.horizontalFlowPanel.Size = new System.Drawing.Size(9999, 459);
            this.horizontalFlowPanel.TabIndex = 3;
            // 
            // qrMargin
            // 
            this.qrMargin.Location = new System.Drawing.Point(3, 3);
            this.qrMargin.Name = "qrMargin";
            this.qrMargin.Size = new System.Drawing.Size(90, 212);
            this.qrMargin.TabIndex = 2;
            // 
            // qrCode
            // 
            this.qrCode.Image = global::UltimateBlueScreenSimulator.Properties.Resources.bsodqr;
            this.qrCode.Location = new System.Drawing.Point(99, 3);
            this.qrCode.Name = "qrCode";
            this.qrCode.Size = new System.Drawing.Size(110, 110);
            this.qrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.qrCode.TabIndex = 0;
            this.qrCode.TabStop = false;
            // 
            // supportContainer
            // 
            this.supportContainer.BackColor = System.Drawing.Color.Transparent;
            this.supportContainer.Controls.Add(this.errorCode);
            this.supportContainer.Controls.Add(this.supportInfo);
            this.supportContainer.Location = new System.Drawing.Point(227, 3);
            this.supportContainer.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.supportContainer.Name = "supportContainer";
            this.supportContainer.Size = new System.Drawing.Size(825, 153);
            this.supportContainer.TabIndex = 1;
            // 
            // errorCode
            // 
            this.errorCode.Font = new System.Drawing.Font("Segoe UI Semilight", 11F);
            this.errorCode.Location = new System.Drawing.Point(0, 56);
            this.errorCode.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.errorCode.Name = "errorCode";
            this.errorCode.Size = new System.Drawing.Size(1000, 156);
            this.errorCode.TabIndex = 4;
            this.errorCode.Text = "If you call a support person, give them this info:\r\n\r\nStop code: ";
            // 
            // supportInfo
            // 
            this.supportInfo.Font = new System.Drawing.Font("Segoe UI Semilight", 11F);
            this.supportInfo.Location = new System.Drawing.Point(0, 0);
            this.supportInfo.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.supportInfo.Name = "supportInfo";
            this.supportInfo.Size = new System.Drawing.Size(714, 36);
            this.supportInfo.TabIndex = 3;
            this.supportInfo.Text = "For more information about this issue and possible fixes, visit http://windows.co" +
    "m/stopcode";
            // 
            // progressUpdater
            // 
            this.progressUpdater.Enabled = true;
            this.progressUpdater.Interval = 500;
            this.progressUpdater.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // waterMarkText
            // 
            this.waterMarkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.waterMarkText.AutoSize = true;
            this.waterMarkText.BackColor = System.Drawing.Color.Transparent;
            this.waterMarkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.waterMarkText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(163)))), ((int)(((byte)(230)))));
            this.waterMarkText.Location = new System.Drawing.Point(1050, 670);
            this.waterMarkText.Name = "waterMarkText";
            this.waterMarkText.Size = new System.Drawing.Size(188, 20);
            this.waterMarkText.TabIndex = 4;
            this.waterMarkText.Text = "bluescreen simulator plus";
            // 
            // memCodes
            // 
            this.memCodes.AutoSize = true;
            this.memCodes.BackColor = System.Drawing.Color.Transparent;
            this.memCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.memCodes.Location = new System.Drawing.Point(-3, 1);
            this.memCodes.Name = "memCodes";
            this.memCodes.Size = new System.Drawing.Size(132, 60);
            this.memCodes.TabIndex = 5;
            this.memCodes.Text = "0x0000000000000000\r\n0x0000000000000000\r\n0x0000000000000000\r\n0x0000000000000000";
            // 
            // screenUpdater
            // 
            this.screenUpdater.Enabled = true;
            this.screenUpdater.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // windowsIcons
            // 
            this.windowsIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("windowsIcons.ImageStream")));
            this.windowsIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.windowsIcons.Images.SetKeyName(0, "artage-io-48148_1564916990.ico");
            this.windowsIcons.Images.SetKeyName(1, "Tatice-Operating-Systems-Windows.ico");
            this.windowsIcons.Images.SetKeyName(2, "Dakirby309-Windows-8-Metro-Folders-OS-Windows-8-Metro.ico");
            this.windowsIcons.Images.SetKeyName(3, "new-windows-logo (2).ico");
            // 
            // WXBS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(113)))), ((int)(((byte)(170)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.memCodes);
            this.Controls.Add(this.waterMarkText);
            this.Controls.Add(this.verticalFlowPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "WXBS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modern Windows blue screen simulator";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WXBS_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WXBS_FormClosed);
            this.Load += new System.EventHandler(this.WXBS_Load);
            this.LocationChanged += new System.EventHandler(this.WXBS_LocationChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WXBS_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WXBS_KeyDown);
            this.Resize += new System.EventHandler(this.WXBS_Resize);
            this.verticalFlowPanel.ResumeLayout(false);
            this.verticalFlowPanel.PerformLayout();
            this.horizontalFlowPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qrCode)).EndInit();
            this.supportContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel verticalFlowPanel;
        private System.Windows.Forms.Label yourPCranLabel;
        private System.Windows.Forms.Label progressIndicator;
        private System.Windows.Forms.FlowLayoutPanel horizontalFlowPanel;
        private System.Windows.Forms.Panel supportContainer;
        private System.Windows.Forms.Label supportInfo;
        private System.Windows.Forms.Panel qrMargin;
        private System.Windows.Forms.Timer progressUpdater;
        public System.Windows.Forms.Label waterMarkText;
        public System.Windows.Forms.Label errorCode;
        public System.Windows.Forms.Label emoticonLabel;
        internal System.Windows.Forms.Label memCodes;
        private System.Windows.Forms.Timer screenUpdater;
        private System.Windows.Forms.ImageList windowsIcons;
        private System.Windows.Forms.PictureBox qrCode;
    }
}
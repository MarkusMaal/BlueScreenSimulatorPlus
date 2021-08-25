namespace UltimateBlueScreenSimulator
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.splashEmoticon = new System.Windows.Forms.Label();
            this.splashPlus = new System.Windows.Forms.Label();
            this.appNameLabel = new System.Windows.Forms.Label();
            this.SplashText = new System.Windows.Forms.Label();
            this.veriFileTimer = new System.Windows.Forms.Timer(this.components);
            this.appMarketedVersionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // splashEmoticon
            // 
            this.splashEmoticon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.splashEmoticon.BackColor = System.Drawing.Color.Transparent;
            this.splashEmoticon.Font = new System.Drawing.Font("Segoe UI", 105F);
            this.splashEmoticon.Location = new System.Drawing.Point(3, -38);
            this.splashEmoticon.Name = "splashEmoticon";
            this.splashEmoticon.Size = new System.Drawing.Size(158, 203);
            this.splashEmoticon.TabIndex = 0;
            this.splashEmoticon.Text = ":)";
            this.splashEmoticon.UseWaitCursor = true;
            // 
            // splashPlus
            // 
            this.splashPlus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.splashPlus.Font = new System.Drawing.Font("Segoe UI", 32F);
            this.splashPlus.ForeColor = System.Drawing.Color.Lime;
            this.splashPlus.Location = new System.Drawing.Point(98, -10);
            this.splashPlus.Name = "splashPlus";
            this.splashPlus.Size = new System.Drawing.Size(79, 64);
            this.splashPlus.TabIndex = 1;
            this.splashPlus.Text = "+";
            this.splashPlus.UseWaitCursor = true;
            // 
            // appNameLabel
            // 
            this.appNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.appNameLabel.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.appNameLabel.Location = new System.Drawing.Point(116, 54);
            this.appNameLabel.Name = "appNameLabel";
            this.appNameLabel.Size = new System.Drawing.Size(279, 38);
            this.appNameLabel.TabIndex = 2;
            this.appNameLabel.Text = "Blue Screen Simulator Plus";
            this.appNameLabel.UseWaitCursor = true;
            // 
            // SplashText
            // 
            this.SplashText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.SplashText.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.SplashText.Location = new System.Drawing.Point(20, 129);
            this.SplashText.Name = "SplashText";
            this.SplashText.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.SplashText.Size = new System.Drawing.Size(426, 20);
            this.SplashText.TabIndex = 3;
            this.SplashText.Text = "Please wait...";
            this.SplashText.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SplashText.UseWaitCursor = true;
            // 
            // veriFileTimer
            // 
            this.veriFileTimer.Enabled = true;
            this.veriFileTimer.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // appMarketedVersionLabel
            // 
            this.appMarketedVersionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.appMarketedVersionLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appMarketedVersionLabel.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.appMarketedVersionLabel.ForeColor = System.Drawing.Color.MediumBlue;
            this.appMarketedVersionLabel.Location = new System.Drawing.Point(376, 42);
            this.appMarketedVersionLabel.Name = "appMarketedVersionLabel";
            this.appMarketedVersionLabel.Size = new System.Drawing.Size(61, 64);
            this.appMarketedVersionLabel.TabIndex = 4;
            this.appMarketedVersionLabel.Text = "2.0";
            this.appMarketedVersionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.appMarketedVersionLabel.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 8.5F);
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(119, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "advanced bugcheck simulation technology";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(389, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "pre-release 3";
            this.label2.UseWaitCursor = true;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::UltimateBlueScreenSimulator.Properties.Resources.round_corners;
            this.ClientSize = new System.Drawing.Size(471, 149);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.appMarketedVersionLabel);
            this.Controls.Add(this.SplashText);
            this.Controls.Add(this.appNameLabel);
            this.Controls.Add(this.splashPlus);
            this.Controls.Add(this.splashEmoticon);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Splash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.UseWaitCursor = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Splash_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label splashEmoticon;
        private System.Windows.Forms.Label splashPlus;
        private System.Windows.Forms.Label appNameLabel;
        internal System.Windows.Forms.Label SplashText;
        internal System.Windows.Forms.Timer veriFileTimer;
        private System.Windows.Forms.Label appMarketedVersionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
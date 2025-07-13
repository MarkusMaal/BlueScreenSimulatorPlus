namespace UltimateBlueScreenSimulator
{
    partial class Cebsod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cebsod));
            this.infoLabel = new System.Windows.Forms.AliasedLabel();
            this.techinfoLabel = new System.Windows.Forms.AliasedLabel();
            this.technicalCode = new System.Windows.Forms.AliasedLabel();
            this.timeOut = new System.Windows.Forms.AliasedLabel();
            this.screenUpdater = new System.Windows.Forms.Timer(this.components);
            this.waterMarkText = new System.Windows.Forms.AliasedLabel();
            this.rainBowScreen = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.infoLabel.Location = new System.Drawing.Point(-2, 10);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(719, 47);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "A problem has occurred and Windows CE has been shut down to prevent damage to you" +
    "r\r\ncomputer.\r\nIf you will try to restart your computer, press Ctrl+Alt+Delete.";
            this.infoLabel.UseCompatibleTextRendering = true;
            // 
            // techinfoLabel
            // 
            this.techinfoLabel.AutoSize = true;
            this.techinfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.techinfoLabel.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.techinfoLabel.Location = new System.Drawing.Point(-2, 69);
            this.techinfoLabel.Name = "techinfoLabel";
            this.techinfoLabel.Size = new System.Drawing.Size(194, 19);
            this.techinfoLabel.TabIndex = 2;
            this.techinfoLabel.Text = "Technical information:";
            this.techinfoLabel.UseCompatibleTextRendering = true;
            // 
            // technicalCode
            // 
            this.technicalCode.AutoSize = true;
            this.technicalCode.BackColor = System.Drawing.Color.Transparent;
            this.technicalCode.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.technicalCode.Location = new System.Drawing.Point(-2, 101);
            this.technicalCode.Name = "technicalCode";
            this.technicalCode.Size = new System.Drawing.Size(435, 19);
            this.technicalCode.TabIndex = 3;
            this.technicalCode.Text = "*** STOP: 0xADDEAD (user manually initiated crash)";
            this.technicalCode.UseCompatibleTextRendering = true;
            // 
            // timeOut
            // 
            this.timeOut.AutoSize = true;
            this.timeOut.BackColor = System.Drawing.Color.Transparent;
            this.timeOut.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.timeOut.Location = new System.Drawing.Point(-2, 138);
            this.timeOut.Name = "timeOut";
            this.timeOut.Size = new System.Drawing.Size(349, 33);
            this.timeOut.TabIndex = 4;
            this.timeOut.Text = "The computer will restart automatically\r\nafter 30 seconds.";
            this.timeOut.UseCompatibleTextRendering = true;
            // 
            // screenUpdater
            // 
            this.screenUpdater.Enabled = true;
            this.screenUpdater.Interval = 1000;
            this.screenUpdater.Tick += new System.EventHandler(this.TimeoutProgression);
            // 
            // waterMarkText
            // 
            this.waterMarkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.waterMarkText.AutoSize = true;
            this.waterMarkText.BackColor = System.Drawing.Color.Transparent;
            this.waterMarkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.waterMarkText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.waterMarkText.Location = new System.Drawing.Point(12, 364);
            this.waterMarkText.Name = "waterMarkText";
            this.waterMarkText.Size = new System.Drawing.Size(148, 15);
            this.waterMarkText.TabIndex = 8;
            this.waterMarkText.Text = "bluescreen simulator plus";
            // 
            // rainBowScreen
            // 
            this.rainBowScreen.Interval = 10;
            this.rainBowScreen.Tick += new System.EventHandler(this.DoubleRainbow);
            // 
            // Cebsod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(750, 400);
            this.Controls.Add(this.waterMarkText);
            this.Controls.Add(this.timeOut);
            this.Controls.Add(this.technicalCode);
            this.Controls.Add(this.techinfoLabel);
            this.Controls.Add(this.infoLabel);
            this.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Cebsod";
            this.Text = "Windows CE 5 blue screen simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Unload);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AfterUnload);
            this.Load += new System.EventHandler(this.Initialize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cebsod_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Cebsod_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.AliasedLabel technicalCode;
        private System.Windows.Forms.Timer screenUpdater;
        private System.Windows.Forms.AliasedLabel infoLabel;
        private System.Windows.Forms.AliasedLabel techinfoLabel;
        private System.Windows.Forms.AliasedLabel timeOut;
        public System.Windows.Forms.AliasedLabel waterMarkText;
        private System.Windows.Forms.Timer rainBowScreen;


    }

}
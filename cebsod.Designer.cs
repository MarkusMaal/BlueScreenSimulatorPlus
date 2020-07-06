namespace UltimateBlueScreenSimulator
{
    partial class cebsod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cebsod));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.technicalCode = new System.Windows.Forms.Label();
            this.timeOut = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.waterMarkText = new System.Windows.Forms.Label();
            this.rainBowScreen = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.label1.Location = new System.Drawing.Point(-2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(663, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "A problem has occurred and Windows CE has been shut down to prevent damage to you" +
    "r\r\ncomputer.\r\nIf you will try to restart your computer, press Ctrl+Alt+Delete.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.label2.Location = new System.Drawing.Point(-2, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Technical information:";
            // 
            // technicalCode
            // 
            this.technicalCode.AutoSize = true;
            this.technicalCode.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.technicalCode.Location = new System.Drawing.Point(-2, 101);
            this.technicalCode.Name = "technicalCode";
            this.technicalCode.Size = new System.Drawing.Size(407, 14);
            this.technicalCode.TabIndex = 3;
            this.technicalCode.Text = "*** STOP: 0xADDEAD (user manually initiated crash)";
            // 
            // timeOut
            // 
            this.timeOut.AutoSize = true;
            this.timeOut.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.timeOut.Location = new System.Drawing.Point(-2, 138);
            this.timeOut.Name = "timeOut";
            this.timeOut.Size = new System.Drawing.Size(319, 28);
            this.timeOut.TabIndex = 4;
            this.timeOut.Text = "The computer will restart automatically\r\nafter 30 seconds.";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // waterMarkText
            // 
            this.waterMarkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.waterMarkText.AutoSize = true;
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
            this.rainBowScreen.Tick += new System.EventHandler(this.RainBowScreen_Tick);
            // 
            // cebsod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(750, 400);
            this.Controls.Add(this.waterMarkText);
            this.Controls.Add(this.timeOut);
            this.Controls.Add(this.technicalCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "cebsod";
            this.Text = "Windows CE 5 blue screen simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cebsod_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Cebsod_FormClosed);
            this.Load += new System.EventHandler(this.Cebsod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label technicalCode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label timeOut;
        public System.Windows.Forms.Label waterMarkText;
        private System.Windows.Forms.Timer rainBowScreen;
    }
}
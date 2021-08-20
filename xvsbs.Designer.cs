using System.Drawing.Text;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
{
    partial class Xvsbs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Xvsbs));
            this.dumpTimer = new System.Windows.Forms.Timer(this.components);
            this.tardisFade = new System.Windows.Forms.Timer(this.components);
            this.rainBowScreen = new System.Windows.Forms.Timer(this.components);
            this.introductionText = new System.Windows.Forms.AliasedLabel();
            this.errorCode = new System.Windows.Forms.AliasedLabel();
            this.supportInfo = new System.Windows.Forms.AliasedLabel();
            this.technicalCode = new System.Windows.Forms.AliasedLabel();
            this.dumpLabel = new System.Windows.Forms.AliasedLabel();
            this.waterMarkText = new System.Windows.Forms.AliasedLabel();
            this.screenUpdater = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // dumpTimer
            // 
            this.dumpTimer.Enabled = true;
            this.dumpTimer.Interval = 500;
            this.dumpTimer.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // tardisFade
            // 
            this.tardisFade.Interval = 10;
            this.tardisFade.Tick += new System.EventHandler(this.TardisFade_Tick);
            // 
            // rainBowScreen
            // 
            this.rainBowScreen.Interval = 10;
            this.rainBowScreen.Tick += new System.EventHandler(this.RainBowScreen_Tick);
            // 
            // introductionText
            // 
            this.introductionText.BackColor = this.BackColor;
            this.introductionText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.introductionText.Font = new System.Drawing.Font("Lucida Console", 9.7F);
            this.introductionText.ForeColor = this.ForeColor;
            this.introductionText.Location = new System.Drawing.Point(-1, 15);
            this.introductionText.Name = "introductionText";
            this.introductionText.Size = new System.Drawing.Size(641, 28);
            this.introductionText.TabIndex = 8;
            this.introductionText.Text = "A problem has been detected and Windows has been shut down to prevent damage\nto y" +
    "our computer.";
            this.introductionText.UseCompatibleTextRendering = true;
            // 
            // errorCode
            // 
            this.errorCode.AutoSize = true;
            this.errorCode.BackColor = this.BackColor;
            this.errorCode.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.errorCode.Font = new System.Drawing.Font("Lucida Console", 9.7F);
            this.errorCode.ForeColor = this.ForeColor;
            this.errorCode.Location = new System.Drawing.Point(-1, 58);
            this.errorCode.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.errorCode.Name = "errorCode";
            this.errorCode.Size = new System.Drawing.Size(382, 18);
            this.errorCode.TabIndex = 9;
            this.errorCode.Text = "The end-user manually generated the crash dump.";
            this.errorCode.UseCompatibleTextRendering = true;
            // 
            // supportInfo
            // 
            this.supportInfo.AutoSize = true;
            this.supportInfo.BackColor = this.BackColor;
            this.supportInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.supportInfo.Font = new System.Drawing.Font("Lucida Console", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.supportInfo.ForeColor = this.ForeColor;
            this.supportInfo.Location = new System.Drawing.Point(-1, 90);
            this.supportInfo.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.supportInfo.Name = "supportInfo";
            this.supportInfo.Size = new System.Drawing.Size(602, 213);
            this.supportInfo.TabIndex = 10;
            this.supportInfo.Text = resources.GetString("supportInfo.Text");
            this.supportInfo.UseCompatibleTextRendering = true;
            // 
            // technicalCode
            // 
            this.technicalCode.AutoSize = true;
            this.technicalCode.BackColor = this.BackColor;
            this.technicalCode.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.technicalCode.Font = new System.Drawing.Font("Lucida Console", 9.7F);
            this.technicalCode.ForeColor = this.ForeColor;
            this.technicalCode.Location = new System.Drawing.Point(-1, 312);
            this.technicalCode.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.technicalCode.Name = "technicalCode";
            this.technicalCode.Size = new System.Drawing.Size(559, 18);
            this.technicalCode.TabIndex = 11;
            this.technicalCode.Text = "*** STOP: 0xDEADDEAD (0x00000000, 0x00000000, 0x00000000, 0x00000000)";
            this.technicalCode.UseCompatibleTextRendering = true;
            // 
            // dumpLabel
            // 
            this.dumpLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dumpLabel.Font = new System.Drawing.Font("Lucida Console", 9.7F);
            this.dumpLabel.Location = new System.Drawing.Point(-1, 354);
            this.dumpLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.dumpLabel.Name = "dumpLabel";
            this.dumpLabel.Size = new System.Drawing.Size(641, 88);
            this.dumpLabel.TabIndex = 12;
            this.dumpLabel.UseCompatibleTextRendering = true;
            // 
            // waterMarkText
            // 
            this.waterMarkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.waterMarkText.AutoSize = true;
            this.waterMarkText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.waterMarkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.waterMarkText.Location = new System.Drawing.Point(-1, 0);
            this.waterMarkText.Name = "waterMarkText";
            this.waterMarkText.Size = new System.Drawing.Size(148, 15);
            this.waterMarkText.TabIndex = 7;
            this.waterMarkText.Text = "bluescreen simulator plus";
            // 
            // screenUpdater
            // 
            this.screenUpdater.Enabled = true;
            this.screenUpdater.Interval = 500;
            this.screenUpdater.Tick += new System.EventHandler(this.screenUpdater_Tick);
            // 
            // Xvsbs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.introductionText);
            this.Controls.Add(this.errorCode);
            this.Controls.Add(this.supportInfo);
            this.Controls.Add(this.technicalCode);
            this.Controls.Add(this.dumpLabel);
            this.Controls.Add(this.waterMarkText);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Xvsbs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows NT 5.1 blue screen simulator";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Xvsbs_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Xvsbs_FormClosed);
            this.Load += new System.EventHandler(this.Xvsbs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public AliasedLabel waterMarkText;
        public System.Windows.Forms.Timer dumpTimer;
        private System.Windows.Forms.Timer tardisFade;
        private System.Windows.Forms.Timer rainBowScreen;
        public AliasedLabel introductionText;
        public AliasedLabel errorCode;
        public AliasedLabel supportInfo;
        public AliasedLabel technicalCode;
        public AliasedLabel dumpLabel;
        private Timer screenUpdater;
    }

}
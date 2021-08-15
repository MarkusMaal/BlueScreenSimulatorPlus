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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tardisFade = new System.Windows.Forms.Timer(this.components);
            this.rainBowScreen = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.AliasedLabel();
            this.errorCode = new System.Windows.Forms.AliasedLabel();
            this.supportInfo = new System.Windows.Forms.AliasedLabel();
            this.technicalCode = new System.Windows.Forms.AliasedLabel();
            this.label5 = new System.Windows.Forms.AliasedLabel();
            this.waterMarkText = new System.Windows.Forms.AliasedLabel();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
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
            // label1
            // 
            this.label1.BackColor = this.BackColor;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 9.7F);
            this.label1.ForeColor = this.ForeColor;
            this.label1.Location = new System.Drawing.Point(-1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(641, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "A problem has been detected and Windows has been shut down to prevent damage\nto y" +
    "our computer.";
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
            this.errorCode.Size = new System.Drawing.Size(383, 13);
            this.errorCode.TabIndex = 9;
            this.errorCode.Text = "The end-user manually generated the crash dump.";
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
            this.supportInfo.Size = new System.Drawing.Size(591, 195);
            this.supportInfo.TabIndex = 10;
            this.supportInfo.Text = resources.GetString("supportInfo.Text");
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
            this.technicalCode.Size = new System.Drawing.Size(559, 13);
            this.technicalCode.TabIndex = 11;
            this.technicalCode.Text = "*** STOP: 0xDEADDEAD (0x00000000, 0x00000000, 0x00000000, 0x00000000)";
            // 
            // label5
            // 
            this.label5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label5.Font = new System.Drawing.Font("Lucida Console", 9.7F);
            this.label5.Location = new System.Drawing.Point(-1, 354);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(641, 88);
            this.label5.TabIndex = 12;
            this.label5.Text = "Beginning dump of physical memory";
            // 
            // waterMarkText
            // 
            this.waterMarkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.waterMarkText.AutoSize = true;
            this.waterMarkText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.waterMarkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.waterMarkText.Location = new System.Drawing.Point(-4, -3);
            this.waterMarkText.Name = "waterMarkText";
            this.waterMarkText.Size = new System.Drawing.Size(148, 15);
            this.waterMarkText.TabIndex = 7;
            this.waterMarkText.Text = "bluescreen simulator plus";
            // 
            // Xvsbs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.errorCode);
            this.Controls.Add(this.supportInfo);
            this.Controls.Add(this.technicalCode);
            this.Controls.Add(this.label5);
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
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer tardisFade;
        private System.Windows.Forms.Timer rainBowScreen;
        public AliasedLabel label1;
        public AliasedLabel errorCode;
        public AliasedLabel supportInfo;
        public AliasedLabel technicalCode;
        public AliasedLabel label5;
    }

}
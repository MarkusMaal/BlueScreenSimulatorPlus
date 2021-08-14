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
            this.label7 = new UltimateBlueScreenSimulator.AliasedLabel();
            this.label6 = new UltimateBlueScreenSimulator.AliasedLabel();
            this.label1 = new UltimateBlueScreenSimulator.AliasedLabel();
            this.errorCode = new UltimateBlueScreenSimulator.AliasedLabel();
            this.supportInfo = new UltimateBlueScreenSimulator.AliasedLabel();
            this.technicalCode = new UltimateBlueScreenSimulator.AliasedLabel();
            this.label5 = new UltimateBlueScreenSimulator.AliasedLabel();
            this.waterMarkText = new UltimateBlueScreenSimulator.AliasedLabel();
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.label7.Location = new System.Drawing.Point(-1, 407);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(633, 33);
            this.label7.TabIndex = 14;
            this.label7.Text = "Contact your system administrator or technical support group for further\r\nassista" +
    "nce.";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.label6.Location = new System.Drawing.Point(-1, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Physical memory dump complete.";
            this.label6.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.label1.Location = new System.Drawing.Point(-1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(641, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "A problem has been detected and Windows has been shut down to prevent damage\r\nto " +
    "your computer.";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // errorCode
            // 
            this.errorCode.AutoSize = true;
            this.errorCode.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.errorCode.Location = new System.Drawing.Point(-1, 63);
            this.errorCode.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.errorCode.Name = "errorCode";
            this.errorCode.Size = new System.Drawing.Size(410, 19);
            this.errorCode.TabIndex = 9;
            this.errorCode.Text = "The end-user manually generated the crash dump.";
            this.errorCode.UseCompatibleTextRendering = true;
            // 
            // supportInfo
            // 
            this.supportInfo.AutoSize = true;
            this.supportInfo.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.supportInfo.Location = new System.Drawing.Point(-1, 102);
            this.supportInfo.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.supportInfo.Name = "supportInfo";
            this.supportInfo.Size = new System.Drawing.Size(642, 213);
            this.supportInfo.TabIndex = 10;
            this.supportInfo.Text = resources.GetString("supportInfo.Text");
            this.supportInfo.UseCompatibleTextRendering = true;
            // 
            // technicalCode
            // 
            this.technicalCode.AutoSize = true;
            this.technicalCode.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.technicalCode.Location = new System.Drawing.Point(-1, 335);
            this.technicalCode.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.technicalCode.Name = "technicalCode";
            this.technicalCode.Size = new System.Drawing.Size(599, 19);
            this.technicalCode.TabIndex = 11;
            this.technicalCode.Text = "*** STOP: 0xDEADDEAD (0x00000000, 0x00000000, 0x00000000, 0x00000000)";
            this.technicalCode.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.label5.Location = new System.Drawing.Point(-1, 377);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(289, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Beginning dump of physical memory";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // waterMarkText
            // 
            this.waterMarkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.waterMarkText.AutoSize = true;
            this.waterMarkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.waterMarkText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.waterMarkText.Location = new System.Drawing.Point(-4, -3);
            this.waterMarkText.Name = "waterMarkText";
            this.waterMarkText.Size = new System.Drawing.Size(145, 19);
            this.waterMarkText.TabIndex = 7;
            this.waterMarkText.Text = "bluescreen simulator plus";
            this.waterMarkText.UseCompatibleTextRendering = true;
            // 
            // Xvsbs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
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
            this.Text = "Windows NT 5.1/6.0/6.1 blue screen simulator";
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
        public AliasedLabel label6;
        public AliasedLabel label7;
    }

    public partial class AliasedLabel : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            this.UseCompatibleTextRendering = true;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            base.OnPaint(e);
        }
    }
}
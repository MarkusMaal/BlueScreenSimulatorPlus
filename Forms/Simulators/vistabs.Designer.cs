
namespace UltimateBlueScreenSimulator
{
    partial class Vistabs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vistabs));
            this.screenUpdater = new System.Windows.Forms.Timer(this.components);
            this.tardisFade = new System.Windows.Forms.Timer(this.components);
            this.rainBowScreen = new System.Windows.Forms.Timer(this.components);
            this.technicalCode = new System.Windows.Forms.AliasedLabel();
            this.dumpText = new System.Windows.Forms.AliasedLabel();
            this.introductionText = new System.Windows.Forms.AliasedLabel();
            this.errorCode = new System.Windows.Forms.AliasedLabel();
            this.supportInfo = new System.Windows.Forms.AliasedLabel();
            this.waterMarkText = new System.Windows.Forms.AliasedLabel();
            this.SuspendLayout();
            // 
            // screenUpdater
            // 
            this.screenUpdater.Enabled = true;
            this.screenUpdater.Interval = 250;
            this.screenUpdater.Tick += new System.EventHandler(this.Timer1_Tick);
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
            // technicalCode
            // 
            this.technicalCode.AutoSize = true;
            this.technicalCode.BackColor = System.Drawing.Color.Transparent;
            this.technicalCode.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.technicalCode.Font = new System.Drawing.Font("Consolas", 9F);
            this.technicalCode.ForeColor = System.Drawing.Color.White;
            this.technicalCode.Location = new System.Drawing.Point(-1, 331);
            this.technicalCode.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.technicalCode.MaximumSize = new System.Drawing.Size(641, 0);
            this.technicalCode.Name = "technicalCode";
            this.technicalCode.Size = new System.Drawing.Size(490, 14);
            this.technicalCode.TabIndex = 11;
            this.technicalCode.Text = "*** STOP: 0xDEADDEAD (0x00000000, 0x00000000, 0x00000000, 0x00000000)";
            // 
            // dumpText
            // 
            this.dumpText.AutoSize = true;
            this.dumpText.BackColor = System.Drawing.Color.Transparent;
            this.dumpText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dumpText.Font = new System.Drawing.Font("Consolas", 9F);
            this.dumpText.ForeColor = System.Drawing.Color.White;
            this.dumpText.Location = new System.Drawing.Point(-1, 373);
            this.dumpText.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.dumpText.MaximumSize = new System.Drawing.Size(641, 0);
            this.dumpText.Name = "dumpText";
            this.dumpText.Size = new System.Drawing.Size(84, 14);
            this.dumpText.TabIndex = 12;
            this.dumpText.Text = "Sample Text";
            // 
            // introductionText
            // 
            this.introductionText.AutoSize = true;
            this.introductionText.BackColor = System.Drawing.Color.Transparent;
            this.introductionText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.introductionText.Font = new System.Drawing.Font("Consolas", 9F);
            this.introductionText.ForeColor = System.Drawing.Color.White;
            this.introductionText.Location = new System.Drawing.Point(-1, 15);
            this.introductionText.MaximumSize = new System.Drawing.Size(641, 0);
            this.introductionText.Name = "introductionText";
            this.introductionText.Size = new System.Drawing.Size(539, 28);
            this.introductionText.TabIndex = 8;
            this.introductionText.Text = "A problem has been detected and Windows has been shut down to prevent damage\nto y" +
    "our computer.";
            // 
            // errorCode
            // 
            this.errorCode.AutoSize = true;
            this.errorCode.BackColor = System.Drawing.Color.Transparent;
            this.errorCode.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.errorCode.Font = new System.Drawing.Font("Consolas", 9F);
            this.errorCode.ForeColor = System.Drawing.Color.White;
            this.errorCode.Location = new System.Drawing.Point(-1, 58);
            this.errorCode.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.errorCode.MaximumSize = new System.Drawing.Size(641, 0);
            this.errorCode.Name = "errorCode";
            this.errorCode.Size = new System.Drawing.Size(336, 14);
            this.errorCode.TabIndex = 9;
            this.errorCode.Text = "The end-user manually generated the crash dump.";
            // 
            // supportInfo
            // 
            this.supportInfo.AutoSize = true;
            this.supportInfo.BackColor = System.Drawing.Color.Transparent;
            this.supportInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.supportInfo.Font = new System.Drawing.Font("Consolas", 9F);
            this.supportInfo.ForeColor = System.Drawing.Color.White;
            this.supportInfo.Location = new System.Drawing.Point(-1, 90);
            this.supportInfo.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.supportInfo.MaximumSize = new System.Drawing.Size(641, 0);
            this.supportInfo.Name = "supportInfo";
            this.supportInfo.Size = new System.Drawing.Size(623, 28);
            this.supportInfo.TabIndex = 10;
            this.supportInfo.Text = "You are not supposed to see this text under any condition. If you see this text, " +
    "please let the cops know immediately.";
            // 
            // waterMarkText
            // 
            this.waterMarkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.waterMarkText.AutoSize = true;
            this.waterMarkText.BackColor = System.Drawing.Color.Transparent;
            this.waterMarkText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.waterMarkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.waterMarkText.Location = new System.Drawing.Point(489, 0);
            this.waterMarkText.Name = "waterMarkText";
            this.waterMarkText.Size = new System.Drawing.Size(151, 15);
            this.waterMarkText.TabIndex = 7;
            this.waterMarkText.Text = "blue screen simulator plus";
            // 
            // Vistabs
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.technicalCode);
            this.Controls.Add(this.dumpText);
            this.Controls.Add(this.introductionText);
            this.Controls.Add(this.errorCode);
            this.Controls.Add(this.supportInfo);
            this.Controls.Add(this.waterMarkText);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Vistabs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows NT 6.0/6.1 blue screen simulator";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Xvsbs_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Xvsbs_FormClosed);
            this.Load += new System.EventHandler(this.Xvsbs_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Vistabs_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Vistabs_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Timer screenUpdater;
        private System.Windows.Forms.Timer tardisFade;
        private System.Windows.Forms.Timer rainBowScreen;
        public System.Windows.Forms.AliasedLabel waterMarkText;
        public System.Windows.Forms.AliasedLabel errorCode;
        public System.Windows.Forms.AliasedLabel supportInfo;
        public System.Windows.Forms.AliasedLabel technicalCode;
        public System.Windows.Forms.AliasedLabel dumpText;
        private System.Windows.Forms.AliasedLabel introductionText;
    }

}
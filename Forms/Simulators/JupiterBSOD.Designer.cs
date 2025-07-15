namespace UltimateBlueScreenSimulator
{
    partial class JupiterBSOD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JupiterBSOD));
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.DetailsLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.timecounter = new System.Windows.Forms.Timer(this.components);
            this.Watermark = new System.Windows.Forms.Label();
            this.screenUpdater = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HeaderLabel.BackColor = System.Drawing.Color.Transparent;
            this.HeaderLabel.Font = new System.Drawing.Font("Segoe UI", 26F);
            this.HeaderLabel.Location = new System.Drawing.Point(250, 220);
            this.HeaderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(773, 52);
            this.HeaderLabel.TabIndex = 0;
            this.HeaderLabel.Text = "Your computer needs to restart.";
            // 
            // DetailsLabel
            // 
            this.DetailsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DetailsLabel.BackColor = System.Drawing.Color.Transparent;
            this.DetailsLabel.Location = new System.Drawing.Point(250, 272);
            this.DetailsLabel.Name = "DetailsLabel";
            this.DetailsLabel.Size = new System.Drawing.Size(773, 56);
            this.DetailsLabel.TabIndex = 1;
            this.DetailsLabel.Text = "It encountered a problem and will restart automatically.\r\nError: 0x000000F4";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProgressLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProgressLabel.Font = new System.Drawing.Font("Segoe UI", 15.5F);
            this.ProgressLabel.Location = new System.Drawing.Point(250, 428);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(774, 65);
            this.ProgressLabel.TabIndex = 2;
            this.ProgressLabel.Text = "Collecting problem information:    10 seconds remaining";
            // 
            // timecounter
            // 
            this.timecounter.Interval = 1000;
            this.timecounter.Tick += new System.EventHandler(this.Timecounter_Tick);
            // 
            // Watermark
            // 
            this.Watermark.AutoSize = true;
            this.Watermark.BackColor = System.Drawing.Color.Transparent;
            this.Watermark.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Watermark.ForeColor = System.Drawing.Color.DimGray;
            this.Watermark.Location = new System.Drawing.Point(12, 9);
            this.Watermark.Name = "Watermark";
            this.Watermark.Size = new System.Drawing.Size(145, 15);
            this.Watermark.TabIndex = 3;
            this.Watermark.Text = "blue screen simulator plus";
            // 
            // screenUpdater
            // 
            this.screenUpdater.Enabled = true;
            this.screenUpdater.Tick += new System.EventHandler(this.ScreenUpdater_Tick);
            // 
            // JupiterBSOD
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.Watermark);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.DetailsLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "JupiterBSOD";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "JupiterBSOD";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JupiterBSOD_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JupiterBSOD_FormClosed);
            this.Load += new System.EventHandler(this.JupiterBSOD_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JupiterBSOD_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.JupiterBSOD_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Label DetailsLabel;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Timer timecounter;
        private System.Windows.Forms.Label Watermark;
        private System.Windows.Forms.Timer screenUpdater;
    }
}
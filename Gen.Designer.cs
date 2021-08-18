
namespace UltimateBlueScreenSimulator
{
    partial class Gen
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
            this.genProgressBar = new System.Windows.Forms.ProgressBar();
            this.genLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // genProgressBar
            // 
            this.genProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.genProgressBar.Location = new System.Drawing.Point(12, 29);
            this.genProgressBar.Name = "genProgressBar";
            this.genProgressBar.Size = new System.Drawing.Size(250, 11);
            this.genProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.genProgressBar.TabIndex = 0;
            // 
            // genLabel
            // 
            this.genLabel.AutoSize = true;
            this.genLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.genLabel.Location = new System.Drawing.Point(8, 9);
            this.genLabel.Name = "genLabel";
            this.genLabel.Size = new System.Drawing.Size(169, 17);
            this.genLabel.TabIndex = 1;
            this.genLabel.Text = "Generating blue screen...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Gen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 48);
            this.Controls.Add(this.genLabel);
            this.Controls.Add(this.genProgressBar);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Gen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Gen_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar genProgressBar;
        private System.Windows.Forms.Label genLabel;
        private System.Windows.Forms.Timer timer1;
    }
}
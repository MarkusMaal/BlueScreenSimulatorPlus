
using MaterialSkin.Controls;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gen));
            this.genProgressBar = new MaterialSkin.Controls.MaterialProgressBar();
            this.genTimer = new System.Windows.Forms.Timer(this.components);
            this.genLabel = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // genProgressBar
            // 
            this.genProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.genProgressBar.Depth = 0;
            this.genProgressBar.Location = new System.Drawing.Point(9, 53);
            this.genProgressBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.genProgressBar.Name = "genProgressBar";
            this.genProgressBar.Size = new System.Drawing.Size(297, 5);
            this.genProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.genProgressBar.TabIndex = 0;
            this.genProgressBar.UseWaitCursor = true;
            // 
            // genTimer
            // 
            this.genTimer.Enabled = true;
            this.genTimer.Tick += new System.EventHandler(this.ProgressChecker);
            // 
            // genLabel
            // 
            this.genLabel.AutoSize = true;
            this.genLabel.Depth = 0;
            this.genLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.genLabel.Location = new System.Drawing.Point(6, 21);
            this.genLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.genLabel.Name = "genLabel";
            this.genLabel.Size = new System.Drawing.Size(174, 19);
            this.genLabel.TabIndex = 1;
            this.genLabel.Text = "Generating blue screen...";
            this.genLabel.UseWaitCursor = true;
            // 
            // Gen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 57);
            this.Controls.Add(this.genLabel);
            this.Controls.Add(this.genProgressBar);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Gen";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.UseWaitCursor = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreventUserClosing);
            this.Load += new System.EventHandler(this.Gen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialProgressBar genProgressBar;
        private System.Windows.Forms.Timer genTimer;
        private MaterialLabel genLabel;
    }
}
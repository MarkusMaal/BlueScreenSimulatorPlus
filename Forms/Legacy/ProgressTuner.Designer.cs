namespace UltimateBlueScreenSimulator.Forms.Legacy
{
    partial class ProgressTuner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressTuner));
            this.progressTrackBar = new System.Windows.Forms.TrackBar();
            this.totalTimeText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addKeyFrame = new System.Windows.Forms.Button();
            this.deleteKeyFrame = new System.Windows.Forms.Button();
            this.nextKeyFrameButton = new System.Windows.Forms.Button();
            this.previousKeyFrameButton = new System.Windows.Forms.Button();
            this.progressVisualization = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.incPercent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressPositionLabel = new System.Windows.Forms.Label();
            this.randomButton = new System.Windows.Forms.Button();
            this.repeatButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.progressTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressVisualization)).BeginInit();
            this.SuspendLayout();
            // 
            // progressTrackBar
            // 
            this.progressTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressTrackBar.Location = new System.Drawing.Point(12, 21);
            this.progressTrackBar.Maximum = 10000;
            this.progressTrackBar.Name = "progressTrackBar";
            this.progressTrackBar.Size = new System.Drawing.Size(516, 45);
            this.progressTrackBar.TabIndex = 0;
            this.progressTrackBar.TickFrequency = 1000;
            this.progressTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.progressTrackBar.ValueChanged += new System.EventHandler(this.progressTrackBar_Scroll);
            // 
            // totalTimeText
            // 
            this.totalTimeText.Location = new System.Drawing.Point(94, 108);
            this.totalTimeText.Name = "totalTimeText";
            this.totalTimeText.Size = new System.Drawing.Size(34, 20);
            this.totalTimeText.TabIndex = 2;
            this.totalTimeText.Text = "10.0";
            this.totalTimeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalTimeText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total time:";
            // 
            // addKeyFrame
            // 
            this.addKeyFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addKeyFrame.Location = new System.Drawing.Point(455, 82);
            this.addKeyFrame.Name = "addKeyFrame";
            this.addKeyFrame.Size = new System.Drawing.Size(65, 23);
            this.addKeyFrame.TabIndex = 4;
            this.addKeyFrame.Text = "&Set KF";
            this.addKeyFrame.UseVisualStyleBackColor = true;
            this.addKeyFrame.Click += new System.EventHandler(this.AddKeyFrame_Click);
            // 
            // deleteKeyFrame
            // 
            this.deleteKeyFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteKeyFrame.Location = new System.Drawing.Point(378, 82);
            this.deleteKeyFrame.Name = "deleteKeyFrame";
            this.deleteKeyFrame.Size = new System.Drawing.Size(71, 23);
            this.deleteKeyFrame.TabIndex = 3;
            this.deleteKeyFrame.Text = "&Delete KF";
            this.deleteKeyFrame.UseVisualStyleBackColor = true;
            this.deleteKeyFrame.Click += new System.EventHandler(this.deleteKeyFrame_Click);
            // 
            // nextKeyFrameButton
            // 
            this.nextKeyFrameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextKeyFrameButton.Location = new System.Drawing.Point(70, 165);
            this.nextKeyFrameButton.Name = "nextKeyFrameButton";
            this.nextKeyFrameButton.Size = new System.Drawing.Size(43, 23);
            this.nextKeyFrameButton.TabIndex = 6;
            this.nextKeyFrameButton.Text = "KF&+";
            this.nextKeyFrameButton.UseVisualStyleBackColor = true;
            this.nextKeyFrameButton.Click += new System.EventHandler(this.nextKeyFrameButton_Click);
            // 
            // previousKeyFrameButton
            // 
            this.previousKeyFrameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previousKeyFrameButton.Location = new System.Drawing.Point(20, 165);
            this.previousKeyFrameButton.Name = "previousKeyFrameButton";
            this.previousKeyFrameButton.Size = new System.Drawing.Size(44, 23);
            this.previousKeyFrameButton.TabIndex = 5;
            this.previousKeyFrameButton.Text = "&-KF";
            this.previousKeyFrameButton.UseVisualStyleBackColor = true;
            this.previousKeyFrameButton.Click += new System.EventHandler(this.previousKeyFrameButton_Click);
            // 
            // progressVisualization
            // 
            this.progressVisualization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressVisualization.Location = new System.Drawing.Point(23, 12);
            this.progressVisualization.Name = "progressVisualization";
            this.progressVisualization.Size = new System.Drawing.Size(493, 10);
            this.progressVisualization.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.progressVisualization.TabIndex = 7;
            this.progressVisualization.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "s";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Increment by";
            // 
            // incPercent
            // 
            this.incPercent.Location = new System.Drawing.Point(94, 85);
            this.incPercent.Name = "incPercent";
            this.incPercent.Size = new System.Drawing.Size(35, 20);
            this.incPercent.TabIndex = 1;
            this.incPercent.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "%";
            // 
            // progressPositionLabel
            // 
            this.progressPositionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressPositionLabel.Location = new System.Drawing.Point(25, 62);
            this.progressPositionLabel.Name = "progressPositionLabel";
            this.progressPositionLabel.Size = new System.Drawing.Size(493, 13);
            this.progressPositionLabel.TabIndex = 12;
            this.progressPositionLabel.Text = "total: 0%, position: 0s";
            this.progressPositionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // randomButton
            // 
            this.randomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.randomButton.Location = new System.Drawing.Point(119, 165);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(60, 23);
            this.randomButton.TabIndex = 7;
            this.randomButton.Text = "&Random";
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // repeatButton
            // 
            this.repeatButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.repeatButton.Enabled = false;
            this.repeatButton.Location = new System.Drawing.Point(185, 165);
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(60, 23);
            this.repeatButton.TabIndex = 8;
            this.repeatButton.Text = "R&epeat";
            this.repeatButton.UseVisualStyleBackColor = true;
            this.repeatButton.Click += new System.EventHandler(this.repeatButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(459, 165);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(57, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OKClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(378, 165);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelClick);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.Location = new System.Drawing.Point(251, 165);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(60, 23);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearAll);
            // 
            // ProgressTuner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 208);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.repeatButton);
            this.Controls.Add(this.randomButton);
            this.Controls.Add(this.progressPositionLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.incPercent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressVisualization);
            this.Controls.Add(this.previousKeyFrameButton);
            this.Controls.Add(this.nextKeyFrameButton);
            this.Controls.Add(this.deleteKeyFrame);
            this.Controls.Add(this.addKeyFrame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalTimeText);
            this.Controls.Add(this.progressTrackBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(443, 221);
            this.Name = "ProgressTuner";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Progress tuner - Test mode";
            ((System.ComponentModel.ISupportInitialize)(this.progressTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressVisualization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addKeyFrame;
        private System.Windows.Forms.Button deleteKeyFrame;
        private System.Windows.Forms.Button nextKeyFrameButton;
        private System.Windows.Forms.Button previousKeyFrameButton;
        private System.Windows.Forms.PictureBox progressVisualization;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox incPercent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label progressPositionLabel;
        private System.Windows.Forms.Button randomButton;
        private System.Windows.Forms.Button repeatButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        internal System.Windows.Forms.TrackBar progressTrackBar;
        internal System.Windows.Forms.TextBox totalTimeText;
        private System.Windows.Forms.Button clearButton;
    }
}
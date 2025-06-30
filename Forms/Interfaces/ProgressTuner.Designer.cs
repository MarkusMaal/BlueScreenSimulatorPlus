
using MaterialSkin.Controls;

namespace UltimateBlueScreenSimulator
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
            this.progressTrackBar = new MaterialSkin.Controls.MaterialSlider();
            this.totalTimeText = new MaterialSkin.Controls.MaterialTextBox();
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.addKeyFrame = new MaterialSkin.Controls.MaterialButton();
            this.deleteKeyFrame = new MaterialSkin.Controls.MaterialButton();
            this.nextKeyFrameButton = new MaterialSkin.Controls.MaterialButton();
            this.previousKeyFrameButton = new MaterialSkin.Controls.MaterialButton();
            this.progressVisualization = new System.Windows.Forms.PictureBox();
            this.label2 = new MaterialSkin.Controls.MaterialLabel();
            this.label3 = new MaterialSkin.Controls.MaterialLabel();
            this.incPercent = new MaterialSkin.Controls.MaterialTextBox();
            this.label4 = new MaterialSkin.Controls.MaterialLabel();
            this.progressPositionLabel = new MaterialSkin.Controls.MaterialLabel();
            this.randomButton = new MaterialSkin.Controls.MaterialButton();
            this.repeatButton = new MaterialSkin.Controls.MaterialButton();
            this.okButton = new MaterialSkin.Controls.MaterialButton();
            this.cancelButton = new MaterialSkin.Controls.MaterialButton();
            this.clearButton = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.progressVisualization)).BeginInit();
            this.SuspendLayout();
            // 
            // progressTrackBar
            // 
            this.progressTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressTrackBar.Depth = 0;
            this.progressTrackBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.progressTrackBar.Location = new System.Drawing.Point(-3, 51);
            this.progressTrackBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.progressTrackBar.Name = "progressTrackBar";
            this.progressTrackBar.ShowText = false;
            this.progressTrackBar.ShowValue = false;
            this.progressTrackBar.Size = new System.Drawing.Size(715, 40);
            this.progressTrackBar.TabIndex = 0;
            this.progressTrackBar.Text = "My Data";
            this.progressTrackBar.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.progressTrackBar_Scroll);
            // 
            // totalTimeText
            // 
            this.totalTimeText.AnimateReadOnly = false;
            this.totalTimeText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalTimeText.Depth = 0;
            this.totalTimeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.totalTimeText.LeadingIcon = null;
            this.totalTimeText.Location = new System.Drawing.Point(97, 159);
            this.totalTimeText.MaxLength = 50;
            this.totalTimeText.MouseState = MaterialSkin.MouseState.OUT;
            this.totalTimeText.Multiline = false;
            this.totalTimeText.Name = "totalTimeText";
            this.totalTimeText.Size = new System.Drawing.Size(65, 36);
            this.totalTimeText.TabIndex = 2;
            this.totalTimeText.Text = "10.0";
            this.totalTimeText.TrailingIcon = null;
            this.totalTimeText.UseTallSize = false;
            this.totalTimeText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(14, 169);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total time:";
            // 
            // addKeyFrame
            // 
            this.addKeyFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addKeyFrame.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addKeyFrame.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.addKeyFrame.Depth = 0;
            this.addKeyFrame.HighEmphasis = true;
            this.addKeyFrame.Icon = null;
            this.addKeyFrame.Location = new System.Drawing.Point(614, 122);
            this.addKeyFrame.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addKeyFrame.MouseState = MaterialSkin.MouseState.HOVER;
            this.addKeyFrame.Name = "addKeyFrame";
            this.addKeyFrame.NoAccentTextColor = System.Drawing.Color.Empty;
            this.addKeyFrame.Size = new System.Drawing.Size(78, 36);
            this.addKeyFrame.TabIndex = 4;
            this.addKeyFrame.Text = "&Set KF";
            this.addKeyFrame.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.addKeyFrame.UseAccentColor = false;
            this.addKeyFrame.UseVisualStyleBackColor = true;
            this.addKeyFrame.Click += new System.EventHandler(this.AddKeyFrame_Click);
            // 
            // deleteKeyFrame
            // 
            this.deleteKeyFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteKeyFrame.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteKeyFrame.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.deleteKeyFrame.Depth = 0;
            this.deleteKeyFrame.HighEmphasis = true;
            this.deleteKeyFrame.Icon = null;
            this.deleteKeyFrame.Location = new System.Drawing.Point(501, 122);
            this.deleteKeyFrame.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.deleteKeyFrame.MouseState = MaterialSkin.MouseState.HOVER;
            this.deleteKeyFrame.Name = "deleteKeyFrame";
            this.deleteKeyFrame.NoAccentTextColor = System.Drawing.Color.Empty;
            this.deleteKeyFrame.Size = new System.Drawing.Size(104, 36);
            this.deleteKeyFrame.TabIndex = 3;
            this.deleteKeyFrame.Text = "&Delete KF";
            this.deleteKeyFrame.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.deleteKeyFrame.UseAccentColor = false;
            this.deleteKeyFrame.UseVisualStyleBackColor = true;
            this.deleteKeyFrame.Click += new System.EventHandler(this.deleteKeyFrame_Click);
            // 
            // nextKeyFrameButton
            // 
            this.nextKeyFrameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextKeyFrameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nextKeyFrameButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.nextKeyFrameButton.Depth = 0;
            this.nextKeyFrameButton.HighEmphasis = true;
            this.nextKeyFrameButton.Icon = null;
            this.nextKeyFrameButton.Location = new System.Drawing.Point(83, 212);
            this.nextKeyFrameButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.nextKeyFrameButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.nextKeyFrameButton.Name = "nextKeyFrameButton";
            this.nextKeyFrameButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.nextKeyFrameButton.Size = new System.Drawing.Size(64, 36);
            this.nextKeyFrameButton.TabIndex = 6;
            this.nextKeyFrameButton.Text = "KF&+";
            this.nextKeyFrameButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.nextKeyFrameButton.UseAccentColor = false;
            this.nextKeyFrameButton.UseVisualStyleBackColor = true;
            this.nextKeyFrameButton.Click += new System.EventHandler(this.nextKeyFrameButton_Click);
            // 
            // previousKeyFrameButton
            // 
            this.previousKeyFrameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previousKeyFrameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.previousKeyFrameButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.previousKeyFrameButton.Depth = 0;
            this.previousKeyFrameButton.HighEmphasis = true;
            this.previousKeyFrameButton.Icon = null;
            this.previousKeyFrameButton.Location = new System.Drawing.Point(14, 212);
            this.previousKeyFrameButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.previousKeyFrameButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.previousKeyFrameButton.Name = "previousKeyFrameButton";
            this.previousKeyFrameButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.previousKeyFrameButton.Size = new System.Drawing.Size(64, 36);
            this.previousKeyFrameButton.TabIndex = 5;
            this.previousKeyFrameButton.Text = "&-KF";
            this.previousKeyFrameButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.previousKeyFrameButton.UseAccentColor = false;
            this.previousKeyFrameButton.UseVisualStyleBackColor = true;
            this.previousKeyFrameButton.Click += new System.EventHandler(this.previousKeyFrameButton_Click);
            // 
            // progressVisualization
            // 
            this.progressVisualization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressVisualization.Location = new System.Drawing.Point(17, 42);
            this.progressVisualization.Name = "progressVisualization";
            this.progressVisualization.Size = new System.Drawing.Size(674, 10);
            this.progressVisualization.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.progressVisualization.TabIndex = 7;
            this.progressVisualization.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Depth = 0;
            this.label2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(168, 169);
            this.label2.MouseState = MaterialSkin.MouseState.HOVER;
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "s";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Depth = 0;
            this.label3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(14, 124);
            this.label3.MouseState = MaterialSkin.MouseState.HOVER;
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Increment by";
            // 
            // incPercent
            // 
            this.incPercent.AnimateReadOnly = false;
            this.incPercent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.incPercent.Depth = 0;
            this.incPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.incPercent.LeadingIcon = null;
            this.incPercent.Location = new System.Drawing.Point(112, 117);
            this.incPercent.MaxLength = 50;
            this.incPercent.MouseState = MaterialSkin.MouseState.OUT;
            this.incPercent.Multiline = false;
            this.incPercent.Name = "incPercent";
            this.incPercent.Size = new System.Drawing.Size(50, 36);
            this.incPercent.TabIndex = 1;
            this.incPercent.Text = "0";
            this.incPercent.TrailingIcon = null;
            this.incPercent.UseTallSize = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Depth = 0;
            this.label4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.Location = new System.Drawing.Point(168, 124);
            this.label4.MouseState = MaterialSkin.MouseState.HOVER;
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "%";
            // 
            // progressPositionLabel
            // 
            this.progressPositionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressPositionLabel.Depth = 0;
            this.progressPositionLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.progressPositionLabel.Location = new System.Drawing.Point(19, 92);
            this.progressPositionLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.progressPositionLabel.Name = "progressPositionLabel";
            this.progressPositionLabel.Size = new System.Drawing.Size(675, 19);
            this.progressPositionLabel.TabIndex = 12;
            this.progressPositionLabel.Text = "total: 0%, position: 0s";
            this.progressPositionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // randomButton
            // 
            this.randomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.randomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.randomButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.randomButton.Depth = 0;
            this.randomButton.HighEmphasis = true;
            this.randomButton.Icon = null;
            this.randomButton.Location = new System.Drawing.Point(152, 212);
            this.randomButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.randomButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.randomButton.Name = "randomButton";
            this.randomButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.randomButton.Size = new System.Drawing.Size(93, 36);
            this.randomButton.TabIndex = 7;
            this.randomButton.Text = "&Random";
            this.randomButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.randomButton.UseAccentColor = false;
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // repeatButton
            // 
            this.repeatButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.repeatButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.repeatButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.repeatButton.Depth = 0;
            this.repeatButton.Enabled = false;
            this.repeatButton.HighEmphasis = true;
            this.repeatButton.Icon = null;
            this.repeatButton.Location = new System.Drawing.Point(254, 212);
            this.repeatButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.repeatButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.repeatButton.Size = new System.Drawing.Size(85, 36);
            this.repeatButton.TabIndex = 8;
            this.repeatButton.Text = "R&epeat";
            this.repeatButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.repeatButton.UseAccentColor = false;
            this.repeatButton.UseVisualStyleBackColor = true;
            this.repeatButton.Click += new System.EventHandler(this.repeatButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.okButton.Depth = 0;
            this.okButton.HighEmphasis = true;
            this.okButton.Icon = null;
            this.okButton.Location = new System.Drawing.Point(627, 212);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.okButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.okButton.Name = "okButton";
            this.okButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.okButton.Size = new System.Drawing.Size(64, 36);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "&OK";
            this.okButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.okButton.UseAccentColor = false;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OKClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.cancelButton.Depth = 0;
            this.cancelButton.HighEmphasis = true;
            this.cancelButton.Icon = null;
            this.cancelButton.Location = new System.Drawing.Point(532, 212);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.cancelButton.Size = new System.Drawing.Size(87, 36);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.cancelButton.UseAccentColor = false;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelClick);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clearButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.clearButton.Depth = 0;
            this.clearButton.HighEmphasis = true;
            this.clearButton.Icon = null;
            this.clearButton.Location = new System.Drawing.Point(347, 212);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.clearButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.clearButton.Name = "clearButton";
            this.clearButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.clearButton.Size = new System.Drawing.Size(66, 36);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "Clear";
            this.clearButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.clearButton.UseAccentColor = false;
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearAll);
            // 
            // ProgressTuner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 260);
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
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 260);
            this.Name = "ProgressTuner";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Progress tuner - Test mode";
            this.Load += new System.EventHandler(this.ProgressTuner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.progressVisualization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialLabel label1;
        private MaterialButton addKeyFrame;
        private MaterialButton deleteKeyFrame;
        private MaterialButton nextKeyFrameButton;
        private MaterialButton previousKeyFrameButton;
        private System.Windows.Forms.PictureBox progressVisualization;
        private MaterialLabel label2;
        private MaterialLabel label3;
        private MaterialTextBox incPercent;
        private MaterialLabel label4;
        private MaterialLabel progressPositionLabel;
        private MaterialButton randomButton;
        private MaterialButton repeatButton;
        private MaterialButton okButton;
        private MaterialButton cancelButton;
        internal MaterialSlider progressTrackBar;
        internal MaterialTextBox totalTimeText;
        private MaterialButton clearButton;
    }
}
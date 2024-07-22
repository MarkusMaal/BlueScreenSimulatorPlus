namespace UltimateBlueScreenSimulator.Forms.Interfaces
{
    partial class ErrorCodeEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorCodeEditor));
            this.chooseCode1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.chooseCode2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.chooseCode3 = new MaterialSkin.Controls.MaterialRadioButton();
            this.chooseCode4 = new MaterialSkin.Controls.MaterialRadioButton();
            this.codeListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.codeContent = new MaterialSkin.Controls.MaterialTextBox();
            this.topLabel = new MaterialSkin.Controls.MaterialLabel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton4 = new MaterialSkin.Controls.MaterialButton();
            this.codeListPanel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chooseCode1
            // 
            this.chooseCode1.AutoSize = true;
            this.chooseCode1.Checked = true;
            this.chooseCode1.Depth = 0;
            this.chooseCode1.Location = new System.Drawing.Point(0, 0);
            this.chooseCode1.Margin = new System.Windows.Forms.Padding(0);
            this.chooseCode1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chooseCode1.MouseState = MaterialSkin.MouseState.HOVER;
            this.chooseCode1.Name = "chooseCode1";
            this.chooseCode1.Ripple = true;
            this.chooseCode1.Size = new System.Drawing.Size(84, 37);
            this.chooseCode1.TabIndex = 0;
            this.chooseCode1.TabStop = true;
            this.chooseCode1.Text = "Code 1";
            this.chooseCode1.UseVisualStyleBackColor = true;
            this.chooseCode1.CheckedChanged += new System.EventHandler(this.SwitchCode1);
            // 
            // chooseCode2
            // 
            this.chooseCode2.AutoSize = true;
            this.chooseCode2.Depth = 0;
            this.chooseCode2.Location = new System.Drawing.Point(84, 0);
            this.chooseCode2.Margin = new System.Windows.Forms.Padding(0);
            this.chooseCode2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chooseCode2.MouseState = MaterialSkin.MouseState.HOVER;
            this.chooseCode2.Name = "chooseCode2";
            this.chooseCode2.Ripple = true;
            this.chooseCode2.Size = new System.Drawing.Size(84, 37);
            this.chooseCode2.TabIndex = 0;
            this.chooseCode2.TabStop = true;
            this.chooseCode2.Text = "Code 2";
            this.chooseCode2.UseVisualStyleBackColor = true;
            this.chooseCode2.CheckedChanged += new System.EventHandler(this.SwitchCode2);
            // 
            // chooseCode3
            // 
            this.chooseCode3.AutoSize = true;
            this.chooseCode3.Depth = 0;
            this.chooseCode3.Location = new System.Drawing.Point(168, 0);
            this.chooseCode3.Margin = new System.Windows.Forms.Padding(0);
            this.chooseCode3.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chooseCode3.MouseState = MaterialSkin.MouseState.HOVER;
            this.chooseCode3.Name = "chooseCode3";
            this.chooseCode3.Ripple = true;
            this.chooseCode3.Size = new System.Drawing.Size(84, 37);
            this.chooseCode3.TabIndex = 0;
            this.chooseCode3.TabStop = true;
            this.chooseCode3.Text = "Code 3";
            this.chooseCode3.UseVisualStyleBackColor = true;
            this.chooseCode3.CheckedChanged += new System.EventHandler(this.SwitchCode3);
            // 
            // chooseCode4
            // 
            this.chooseCode4.AutoSize = true;
            this.chooseCode4.Depth = 0;
            this.chooseCode4.Location = new System.Drawing.Point(252, 0);
            this.chooseCode4.Margin = new System.Windows.Forms.Padding(0);
            this.chooseCode4.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chooseCode4.MouseState = MaterialSkin.MouseState.HOVER;
            this.chooseCode4.Name = "chooseCode4";
            this.chooseCode4.Ripple = true;
            this.chooseCode4.Size = new System.Drawing.Size(84, 37);
            this.chooseCode4.TabIndex = 0;
            this.chooseCode4.TabStop = true;
            this.chooseCode4.Text = "Code 4";
            this.chooseCode4.UseVisualStyleBackColor = true;
            this.chooseCode4.CheckedChanged += new System.EventHandler(this.SwitchCode4);
            // 
            // codeListPanel
            // 
            this.codeListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeListPanel.AutoSize = true;
            this.codeListPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.codeListPanel.Controls.Add(this.chooseCode1);
            this.codeListPanel.Controls.Add(this.chooseCode2);
            this.codeListPanel.Controls.Add(this.chooseCode3);
            this.codeListPanel.Controls.Add(this.chooseCode4);
            this.codeListPanel.Location = new System.Drawing.Point(6, 144);
            this.codeListPanel.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.codeListPanel.Name = "codeListPanel";
            this.codeListPanel.Size = new System.Drawing.Size(336, 37);
            this.codeListPanel.TabIndex = 1;
            // 
            // codeContent
            // 
            this.codeContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeContent.AnimateReadOnly = false;
            this.codeContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeContent.Depth = 0;
            this.codeContent.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.codeContent.LeadingIcon = null;
            this.codeContent.Location = new System.Drawing.Point(23, 218);
            this.codeContent.Margin = new System.Windows.Forms.Padding(20, 20, 3, 3);
            this.codeContent.MaxLength = 50;
            this.codeContent.MouseState = MaterialSkin.MouseState.OUT;
            this.codeContent.Multiline = false;
            this.codeContent.Name = "codeContent";
            this.codeContent.Size = new System.Drawing.Size(710, 50);
            this.codeContent.TabIndex = 2;
            this.codeContent.Text = "";
            this.codeContent.TrailingIcon = global::UltimateBlueScreenSimulator.Properties.Resources.success;
            this.codeContent.TextChanged += new System.EventHandler(this.codeContent_TextChanged);
            // 
            // topLabel
            // 
            this.topLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topLabel.Depth = 0;
            this.topLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.topLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            this.topLabel.Location = new System.Drawing.Point(13, 74);
            this.topLabel.Margin = new System.Windows.Forms.Padding(10, 10, 10, 40);
            this.topLabel.MinimumSize = new System.Drawing.Size(0, 60);
            this.topLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(720, 70);
            this.topLabel.TabIndex = 3;
            this.topLabel.Text = "The following error code method will be used:\r\n\r\n0xRRRRRRRRRRRRRRRR, 0xRRRRRRRRRR" +
    "RRRRRR, 0xRRRRRRRRRRRRRRRR, 0xRRRRRRRRRRRRRRRR";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.materialButton2);
            this.flowLayoutPanel3.Controls.Add(this.materialButton3);
            this.flowLayoutPanel3.Controls.Add(this.materialButton1);
            this.flowLayoutPanel3.Controls.Add(this.materialButton4);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(23, 320);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(20, 20, 3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(710, 48);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(581, 6);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(125, 36);
            this.materialButton2.TabIndex = 5;
            this.materialButton2.Text = "Random code";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(470, 6);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(103, 36);
            this.materialButton3.TabIndex = 6;
            this.materialButton3.Text = "Calculate";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            this.materialButton3.Click += new System.EventHandler(this.materialButton3_Click);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(363, 6);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(99, 36);
            this.materialButton1.TabIndex = 0;
            this.materialButton1.Text = "Null code";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // materialButton4
            // 
            this.materialButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton4.Depth = 0;
            this.materialButton4.HighEmphasis = true;
            this.materialButton4.Icon = null;
            this.materialButton4.Location = new System.Drawing.Point(236, 6);
            this.materialButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton4.Size = new System.Drawing.Size(119, 36);
            this.materialButton4.TabIndex = 5;
            this.materialButton4.Text = "Apply to all";
            this.materialButton4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton4.UseAccentColor = false;
            this.materialButton4.UseVisualStyleBackColor = true;
            this.materialButton4.Click += new System.EventHandler(this.materialButton4_Click);
            // 
            // ErrorCodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 380);
            this.Controls.Add(this.topLabel);
            this.Controls.Add(this.codeListPanel);
            this.Controls.Add(this.codeContent);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(380, 380);
            this.Name = "ErrorCodeEditor";
            this.Text = "Error code editor";
            this.Load += new System.EventHandler(this.ErrorCodeEditor_Load);
            this.codeListPanel.ResumeLayout(false);
            this.codeListPanel.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRadioButton chooseCode1;
        private MaterialSkin.Controls.MaterialRadioButton chooseCode2;
        private MaterialSkin.Controls.MaterialRadioButton chooseCode3;
        private MaterialSkin.Controls.MaterialRadioButton chooseCode4;
        private System.Windows.Forms.FlowLayoutPanel codeListPanel;
        private MaterialSkin.Controls.MaterialTextBox codeContent;
        private MaterialSkin.Controls.MaterialLabel topLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialButton materialButton4;
    }
}
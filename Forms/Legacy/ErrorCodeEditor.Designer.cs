namespace UltimateBlueScreenSimulator.Forms.Legacy
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
            this.chooseCode1 = new System.Windows.Forms.RadioButton();
            this.chooseCode2 = new System.Windows.Forms.RadioButton();
            this.chooseCode3 = new System.Windows.Forms.RadioButton();
            this.chooseCode4 = new System.Windows.Forms.RadioButton();
            this.codeListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.codeContent = new System.Windows.Forms.TextBox();
            this.topLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.materialButton2 = new System.Windows.Forms.Button();
            this.materialButton3 = new System.Windows.Forms.Button();
            this.materialButton1 = new System.Windows.Forms.Button();
            this.materialButton4 = new System.Windows.Forms.Button();
            this.codeListPanel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chooseCode1
            // 
            this.chooseCode1.AutoSize = true;
            this.chooseCode1.Checked = true;
            this.chooseCode1.Location = new System.Drawing.Point(0, 0);
            this.chooseCode1.Margin = new System.Windows.Forms.Padding(0);
            this.chooseCode1.Name = "chooseCode1";
            this.chooseCode1.Size = new System.Drawing.Size(59, 17);
            this.chooseCode1.TabIndex = 0;
            this.chooseCode1.TabStop = true;
            this.chooseCode1.Text = "Code 1";
            this.chooseCode1.UseVisualStyleBackColor = true;
            this.chooseCode1.CheckedChanged += new System.EventHandler(this.SwitchCode1);
            // 
            // chooseCode2
            // 
            this.chooseCode2.AutoSize = true;
            this.chooseCode2.Location = new System.Drawing.Point(59, 0);
            this.chooseCode2.Margin = new System.Windows.Forms.Padding(0);
            this.chooseCode2.Name = "chooseCode2";
            this.chooseCode2.Size = new System.Drawing.Size(59, 17);
            this.chooseCode2.TabIndex = 0;
            this.chooseCode2.TabStop = true;
            this.chooseCode2.Text = "Code 2";
            this.chooseCode2.UseVisualStyleBackColor = true;
            this.chooseCode2.CheckedChanged += new System.EventHandler(this.SwitchCode2);
            // 
            // chooseCode3
            // 
            this.chooseCode3.AutoSize = true;
            this.chooseCode3.Location = new System.Drawing.Point(118, 0);
            this.chooseCode3.Margin = new System.Windows.Forms.Padding(0);
            this.chooseCode3.Name = "chooseCode3";
            this.chooseCode3.Size = new System.Drawing.Size(59, 17);
            this.chooseCode3.TabIndex = 0;
            this.chooseCode3.TabStop = true;
            this.chooseCode3.Text = "Code 3";
            this.chooseCode3.UseVisualStyleBackColor = true;
            this.chooseCode3.CheckedChanged += new System.EventHandler(this.SwitchCode3);
            // 
            // chooseCode4
            // 
            this.chooseCode4.AutoSize = true;
            this.chooseCode4.Location = new System.Drawing.Point(177, 0);
            this.chooseCode4.Margin = new System.Windows.Forms.Padding(0);
            this.chooseCode4.Name = "chooseCode4";
            this.chooseCode4.Size = new System.Drawing.Size(59, 17);
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
            this.codeListPanel.Location = new System.Drawing.Point(10, 65);
            this.codeListPanel.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.codeListPanel.Name = "codeListPanel";
            this.codeListPanel.Size = new System.Drawing.Size(236, 17);
            this.codeListPanel.TabIndex = 1;
            // 
            // codeContent
            // 
            this.codeContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codeContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.codeContent.Location = new System.Drawing.Point(8, 93);
            this.codeContent.Margin = new System.Windows.Forms.Padding(20, 20, 3, 3);
            this.codeContent.MaxLength = 50;
            this.codeContent.Name = "codeContent";
            this.codeContent.Size = new System.Drawing.Size(729, 26);
            this.codeContent.TabIndex = 2;
            this.codeContent.TextChanged += new System.EventHandler(this.CodeContent_TextChanged);
            // 
            // topLabel
            // 
            this.topLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.topLabel.Location = new System.Drawing.Point(9, 9);
            this.topLabel.Margin = new System.Windows.Forms.Padding(10, 10, 10, 40);
            this.topLabel.MinimumSize = new System.Drawing.Size(0, 50);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(736, 50);
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
            this.flowLayoutPanel3.Location = new System.Drawing.Point(23, 151);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(20, 20, 3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(716, 38);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Location = new System.Drawing.Point(619, 6);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.Size = new System.Drawing.Size(93, 26);
            this.materialButton2.TabIndex = 5;
            this.materialButton2.Text = "Random code";
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.MaterialButton2_Click);
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Location = new System.Drawing.Point(534, 6);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.Size = new System.Drawing.Size(77, 26);
            this.materialButton3.TabIndex = 6;
            this.materialButton3.Text = "Calculate";
            this.materialButton3.UseVisualStyleBackColor = true;
            this.materialButton3.Click += new System.EventHandler(this.MaterialButton3_Click);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Location = new System.Drawing.Point(451, 6);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.Size = new System.Drawing.Size(75, 26);
            this.materialButton1.TabIndex = 0;
            this.materialButton1.Text = "Null code";
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.MaterialButton1_Click);
            // 
            // materialButton4
            // 
            this.materialButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton4.Location = new System.Drawing.Point(356, 6);
            this.materialButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.Size = new System.Drawing.Size(87, 26);
            this.materialButton4.TabIndex = 5;
            this.materialButton4.Text = "Apply to all";
            this.materialButton4.UseVisualStyleBackColor = true;
            this.materialButton4.Click += new System.EventHandler(this.MaterialButton4_Click);
            // 
            // ErrorCodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 201);
            this.Controls.Add(this.topLabel);
            this.Controls.Add(this.codeListPanel);
            this.Controls.Add(this.codeContent);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(768, 240);
            this.Name = "ErrorCodeEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error code editor";
            this.Load += new System.EventHandler(this.ErrorCodeEditor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ErrorCodeEditor_KeyDown);
            this.codeListPanel.ResumeLayout(false);
            this.codeListPanel.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton chooseCode1;
        private System.Windows.Forms.RadioButton chooseCode2;
        private System.Windows.Forms.RadioButton chooseCode3;
        private System.Windows.Forms.RadioButton chooseCode4;
        private System.Windows.Forms.FlowLayoutPanel codeListPanel;
        private System.Windows.Forms.TextBox codeContent;
        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button materialButton2;
        private System.Windows.Forms.Button materialButton1;
        private System.Windows.Forms.Button materialButton3;
        private System.Windows.Forms.Button materialButton4;
    }
}
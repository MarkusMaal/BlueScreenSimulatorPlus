namespace UltimateBlueScreenSimulator.Forms.Interfaces
{
    partial class NTdtor
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "example.sys",
            "RRRRRRRR;RRRRRRRR"}, -1);
            MaterialSkin.MaterialListBoxItem materialListBoxItem1 = new MaterialSkin.MaterialListBoxItem();
            MaterialSkin.MaterialListBoxItem materialListBoxItem2 = new MaterialSkin.MaterialListBoxItem();
            MaterialSkin.MaterialListBoxItem materialListBoxItem3 = new MaterialSkin.MaterialListBoxItem();
            this.codefilesList = new MaterialSkin.Controls.MaterialListView();
            this.fileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.codeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.delCodeButton = new MaterialSkin.Controls.MaterialButton();
            this.randCodesList = new MaterialSkin.Controls.MaterialListBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.codeBox = new MaterialSkin.Controls.MaterialTextBox();
            this.filenameBox = new MaterialSkin.Controls.MaterialTextBox();
            this.browseButton = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.delEntryButton = new MaterialSkin.Controls.MaterialButton();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton5 = new MaterialSkin.Controls.MaterialButton();
            this.fixedButton = new MaterialSkin.Controls.MaterialButton();
            this.fixedRandomButton = new MaterialSkin.Controls.MaterialButton();
            this.randomButton = new MaterialSkin.Controls.MaterialButton();
            this.zeroButton = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codefilesList
            // 
            this.codefilesList.AutoSizeTable = false;
            this.codefilesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.codefilesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codefilesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileColumn,
            this.codeColumn});
            this.codefilesList.Depth = 0;
            this.codefilesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codefilesList.FullRowSelect = true;
            this.codefilesList.HideSelection = false;
            this.codefilesList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.codefilesList.Location = new System.Drawing.Point(0, 0);
            this.codefilesList.MinimumSize = new System.Drawing.Size(200, 100);
            this.codefilesList.MouseLocation = new System.Drawing.Point(-1, -1);
            this.codefilesList.MouseState = MaterialSkin.MouseState.OUT;
            this.codefilesList.Name = "codefilesList";
            this.codefilesList.OwnerDraw = true;
            this.codefilesList.Size = new System.Drawing.Size(432, 440);
            this.codefilesList.TabIndex = 0;
            this.codefilesList.UseCompatibleStateImageBehavior = false;
            this.codefilesList.View = System.Windows.Forms.View.Details;
            this.codefilesList.SelectedIndexChanged += new System.EventHandler(this.codefilesList_SelectedIndexChanged);
            this.codefilesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codefilesList_KeyDown);
            this.codefilesList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.codefilesList_MouseClick);
            // 
            // fileColumn
            // 
            this.fileColumn.Text = "Filename";
            this.fileColumn.Width = 150;
            // 
            // codeColumn
            // 
            this.codeColumn.Text = "Codes";
            this.codeColumn.Width = 263;
            // 
            // delCodeButton
            // 
            this.delCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delCodeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delCodeButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.delCodeButton.Depth = 0;
            this.delCodeButton.Enabled = false;
            this.delCodeButton.HighEmphasis = true;
            this.delCodeButton.Icon = null;
            this.delCodeButton.Location = new System.Drawing.Point(271, 6);
            this.delCodeButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.delCodeButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.delCodeButton.Name = "delCodeButton";
            this.delCodeButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.delCodeButton.Size = new System.Drawing.Size(115, 36);
            this.delCodeButton.TabIndex = 2;
            this.delCodeButton.Text = "Delete code";
            this.delCodeButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.delCodeButton.UseAccentColor = false;
            this.delCodeButton.UseVisualStyleBackColor = true;
            this.delCodeButton.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // randCodesList
            // 
            this.randCodesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.randCodesList.BackColor = System.Drawing.Color.White;
            this.randCodesList.BorderColor = System.Drawing.Color.LightGray;
            this.randCodesList.Depth = 0;
            this.randCodesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialListBoxItem1.SecondaryText = "Code 1";
            materialListBoxItem1.Tag = null;
            materialListBoxItem1.Text = "RRRRRRRR";
            materialListBoxItem2.SecondaryText = "Code 2";
            materialListBoxItem2.Tag = null;
            materialListBoxItem2.Text = "RRRRRRRR";
            materialListBoxItem3.SecondaryText = "Code 3";
            materialListBoxItem3.Tag = null;
            materialListBoxItem3.Text = "RRRRRRRR";
            this.randCodesList.Items.Add(materialListBoxItem1);
            this.randCodesList.Items.Add(materialListBoxItem2);
            this.randCodesList.Items.Add(materialListBoxItem3);
            this.randCodesList.Location = new System.Drawing.Point(9, 144);
            this.randCodesList.MouseState = MaterialSkin.MouseState.HOVER;
            this.randCodesList.MultiSelect = true;
            this.randCodesList.Name = "randCodesList";
            this.randCodesList.SelectedIndex = -1;
            this.randCodesList.SelectedItem = null;
            this.randCodesList.Size = new System.Drawing.Size(521, 180);
            this.randCodesList.Style = MaterialSkin.Controls.MaterialListBox.ListBoxStyle.TwoLine;
            this.randCodesList.TabIndex = 3;
            this.randCodesList.SelectedIndexChanged += new MaterialSkin.Controls.MaterialListBox.SelectedIndexChangedEventHandler(this.randCodesList_SelectedIndexChanged);
            this.randCodesList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.randCodesList_MouseClick);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(9, 80);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(45, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Codes";
            // 
            // codeBox
            // 
            this.codeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeBox.AnimateReadOnly = false;
            this.codeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeBox.Depth = 0;
            this.codeBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.codeBox.LeadingIcon = null;
            this.codeBox.Location = new System.Drawing.Point(9, 102);
            this.codeBox.MaxLength = 8;
            this.codeBox.MouseState = MaterialSkin.MouseState.OUT;
            this.codeBox.Multiline = false;
            this.codeBox.Name = "codeBox";
            this.codeBox.Size = new System.Drawing.Size(236, 36);
            this.codeBox.TabIndex = 4;
            this.codeBox.Text = "";
            this.codeBox.TrailingIcon = null;
            this.codeBox.UseTallSize = false;
            this.codeBox.TextChanged += new System.EventHandler(this.codeBox_TextChanged);
            // 
            // filenameBox
            // 
            this.filenameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameBox.AnimateReadOnly = false;
            this.filenameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filenameBox.Depth = 0;
            this.filenameBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.filenameBox.LeadingIcon = null;
            this.filenameBox.Location = new System.Drawing.Point(9, 31);
            this.filenameBox.MaxLength = 50;
            this.filenameBox.MouseState = MaterialSkin.MouseState.OUT;
            this.filenameBox.Multiline = false;
            this.filenameBox.Name = "filenameBox";
            this.filenameBox.Size = new System.Drawing.Size(451, 36);
            this.filenameBox.TabIndex = 4;
            this.filenameBox.Text = "";
            this.filenameBox.TrailingIcon = null;
            this.filenameBox.UseTallSize = false;
            this.filenameBox.TextChanged += new System.EventHandler(this.filenameBox_TextChanged);
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.browseButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.browseButton.Depth = 0;
            this.browseButton.HighEmphasis = true;
            this.browseButton.Icon = null;
            this.browseButton.Location = new System.Drawing.Point(467, 31);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.browseButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.browseButton.Name = "browseButton";
            this.browseButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.browseButton.Size = new System.Drawing.Size(64, 36);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "..";
            this.browseButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.browseButton.UseAccentColor = false;
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(9, 9);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(66, 19);
            this.materialLabel3.TabIndex = 1;
            this.materialLabel3.Text = "Filename";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 64);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.codefilesList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.materialLabel3);
            this.splitContainer1.Panel2.Controls.Add(this.filenameBox);
            this.splitContainer1.Panel2.Controls.Add(this.codeBox);
            this.splitContainer1.Panel2.Controls.Add(this.materialLabel2);
            this.splitContainer1.Panel2.Controls.Add(this.randCodesList);
            this.splitContainer1.Panel2.Controls.Add(this.fixedButton);
            this.splitContainer1.Panel2.Controls.Add(this.fixedRandomButton);
            this.splitContainer1.Panel2.Controls.Add(this.randomButton);
            this.splitContainer1.Panel2.Controls.Add(this.zeroButton);
            this.splitContainer1.Panel2.Controls.Add(this.browseButton);
            this.splitContainer1.Size = new System.Drawing.Size(976, 440);
            this.splitContainer1.SplitterDistance = 432;
            this.splitContainer1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.delEntryButton);
            this.flowLayoutPanel1.Controls.Add(this.delCodeButton);
            this.flowLayoutPanel1.Controls.Add(this.materialButton3);
            this.flowLayoutPanel1.Controls.Add(this.materialButton5);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 373);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(521, 67);
            this.flowLayoutPanel1.TabIndex = 5;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // delEntryButton
            // 
            this.delEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delEntryButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delEntryButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.delEntryButton.Depth = 0;
            this.delEntryButton.Enabled = false;
            this.delEntryButton.HighEmphasis = true;
            this.delEntryButton.Icon = null;
            this.delEntryButton.Location = new System.Drawing.Point(394, 6);
            this.delEntryButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.delEntryButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.delEntryButton.Name = "delEntryButton";
            this.delEntryButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.delEntryButton.Size = new System.Drawing.Size(123, 36);
            this.delEntryButton.TabIndex = 2;
            this.delEntryButton.Text = "Delete entry";
            this.delEntryButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.delEntryButton.UseAccentColor = false;
            this.delEntryButton.UseVisualStyleBackColor = true;
            this.delEntryButton.Click += new System.EventHandler(this.materialButton4_Click);
            // 
            // materialButton3
            // 
            this.materialButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(171, 6);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(92, 36);
            this.materialButton3.TabIndex = 2;
            this.materialButton3.Text = "Add code";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            this.materialButton3.Click += new System.EventHandler(this.materialButton3_Click);
            // 
            // materialButton5
            // 
            this.materialButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton5.Depth = 0;
            this.materialButton5.HighEmphasis = true;
            this.materialButton5.Icon = null;
            this.materialButton5.Location = new System.Drawing.Point(7, 6);
            this.materialButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton5.Name = "materialButton5";
            this.materialButton5.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton5.Size = new System.Drawing.Size(156, 36);
            this.materialButton5.TabIndex = 2;
            this.materialButton5.Text = "Add file \\w codes";
            this.materialButton5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton5.UseAccentColor = false;
            this.materialButton5.UseVisualStyleBackColor = true;
            this.materialButton5.Click += new System.EventHandler(this.materialButton5_Click);
            // 
            // fixedButton
            // 
            this.fixedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fixedButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fixedButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.fixedButton.Depth = 0;
            this.fixedButton.HighEmphasis = true;
            this.fixedButton.Icon = null;
            this.fixedButton.Location = new System.Drawing.Point(252, 102);
            this.fixedButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.fixedButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.fixedButton.Name = "fixedButton";
            this.fixedButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.fixedButton.Size = new System.Drawing.Size(64, 36);
            this.fixedButton.TabIndex = 2;
            this.fixedButton.Text = "F";
            this.fixedButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.fixedButton.UseAccentColor = false;
            this.fixedButton.UseVisualStyleBackColor = true;
            this.fixedButton.Click += new System.EventHandler(this.fixedButton_Click);
            // 
            // fixedRandomButton
            // 
            this.fixedRandomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fixedRandomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fixedRandomButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.fixedRandomButton.Depth = 0;
            this.fixedRandomButton.HighEmphasis = true;
            this.fixedRandomButton.Icon = null;
            this.fixedRandomButton.Location = new System.Drawing.Point(324, 102);
            this.fixedRandomButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.fixedRandomButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.fixedRandomButton.Name = "fixedRandomButton";
            this.fixedRandomButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.fixedRandomButton.Size = new System.Drawing.Size(64, 36);
            this.fixedRandomButton.TabIndex = 2;
            this.fixedRandomButton.Text = "Gen";
            this.fixedRandomButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.fixedRandomButton.UseAccentColor = false;
            this.fixedRandomButton.UseVisualStyleBackColor = true;
            this.fixedRandomButton.Click += new System.EventHandler(this.fixedRandomButton_Click);
            // 
            // randomButton
            // 
            this.randomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.randomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.randomButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.randomButton.Depth = 0;
            this.randomButton.HighEmphasis = true;
            this.randomButton.Icon = null;
            this.randomButton.Location = new System.Drawing.Point(396, 102);
            this.randomButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.randomButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.randomButton.Name = "randomButton";
            this.randomButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.randomButton.Size = new System.Drawing.Size(64, 36);
            this.randomButton.TabIndex = 2;
            this.randomButton.Text = "R";
            this.randomButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.randomButton.UseAccentColor = false;
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // zeroButton
            // 
            this.zeroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zeroButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zeroButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.zeroButton.Depth = 0;
            this.zeroButton.HighEmphasis = true;
            this.zeroButton.Icon = null;
            this.zeroButton.Location = new System.Drawing.Point(466, 102);
            this.zeroButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.zeroButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.zeroButton.Size = new System.Drawing.Size(64, 36);
            this.zeroButton.TabIndex = 2;
            this.zeroButton.Text = "0";
            this.zeroButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.zeroButton.UseAccentColor = false;
            this.zeroButton.UseVisualStyleBackColor = true;
            this.zeroButton.Click += new System.EventHandler(this.zeroButton_Click);
            // 
            // NTdtor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 507);
            this.Controls.Add(this.splitContainer1);
            this.Name = "NTdtor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Windows NT code editor";
            this.Load += new System.EventHandler(this.NTdtor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialListView codefilesList;
        private System.Windows.Forms.ColumnHeader fileColumn;
        private System.Windows.Forms.ColumnHeader codeColumn;
        private MaterialSkin.Controls.MaterialButton delCodeButton;
        private MaterialSkin.Controls.MaterialListBox randCodesList;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox codeBox;
        private MaterialSkin.Controls.MaterialTextBox filenameBox;
        private MaterialSkin.Controls.MaterialButton browseButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialButton delEntryButton;
        private MaterialSkin.Controls.MaterialButton materialButton5;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialButton fixedRandomButton;
        private MaterialSkin.Controls.MaterialButton randomButton;
        private MaterialSkin.Controls.MaterialButton zeroButton;
        private MaterialSkin.Controls.MaterialButton fixedButton;
    }
}
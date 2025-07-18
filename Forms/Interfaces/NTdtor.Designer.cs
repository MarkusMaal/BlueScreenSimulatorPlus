﻿namespace UltimateBlueScreenSimulator.Forms.Interfaces
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "example.sys",
            "RRRRRRRR;RRRRRRRR"}, -1);
            MaterialSkin2Framework.MaterialListBoxItem materialListBoxItem4 = new MaterialSkin2Framework.MaterialListBoxItem();
            MaterialSkin2Framework.MaterialListBoxItem materialListBoxItem5 = new MaterialSkin2Framework.MaterialListBoxItem();
            MaterialSkin2Framework.MaterialListBoxItem materialListBoxItem6 = new MaterialSkin2Framework.MaterialListBoxItem();
            this.codefilesList = new MaterialSkin2Framework.Controls.MaterialListView();
            this.fileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.codeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.delCodeButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.randCodesList = new MaterialSkin2Framework.Controls.MaterialListBox();
            this.materialLabel2 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.codeBox = new MaterialSkin2Framework.Controls.MaterialTextBox2();
            this.filenameBox = new MaterialSkin2Framework.Controls.MaterialTextBox2();
            this.browseButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.materialLabel3 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.activeModeLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.delEntryButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.materialButton3 = new MaterialSkin2Framework.Controls.MaterialButton();
            this.materialButton5 = new MaterialSkin2Framework.Controls.MaterialButton();
            this.fixedButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.fixedRandomButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.randomButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.zeroButton = new MaterialSkin2Framework.Controls.MaterialButton();
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
            listViewItem2});
            this.codefilesList.Location = new System.Drawing.Point(0, 0);
            this.codefilesList.MinimumSize = new System.Drawing.Size(200, 100);
            this.codefilesList.MouseLocation = new System.Drawing.Point(-1, -1);
            this.codefilesList.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.codefilesList.Name = "codefilesList";
            this.codefilesList.OwnerDraw = true;
            this.codefilesList.Size = new System.Drawing.Size(432, 440);
            this.codefilesList.TabIndex = 0;
            this.codefilesList.UseCompatibleStateImageBehavior = false;
            this.codefilesList.View = System.Windows.Forms.View.Details;
            this.codefilesList.SelectedIndexChanged += new System.EventHandler(this.CodefilesList_SelectedIndexChanged);
            this.codefilesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodefilesList_KeyDown);
            this.codefilesList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CodefilesList_MouseClick);
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
            this.delCodeButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.delCodeButton.Depth = 0;
            this.delCodeButton.Enabled = false;
            this.delCodeButton.HighEmphasis = true;
            this.delCodeButton.Icon = null;
            this.delCodeButton.Location = new System.Drawing.Point(271, 6);
            this.delCodeButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.delCodeButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.delCodeButton.Name = "delCodeButton";
            this.delCodeButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.delCodeButton.Size = new System.Drawing.Size(115, 36);
            this.delCodeButton.TabIndex = 11;
            this.delCodeButton.Text = "Delete code";
            this.delCodeButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.delCodeButton.UseAccentColor = false;
            this.delCodeButton.UseVisualStyleBackColor = true;
            this.delCodeButton.Click += new System.EventHandler(this.MaterialButton2_Click);
            this.delCodeButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTdtor_KeyDown);
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
            materialListBoxItem4.SecondaryText = "Code 1";
            materialListBoxItem4.Tag = null;
            materialListBoxItem4.Text = "RRRRRRRR";
            materialListBoxItem5.SecondaryText = "Code 2";
            materialListBoxItem5.Tag = null;
            materialListBoxItem5.Text = "RRRRRRRR";
            materialListBoxItem6.SecondaryText = "Code 3";
            materialListBoxItem6.Tag = null;
            materialListBoxItem6.Text = "RRRRRRRR";
            this.randCodesList.Items.Add(materialListBoxItem4);
            this.randCodesList.Items.Add(materialListBoxItem5);
            this.randCodesList.Items.Add(materialListBoxItem6);
            this.randCodesList.Location = new System.Drawing.Point(9, 144);
            this.randCodesList.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.randCodesList.MultiSelect = true;
            this.randCodesList.Name = "randCodesList";
            this.randCodesList.SelectedIndex = -1;
            this.randCodesList.SelectedItem = null;
            this.randCodesList.Size = new System.Drawing.Size(521, 180);
            this.randCodesList.Style = MaterialSkin2Framework.Controls.MaterialListBox.ListBoxStyle.TwoLine;
            this.randCodesList.TabIndex = 8;
            this.randCodesList.SelectedIndexChanged += new MaterialSkin2Framework.Controls.MaterialListBox.SelectedIndexChangedEventHandler(this.RandCodesList_SelectedIndexChanged);
            this.randCodesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTdtor_KeyDown);
            this.randCodesList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RandCodesList_MouseClick);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(9, 80);
            this.materialLabel2.MouseState = MaterialSkin2Framework.MouseState.HOVER;
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
            this.codeBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.codeBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.codeBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.codeBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.codeBox.Depth = 0;
            this.codeBox.Enabled = false;
            this.codeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.codeBox.HideSelection = true;
            this.codeBox.LeadingIcon = null;
            this.codeBox.Location = new System.Drawing.Point(9, 102);
            this.codeBox.MaxLength = 8;
            this.codeBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.codeBox.Name = "codeBox";
            this.codeBox.PasswordChar = '\0';
            this.codeBox.PrefixSuffixText = null;
            this.codeBox.ReadOnly = false;
            this.codeBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.codeBox.SelectedText = "";
            this.codeBox.SelectionLength = 0;
            this.codeBox.SelectionStart = 0;
            this.codeBox.ShortcutsEnabled = true;
            this.codeBox.Size = new System.Drawing.Size(236, 36);
            this.codeBox.TabIndex = 3;
            this.codeBox.TabStop = false;
            this.codeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.codeBox.TrailingIcon = null;
            this.codeBox.UseSystemPasswordChar = false;
            this.codeBox.UseTallSize = false;
            this.codeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTdtor_KeyDown);
            this.codeBox.TextChanged += new System.EventHandler(this.CodeBox_TextChanged);
            // 
            // filenameBox
            // 
            this.filenameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameBox.AnimateReadOnly = false;
            this.filenameBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.filenameBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.filenameBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.filenameBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.filenameBox.Depth = 0;
            this.filenameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.filenameBox.HideSelection = true;
            this.filenameBox.LeadingIcon = null;
            this.filenameBox.Location = new System.Drawing.Point(9, 31);
            this.filenameBox.MaxLength = 50;
            this.filenameBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.filenameBox.Name = "filenameBox";
            this.filenameBox.PasswordChar = '\0';
            this.filenameBox.PrefixSuffixText = null;
            this.filenameBox.ReadOnly = false;
            this.filenameBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.filenameBox.SelectedText = "";
            this.filenameBox.SelectionLength = 0;
            this.filenameBox.SelectionStart = 0;
            this.filenameBox.ShortcutsEnabled = true;
            this.filenameBox.Size = new System.Drawing.Size(451, 36);
            this.filenameBox.TabIndex = 1;
            this.filenameBox.TabStop = false;
            this.filenameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.filenameBox.TrailingIcon = null;
            this.filenameBox.UseSystemPasswordChar = false;
            this.filenameBox.UseTallSize = false;
            this.filenameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTdtor_KeyDown);
            this.filenameBox.TextChanged += new System.EventHandler(this.FilenameBox_TextChanged);
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.browseButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.browseButton.Depth = 0;
            this.browseButton.HighEmphasis = true;
            this.browseButton.Icon = null;
            this.browseButton.Location = new System.Drawing.Point(467, 31);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.browseButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.browseButton.Name = "browseButton";
            this.browseButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.browseButton.Size = new System.Drawing.Size(64, 36);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "..";
            this.browseButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.browseButton.UseAccentColor = false;
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            this.browseButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTdtor_KeyDown);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(9, 9);
            this.materialLabel3.MouseState = MaterialSkin2Framework.MouseState.HOVER;
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
            this.splitContainer1.Panel2.Controls.Add(this.activeModeLabel);
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
            // activeModeLabel
            // 
            this.activeModeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activeModeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.activeModeLabel.Depth = 0;
            this.activeModeLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.activeModeLabel.Location = new System.Drawing.Point(9, 350);
            this.activeModeLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.activeModeLabel.Name = "activeModeLabel";
            this.activeModeLabel.Size = new System.Drawing.Size(522, 23);
            this.activeModeLabel.TabIndex = 6;
            this.activeModeLabel.Text = "Insert mode (click to toggle)";
            this.activeModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.activeModeLabel.Click += new System.EventHandler(this.activeModeLabel_Click);
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
            this.flowLayoutPanel1.TabIndex = 9;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // delEntryButton
            // 
            this.delEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delEntryButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delEntryButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.delEntryButton.Depth = 0;
            this.delEntryButton.Enabled = false;
            this.delEntryButton.HighEmphasis = true;
            this.delEntryButton.Icon = null;
            this.delEntryButton.Location = new System.Drawing.Point(394, 6);
            this.delEntryButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.delEntryButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.delEntryButton.Name = "delEntryButton";
            this.delEntryButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.delEntryButton.Size = new System.Drawing.Size(123, 36);
            this.delEntryButton.TabIndex = 12;
            this.delEntryButton.Text = "Delete entry";
            this.delEntryButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.delEntryButton.UseAccentColor = false;
            this.delEntryButton.UseVisualStyleBackColor = true;
            this.delEntryButton.Click += new System.EventHandler(this.MaterialButton4_Click);
            this.delEntryButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTdtor_KeyDown);
            // 
            // materialButton3
            // 
            this.materialButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(171, 6);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(92, 36);
            this.materialButton3.TabIndex = 10;
            this.materialButton3.Text = "Add code";
            this.materialButton3.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            this.materialButton3.Click += new System.EventHandler(this.MaterialButton3_Click);
            this.materialButton3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTdtor_KeyDown);
            // 
            // materialButton5
            // 
            this.materialButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton5.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton5.Depth = 0;
            this.materialButton5.HighEmphasis = true;
            this.materialButton5.Icon = null;
            this.materialButton5.Location = new System.Drawing.Point(7, 6);
            this.materialButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton5.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialButton5.Name = "materialButton5";
            this.materialButton5.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton5.Size = new System.Drawing.Size(156, 36);
            this.materialButton5.TabIndex = 9;
            this.materialButton5.Text = "Add file \\w codes";
            this.materialButton5.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton5.UseAccentColor = false;
            this.materialButton5.UseVisualStyleBackColor = true;
            this.materialButton5.Click += new System.EventHandler(this.MaterialButton5_Click);
            this.materialButton5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTdtor_KeyDown);
            // 
            // fixedButton
            // 
            this.fixedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fixedButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fixedButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.fixedButton.Depth = 0;
            this.fixedButton.Enabled = false;
            this.fixedButton.HighEmphasis = true;
            this.fixedButton.Icon = null;
            this.fixedButton.Location = new System.Drawing.Point(252, 102);
            this.fixedButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.fixedButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.fixedButton.Name = "fixedButton";
            this.fixedButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.fixedButton.Size = new System.Drawing.Size(64, 36);
            this.fixedButton.TabIndex = 4;
            this.fixedButton.Text = "F";
            this.fixedButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.fixedButton.UseAccentColor = false;
            this.fixedButton.UseVisualStyleBackColor = true;
            this.fixedButton.Click += new System.EventHandler(this.FixedButton_Click);
            this.fixedButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTdtor_KeyDown);
            // 
            // fixedRandomButton
            // 
            this.fixedRandomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fixedRandomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fixedRandomButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.fixedRandomButton.Depth = 0;
            this.fixedRandomButton.Enabled = false;
            this.fixedRandomButton.HighEmphasis = true;
            this.fixedRandomButton.Icon = null;
            this.fixedRandomButton.Location = new System.Drawing.Point(324, 102);
            this.fixedRandomButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.fixedRandomButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.fixedRandomButton.Name = "fixedRandomButton";
            this.fixedRandomButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.fixedRandomButton.Size = new System.Drawing.Size(64, 36);
            this.fixedRandomButton.TabIndex = 5;
            this.fixedRandomButton.Text = "Gen";
            this.fixedRandomButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.fixedRandomButton.UseAccentColor = false;
            this.fixedRandomButton.UseVisualStyleBackColor = true;
            this.fixedRandomButton.Click += new System.EventHandler(this.FixedRandomButton_Click);
            this.fixedRandomButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTdtor_KeyDown);
            // 
            // randomButton
            // 
            this.randomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.randomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.randomButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.randomButton.Depth = 0;
            this.randomButton.Enabled = false;
            this.randomButton.HighEmphasis = true;
            this.randomButton.Icon = null;
            this.randomButton.Location = new System.Drawing.Point(396, 102);
            this.randomButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.randomButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.randomButton.Name = "randomButton";
            this.randomButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.randomButton.Size = new System.Drawing.Size(64, 36);
            this.randomButton.TabIndex = 6;
            this.randomButton.Text = "R";
            this.randomButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.randomButton.UseAccentColor = false;
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.RandomButton_Click);
            this.randomButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTdtor_KeyDown);
            // 
            // zeroButton
            // 
            this.zeroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zeroButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zeroButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.zeroButton.Depth = 0;
            this.zeroButton.Enabled = false;
            this.zeroButton.HighEmphasis = true;
            this.zeroButton.Icon = null;
            this.zeroButton.Location = new System.Drawing.Point(466, 102);
            this.zeroButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.zeroButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.zeroButton.Size = new System.Drawing.Size(64, 36);
            this.zeroButton.TabIndex = 7;
            this.zeroButton.Text = "0";
            this.zeroButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.zeroButton.UseAccentColor = false;
            this.zeroButton.UseVisualStyleBackColor = true;
            this.zeroButton.Click += new System.EventHandler(this.ZeroButton_Click);
            this.zeroButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTdtor_KeyDown);
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTdtor_KeyDown);
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

        private MaterialSkin2Framework.Controls.MaterialListView codefilesList;
        private System.Windows.Forms.ColumnHeader fileColumn;
        private System.Windows.Forms.ColumnHeader codeColumn;
        private MaterialSkin2Framework.Controls.MaterialButton delCodeButton;
        private MaterialSkin2Framework.Controls.MaterialListBox randCodesList;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel2;
        private MaterialSkin2Framework.Controls.MaterialTextBox2 codeBox;
        private MaterialSkin2Framework.Controls.MaterialTextBox2 filenameBox;
        private MaterialSkin2Framework.Controls.MaterialButton browseButton;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin2Framework.Controls.MaterialButton delEntryButton;
        private MaterialSkin2Framework.Controls.MaterialButton materialButton5;
        private MaterialSkin2Framework.Controls.MaterialButton materialButton3;
        private MaterialSkin2Framework.Controls.MaterialButton fixedRandomButton;
        private MaterialSkin2Framework.Controls.MaterialButton randomButton;
        private MaterialSkin2Framework.Controls.MaterialButton zeroButton;
        private MaterialSkin2Framework.Controls.MaterialButton fixedButton;
        private MaterialSkin2Framework.Controls.MaterialLabel activeModeLabel;
    }
}
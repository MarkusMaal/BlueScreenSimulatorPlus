using System.Windows.Controls;

namespace UltimateBlueScreenSimulator.Forms.Legacy
{

    partial class IndexForm
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
            "Example",
            "RRRRRRRR"}, -1);
            this.delCodeButton = new System.Windows.Forms.Button();
            this.randCodesList = new System.Windows.Forms.ListBox();
            this.materialLabel2 = new System.Windows.Forms.Label();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.filenameBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.materialLabel3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.codefilesList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.delEntryButton = new System.Windows.Forms.Button();
            this.materialButton3 = new System.Windows.Forms.Button();
            this.materialButton5 = new System.Windows.Forms.Button();
            this.fixedButton = new System.Windows.Forms.Button();
            this.fixedRandomButton = new System.Windows.Forms.Button();
            this.randomButton = new System.Windows.Forms.Button();
            this.zeroButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // delCodeButton
            // 
            this.delCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delCodeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delCodeButton.Enabled = false;
            this.delCodeButton.Location = new System.Drawing.Point(334, 6);
            this.delCodeButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.delCodeButton.Name = "delCodeButton";
            this.delCodeButton.Size = new System.Drawing.Size(88, 26);
            this.delCodeButton.TabIndex = 2;
            this.delCodeButton.Text = "Delete code";
            this.delCodeButton.UseVisualStyleBackColor = true;
            this.delCodeButton.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // randCodesList
            // 
            this.randCodesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.randCodesList.BackColor = System.Drawing.Color.White;
            this.randCodesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.randCodesList.ItemHeight = 20;
            this.randCodesList.Items.AddRange(new object[] {
            "RRRRRRRR",
            "RRRRRRRR",
            "RRRRRRRR"});
            this.randCodesList.Location = new System.Drawing.Point(12, 100);
            this.randCodesList.Name = "randCodesList";
            this.randCodesList.Size = new System.Drawing.Size(525, 224);
            this.randCodesList.TabIndex = 3;
            this.randCodesList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.randCodesList_MouseClick);
            this.randCodesList.SelectedIndexChanged += new System.EventHandler(this.randCodesList_SelectedIndexChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(9, 53);
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(48, 17);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Codes";
            // 
            // codeBox
            // 
            this.codeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.codeBox.Location = new System.Drawing.Point(9, 75);
            this.codeBox.MaxLength = 8;
            this.codeBox.Name = "codeBox";
            this.codeBox.Size = new System.Drawing.Size(240, 19);
            this.codeBox.TabIndex = 4;
            this.codeBox.TextChanged += new System.EventHandler(this.codeBox_TextChanged);
            // 
            // filenameBox
            // 
            this.filenameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filenameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.filenameBox.Location = new System.Drawing.Point(9, 31);
            this.filenameBox.MaxLength = 50;
            this.filenameBox.Name = "filenameBox";
            this.filenameBox.Size = new System.Drawing.Size(455, 19);
            this.filenameBox.TabIndex = 4;
            this.filenameBox.TextChanged += new System.EventHandler(this.filenameBox_TextChanged);
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.browseButton.Location = new System.Drawing.Point(470, 31);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(64, 22);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "..";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(9, 9);
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(65, 17);
            this.materialLabel3.TabIndex = 1;
            this.materialLabel3.Text = "Filename";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Size = new System.Drawing.Size(982, 507);
            this.splitContainer1.SplitterDistance = 434;
            this.splitContainer1.TabIndex = 5;
            // 
            // codefilesList
            // 
            this.codefilesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.codefilesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codefilesList.FullRowSelect = true;
            this.codefilesList.GridLines = true;
            this.codefilesList.HideSelection = false;
            this.codefilesList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.codefilesList.Location = new System.Drawing.Point(0, 0);
            this.codefilesList.Name = "codefilesList";
            this.codefilesList.Size = new System.Drawing.Size(434, 507);
            this.codefilesList.TabIndex = 0;
            this.codefilesList.UseCompatibleStateImageBehavior = false;
            this.codefilesList.View = System.Windows.Forms.View.Details;
            this.codefilesList.SelectedIndexChanged += new System.EventHandler(this.codefilesList_SelectedIndexChanged);
            this.codefilesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codefilesList_KeyDown);
            this.codefilesList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.codefilesList_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Filename";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Error codes";
            this.columnHeader2.Width = 300;
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 327);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(525, 180);
            this.flowLayoutPanel1.TabIndex = 5;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // delEntryButton
            // 
            this.delEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delEntryButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delEntryButton.Location = new System.Drawing.Point(430, 6);
            this.delEntryButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.delEntryButton.Name = "delEntryButton";
            this.delEntryButton.Size = new System.Drawing.Size(91, 26);
            this.delEntryButton.TabIndex = 2;
            this.delEntryButton.Text = "Delete entry";
            this.delEntryButton.UseVisualStyleBackColor = true;
            this.delEntryButton.Click += new System.EventHandler(this.materialButton4_Click);
            // 
            // materialButton3
            // 
            this.materialButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Location = new System.Drawing.Point(234, 6);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.Size = new System.Drawing.Size(92, 26);
            this.materialButton3.TabIndex = 2;
            this.materialButton3.Text = "Add code";
            this.materialButton3.UseVisualStyleBackColor = true;
            this.materialButton3.Click += new System.EventHandler(this.materialButton3_Click);
            // 
            // materialButton5
            // 
            this.materialButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton5.Location = new System.Drawing.Point(114, 6);
            this.materialButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton5.Name = "materialButton5";
            this.materialButton5.Size = new System.Drawing.Size(112, 26);
            this.materialButton5.TabIndex = 2;
            this.materialButton5.Text = "Add file \\w codes";
            this.materialButton5.UseVisualStyleBackColor = true;
            this.materialButton5.Click += new System.EventHandler(this.materialButton5_Click);
            // 
            // fixedButton
            // 
            this.fixedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fixedButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fixedButton.Location = new System.Drawing.Point(256, 72);
            this.fixedButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.fixedButton.Name = "fixedButton";
            this.fixedButton.Size = new System.Drawing.Size(64, 25);
            this.fixedButton.TabIndex = 2;
            this.fixedButton.Text = "F";
            this.fixedButton.UseVisualStyleBackColor = true;
            this.fixedButton.Click += new System.EventHandler(this.fixedButton_Click);
            // 
            // fixedRandomButton
            // 
            this.fixedRandomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fixedRandomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fixedRandomButton.Location = new System.Drawing.Point(328, 72);
            this.fixedRandomButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.fixedRandomButton.Name = "fixedRandomButton";
            this.fixedRandomButton.Size = new System.Drawing.Size(64, 25);
            this.fixedRandomButton.TabIndex = 2;
            this.fixedRandomButton.Text = "Gen";
            this.fixedRandomButton.UseVisualStyleBackColor = true;
            this.fixedRandomButton.Click += new System.EventHandler(this.fixedRandomButton_Click);
            // 
            // randomButton
            // 
            this.randomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.randomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.randomButton.Location = new System.Drawing.Point(400, 72);
            this.randomButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(64, 25);
            this.randomButton.TabIndex = 2;
            this.randomButton.Text = "R";
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // zeroButton
            // 
            this.zeroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zeroButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zeroButton.Location = new System.Drawing.Point(471, 72);
            this.zeroButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Size = new System.Drawing.Size(64, 25);
            this.zeroButton.TabIndex = 2;
            this.zeroButton.Text = "0";
            this.zeroButton.UseVisualStyleBackColor = true;
            this.zeroButton.Click += new System.EventHandler(this.zeroButton_Click);
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 507);
            this.Controls.Add(this.splitContainer1);
            this.Name = "IndexForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Windows NT code editor";
            this.Load += new System.EventHandler(this.NTdtor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button delCodeButton;
        private System.Windows.Forms.ListBox randCodesList;
        private System.Windows.Forms.Label materialLabel2;
        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.TextBox filenameBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label materialLabel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button delEntryButton;
        private System.Windows.Forms.Button materialButton5;
        private System.Windows.Forms.Button materialButton3;
        private System.Windows.Forms.Button fixedRandomButton;
        private System.Windows.Forms.Button randomButton;
        private System.Windows.Forms.Button zeroButton;
        private System.Windows.Forms.Button fixedButton;
        private System.Windows.Forms.ListView codefilesList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
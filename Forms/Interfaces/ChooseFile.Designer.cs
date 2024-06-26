
namespace UltimateBlueScreenSimulator
{
    partial class ChooseFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseFile));
            this.fileBrowser = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.okButton = new MaterialSkin.Controls.MaterialButton();
            this.customizeFilesButton = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // fileBrowser
            // 
            this.fileBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileBrowser.AutoSizeTable = false;
            this.fileBrowser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fileBrowser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileBrowser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.fileBrowser.Depth = 0;
            this.fileBrowser.FullRowSelect = true;
            this.fileBrowser.HideSelection = false;
            this.fileBrowser.Location = new System.Drawing.Point(3, 64);
            this.fileBrowser.MinimumSize = new System.Drawing.Size(200, 100);
            this.fileBrowser.MouseLocation = new System.Drawing.Point(-1, -1);
            this.fileBrowser.MouseState = MaterialSkin.MouseState.OUT;
            this.fileBrowser.Name = "fileBrowser";
            this.fileBrowser.OwnerDraw = true;
            this.fileBrowser.Size = new System.Drawing.Size(582, 214);
            this.fileBrowser.TabIndex = 1;
            this.fileBrowser.UseCompatibleStateImageBehavior = false;
            this.fileBrowser.View = System.Windows.Forms.View.Details;
            this.fileBrowser.ItemActivate += new System.EventHandler(this.WhenUserSelectsTheDesiredFile);
            this.fileBrowser.SelectedIndexChanged += new System.EventHandler(this.fileBrowser_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Filename";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 456;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.AutoSize = false;
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.okButton.Depth = 0;
            this.okButton.Enabled = false;
            this.okButton.HighEmphasis = true;
            this.okButton.Icon = null;
            this.okButton.Location = new System.Drawing.Point(506, 287);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.okButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.okButton.Name = "okButton";
            this.okButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.okButton.Size = new System.Drawing.Size(75, 24);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.okButton.UseAccentColor = false;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // customizeFilesButton
            // 
            this.customizeFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.customizeFilesButton.AutoSize = false;
            this.customizeFilesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.customizeFilesButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.customizeFilesButton.Depth = 0;
            this.customizeFilesButton.HighEmphasis = true;
            this.customizeFilesButton.Icon = null;
            this.customizeFilesButton.Location = new System.Drawing.Point(398, 287);
            this.customizeFilesButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.customizeFilesButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.customizeFilesButton.Name = "customizeFilesButton";
            this.customizeFilesButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.customizeFilesButton.Size = new System.Drawing.Size(100, 24);
            this.customizeFilesButton.TabIndex = 2;
            this.customizeFilesButton.Text = "Customize";
            this.customizeFilesButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.customizeFilesButton.UseAccentColor = false;
            this.customizeFilesButton.UseVisualStyleBackColor = true;
            this.customizeFilesButton.Click += new System.EventHandler(this.customizeFilesButton_Click);
            // 
            // ChooseFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 320);
            this.Controls.Add(this.customizeFilesButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fileBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChooseFile";
            this.Text = "Choose culprit file";
            this.Load += new System.EventHandler(this.Initialize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        internal MaterialSkin.Controls.MaterialListView fileBrowser;
        private MaterialSkin.Controls.MaterialButton okButton;
        private MaterialSkin.Controls.MaterialButton customizeFilesButton;
    }
}
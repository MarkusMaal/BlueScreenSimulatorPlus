
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
            this.SuspendLayout();
            // 
            // fileBrowser
            // 
            this.fileBrowser.AutoSizeTable = false;
            this.fileBrowser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fileBrowser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileBrowser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.fileBrowser.Depth = 0;
            this.fileBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileBrowser.FullRowSelect = true;
            this.fileBrowser.GridLines = true;
            this.fileBrowser.HideSelection = false;
            this.fileBrowser.Location = new System.Drawing.Point(0, 0);
            this.fileBrowser.MinimumSize = new System.Drawing.Size(200, 100);
            this.fileBrowser.MouseLocation = new System.Drawing.Point(-1, -1);
            this.fileBrowser.MouseState = MaterialSkin.MouseState.OUT;
            this.fileBrowser.Name = "fileBrowser";
            this.fileBrowser.OwnerDraw = true;
            this.fileBrowser.Size = new System.Drawing.Size(588, 320);
            this.fileBrowser.TabIndex = 1;
            this.fileBrowser.UseCompatibleStateImageBehavior = false;
            this.fileBrowser.View = System.Windows.Forms.View.Details;
            this.fileBrowser.ItemActivate += new System.EventHandler(this.WhenUserSelectsTheDesiredFile);
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
            // ChooseFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 320);
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
    }
}
namespace UltimateBlueScreenSimulator.Forms.Interfaces
{
    partial class MessageTableEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageTableEditor));
            this.messageList = new MaterialSkin2Framework.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.removeButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.editButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.textTextBox = new MaterialSkin2Framework.Controls.MaterialTextBox2();
            this.subitemTextBox = new MaterialSkin2Framework.Controls.MaterialTextBox2();
            this.clearButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // messageList
            // 
            this.messageList.AccessibleDescription = "List of messages, which can be edited";
            this.messageList.AccessibleName = "Message list";
            this.messageList.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.messageList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageList.AutoSizeTable = false;
            this.messageList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.messageList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.messageList.Depth = 0;
            this.messageList.FullRowSelect = true;
            this.messageList.HideSelection = false;
            this.messageList.LabelEdit = true;
            this.messageList.Location = new System.Drawing.Point(6, 67);
            this.messageList.MinimumSize = new System.Drawing.Size(200, 100);
            this.messageList.MouseLocation = new System.Drawing.Point(-1, -1);
            this.messageList.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.messageList.Name = "messageList";
            this.messageList.OwnerDraw = true;
            this.messageList.Size = new System.Drawing.Size(824, 342);
            this.messageList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.messageList.TabIndex = 0;
            this.messageList.UseCompatibleStateImageBehavior = false;
            this.messageList.View = System.Windows.Forms.View.Details;
            this.messageList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.materialListView1_AfterLabelEdit);
            this.messageList.SelectedIndexChanged += new System.EventHandler(this.materialListView1_SelectedIndexChanged);
            this.messageList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageList_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Foo";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Bar";
            this.columnHeader2.Width = 300;
            // 
            // addButton
            // 
            this.addButton.AccessibleDescription = "Adds an entry with specified key and value to the list";
            this.addButton.AccessibleName = "Add button";
            this.addButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.addButton.Depth = 0;
            this.addButton.HighEmphasis = true;
            this.addButton.Icon = null;
            this.addButton.Location = new System.Drawing.Point(766, 418);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.addButton.Name = "addButton";
            this.addButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.addButton.Size = new System.Drawing.Size(64, 36);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "&Add";
            this.addButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.addButton.UseAccentColor = false;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // removeButton
            // 
            this.removeButton.AccessibleDescription = "Removes selected entry or entries from the list";
            this.removeButton.AccessibleName = "Remove button";
            this.removeButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.removeButton.Depth = 0;
            this.removeButton.Enabled = false;
            this.removeButton.HighEmphasis = true;
            this.removeButton.Icon = null;
            this.removeButton.Location = new System.Drawing.Point(597, 418);
            this.removeButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.removeButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.removeButton.Name = "removeButton";
            this.removeButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.removeButton.Size = new System.Drawing.Size(89, 36);
            this.removeButton.TabIndex = 6;
            this.removeButton.Text = "&Remove";
            this.removeButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.removeButton.UseAccentColor = true;
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // editButton
            // 
            this.editButton.AccessibleDescription = "While having an item selected, clicking this button will cause the entry to chang" +
    "e to the values on textboxes";
            this.editButton.AccessibleName = "Edit button";
            this.editButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.editButton.Depth = 0;
            this.editButton.Enabled = false;
            this.editButton.HighEmphasis = true;
            this.editButton.Icon = null;
            this.editButton.Location = new System.Drawing.Point(694, 418);
            this.editButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.editButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.editButton.Name = "editButton";
            this.editButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.editButton.Size = new System.Drawing.Size(64, 36);
            this.editButton.TabIndex = 5;
            this.editButton.Text = "&Edit";
            this.editButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.editButton.UseAccentColor = false;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // textTextBox
            // 
            this.textTextBox.AccessibleDescription = "Key of selected entry";
            this.textTextBox.AccessibleName = "Key";
            this.textTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.textTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textTextBox.AnimateReadOnly = false;
            this.textTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.textTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textTextBox.Depth = 0;
            this.textTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textTextBox.HelperText = "Item";
            this.textTextBox.HideSelection = true;
            this.textTextBox.LeadingIcon = null;
            this.textTextBox.Location = new System.Drawing.Point(6, 416);
            this.textTextBox.MaxLength = 50;
            this.textTextBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.PasswordChar = '\0';
            this.textTextBox.PrefixSuffixText = null;
            this.textTextBox.ReadOnly = false;
            this.textTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textTextBox.SelectedText = "";
            this.textTextBox.SelectionLength = 0;
            this.textTextBox.SelectionStart = 0;
            this.textTextBox.ShortcutsEnabled = true;
            this.textTextBox.ShowAssistiveText = true;
            this.textTextBox.Size = new System.Drawing.Size(188, 52);
            this.textTextBox.TabIndex = 2;
            this.textTextBox.TabStop = false;
            this.textTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textTextBox.TrailingIcon = null;
            this.textTextBox.UseSystemPasswordChar = false;
            this.textTextBox.UseTallSize = false;
            // 
            // subitemTextBox
            // 
            this.subitemTextBox.AccessibleDescription = "Value of selected entry";
            this.subitemTextBox.AccessibleName = "Value";
            this.subitemTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.subitemTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.subitemTextBox.AnimateReadOnly = false;
            this.subitemTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.subitemTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.subitemTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.subitemTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.subitemTextBox.Depth = 0;
            this.subitemTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.subitemTextBox.HelperText = "Subitem";
            this.subitemTextBox.HideSelection = true;
            this.subitemTextBox.LeadingIcon = null;
            this.subitemTextBox.Location = new System.Drawing.Point(201, 416);
            this.subitemTextBox.MaxLength = 50;
            this.subitemTextBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.subitemTextBox.Name = "subitemTextBox";
            this.subitemTextBox.PasswordChar = '\0';
            this.subitemTextBox.PrefixSuffixText = null;
            this.subitemTextBox.ReadOnly = false;
            this.subitemTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.subitemTextBox.SelectedText = "";
            this.subitemTextBox.SelectionLength = 0;
            this.subitemTextBox.SelectionStart = 0;
            this.subitemTextBox.ShortcutsEnabled = true;
            this.subitemTextBox.ShowAssistiveText = true;
            this.subitemTextBox.Size = new System.Drawing.Size(248, 52);
            this.subitemTextBox.TabIndex = 3;
            this.subitemTextBox.TabStop = false;
            this.subitemTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.subitemTextBox.TrailingIcon = null;
            this.subitemTextBox.UseSystemPasswordChar = false;
            this.subitemTextBox.UseTallSize = false;
            // 
            // clearButton
            // 
            this.clearButton.AccessibleDescription = "Deletes all entries from message list";
            this.clearButton.AccessibleName = "Clear";
            this.clearButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clearButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.clearButton.Depth = 0;
            this.clearButton.HighEmphasis = true;
            this.clearButton.Icon = null;
            this.clearButton.Location = new System.Drawing.Point(514, 418);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.clearButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.clearButton.Name = "clearButton";
            this.clearButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.clearButton.Size = new System.Drawing.Size(75, 36);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "&Clear";
            this.clearButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.clearButton.UseAccentColor = true;
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // MessageTableEditor
            // 
            this.AccessibleDescription = "Allows you to edit messages used by this program";
            this.AccessibleName = "Message table editor";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 474);
            this.Controls.Add(this.subitemTextBox);
            this.Controls.Add(this.textTextBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.messageList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 220);
            this.Name = "MessageTableEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message table editor";
            this.Load += new System.EventHandler(this.MessageTableEditor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageTableEditor_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin2Framework.Controls.MaterialListView messageList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private MaterialSkin2Framework.Controls.MaterialButton addButton;
        private MaterialSkin2Framework.Controls.MaterialButton removeButton;
        private MaterialSkin2Framework.Controls.MaterialButton editButton;
        private MaterialSkin2Framework.Controls.MaterialTextBox2 textTextBox;
        private MaterialSkin2Framework.Controls.MaterialTextBox2 subitemTextBox;
        private MaterialSkin2Framework.Controls.MaterialButton clearButton;
    }
}
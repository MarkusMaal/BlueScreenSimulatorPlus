namespace UltimateBlueScreenSimulator.Forms.Legacy
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "test",
            "aaaa"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageTableEditor));
            this.messageList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.subitemTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
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
            this.messageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.messageList.FullRowSelect = true;
            this.messageList.HideSelection = false;
            this.messageList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.messageList.LabelEdit = true;
            this.messageList.Location = new System.Drawing.Point(6, 12);
            this.messageList.MinimumSize = new System.Drawing.Size(200, 100);
            this.messageList.Name = "messageList";
            this.messageList.Size = new System.Drawing.Size(824, 370);
            this.messageList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.messageList.TabIndex = 0;
            this.messageList.UseCompatibleStateImageBehavior = false;
            this.messageList.View = System.Windows.Forms.View.Details;
            this.messageList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.MaterialListView1_AfterLabelEdit);
            this.messageList.SelectedIndexChanged += new System.EventHandler(this.MaterialListView1_SelectedIndexChanged);
            this.messageList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageList_KeyDown);
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
            this.addButton.Location = new System.Drawing.Point(765, 386);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(64, 28);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "&Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.MaterialButton1_Click);
            // 
            // removeButton
            // 
            this.removeButton.AccessibleDescription = "Removes selected entry or entries from the list";
            this.removeButton.AccessibleName = "Remove button";
            this.removeButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(668, 386);
            this.removeButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(89, 28);
            this.removeButton.TabIndex = 6;
            this.removeButton.Text = "&Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.MaterialButton2_Click);
            // 
            // editButton
            // 
            this.editButton.AccessibleDescription = "While having an item selected, clicking this button will cause the entry to chang" +
    "e to the values on textboxes";
            this.editButton.AccessibleName = "Edit button";
            this.editButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(596, 386);
            this.editButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(64, 28);
            this.editButton.TabIndex = 5;
            this.editButton.Text = "&Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // textTextBox
            // 
            this.textTextBox.AccessibleDescription = "Key of selected entry";
            this.textTextBox.AccessibleName = "Key";
            this.textTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.textTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textTextBox.Location = new System.Drawing.Point(6, 388);
            this.textTextBox.MaxLength = 50;
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(188, 26);
            this.textTextBox.TabIndex = 2;
            // 
            // subitemTextBox
            // 
            this.subitemTextBox.AccessibleDescription = "Value of selected entry";
            this.subitemTextBox.AccessibleName = "Value";
            this.subitemTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.subitemTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.subitemTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.subitemTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.subitemTextBox.Location = new System.Drawing.Point(201, 388);
            this.subitemTextBox.MaxLength = 50;
            this.subitemTextBox.Name = "subitemTextBox";
            this.subitemTextBox.Size = new System.Drawing.Size(248, 26);
            this.subitemTextBox.TabIndex = 3;
            // 
            // clearButton
            // 
            this.clearButton.AccessibleDescription = "Deletes all entries from message list";
            this.clearButton.AccessibleName = "Clear";
            this.clearButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clearButton.Location = new System.Drawing.Point(513, 386);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 28);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "&Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // MessageTableEditor
            // 
            this.AccessibleDescription = "Allows you to edit messages used by this program";
            this.AccessibleName = "Message table editor";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 420);
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

        private System.Windows.Forms.ListView messageList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.TextBox textTextBox;
        private System.Windows.Forms.TextBox subitemTextBox;
        private System.Windows.Forms.Button clearButton;
    }
}
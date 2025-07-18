﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin2Framework;
using MaterialSkin2Framework.Controls;

namespace UltimateBlueScreenSimulator.Forms.Interfaces
{
    public partial class MessageTableEditor : MaterialForm
    {
        internal bool nt_errors = false;
        internal bool nx_errors = false;
        public MessageTableEditor()
        {
            MaterialSkinManager materialSkinManager = Program.F1.materialSkinManager;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private void MaterialListView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            textTextBox.Text = messageList.SelectedItems[0].Text;
            subitemTextBox.Text = messageList.SelectedItems[0].SubItems[1].Text;
            UpdateTemplate();
        }

        private void UpdateTemplate()
        {
            List<string> errorPairs = new List<string>();
            if (nx_errors)
            {
                Program.gs.Log("Info", "9x error database has been modified");
                foreach (ListViewItem lvi in messageList.Items)
                {
                    errorPairs.Add(lvi.SubItems[0].Text + "\t" + lvi.SubItems[1].Text);
                }
                Program.templates.NxErrors = errorPairs.ToArray();
                Program.ReloadNxErrors();
            }
            else if (nt_errors)
            {
                Program.gs.Log("Info", "NT error database has been modified");
                foreach (ListViewItem lvi in messageList.Items)
                {
                    errorPairs.Add(lvi.SubItems[0].Text + "\t" + lvi.SubItems[1].Text);
                }
                Program.templates.NtErrors = errorPairs.ToArray();
                Program.ReloadNTErrors();
            }
            else
            {
                Program.gs.Log("Info", "List of default culprit files has been modified");
                foreach (ListViewItem lvi in messageList.Items)
                {
                    errorPairs.Add(lvi.SubItems[0].Text + ":" + lvi.SubItems[1].Text);
                }
                Program.templates.CulpritFiles = errorPairs.ToArray();
            }
        }

        private void MessageTableEditor_Load(object sender, EventArgs e)
        {
            if (nt_errors || nx_errors)
            {
                messageList.Columns[0].Text = "Code";
            }
            else
            {
                messageList.Columns[0].Text = "File";
            }
            messageList.Columns[1].Text = "Description";
            foreach (string nt_error in nx_errors ? Program.templates.NxErrors : (nt_errors ? Program.templates.NtErrors : Program.templates.CulpritFiles))
            {
                if (nt_error == "")
                {
                    continue;
                }
                ListViewItem lvi = new ListViewItem
                {
                    Text = nt_error.Split(nt_errors || nx_errors ? '\t' : ':')[0]
                };
                lvi.SubItems.Add(nt_error.Split(nt_errors || nx_errors ? '\t' : ':')[1]);
                messageList.Items.Add(lvi);
            }
        }

        private void MaterialButton1_Click(object sender, EventArgs e)
        {
            messageList.Items.Add(new ListViewItem()
            {
                Text = textTextBox.Text,
                SubItems = {subitemTextBox.Text}
            });
            textTextBox.Text = "";
            subitemTextBox.Text = "";
            messageList.SelectedIndices.Clear();
            UpdateTemplate();
        }

        private void MaterialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enabled = messageList.SelectedIndices.Count > 0;
            removeButton.Enabled = enabled;
            editButton.Enabled = enabled;
            // textTextBox.Enabled = enabled;
            // subitemTextBox.Enabled = enabled;
            textTextBox.Text = messageList.SelectedIndices.Count == 1 ? messageList.SelectedItems[0].Text : "";
            subitemTextBox.Text = messageList.SelectedIndices.Count == 1 ? messageList.SelectedItems[0].SubItems[1].Text : "";
        }

        private void MaterialButton2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in messageList.SelectedItems)
            {
                messageList.Items.Remove(lvi);
            }
            UpdateTemplate();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            foreach (int i in messageList.SelectedIndices)
            {
                try
                {
                    if (textTextBox.Text != "")
                    {
                        messageList.Items[i].Text = textTextBox.Text;
                    }
                    if (subitemTextBox.Text != "")
                    {
                        messageList.Items[i].SubItems[1].Text = subitemTextBox.Text;
                    }
                } catch
                {
                    Program.gs.Log("Error", "Message table editor: Unable to modify value at index " + i);
                }
            }
            UpdateTemplate();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            messageList.Items.Clear();
            UpdateTemplate();
        }

        private void MessageList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                removeButton.PerformClick();
            }
        }

        private void MessageTableEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}

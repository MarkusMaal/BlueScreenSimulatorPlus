using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator.Forms.Interfaces
{
    public partial class NTdtor : MaterialForm
    {
        bool locked = false;
        internal BlueScreen me;
        private readonly string validChars = "0123456789ABCDEFR";

        public NTdtor()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = Program.f1.materialSkinManager;
            materialSkinManager.AddFormToManage(this);
        }

        private void NTdtor_Load(object sender, EventArgs e)
        {
            this.Text += " - " + me.GetString("friendlyname");
            UpdateCodeList();
        }

        private void UpdateCodeList()
        {
            if (locked) { return; } // to avoid StackOverflowException
            locked = true;
            Array selectedItems = Array.CreateInstance(typeof(int), codefilesList.SelectedIndices.Count);
            codefilesList.SelectedIndices.CopyTo(selectedItems, 0);
            if (me.GetFiles().Count != codefilesList.Items.Count)
            {
                randCodesList.Clear();
                codefilesList.Items.Clear();
                foreach (KeyValuePair<string, string[]> kvp in me.GetFiles())
                {
                    ListViewItem lvi = new ListViewItem(kvp.Key);
                    lvi.SubItems.Add(string.Join(";", kvp.Value));
                    codefilesList.Items.Add(lvi);
                }
            } else
            {
                int i = 0;
                try
                {
                    foreach (KeyValuePair<string, string[]> kvp in me.GetFiles())
                    {
                        if ((codefilesList.Items[i].Text != kvp.Key) || (codefilesList.Items[i].SubItems[1].Text != string.Join(";", kvp.Value)))
                        {
                            ListViewItem lvi = new ListViewItem(kvp.Key);
                            lvi.SubItems.Add(string.Join(";", kvp.Value));
                            codefilesList.Items[i] = lvi;
                        }
                        i++;
                    }
                } catch (Exception e)
                {
                    Program.gs.Log("Error", "Failed to update code list: " + e.Message);
                }
            }
            if (selectedItems.Length != codefilesList.SelectedIndices.Count)
            {
                foreach (int i in selectedItems)
                {
                    if (i < codefilesList.Items.Count)
                    {
                        codefilesList.SelectedIndices.Add(i);
                    }
                }
            }
            if (codefilesList.SelectedIndices.Count > 0)
            {
                UpdateRandList();
            }
            locked = false;
        }

        private void codefilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            delEntryButton.Enabled = codefilesList.SelectedIndices.Count > 0;
            if (codefilesList.SelectedItems.Count == 1)
            {
                KeyValuePair<string, string[]> currentFile = me.GetFile(codefilesList.SelectedIndices[0]);
                if (filenameBox.Text != currentFile.Key)
                {
                    filenameBox.Text = currentFile.Key;
                }
            } else
            {
                randCodesList.Clear();
                if (!filenameBox.Focused)
                {
                    filenameBox.Text = "";
                }
            }
        }

        private void UpdateRandList()
        {
            if (codefilesList.SelectedIndices.Count == 1) // skip updating if nothing is selected
            {
                int bck = randCodesList.SelectedIndex;
                randCodesList.Clear();
                int i = 1;
                foreach (string code in me.GetFile(codefilesList.SelectedIndices[0]).Value)
                {
                    MaterialListBoxItem mlbi = new MaterialListBoxItem(code);
                    mlbi.SecondaryText = $"Code {i}";
                    randCodesList.AddItem(mlbi);
                    i++;
                }
                if (bck != randCodesList.Items.Count)
                {
                    randCodesList.SelectedIndex = bck;
                }
            }
        }

        private void DeleteSelectedEntries()
        {
            ListView.SelectedIndexCollection selectedItems = codefilesList.SelectedIndices;

            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                me.RemoveFile(selectedItems[i]); 
            }
            UpdateCodeList();
        }

        private void codefilesList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedEntries();
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            DeleteSelectedEntries();
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            List<string> codes = new List<string>();
            foreach (MaterialListBoxItem m in randCodesList.Items)
            {
                codes.Add(m.Text);
            }
            me.PushFile(filenameBox.Text, codes.ToArray());
            UpdateCodeList();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            foreach (int idx in codefilesList.SelectedIndices)
            {
                me.PushCode(idx, "RRRRRRRR");
            }
            UpdateCodeList();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            foreach (int idx in codefilesList.SelectedIndices)
            {
                me.RemoveCode(idx, randCodesList.SelectedIndex);
            }
            UpdateCodeList();
        }

        private void randCodesList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                randCodesList.SelectedIndex = -1;
            }
            delCodeButton.Enabled = randCodesList.SelectedIndex != -1;
        }

        private void randCodesList_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {
            if (randCodesList.SelectedIndex != -1)
            {
                codeBox.Text = randCodesList.SelectedItem.Text;
            }
            delCodeButton.Enabled = randCodesList.SelectedIndex != -1;
            
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            ChooseFile cf = new ChooseFile();
            if (cf.ShowDialog() == DialogResult.OK)
            {
                filenameBox.Text = cf.fileBrowser.SelectedItems[0].Text;
            }
        }

        private void codefilesList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                codefilesList.SelectedItems.Clear();
            }
        }

        private void filenameBox_TextChanged(object sender, EventArgs e)
        {
            if ((codefilesList.SelectedItems.Count > 0) && (filenameBox.Text.Length > 0))
            {
                foreach (int idx in codefilesList.SelectedIndices)
                {
                    me.RenameFile(idx, filenameBox.Text);
                }
                UpdateCodeList();
            }
        }

        private bool ValidateString(string str, string chars)
        {
            string newStr = str;
            foreach (char ch in chars)
            {
                newStr = newStr.Replace(ch.ToString(), "");
            }
            return newStr == "";
        }

        private void codeBox_TextChanged(object sender, EventArgs e)
        {
            int bck = randCodesList.SelectedIndex;
            if ((randCodesList.SelectedIndex != -1))
            {
                if ((codeBox.Text.Length == 8) && ValidateString(codeBox.Text, validChars))
                {
                    List<string> codes = new List<string>();
                    foreach (MaterialListBoxItem mlbi in randCodesList.Items)
                    {
                        codes.Add(mlbi.Text);
                    }
                    codes[randCodesList.SelectedIndex] = codeBox.Text;
                    foreach (int i in codefilesList.SelectedIndices)
                    {
                        me.SetFileCodes(i, codes.ToArray());
                    }
                    UpdateCodeList();
                    codeBox.TrailingIcon = Properties.Resources.success;
                } else
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    codeBox.TrailingIcon = Properties.Resources.failure;
                }
            }
            randCodesList.SelectedIndex = bck;
        }

        /// <summary>
        /// Allows for bulk updating file code values
        /// </summary>
        /// <param name="random">Specifies if we should generate fixed codes (generates if true)</param>
        /// <param name="inspir">Template to set the values to, default is "RRRRRRRR"</param>
        private void SetCodeValues(bool random = false, string inspir = "RRRRRRRR")
        {
            foreach (int i in codefilesList.SelectedIndices)
            {
                List<string> fixedCodes = new List<string>();
                foreach (string code in me.GetFile(i).Value)
                {
                    fixedCodes.Add(random ? me.GenHex(8, code) : inspir);
                }
                me.SetFileCodes(i, fixedCodes.ToArray());
            }
            UpdateCodeList();
        }

        private void fixedRandomButton_Click(object sender, EventArgs e)
        {
            if (randCodesList.SelectedItems.Count > 0)
            {
                codeBox.Text = me.GenHex(8, codeBox.Text);
            } else
            {
                SetCodeValues(true);
            }
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            if (randCodesList.SelectedItems.Count > 0)
            {
                codeBox.Text = "RRRRRRRR";
            } else
            {
                SetCodeValues(false);
            }
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            if (randCodesList.SelectedItems.Count > 0)
            {
                codeBox.Text = "00000000";
            } else
            {
                SetCodeValues(false, "00000000");
            }
        }

        private void fixedButton_Click(object sender, EventArgs e)
        {
            if (randCodesList.SelectedItems.Count > 0)
            {
                codeBox.Text = codeBox.Text;
            }
            else
            {
                SetCodeValues(false, codeBox.Text);
            }
        }

        private void NTdtor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}

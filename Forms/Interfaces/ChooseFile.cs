using System;
using System.Windows.Forms;
using MaterialSkin2Framework;
using MaterialSkin2Framework.Controls;
using UltimateBlueScreenSimulator.Forms.Interfaces;

namespace UltimateBlueScreenSimulator
{
    public partial class ChooseFile : MaterialForm
    {
        public ChooseFile()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = Program.F1.materialSkinManager;
            materialSkinManager.AddFormToManage(this);
        }

        private void Initialize(object sender, EventArgs e)
        {
            Repopulate();
            // old method for applying night theme
            /*if (Program.f1.nightThemeToolStripMenuItem.Checked)
            {
                fileBrowser.BackColor = System.Drawing.Color.Black;
                fileBrowser.ForeColor = System.Drawing.Color.Gray;
                fileBrowser.GridLines = false;
            }*/
        }

        private void WhenUserSelectsTheDesiredFile(object sender, EventArgs e)
        {
            if ((fileBrowser.SelectedItems[0].Text == "Null.SYS") && (Program.gs.EnableEggs))
            {
                if (MessageBox.Show("This file will cause weird things to happen with this program. If you do not wish to have weird things happen, please disable easter eggs first. Do you still want to continue?", "Hmmmmmmmmmmmm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void FileBrowser_SelectedIndexChanged(object sender, EventArgs e)
        {
            okButton.Enabled = fileBrowser.SelectedItems.Count > 0;
        }

        private void Repopulate()
        {
            fileBrowser.Items.Clear();
            foreach (string line in Program.templates.CulpritFiles)
            {
                if (line.Contains(":"))
                {
                    ListViewItem lvi = new ListViewItem
                    {
                        Text = line.Split(':')[0]
                    };
                    lvi.SubItems.Add(line.Split(':')[1]);
                    fileBrowser.Items.Add(lvi);
                }
            }
        }

        private void CustomizeFilesButton_Click(object sender, EventArgs e)
        {
            MessageTableEditor mte = new MessageTableEditor
            {
                nt_errors = false,
                Location = this.Location,
                Size = this.Size,
                StartPosition = FormStartPosition.Manual
            };
            Hide();
            mte.ShowDialog();
            this.Location = mte.Location;
            this.Size = mte.Size;
            Repopulate();
            Show();
        }

        private void ChooseFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}

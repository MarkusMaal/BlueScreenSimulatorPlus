using System;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator.Forms.Legacy
{
    public partial class ChooseFile : Form
    {
        public ChooseFile()
        {
            InitializeComponent();
        }

        private void Initialize(object sender, EventArgs e)
        {
            foreach (string line in Properties.Resources.CULPRIT_FILES.Split('\n'))
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
            if (Program.F2.nightThemeToolStripMenuItem.Checked)
            {
                fileBrowser.BackColor = System.Drawing.Color.Black;
                fileBrowser.ForeColor = System.Drawing.Color.Gray;
                fileBrowser.GridLines = false;
            }
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
            DialogResult = DialogResult.OK;
            Close();
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

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageTableEditor mte = new MessageTableEditor
            {
                nt_errors = false,
                Location = Location,
                Size = Size,
                StartPosition = FormStartPosition.Manual
            };
            Hide();
            mte.ShowDialog();
            Location = mte.Location;
            Size = mte.Size;
            Repopulate();
            Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FileBrowser_SelectedIndexChanged(object sender, EventArgs e)
        {
            okButton.Enabled = fileBrowser.SelectedItems.Count > 0;
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (Program.f2.nightThemeToolStripMenuItem.Checked)
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
            this.DialogResult = DialogResult.OK;
            this.Close();
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

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void fileBrowser_SelectedIndexChanged(object sender, EventArgs e)
        {
            okButton.Enabled = fileBrowser.SelectedItems.Count > 0;
        }
    }
}

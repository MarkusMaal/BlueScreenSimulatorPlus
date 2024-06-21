using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace UltimateBlueScreenSimulator
{
    public partial class ChooseFile : MaterialForm
    {
        public ChooseFile()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = Program.f1.materialSkinManager;
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
            this.Close();
        }
    }
}

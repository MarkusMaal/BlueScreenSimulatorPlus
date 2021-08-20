using System;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
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
        }

        private void WhenUserSelectsTheDesiredFile(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

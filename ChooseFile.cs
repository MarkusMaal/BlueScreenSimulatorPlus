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

        private void ChooseFile_Load(object sender, EventArgs e)
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
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void ListView1_ItemActivate(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

using System;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class AddBluescreen : Form
    {
        public AddBluescreen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddBluescreen_Load(object sender, EventArgs e)
        {
            templatePicker.SelectedIndex = 0;
        }

        private void templatePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (templatePicker.SelectedItem.ToString())
            {
                case "Windows 3.1x":
                    osBox.Text = "Windows 3.1x";
                    friendlyBox.Text = "Windows 3.1x (EGA text mode, Standard)";
                    iconBox.SelectedIndex = 0;
                    break;
                case "Windows 9x/Me":
                    osBox.Text = "Windows 9x/Me";
                    friendlyBox.Text = "Windows 9x/Millennium Edition (EGA text mode, Standard)";
                    iconBox.SelectedIndex = 0;
                    break;
                case "Windows CE":
                    osBox.Text = "Windows CE";
                    friendlyBox.Text = "Windows CE 3.0 and later (750x400, Standard)";
                    iconBox.SelectedIndex = 1;
                    break;
                case "Windows NT 3.x/4.0":
                    osBox.Text = "Windows NT 3.x/4.0";
                    friendlyBox.Text = "Windows NT 4.0/3.x (VGA text mode, Standard)";
                    iconBox.SelectedIndex = 0;
                    break;
                case "Windows 2000":
                    osBox.Text = "Windows 2000";
                    friendlyBox.Text = "Windows 2000 Professional/Server Family (640x480, Standard)";
                    iconBox.SelectedIndex = 0;
                    break;
                case "Windows XP":
                    osBox.Text = "Windows XP";
                    friendlyBox.Text = "Windows XP (640x480, Standard)";
                    iconBox.SelectedIndex = 1;
                    break;
                    break;
                case "Windows Vista/7":
                    osBox.Text = "Windows Vista/7";
                    friendlyBox.Text = "Windows Vista/7 (640x480, ClearType)";
                    iconBox.SelectedIndex = 1;
                    break;
                case "Windows Boot Manager":
                    osBox.Text = "BOOTMGR";
                    friendlyBox.Text = "Windows Boot Manager (1024x768, Standard)";
                    iconBox.SelectedIndex = 1;
                    break;
                case "Windows 8/8.1":
                    osBox.Text = "Windows 8/8.1";
                    friendlyBox.Text = "Windows 8/8.1 (Native, ClearType)";
                    iconBox.SelectedIndex = 3;
                    break;
                case "Windows 10":
                    osBox.Text = "Windows 10";
                    friendlyBox.Text = "Windows 10 (Native, ClearType)";
                    iconBox.SelectedIndex = 3;
                    break;
                case "Windows 11":
                    osBox.Text = "Windows 11";
                    friendlyBox.Text = "Windows 11 (Native, ClearType)";
                    iconBox.SelectedIndex = 2;
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (MessageBox.Show("Warning: This feature is mainly used for development purposes. Setting an incorrect value here, may lead your configuration to become unusable. Are you sure you want to continue anyway?", "Custom OS warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    osBox.Enabled = checkBox1.Checked;
                } else
                {
                    checkBox1.Checked = false;
                }
            } else
            {
                osBox.Enabled = checkBox1.Checked;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BlueScreen my_config = new BlueScreen(osBox.Text);
            my_config.SetString("friendlyname", friendlyBox.Text);
            my_config.SetString("icon", iconBox.SelectedItem.ToString());
            Program.bluescreens.Add(my_config);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

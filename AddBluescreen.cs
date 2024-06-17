using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class AddBluescreen : MaterialForm
    {
        string base_os = "Windows 1.x/2.x";
        public AddBluescreen()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = Program.f2.materialSkinManager;
        }

        private void CancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Initialize(object sender, EventArgs e)
        {
            templatePicker.SelectedIndex = 0;
        }

        private void OSSelector(object sender, EventArgs e)
        {
            switch (templatePicker.SelectedItem.ToString())
            {
                case "Windows 1.x/2.x":
                    osBox.Text = "Windows 1.x/2.x";
                    friendlyBox.Text = "Windows 1.x/2.x (Text mode, Standard)";
                    iconBox.SelectedIndex = 0;
                    break;
                case "Windows 3.1x":
                    osBox.Text = "Windows 3.1x";
                    friendlyBox.Text = "Windows 3.1x (Text mode, Standard)";
                    iconBox.SelectedIndex = 0;
                    break;
                case "Windows 9x/Me":
                    osBox.Text = "Windows 9x/Me";
                    friendlyBox.Text = "Windows 9x/Millennium Edition (Text mode, Standard)";
                    iconBox.SelectedIndex = 0;
                    break;
                case "Windows CE":
                    osBox.Text = "Windows CE";
                    friendlyBox.Text = "Windows CE 3.0 and later (750x400, Standard)";
                    iconBox.SelectedIndex = 1;
                    break;
                case "Windows NT 3.x/4.0":
                    osBox.Text = "Windows NT 3.x/4.0";
                    friendlyBox.Text = "Windows NT 4.0/3.x (Text mode, Standard)";
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
                case "Windows Vista":
                    osBox.Text = "Windows Vista";
                    friendlyBox.Text = "Windows Vista (640x480, Standard)";
                    iconBox.SelectedIndex = 1;
                    break;
                case "Windows 7":
                    osBox.Text = "Windows 7";
                    friendlyBox.Text = "Windows 7 (640x480, ClearType)";
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
            base_os = osBox.Text;
        }

        private void ConfirmCustomOS(object sender, EventArgs e)
        {
            if (specifyOsBox.Checked)
            {
                if (MessageBox.Show("Warning: This feature is mainly used for development purposes. Setting an incorrect value here, may lead your configuration to become unusable. Are you sure you want to continue anyway?", "Custom OS warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    osBox.Enabled = specifyOsBox.Checked;
                } else
                {
                    specifyOsBox.Checked = false;
                }
            } else
            {
                osBox.Enabled = specifyOsBox.Checked;
            }
        }

        private void MakeBluescreen(object sender, EventArgs e)
        {
            BlueScreen my_config = new BlueScreen(base_os);
            my_config.SetString("friendlyname", friendlyBox.Text);
            my_config.SetString("icon", iconBox.SelectedItem.ToString());
            my_config.SetString("os", osBox.Text);
            Program.bluescreens.Add(my_config);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void JustifyWindowsWarriors(object sender, EventArgs e)
        {
            if (Program.f1.enableeggs)
            {
                if (osBox.Text.Contains("Linux"))
                {
                    osBox.Text = osBox.Text.Replace("Linux", "Windows");
                }
                if (osBox.Text.Contains("Mac"))
                {
                    osBox.Text = osBox.Text.Replace("Mac", "Windows");
                }
                if (osBox.Text.Contains("BSD"))
                {
                    osBox.Text = osBox.Text.Replace("BSD", "Windows");
                }
                if (osBox.Text.Contains("FreeDOS"))
                {
                    osBox.Text = osBox.Text.Replace("FreeDOS", "MS-DOS");
                }
                if (osBox.Text.Contains("TempleOS"))
                {
                    osBox.Text = osBox.Text.Replace("TempleOS", "Windows");
                }
                if (osBox.Text.Contains("ReactOS"))
                {
                    osBox.Text = osBox.Text.Replace("ReactOS", "Windows");
                }
            }
        }
    }
}

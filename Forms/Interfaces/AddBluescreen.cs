using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin2Framework;
using MaterialSkin2Framework.Controls;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class AddBluescreen : MaterialForm
    {
        string base_os = "Windows 1.x/2.x";
        BlueScreen me;

        

        public AddBluescreen()
        {
            MaterialSkinManager materialSkinManager = Program.f1.materialSkinManager;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
        }

        private void CancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Initialize(object sender, EventArgs e)
        {
            if (this.Text != "Edit bugcheck")
            {
                templatePicker.SelectedIndex = 1;
                templatePicker.SelectedIndex = 0;
            }
            if (AllIcons.Images.Count > 0)
            {
                pictureBox1.Image = AllIcons.Images[0];
            }
        }

        internal void Preload(BlueScreen me)
        {
            templatePicker.Text = me.GetString("os");
            templatePicker.Enabled = false;
            this.Text = "Edit bugcheck";

            osBox.Text = me.GetString("os");
            friendlyBox.Text = me.GetString("friendlyname");
            for (int i = 0; i < iconBox.Items.Count; i++)
            {
                if (me.GetString("icon") == iconBox.Items[i].ToString())
                {
                    iconBox.SelectedIndex = i;
                }
            }
            this.me = me;
        }

        private void OSSelector(object sender, EventArgs e)
        {
            switch (templatePicker.SelectedItem.ToString())
            {
                case "Windows 1.x/2.x":
                    osBox.Text = "Windows 1.x/2.x";
                    friendlyBox.Text = "Windows 1.x/2.x (Text mode, Standard)";
                    iconBox.SelectedIndex = (int)Icons.Flag2D;
                    break;
                case "Windows 3.1x":
                    osBox.Text = "Windows 3.1x";
                    friendlyBox.Text = "Windows 3.1x (Text mode, Standard)";
                    iconBox.SelectedIndex = (int)Icons.Flag2D;
                    break;
                case "Windows 9x/Me":
                    osBox.Text = "Windows 9x/Me";
                    friendlyBox.Text = "Windows 9x/Millennium Edition (Text mode, Standard)";
                    iconBox.SelectedIndex = (int)Icons.Flag2D;
                    break;
                case "Windows CE":
                    osBox.Text = "Windows CE";
                    friendlyBox.Text = "Windows CE 3.0 and later (750x400, Standard)";
                    iconBox.SelectedIndex = (int)Icons.Flag3D;
                    break;
                case "Windows NT 3.1":
                    osBox.Text = "Windows NT 3.x/4.0";
                    friendlyBox.Text = "Windows NT 3.1x (Text mode, Standard)";
                    iconBox.SelectedIndex = (int)Icons.Flag2D;
                    break;
                case "Windows NT 3.x/4.0":
                    osBox.Text = "Windows NT 3.x/4.0";
                    friendlyBox.Text = "Windows NT 4.0/3.5x (Text mode, Standard)";
                    iconBox.SelectedIndex = (int)Icons.Flag2D;
                    break;
                case "Windows 2000":
                    osBox.Text = "Windows 2000";
                    friendlyBox.Text = "Windows 2000 Professional/Server Family (640x480, Standard)";
                    iconBox.SelectedIndex = (int)Icons.Flag2D;
                    break;
                case "Windows XP":
                    osBox.Text = "Windows XP";
                    friendlyBox.Text = "Windows XP (640x480, Standard)";
                    iconBox.SelectedIndex = (int)Icons.Flag3D;
                    break;
                case "Windows Vista":
                    osBox.Text = "Windows Vista";
                    friendlyBox.Text = "Windows Vista (640x480, Standard)";
                    iconBox.SelectedIndex = (int)Icons.Flag3D;
                    break;
                case "Windows 7":
                    osBox.Text = "Windows 7";
                    friendlyBox.Text = "Windows 7 (640x480, ClearType)";
                    iconBox.SelectedIndex = (int)Icons.Flag3D;
                    break;
                case "BOOTMGR":
                    osBox.Text = "BOOTMGR";
                    friendlyBox.Text = "Windows Boot Manager (1024x768, Standard)";
                    iconBox.SelectedIndex = (int)Icons.Flag3D;
                    break;
                case "Windows 8 Beta":
                    osBox.Text = "Windows 8 Beta";
                    friendlyBox.Text = "Windows 8 Beta (Native, ClearType)";
                    iconBox.SelectedIndex = (int)Icons.Flag3D;
                    break;
                case "Windows 8/8.1":
                    osBox.Text = "Windows 8/8.1";
                    friendlyBox.Text = "Windows 8/8.1 (Native, ClearType)";
                    iconBox.SelectedIndex = (int)Icons.Window3D;
                    break;
                case "Windows 10":
                    osBox.Text = "Windows 10";
                    friendlyBox.Text = "Windows 10 (Native, ClearType)";
                    iconBox.SelectedIndex = (int)Icons.Window3D;
                    break;
                case "Windows 11":
                    osBox.Text = "Windows 11";
                    friendlyBox.Text = "Windows 11 (Native, ClearType)";
                    iconBox.SelectedIndex = (int)Icons.Window2D;
                    break;
                case "Windows 11 Beta":
                    osBox.Text = "Windows 11 Beta";
                    friendlyBox.Text = "Windows 11 Beta (Native, ClearType)";
                    iconBox.SelectedIndex = (int)Icons.Window2D;
                    break;
            }
            base_os = templatePicker.SelectedItem.ToString();
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
            if (this.Text != "Edit bugcheck")
            {
                Program.templates.AddTemplate(osBox.Text, friendlyBox.Text, base_os);
                Program.templates.GetLast().SetString("icon", iconBox.SelectedItem.ToString());
            }
            else
            {
                me.SetString("friendlyname", friendlyBox.Text);
                me.SetString("os", osBox.Text);
                me.SetString("icon", iconBox.SelectedItem.ToString());
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void JustifyWindowsWarriors(object sender, EventArgs e)
        {
            if (Program.gs.EnableEggs)
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

        private void AddBluescreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }

        private void iconBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AllIcons.Images.Count > iconBox.SelectedIndex)
            {
                pictureBox1.Image = AllIcons.Images[iconBox.SelectedIndex];
            }
        }
    }
}

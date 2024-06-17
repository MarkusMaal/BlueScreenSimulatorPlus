using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using SimulatorDatabase;
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace UltimateBlueScreenSimulator
{
    public partial class NewUi1 : MaterialForm
    {
        public NewUi1()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo400, Primary.Indigo500,
                Primary.Indigo500, Accent.Orange400,
                TextShade.WHITE
            );
        }

        private void NewUi1_Load(object sender, EventArgs e)
        {
            windowVersion.Items.Clear();
            for (int i = Program.bluescreens.Count - 1; i >= 0; i--)
            {
                windowVersion.Items.Add(Program.bluescreens[i].GetString("friendlyname"));
            }
            //WXOptions.Visible = false;
            errorCode.Visible = false;
            nineXmessage.Visible = false;
            serverBox.Visible = false;
            greenBox.Visible = false;
            qrBox.Visible = false;
            checkBox1.Visible = false;
            winMode.Visible = false;
            acpiBox.Visible = false;
            amdBox.Visible = false;
            stackBox.Visible = false;
            checkBox2.Enabled = true;
            ntPanel.Visible = false;
            if (windowVersion.Items.Count > 0) { windowVersion.SelectedIndex = 0; }
            string winver = "";
            int os_build = 0;
            try
            {
                winver = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
                os_build = Convert.ToInt32(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", "0").ToString());
            }
            catch
            {
            }
            /* if (specificos != "")
            {
                winver = specificos;
                specificos = "";
            }*/
            //this code identifies Windows 11
            if (os_build >= 22000)
            {
                SetOS("Windows 11");
            }
            //this code identifies Windows 10
            else if (winver.Contains("Windows 10"))
            {
                SetOS("Windows 10");
            }
            //this code identifies Windows 8 or Windows 8.1
            else if (winver.Contains("Windows 8"))
            {
                SetOS("Windows 8");
            }
            //this code identifies Windows 7
            else if (winver.Contains("Windows 7"))
            {
                SetOS("Windows 7");
            }
            //this code identifies Windows Vista
            else if (winver.Contains("Windows Vista"))
            {
                SetOS("Windows Vista");
            }
            //this code identifies Windows XP
            else if (winver.Contains("Windows XP"))
            {
                SetOS("Windows XP");
            }
            //this code identifies Windows 2000
            else if ((winver.Contains("Windows 2000")) || (winver.Contains("Windows NT 5")))
            {
                SetOS("Windows 2000");
            }
            //this code identifies Windows 95 or Windows 98
            else if ((winver.Contains("Windows 95")) || (winver.Contains("Windows 98")))
            {
                SetOS("Windows 9x");
            }
            //this code identifies old Windows NT versions
            else if ((winver.Contains("Windows NT 4")) || (winver.Contains("Windows NT 3")))
            {
                SetOS("Windows NT");
            }
        }


        void SetOS(string winver)
        {
            for (int i = 0; i < windowVersion.Items.Count; i++)
            {
                if (windowVersion.Items[i].ToString().Contains(winver))
                {
                    windowVersion.SelectedIndex = i;
                }
            }
        }

        private void NewUi1_ResizeEnd(object sender, EventArgs e)
        {
            this.errorCode.Width = this.Width - 20;
            flowLayoutPanel2.Width = this.Width - 20;
            ntPanel.Width = this.Width - 20;
            nineXmessage.Width = this.Width - 20;
            flowLayoutPanel3.Width = this.Width - 20;
            flowLayoutPanel4.Width = this.Width - 20;
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Program.f1.Show();
        }
    }
}

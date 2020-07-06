using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace UltimateBlueScreenSimulator
{
    partial class AboutBox1 : Form
    {
        //If this flag is set, then help tabs are hidden and setting tabs are visible
        public bool SettingTab = false;
        public AboutBox1()
        {
            InitializeComponent();
            //Get assembly information about the program
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = "Blue screen simulator plus";
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = "Codename Bluesmith\nLanguage: C# (.NET framework, Windows Forms)\nCreated by: Markus Maal (TheMarkusGuy/MarkusTegelane)\n\nThis program can only be provided free of charge (if you had to pay for this, please ask for a refund). This program is provided as is, without a warranty.\n2019 Markuse tarkvara (Markus' software)";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void AboutBox1_Load(object sender, EventArgs e)
        {
            //Ping main form that the about box/help/settings dialog is open
            Program.f1.abopen = true;
            //Hide settings tabs
            if (!SettingTab)
            {
                tabPage2.Dispose();
                tabPage5.Dispose();
            }
            //Hide help/about tabs and get settings
            if (SettingTab)
            {
                tabPage1.Dispose();
                tabPage4.Dispose();
                tabPage3.Dispose();
                checkBox3.Checked = Program.f1.enableeggs;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                if (Program.f1.GMode == "HighQualityBicubic") { comboBox1.SelectedIndex = 0; }
                if (Program.f1.GMode == "HighQualityBilinear") { comboBox1.SelectedIndex = 1; }
                if (Program.f1.GMode == "Bilinear") { comboBox1.SelectedIndex = 4; }
                if (Program.f1.GMode == "Bicubic") { comboBox1.SelectedIndex = 3; }
                if (Program.f1.GMode == "NearestNeighbour") { comboBox1.SelectedIndex = 2; }
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, Program.f1.osshows[i]);
                }
                checkBox2.Checked = !Program.f1.showcursor;
            }
        }

        private void TabPage5_Click(object sender, EventArgs e)
        {

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Perform specific actions when switching to a specific tab
            if (tabControl1.SelectedTab.Text == "Update settings")
            {
                //I/O test, to make sure that it is possible to write data to current media. If not, then some options become disabled.
                try
                {
                    File.WriteAllText("iotest", "This is a test");
                    File.Delete("iotest");
                } catch
                {
                    label7.Text = "Cannot write to current directory. Settings will not be saved.";
                    button1.Enabled = false;
                    button2.Enabled = false;
                    radioButton1.Enabled = false;
                }
                //Loads update configuration
                radioButton1.Checked = Program.f1.autoupdate;
                radioButton2.Checked = !Program.f1.autoupdate;
                checkBox1.Checked = Program.f1.hashverify;
                radioButton3.Checked = !Program.f1.postponeupdate;
                radioButton4.Checked = Program.f1.postponeupdate;
            }
            if (tabControl1.SelectedTab.Text == "Simulator settings")
            {
                //Loads simulator configuration
                checkBox3.Checked = Program.f1.enableeggs;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                if (Program.f1.GMode == "HighQualityBicubic") { comboBox1.SelectedIndex = 0; }
                if (Program.f1.GMode == "HighQualityBilinear") { comboBox1.SelectedIndex = 1; }
                if (Program.f1.GMode == "Bilinear") { comboBox1.SelectedIndex = 4; }
                if (Program.f1.GMode == "Bicubic") { comboBox1.SelectedIndex = 3; }
                if (Program.f1.GMode == "NearestNeighbour") { comboBox1.SelectedIndex = 2; }
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, Program.f1.osshows[i]);
                }
                checkBox2.Checked = !Program.f1.showcursor;
            }
            else if (tabControl1.SelectedTab.Text == "Command line help")
            {
                //Loads command line help
                textBox1.Text = Program.cmds.Replace("\n", Environment.NewLine);
            }
        }

        //Help texts
        private void Button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "How to get help?\n\nFor items that have [?] at the end, you can just hover over them for more information.".Replace("\n", Environment.NewLine);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "What is the purpose of this program?\n\nThis program can be used as a way of screenshotting bluescreens without actually crashing your computer or messing with virtual machines. You can also use this program for pranking purposes (no harm will be done to the system).".Replace("\n", Environment.NewLine);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "System requirements:\n\nOS: Windows XP or later\nMicrosoft.NET Framework 4.0 (preinstalled in Windows 8 and later)\nScreen resolution: 1024x720 or higher (1280x1024 or higher recommended)".Replace("\n", Environment.NewLine);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "How do I disable ClearType?\n\nTo disable ClearType, open system properties (Windows + Pause/Break). Then select advanced options (or Advanced tab). Finally select \"Settings\" from the performance section and uncheck font smoothing.".Replace("\n", Environment.NewLine);
        }

        //Closes the dialog and sets dialogresult to ok
        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Removes verification signature from the system
            try
            { 
                if (File.Exists(Environment.GetEnvironmentVariable("USERPROFILE") + "\\bssp_firstlaunch.txt"))
                {
                    File.Delete(Environment.GetEnvironmentVariable("USERPROFILE") + "\\bssp_firstlaunch.txt");
                    MessageBox.Show("Signature removed successfully.", "Verifile verification system", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong. Please send the following details to the developer:\n\n" + ex.Message + "\n\n" + ex.StackTrace);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //This code starts the check for updates
            UpdateInterface ui = new UpdateInterface();
            ui.DownloadFile("markustegelane.tk/app/bssp_version.txt", "vercheck.txt");
            button2.Enabled = false;
            button2.Text = "Checking for updates...";
            timer1.Enabled = true;
            Program.f1.timer3.Interval = 5998;
            Program.f1.timer3.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //Checks if check for updates has finished
            if (!Program.f1.timer3.Enabled)
            {
                timer1.Enabled = false;
                button2.Enabled = true;
                button2.Text = "Check for updates";
            }
        }

        //Saves configuration
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Program.f1.autoupdate = radioButton1.Checked;
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                Program.f1.postponeupdate = false;
            }
            else
            {
                Program.f1.postponeupdate = true;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Program.f1.hashverify = checkBox1.Checked;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Program.f1.GMode = "HighQualityBicubic";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                Program.f1.GMode = "HighQualityBilinear";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Program.f1.GMode = "NearestNeighbour";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                Program.f1.GMode = "Bilinear";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                Program.f1.GMode = "Bicubic";
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            { 
                Program.f1.showcursor = false;
            }
            else
            {
                Program.f1.showcursor = true;
            }
        }

        private void CheckedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            bool[] osenables = {checkedListBox1.GetItemChecked(0), checkedListBox1.GetItemChecked(1), checkedListBox1.GetItemChecked(2), checkedListBox1.GetItemChecked(3), checkedListBox1.GetItemChecked(4), checkedListBox1.GetItemChecked(5), checkedListBox1.GetItemChecked(6), checkedListBox1.GetItemChecked(7), checkedListBox1.GetItemChecked(8) };
            Program.f1.osshows = osenables;
            Program.f1.GetOS();
        }

        private void CheckedListBox1_Click(object sender, EventArgs e)
        {
            bool[] osenables = { checkedListBox1.GetItemChecked(0), checkedListBox1.GetItemChecked(1), checkedListBox1.GetItemChecked(2), checkedListBox1.GetItemChecked(3), checkedListBox1.GetItemChecked(4), checkedListBox1.GetItemChecked(5), checkedListBox1.GetItemChecked(6), checkedListBox1.GetItemChecked(7), checkedListBox1.GetItemChecked(8) };
            Program.f1.osshows = osenables;
            Program.f1.GetOS();
        }

        private void CheckedListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            bool[] osenables = { checkedListBox1.GetItemChecked(0), checkedListBox1.GetItemChecked(1), checkedListBox1.GetItemChecked(2), checkedListBox1.GetItemChecked(3), checkedListBox1.GetItemChecked(4), checkedListBox1.GetItemChecked(5), checkedListBox1.GetItemChecked(6), checkedListBox1.GetItemChecked(7), checkedListBox1.GetItemChecked(8) };
            Program.f1.osshows = osenables;
            Program.f1.GetOS();
        }


        private void AboutBox1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Makes sure that the configuration is saved when closing the form
            Program.f1.abopen = false;
            if (SettingTab)
            { 
                bool[] osenables = { checkedListBox1.GetItemChecked(0), checkedListBox1.GetItemChecked(1), checkedListBox1.GetItemChecked(2), checkedListBox1.GetItemChecked(3), checkedListBox1.GetItemChecked(4), checkedListBox1.GetItemChecked(5), checkedListBox1.GetItemChecked(6), checkedListBox1.GetItemChecked(7), checkedListBox1.GetItemChecked(8) };
                Program.f1.osshows = osenables;
                Program.f1.GetOS();
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            Program.f1.enableeggs = checkBox3.Checked;
        }

        private void AboutBox1_Resize(object sender, EventArgs e)
        {
            //Hides/shows elements in specific window sizes
            if (this.Height <= 360)
            {
                this.labelCompanyName.Text = "Codename Bluesmith\nLanguage: C# (.NET framework, Windows Forms)\nCreated by: Markus Maal (TheMarkusGuy/MarkusTegelane)";
            }
            else
            {
                this.labelCompanyName.Text = "Codename Bluesmith\nLanguage: C# (.NET framework, Windows Forms)\nCreated by: Markus Maal (TheMarkusGuy/MarkusTegelane)\n\nThis program can only be provided free of charge (if you had to pay for this, please ask for a refund). This program is provided as is, without a warranty.\n2019 Markuse tarkvara (Markus' software)";
            }
            textBox2.Size = new Size(flowLayoutPanel5.Width, Convert.ToInt32(flowLayoutPanel5.Height * 0.8010638));
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using SimulatorDatabase;
using System.Collections.Generic;

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
                if (Program.f1.GMode == "HighQualityBicubic") { comboBox1.SelectedIndex = 0; }
                if (Program.f1.GMode == "HighQualityBilinear") { comboBox1.SelectedIndex = 1; }
                if (Program.f1.GMode == "Bilinear") { comboBox1.SelectedIndex = 4; }
                if (Program.f1.GMode == "Bicubic") { comboBox1.SelectedIndex = 3; }
                if (Program.f1.GMode == "NearestNeighbour") { comboBox1.SelectedIndex = 2; }
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
                if (Program.f1.GMode == "HighQualityBicubic") { comboBox1.SelectedIndex = 0; }
                else if (Program.f1.GMode == "HighQualityBilinear") { comboBox1.SelectedIndex = 1; }
                else if (Program.f1.GMode == "Bilinear") { comboBox1.SelectedIndex = 4; }
                else if (Program.f1.GMode == "Bicubic") { comboBox1.SelectedIndex = 3; }
                else if (Program.f1.GMode == "NearestNeighbour") { comboBox1.SelectedIndex = 2; }
                switch (Program.multidisplaymode)
                {
                    case "none":
                        comboBox2.SelectedIndex = 0;
                        break;
                    case "blank":
                        comboBox2.SelectedIndex = 1;
                        break;
                    case "mirror":
                        comboBox2.SelectedIndex = 2;
                        break;
                    case "freeze":
                        comboBox2.SelectedIndex = 3;
                        break;
                }
                checkBox2.Checked = !Program.f1.showcursor;
                listBox1.ClearSelected();
                listBox1.Items.Clear();
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    listBox1.Items.Add(bs.GetString("friendlyname"));
                }
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



        private void AboutBox1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Makes sure that the configuration is saved when closing the form
            Program.f1.abopen = false;
            if (SettingTab)
            { 
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

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count > 0)
            {
                osName.Text = Program.bluescreens[listBox1.SelectedIndex].GetString("friendlyname");
                resetButton.Enabled = (listBox1.SelectedIndices.Count > 0);
                resetHackButton.Enabled = (listBox1.SelectedIndices.Count > 0);
                removeCfg.Enabled = (listBox1.SelectedIndices.Count > 0);
            } else
            {
                osName.Text = "Select a configuration to modify/remove it";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Warning: This will remove any custom settings from this configuration. ANY UNSAVED CHANGES WILL BE LOST!!! Are you sure you want to continue?", "Reset bugcheck", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string backfriendly = Program.bluescreens[listBox1.SelectedIndex].GetString("friendlyname");
                string backicon = Program.bluescreens[listBox1.SelectedIndex].GetString("icon");
                Program.bluescreens[listBox1.SelectedIndex] = new BlueScreen(Program.bluescreens[listBox1.SelectedIndex].GetString("os"));
                Program.bluescreens[listBox1.SelectedIndex].SetString("icon", backicon);
                Program.bluescreens[listBox1.SelectedIndex].SetString("friendlyname", backfriendly);
                MessageBox.Show("Configuration was reset", "Reset everything", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Reason: The user clicked no", "No changes were made", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void resetHackButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Warning: This will remove any setting set under the 'hacks' menu. Other settings set in the main screen will remain the same. ANY UNSAVED CHANGES WILL BE LOST!!! Are you sure you want to continue?", "Reset hacks", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Program.bluescreens[listBox1.SelectedIndex].ClearAllTitleTexts();
                Program.bluescreens[listBox1.SelectedIndex].SetOSSpecificDefaults();
                MessageBox.Show("Hacks were reset", "Reset hacks", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Reason: The user clicked no", "No changes were made", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Warning: This will remove this configuration from the repository. ANY UNSAVED CHANGES WILL BE LOST!!! Are you sure you want to do that?", "Delete bugcheck", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Program.bluescreens.Remove(Program.bluescreens[listBox1.SelectedIndex]);
                tabControl1.SelectedIndex = 0;
                MessageBox.Show("Config removed successfully", "Configuration deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Reason: The user clicked no", "No changes were made", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (new AddBluescreen().ShowDialog() == DialogResult.OK)
            {
                listBox1.ClearSelected();
                listBox1.Items.Clear();
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    listBox1.Items.Add(bs.GetString("friendlyname"));
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0: Program.multidisplaymode = "none"; break;
                case 1: Program.multidisplaymode = "blank"; break;
                case 2: Program.multidisplaymode = "mirror"; break;
                case 3: Program.multidisplaymode = "freeze"; break;
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            if (saveBsconfig.ShowDialog() == DialogResult.OK)
            {
                string filedata = "*** Blue screen simulator plus 2.0 ***";
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    filedata += "\n\n\n#" + bs.GetString("os") + "\n\n";
                    filedata += "\n\n[string]";
                    filedata += "\nfriendlyname=" + bs.GetString("friendlyname") + ";";
                    filedata += "\ncode=" + bs.GetString("code") + ";";
                    filedata += "\necode1=" + bs.GetString("ecode1") + ";";
                    filedata += "\necode2=" + bs.GetString("ecode2") + ";";
                    filedata += "\necode3=" + bs.GetString("ecode3") + ";";
                    filedata += "\necode4=" + bs.GetString("ecode4") + ";";
                    filedata += "\nemoticon=" + bs.GetString("emoticon").Replace("#", ":h:") + ";";
                    filedata += "\nscreen_mode=" + bs.GetString("screen_mode") + ";";
                    filedata += "\nqr_file=" + bs.GetString("qr_file").Replace("#", ":h:") + ";";
                    filedata += "\nculprit=" + bs.GetString("culprit").Replace("#", ":h:") + ";";
                    filedata += "\nicon=" + bs.GetString("icon") + ";";

                    filedata += "\n\n[boolean]";
                    filedata += "\n" + "windowed=" + bs.GetBool("windowed").ToString() + ";";
                    filedata += "\n" + "autoclose=" + bs.GetBool("autoclose").ToString() + ";";
                    filedata += "\n" + "show_description=" + bs.GetBool("show_description").ToString() + ";";
                    filedata += "\n" + "show_file=" + bs.GetBool("show_file").ToString() + ";";
                    filedata += "\n" + "watermark=" + bs.GetBool("watermark").ToString() + ";";
                    filedata += "\n" + "server=" + bs.GetBool("server").ToString() + ";";
                    filedata += "\n" + "qr=" + bs.GetBool("qr").ToString() + ";";
                    filedata += "\n" + "insider=" + bs.GetBool("insider").ToString() + ";";
                    filedata += "\n" + "acpi=" + bs.GetBool("acpi").ToString() + ";";
                    filedata += "\n" + "amd=" + bs.GetBool("amd").ToString() + ";";
                    filedata += "\n" + "stack_trace=" + bs.GetBool("stack_trace").ToString() + ";";
                    filedata += "\n" + "blink=" + bs.GetBool("blink").ToString() + ";";
                    filedata += "\n" + "font_support=" + bs.GetBool("font_support").ToString() + ";";
                    filedata += "\n" + "blinkblink=" + bs.GetBool("blinkblink").ToString() + ";";
                    filedata += "\n" + "winxplus=" + bs.GetBool("winxplus").ToString() + ";";
                    filedata += "\n" + "extracodes=" + bs.GetBool("extracodes").ToString() + ";";
                    filedata += "\n" + "playsound=" + bs.GetBool("playsound").ToString() + ";";

                    filedata += "\n\n[integer]";
                    filedata += "\n" + "windowed=" + bs.GetInt("blink_speed") + ";";
                    filedata += "\n" + "timer=" + bs.GetInt("timer") + ";";
                    filedata += "\n" + "qr_size=" + bs.GetInt("qr_size") + ";";


                    filedata += "\n\n[theme]";
                    filedata += "\nbg=" + RGB_String(bs.GetTheme(true)) + ";";
                    filedata += "\nfg=" + RGB_String(bs.GetTheme(false)) + ";";
                    filedata += "\nhbg=" + RGB_String(bs.GetTheme(true, true)) + ";";
                    filedata += "\nhfg=" + RGB_String(bs.GetTheme(false, true)) + ";";

                    filedata += "\n\n[title]";
                    foreach (KeyValuePair<string, string> entry in bs.GetTitles())
                    {
                        filedata += "\n" + entry.Key + "=" + entry.Value.Replace("#", ":h:") + ";";
                    }

                    filedata += "\n\n[text]";
                    foreach (KeyValuePair<string, string> entry in bs.GetTexts())
                    {
                        filedata += "\n" + entry.Key + "=" + entry.Value.Replace("#", ":h:") + ";";
                    }

                    filedata += "\n\n[format]";
                    filedata += "\nfontfamily=" + bs.GetFont().FontFamily.Name + ";";
                    filedata += "\nsize=" + bs.GetFont().Size.ToString() + ";";
                    filedata += "\nstyle=" + bs.GetFont().Style.ToString() + ";";
                }
                File.WriteAllText(saveBsconfig.FileName, filedata);
                MessageBox.Show("Blue screen configuration saved successfully", "Blue screen simulator 2.x configuration file creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Color StringToRGB(string rgb)
        {
            string[] splitted_rgb = rgb.Split(',');
            return Color.FromArgb(Convert.ToInt32(splitted_rgb[0]), Convert.ToInt32(splitted_rgb[1]), Convert.ToInt32(splitted_rgb[2]));
        }

        private string RGB_String(Color rgb)
        {
            return rgb.R.ToString() + "," + rgb.G.ToString() + "," + rgb.B.ToString();
        }

        private void loadCfg_Click(object sender, EventArgs e)
        {
            if (loadBsconfig.ShowDialog() == DialogResult.OK)
            {
                string filedata = File.ReadAllText(loadBsconfig.FileName);
                string version = filedata.Split('\n')[0];
                if (version.StartsWith("*** Blue screen simulator plus 1."))
                {
                    MessageBox.Show("This configuration file is not compatible with this development build of blue screen simulator plus 2.0.", "Cannot open configuration file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (version.StartsWith("*** Blue screen simulator plus 2."))
                {
                    string[] primary_section_tokens = filedata.Split('#');
                    Program.bluescreens.Clear();
                    foreach (string section in primary_section_tokens)
                    {
                        string[] subsection_tokens = section.Split('[');
                        if (section.StartsWith("*")) { continue; }
                        string os_name = subsection_tokens[0].Replace("\n", "");
                        if (os_name == "") { continue; }
                        BlueScreen bs = new BlueScreen(os_name);
                        bs.ClearAllTitleTexts();
                        foreach (string subsection in subsection_tokens)
                        {
                            string type = "";
                            if (subsection.StartsWith("string")) { type = "string"; }
                            else if (subsection.StartsWith("boolean")) { type = "boolean"; }
                            else if (subsection.StartsWith("integer")) { type = "integer"; }
                            else if (subsection.StartsWith("theme")) { type = "theme"; }
                            else if (subsection.StartsWith("title")) { type = "title"; }
                            else if (subsection.StartsWith("text")) { type = "text"; }
                            else if (subsection.StartsWith("format")) { type = "format"; }
                            string subsection_withoutheading = subsection.Substring(type.Length + 1);
                            string[] entries = subsection_withoutheading.Split(';');
                            Color theme_bg = Color.Black;
                            Color theme_fg = Color.White;
                            Color theme_hbg = Color.White;
                            Color theme_hfg = Color.Black;
                            string fontfamily = "";
                            float size = 1.0f;
                            FontStyle style = FontStyle.Regular;
                            foreach (string entry in entries)
                            {
                                if (entry.Replace("\n", "") != "")
                                {
                                    string key = entry.Split('=')[0].Replace("\n", "");
                                    string value = entry.Substring(entry.IndexOf("=") + 1);
                                    switch (type)
                                    {
                                        case "string":
                                            bs.SetString(key, value);
                                            break;
                                        case "integer":
                                            bs.SetInt(key, Convert.ToInt32(value));
                                            break;
                                        case "boolean":
                                            bs.SetBool(key, Convert.ToBoolean(value));
                                            break;
                                        case "title":
                                            bs.PushTitle(key, value);
                                            break;
                                        case "text":
                                            bs.PushText(key, value);
                                            break;
                                        case "theme":
                                            switch (key)
                                            {
                                                case "bg":
                                                    theme_bg = StringToRGB(value);
                                                    bs.SetTheme(theme_bg, theme_fg);
                                                    break;
                                                case "fg":
                                                    theme_fg = StringToRGB(value);
                                                    bs.SetTheme(theme_bg, theme_fg);
                                                    break;
                                                case "hbg":
                                                    theme_hbg = StringToRGB(value);
                                                    bs.SetTheme(theme_hbg, theme_hfg, true);
                                                    break;
                                                case "hfg":
                                                    theme_hfg = StringToRGB(value);
                                                    bs.SetTheme(theme_hbg, theme_hfg, true);
                                                    break;
                                            }
                                            break;
                                        case "format":
                                            switch (key)
                                            {
                                                case "fontfamily":
                                                    fontfamily = value;
                                                    break;
                                                case "size":
                                                    size = (float)Convert.ToDouble(value);
                                                    break;
                                                case "style":
                                                    style = (FontStyle)Enum.Parse(typeof(FontStyle), value);
                                                    break;
                                            }
                                            break;
                                    }
                                }
                            }
                            bs.SetFont(fontfamily, size, style);
                        }
                        Program.bluescreens.Add(bs);
                    }
                }
            }
            listBox1.ClearSelected();
            listBox1.Items.Clear();
            foreach (BlueScreen bs in Program.bluescreens)
            {
                listBox1.Items.Add(bs.GetString("friendlyname"));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

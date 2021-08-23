using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using SimulatorDatabase;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace UltimateBlueScreenSimulator
{
    partial class AboutSettingsDialog : Form
    {
        //If this flag is set, then help tabs are hidden and setting tabs are visible
        public bool SettingTab = false;
        public int tab_id = 0;
        public bool DevBuild = true;
        public bool finished = false;
        public AboutSettingsDialog()
        {
            InitializeComponent();
            //Get assembly information about the program
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = "Blue Screen Simulator Plus";
            if (DevBuild) { this.labelProductName.Text += " [Development Build]"; }
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = "Codename *Waffles*\nLanguage: C# (.NET framework, Windows Forms)\nCreated by: Markus Maal (TheMarkusGuy/MarkusTegelane)\n\nThis program can only be provided free of charge (if you had to pay for this, please ask for a refund). This program is provided as is, without a warranty.\n2019 Markuse tarkvara (Markus' software)";
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

        private void SetInitalInterface(object sender, EventArgs e)
        {
            if (Program.f1.nightThemeToolStripMenuItem.Checked)
            {
                aboutSettingsTabControl.Appearance = TabAppearance.FlatButtons;
                this.BackColor = Color.Black;
                this.ForeColor = Color.Gray;
                foreach (Panel p in aboutSettingsTabControl.TabPages)
                {
                    p.BackColor = this.BackColor;
                    p.ForeColor = this.ForeColor;
                }
                markusSoftwareLogo.BackColor = Color.DimGray;
                veriFileLogo.BackColor = Color.DimGray;
                primaryServerBox.BackColor = Color.Black;
                primaryServerBox.ForeColor = Color.Gray;
                primaryServerBox.BorderStyle = BorderStyle.FixedSingle;
                configList.BackColor = Color.Black;
                configList.ForeColor = Color.Gray;
                configList.BorderStyle = BorderStyle.FixedSingle;
                helpDisplay.BackColor = Color.Black;
                helpDisplay.ForeColor = Color.Gray;
                commandLineHelpDisplay.BackColor = Color.Black;
                commandLineHelpDisplay.ForeColor = Color.Gray;
            }
            //Ping main form that the about box/help/settings dialog is open
            Program.f1.abopen = true;
            //Hide settings tabs
            if (!SettingTab)
            {
                updatePanel.Dispose();
                simulatorSettingsPanel.Dispose();
            }
            //Hide help/about tabs and get settings
            if (SettingTab)
            {
                aboutPanel.Dispose();
                commandLinePanel.Dispose();
                helpPanel.Dispose();
                eggHunterButton.Checked = Program.f1.enableeggs;
                if (Program.f1.GMode == "HighQualityBicubic") { scalingModeBox.SelectedIndex = 0; }
                if (Program.f1.GMode == "HighQualityBilinear") { scalingModeBox.SelectedIndex = 1; }
                if (Program.f1.GMode == "Bilinear") { scalingModeBox.SelectedIndex = 4; }
                if (Program.f1.GMode == "Bicubic") { scalingModeBox.SelectedIndex = 3; }
                if (Program.f1.GMode == "NearestNeighbour") { scalingModeBox.SelectedIndex = 2; }
                hideInFullscreenButton.Checked = !Program.f1.showcursor;
            }
            aboutSettingsTabControl.SelectedIndex = tab_id;
        }

        private void TabSwitcher(object sender, EventArgs e)
        {
            //Perform specific actions when switching to a specific tab
            if (aboutSettingsTabControl.SelectedTab.Text == "Update settings")
            {
                //I/O test, to make sure that it is possible to write data to current media. If not, then some options become disabled.
                try
                {
                    File.WriteAllText("iotest", "This is a test");
                    File.Delete("iotest");
                } catch
                {
                    noticeLabel.Text = "Cannot write to current directory. Settings will not be saved.";
                    unsignButton.Enabled = false;
                    updateCheckButton.Enabled = false;
                    autoUpdateRadio.Enabled = false;
                }
                //Loads update configuration
                autoUpdateRadio.Checked = Program.f1.autoupdate;
                noUpdatesRadio.Checked = !Program.f1.autoupdate;
                hashBox.Checked = Program.f1.hashverify;
                updateImmediatelyRadio.Checked = !Program.f1.postponeupdate;
                updateOnCloseRadio.Checked = Program.f1.postponeupdate;
                primaryServerBox.Text = Program.update_server;
                if (!((primaryServerBox.Text == "http://markustegelane.tk/app") || (primaryServerBox.Text == "http://web-markustegelane.000webhostapp.com/app")))
                {
                    primaryServerBox.Enabled = true;
                }
            }
            if (aboutSettingsTabControl.SelectedTab.Text == "Simulator settings")
            {
                //Loads simulator configuration
                eggHunterButton.Checked = Program.f1.enableeggs;
                if (Program.f1.GMode == "HighQualityBicubic") { scalingModeBox.SelectedIndex = 0; }
                else if (Program.f1.GMode == "HighQualityBilinear") { scalingModeBox.SelectedIndex = 1; }
                else if (Program.f1.GMode == "Bilinear") { scalingModeBox.SelectedIndex = 4; }
                else if (Program.f1.GMode == "Bicubic") { scalingModeBox.SelectedIndex = 3; }
                else if (Program.f1.GMode == "NearestNeighbour") { scalingModeBox.SelectedIndex = 2; }
                switch (Program.multidisplaymode)
                {
                    case "none":
                        multiDisplayBox.SelectedIndex = 0;
                        break;
                    case "blank":
                        multiDisplayBox.SelectedIndex = 1;
                        break;
                    case "mirror":
                        multiDisplayBox.SelectedIndex = 2;
                        break;
                    case "freeze":
                        multiDisplayBox.SelectedIndex = 3;
                        break;
                }
                hideInFullscreenButton.Checked = !Program.f1.showcursor;
                configList.ClearSelected();
                configList.Items.Clear();
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    configList.Items.Add(bs.GetString("friendlyname"));
                }
                devFlowPanel.Visible = DevBuild;
            }
            else if (aboutSettingsTabControl.SelectedTab.Text == "Command line help")
            {
                //Loads command line help
                commandLineHelpDisplay.Text = Program.cmds.Replace("\n", Environment.NewLine);
            }
        }

        //Help texts
        private void QuickHelp_Help(object sender, EventArgs e)
        {
            helpDisplay.Text = "How to get help?\n\nFor items that have [?] at the end, you can just hover over them for more information.".Replace("\n", Environment.NewLine);
        }

        private void QuickHelp_Purpose(object sender, EventArgs e)
        {
            helpDisplay.Text = "What is the purpose of this program?\n\nThis program can be used as a way of screenshotting bluescreens without actually crashing your computer or messing with virtual machines. You can also use this program for pranking purposes (no harm will be done to the system).".Replace("\n", Environment.NewLine);
        }

        private void QuickHelp_SystemRequirements(object sender, EventArgs e)
        {
            helpDisplay.Text = "System requirements:\n\nOS: Windows XP or later\nMicrosoft.NET Framework 4.0 (preinstalled in Windows 8 and later)\nScreen resolution: 1024x720 or higher (1280x1024 or higher recommended)".Replace("\n", Environment.NewLine);
        }

        //Closes the dialog and sets dialogresult to ok
        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UnsignMe(object sender, EventArgs e)
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

        private void CheckForUpdates(object sender, EventArgs e)
        {
            //This code starts the check for updates
            if (Program.f1.DoWeHaveInternet(1000))
            {
                if (File.Exists("vercheck.txt"))
                {
                    File.Delete("vercheck.txt");
                }
                UpdateInterface ui = new UpdateInterface();
                ui.DownloadFile(Program.update_server + "/bssp_version.txt", "vercheck.txt");
                updateCheckButton.Enabled = false;
                updateCheckButton.Text = "Checking for updates...";
                updateCheckerTimer.Enabled = true;
                Program.f1.updateCheckerTimer.Interval = 5998;
                Program.f1.updateCheckerTimer.Enabled = true;
            } else
            {
                MessageBox.Show("No internet connection available", "Couldn't check for updates", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            //Checks if check for updates has finished
            if (!Program.f1.updateCheckerTimer.Enabled)
            {
                updateCheckerTimer.Enabled = false;
                updateCheckButton.Enabled = true;
                updateCheckButton.Text = "Check for updates";
            }
        }

        //Saves configuration
        private void EnableDisableUpdateSetup(object sender, EventArgs e)
        {
            Program.f1.autoupdate = autoUpdateRadio.Checked;
        }

        private void UpdateWhenDoneSetup(object sender, EventArgs e)
        {
            if (updateImmediatelyRadio.Checked == true)
            {
                Program.f1.postponeupdate = false;
            }
            else
            {
                Program.f1.postponeupdate = true;
            }
        }

        private void HashcheckSetup(object sender, EventArgs e)
        {
            Program.f1.hashverify = hashBox.Checked;
        }

        private void ScalingModeSetup(object sender, EventArgs e)
        {
            if (scalingModeBox.SelectedIndex == 0)
            {
                Program.f1.GMode = "HighQualityBicubic";
            }
            else if (scalingModeBox.SelectedIndex == 1)
            {
                Program.f1.GMode = "HighQualityBilinear";
            }
            else if (scalingModeBox.SelectedIndex == 2)
            {
                Program.f1.GMode = "NearestNeighbour";
            }
            else if (scalingModeBox.SelectedIndex == 4)
            {
                Program.f1.GMode = "Bilinear";
            }
            else if (scalingModeBox.SelectedIndex == 3)
            {
                Program.f1.GMode = "Bicubic";
            }
        }

        private void CursorVisibilitySetup(object sender, EventArgs e)
        {
            if (hideInFullscreenButton.Checked == true)
            { 
                Program.f1.showcursor = false;
            }
            else
            {
                Program.f1.showcursor = true;
            }
        }



        private void ExitMe(object sender, FormClosingEventArgs e)
        {
            //Makes sure that the configuration is saved when closing the form
            Program.f1.abopen = false;
            if (SettingTab)
            { 
                Program.f1.GetOS();
            }
        }

        private void EggHunter(object sender, EventArgs e)
        {
            Program.f1.enableeggs = eggHunterButton.Checked;
        }

        private void OnMeResized(object sender, EventArgs e)
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
            helpDisplay.Size = new Size(helpPanelChild.Width, Convert.ToInt32(helpPanelChild.Height * 0.8010638));
        }

        private void ConfigSelector(object sender, EventArgs e)
        {
            if (configList.SelectedIndices.Count > 0)
            {
                osName.Text = Program.bluescreens[configList.SelectedIndex].GetString("friendlyname");
                resetButton.Enabled = (configList.SelectedIndices.Count > 0);
                resetHackButton.Enabled = (configList.SelectedIndices.Count > 0);
                removeCfg.Enabled = (configList.SelectedIndices.Count > 0);
            } else
            {
                osName.Text = "Select a configuration to modify/remove it";
            }
        }

        private void ConfigHackEraser(object sender, EventArgs e)
        {
            if (MessageBox.Show("Warning: This will remove any custom settings from this configuration. ANY UNSAVED CHANGES WILL BE LOST!!! Are you sure you want to continue?", "Reset bugcheck", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string backfriendly = Program.bluescreens[configList.SelectedIndex].GetString("friendlyname");
                string backicon = Program.bluescreens[configList.SelectedIndex].GetString("icon");
                Program.bluescreens[configList.SelectedIndex] = new BlueScreen(Program.bluescreens[configList.SelectedIndex].GetString("os"));
                Program.bluescreens[configList.SelectedIndex].SetString("icon", backicon);
                Program.bluescreens[configList.SelectedIndex].SetString("friendlyname", backfriendly);
                MessageBox.Show("Configuration was reset", "Reset everything", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Reason: The user clicked no", "No changes were made", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ResetConfig(object sender, EventArgs e)
        {
            if (MessageBox.Show("Warning: This will remove any setting set under the 'hacks' menu. Other settings set in the main screen will remain the same. ANY UNSAVED CHANGES WILL BE LOST!!! Are you sure you want to continue?", "Reset hacks", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Program.bluescreens[configList.SelectedIndex].ClearAllTitleTexts();
                Program.bluescreens[configList.SelectedIndex].SetOSSpecificDefaults();
                MessageBox.Show("Hacks were reset", "Reset hacks", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Reason: The user clicked no", "No changes were made", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ConfigEraser(object sender, EventArgs e)
        {
            if (MessageBox.Show("Warning: This will remove this configuration from the repository. ANY UNSAVED CHANGES WILL BE LOST!!! Are you sure you want to do that?", "Delete bugcheck", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                
                Program.bluescreens.Remove(Program.bluescreens[configList.SelectedIndex]);
                configList.ClearSelected();
                configList.Items.Clear();
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    configList.Items.Add(bs.GetString("friendlyname"));
                }
                MessageBox.Show("Config removed successfully", "Configuration deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Reason: The user clicked no", "No changes were made", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AddConfig(object sender, EventArgs e)
        {
            if (new AddBluescreen().ShowDialog() == DialogResult.OK)
            {
                configList.ClearSelected();
                configList.Items.Clear();
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    configList.Items.Add(bs.GetString("friendlyname"));
                }
            }
        }

        private void MultiDisplaySetup(object sender, EventArgs e)
        {
            switch (multiDisplayBox.SelectedIndex)
            {
                case 0: Program.multidisplaymode = "none"; break;
                case 1: Program.multidisplaymode = "blank"; break;
                case 2: Program.multidisplaymode = "mirror"; break;
                case 3: Program.multidisplaymode = "freeze"; break;
            }
        }

        private void SaveData(string filename)
        {
            string filedata = "*** Blue screen simulator plus 2.0 ***";
            foreach (BlueScreen bs in Program.bluescreens)
            {
                filedata += "\n\n\n#" + bs.GetString("os") + "\n\n";
                if (bs.AllStrings().Count > 0)
                {
                    filedata += "\n\n[string]";
                    foreach (KeyValuePair<string, string> entry in bs.AllStrings())
                    {
                        filedata += "\n" + entry.Key + "=" + entry.Value.Replace(":", "::").Replace("#", ":h:").Replace(";", ":sc:").Replace("[", ":sb:").Replace("]", ":eb:") + ";";
                    }
                }
                filedata += "\necode1=" + bs.GetString("ecode1") + ";";
                filedata += "\necode2=" + bs.GetString("ecode2") + ";";
                filedata += "\necode3=" + bs.GetString("ecode3") + ";";
                filedata += "\necode4=" + bs.GetString("ecode4") + ";";
                filedata += "\nicon=" + bs.GetString("icon") + ";";

                if (bs.GetFiles().Count > 0)
                {
                    filedata += "\n\n[nt_codes]";
                    foreach (KeyValuePair<string, string[]> entry in bs.GetFiles())
                    {
                        filedata += "\n" + entry.Key + "=" + string.Join(",", entry.Value) + ";";
                    }
                }

                if (bs.AllBools().Count > 0)
                {
                    filedata += "\n\n[boolean]";
                    foreach (KeyValuePair<string, bool> entry in bs.AllBools())
                    {
                        filedata += "\n" + entry.Key + "=" + entry.Value.ToString() + ";";
                    }
                }

                if (bs.AllInts().Count > 0)
                {
                    filedata += "\n\n[integer]";
                    foreach (KeyValuePair<string, int> entry in bs.AllInts())
                    {
                        filedata += "\n" + entry.Key + "=" + entry.Value.ToString() + ";";
                    }
                }

                filedata += "\n\n[theme]";
                filedata += "\nbg=" + RGB_String(bs.GetTheme(true)) + ";";
                filedata += "\nfg=" + RGB_String(bs.GetTheme(false)) + ";";
                filedata += "\nhbg=" + RGB_String(bs.GetTheme(true, true)) + ";";
                filedata += "\nhfg=" + RGB_String(bs.GetTheme(false, true)) + ";";

                if (bs.GetTitles().Count > 0)
                {
                    filedata += "\n\n[title]";
                    foreach (KeyValuePair<string, string> entry in bs.GetTitles())
                    {
                        filedata += "\n" + entry.Key + "=" + entry.Value.Replace(":", "::").Replace("#", ":h:").Replace(";", ":sc:").Replace("[", ":sb:").Replace("]", ":eb:") + ";";
                    }
                }

                if (bs.GetTexts().Count > 0)
                {
                    filedata += "\n\n[text]";
                    foreach (KeyValuePair<string, string> entry in bs.GetTexts())
                    {
                        filedata += "\n" + entry.Key + "=" + entry.Value.Replace(":", "::").Replace("#", ":h:").Replace(";", ":sc:").Replace("[", ":sb:").Replace("]", ":eb:") + ";";
                    }
                }

                if (bs.GetBool("font_support"))
                {
                    filedata += "\n\n[format]";
                    filedata += "\nfontfamily=" + bs.GetFont().FontFamily.Name + ";";
                    filedata += "\nsize=" + bs.GetFont().Size.ToString() + ";";
                    filedata += "\nstyle=" + bs.GetFont().Style.ToString() + ";";
                }
            }
            File.WriteAllText(filename, filedata);
            MessageBox.Show("Blue screen configuration saved successfully", "Blue screen simulator 2.x configuration file creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            finished = true;
            Thread.CurrentThread.Abort();
        }

        private void SaveConfig(object sender, EventArgs e)
        {
            if (saveBsconfig.ShowDialog() == DialogResult.OK)
            {
                Thread t = new Thread(() => SaveData(saveBsconfig.FileName));
                t.Start();
                finished = false;
                checkIfLoadedSaved.Enabled = true;
                this.Enabled = false;
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

        // This function only exists to support backwards compatibility with older BSSP config files
        // don't judge it
        // it is a reworked version of spaghetti that existed in the first version
        public void LegacyLoad(string[] filelines)
        {
            try
            {
                // remove versions that aren't supported by 1.x files
                Program.bluescreens.Clear();
                Program.bluescreens.Add(new BlueScreen("Windows 3.1x"));
                Program.bluescreens.Add(new BlueScreen("Windows 9x/Me"));
                Program.bluescreens.Add(new BlueScreen("Windows CE"));
                Program.bluescreens.Add(new BlueScreen("Windows NT 3.x/4.0"));
                Program.bluescreens.Add(new BlueScreen("Windows 2000"));
                Program.bluescreens.Add(new BlueScreen("Windows XP"));
                Program.bluescreens.Add(new BlueScreen("Windows Vista/7"));
                Program.bluescreens.Add(new BlueScreen("Windows 8/8.1"));
                Program.bluescreens.Add(new BlueScreen("Windows 10"));
                foreach (string fileline in filelines)
                {
                    Thread.Sleep(10);
                    if (fileline.Contains("***")) { continue; }
                    if (fileline.StartsWith("FACE "))
                    {
                        Program.bluescreens[7].SetString("emoticon", fileline.Replace("FACE ", ""));
                        Program.bluescreens[8].SetString("emoticon", fileline.Replace("FACE ", ""));
                    }
                    else if (fileline.StartsWith("MODERN "))
                    {
                        Program.bluescreens[7].SetTheme(Color.FromArgb(Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[0].ToString().Split(':')[2].ToString())), Color.FromArgb(Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[1].ToString().Split(':')[2].ToString())));
                        Program.bluescreens[8].SetTheme(Program.bluescreens[7].GetTheme(true), Program.bluescreens[7].GetTheme(false));
                    }
                    else if (fileline.StartsWith("W2K "))
                    {
                        Color[] modests = { Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[2].ToString())), Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[2].ToString())) };
                        Program.bluescreens[4].SetTheme(modests[0], modests[1]);
                    }
                    else if (fileline.StartsWith("NT34 "))
                    {
                        Color[] modests = { Color.FromArgb(Convert.ToInt32(fileline.Replace("NT34 ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("NT34 ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[2].ToString())), Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[2].ToString())) };
                        Program.bluescreens[3].SetTheme(modests[0], modests[1]);
                    }
                    else if (fileline.StartsWith("W9XME "))
                    {
                        Color me9xbsodbg = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[0].ToString().Split(':')[2].ToString()));
                        Color me9xbsodfg = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[1].ToString().Split(':')[2].ToString()));
                        Program.bluescreens[0].SetTheme(me9xbsodbg, me9xbsodfg);
                        Program.bluescreens[1].SetTheme(me9xbsodbg, me9xbsodfg);
                    }
                    else if (fileline.StartsWith("W9XME_HL "))
                    {
                        Color me9xbsodhlbg = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[0].ToString().Split(':')[2].ToString()));
                        Color me9xbsodhlfg = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[1].ToString().Split(':')[2].ToString()));
                        Program.bluescreens[0].SetTheme(me9xbsodhlbg, me9xbsodhlfg, true);
                        Program.bluescreens[1].SetTheme(me9xbsodhlbg, me9xbsodhlfg, true);
                    }
                }
                string restof = "";
                for (int i = 7; i < filelines.Length; i++)
                {
                    Thread.Sleep(10);
                    restof += filelines[i] + "\n";
                }
                string[] sections = restof.Replace("--", "\t").Split('\t');
                string strings = "";
                string fonts = "";
                string miscs = "";
                for (int i = 0; i < sections.Length; i++)
                {
                    Thread.Sleep(10);
                    if (sections[i] == "STRINGBUILD START")
                    {
                        strings = sections[i + 1];
                    }
                    if (sections[i] == "FONT START")
                    {
                        fonts = sections[i + 1];
                    }
                    if (sections[i] == "MISC START")
                    {
                        miscs = sections[i + 1];
                    }
                }
                string[] stringlist = { };
                string[] misclist = { };
                string[] fontlist = { };
                try
                {
                    stringlist = strings.Substring(1, strings.Length - 1).Replace("http://", "\\\\").Replace("//", "\t").Replace("\\\\", "http://").Split('\t');
                    misclist = miscs.Substring(1, miscs.Length - 1).Split('\n');
                    fontlist = fonts.Substring(1, fonts.Length - 1).Split('\n');
                }
                catch { }
                bool fontok = true;
                foreach (string element in fontlist)
                {
                    Thread.Sleep(10);
                    try
                    {
                        if (!element.Contains(",")) { continue; }
                        string[] subfont = element.Replace("label26: ", "").Replace("label39: ", "").Replace("label49: ", "").Replace("label50: ", "").Replace("modernDetailFont: ", "").Replace("emotiFont: ", "").Replace("modernTextFont: ", "").Replace(",4", "").Split(',');
                        FontStyle fs = new FontStyle();
                        fs = FontStyle.Regular;
                        if (subfont[5] == "Bold=True") { fs |= FontStyle.Bold; }
                        if (subfont[6] == "Italic=True") { fs |= FontStyle.Italic; }
                        if (subfont[7] == "Underline=True") { fs |= FontStyle.Underline; }
                        string family = subfont[0].ToString();
                        int fontsize = Convert.ToInt32(subfont[1].Replace("Size=", ""));
                        if (element.StartsWith("modernTextFont: "))
                        {
                            Program.bluescreens[7].SetFont(family, fontsize, fs);
                            Program.bluescreens[8].SetFont(family, fontsize, fs);
                        }
                        if (element.StartsWith("label50: ")) { Program.bluescreens[6].SetFont(family, fontsize, fs); }
                        if (element.StartsWith("label49: ")) { Program.bluescreens[5].SetFont(family, fontsize, fs); }
                        if (element.StartsWith("label39: ")) { Program.bluescreens[4].SetFont(family, fontsize, fs); }
                        if (element.StartsWith("label26: ")) { Program.bluescreens[3].SetFont(family, fontsize, fs); }
                    } catch { fontok = false; }
                }
                try
                {
                    foreach (string element in misclist)
                    {
                        Thread.Sleep(10);
                        if (element.StartsWith("qrType: "))
                        {
                            string decide = element.Replace("qrType: ", "");
                            if (decide == "Default")
                            {
                                Program.bluescreens[7].SetString("qr_file", "local:0");
                                Program.bluescreens[8].SetString("qr_file", "local:0");
                            }
                            if (decide == "Transparent")
                            {
                                Program.bluescreens[7].SetString("qr_file", "local:1");
                                Program.bluescreens[8].SetString("qr_file", "local:1");
                            }
                        }
                   
                        else if (element.StartsWith("qrPath: "))
                        {
                            Program.bluescreens[7].SetString("qr_file", element.Replace("qrPath: ", ""));
                            Program.bluescreens[8].SetString("qr_file", element.Replace("qrPath: ", ""));
                        }
                        else if (element.StartsWith("qrSize: "))
                        {
                            Program.bluescreens[7].SetInt("qr_file", Convert.ToInt32(element.Replace("qrSize: ", "")));
                            Program.bluescreens[8].SetInt("qr_size", Convert.ToInt32(element.Replace("qrSize: ", "")));
                        }
                    }
                }
                catch { }

                // Windows 3.1/9x
                Program.bluescreens[0].SetTitle("Main", stringlist[0].Replace("\n", Environment.NewLine));
                Program.bluescreens[1].SetTitle("Main", stringlist[0].Replace("\n", Environment.NewLine));
                Program.bluescreens[1].SetTitle("System is busy", stringlist[1].Replace("\n", Environment.NewLine));
                Program.bluescreens[1].SetTitle("Warning", stringlist[2].Replace("\n", Environment.NewLine));
                Program.bluescreens[1].SetText("System error", stringlist[3].Replace("\n", Environment.NewLine));
                Program.bluescreens[1].SetText("Prompt", stringlist[4].Replace("\n", Environment.NewLine));
                Program.bluescreens[0].SetText("No unresponsive programs", stringlist[5].Replace("\n", Environment.NewLine));
                Program.bluescreens[0].SetInt("blink_speed", Convert.ToInt32(stringlist[6].Replace("\n", Environment.NewLine)));
                Program.bluescreens[1].SetInt("blink_speed", Convert.ToInt32(stringlist[6].Replace("\n", Environment.NewLine)));
                Program.bluescreens[3].SetInt("blink_speed", Convert.ToInt32(stringlist[6].Replace("\n", Environment.NewLine)));
                Program.bluescreens[1].SetText("Application error", stringlist[7].Replace("\n", Environment.NewLine));
                Program.bluescreens[1].SetText("Driver error", stringlist[8].Replace("\n", Environment.NewLine));
                Program.bluescreens[1].SetText("System is busy", stringlist[9].Replace("\n", Environment.NewLine));
                Program.bluescreens[1].SetText("System is unresponsive", stringlist[10].Replace("\n", Environment.NewLine));

                // Windows CE
                Program.bluescreens[2].SetText("A problem has occurred...", stringlist[11].Replace("\n", Environment.NewLine));
                Program.bluescreens[2].SetText("CTRL+ALT+DEL message", stringlist[12].Replace("\n", Environment.NewLine));
                Program.bluescreens[2].SetText("Technical information", stringlist[13].Replace("\n", Environment.NewLine));
                Program.bluescreens[2].SetText("Technical information formatting", stringlist[14].Replace("\n", Environment.NewLine));
                Program.bluescreens[2].SetText("Restart message", stringlist[15].Replace("\n", Environment.NewLine));
                Program.bluescreens[2].SetInt("timer", Convert.ToInt32(stringlist[16].Replace("\n", Environment.NewLine)));
                Program.bluescreens[2].SetInt("timer", Convert.ToInt32(stringlist[16].Replace("\n", Environment.NewLine)));

                // Windows NT
                Program.bluescreens[3].SetText("Error code formatting", stringlist[17].Replace("\n", Environment.NewLine));
                Program.bluescreens[3].SetText("CPUID formatting", stringlist[18].Replace("\n", Environment.NewLine));
                Program.bluescreens[3].SetText("Stack trace heading", stringlist[19].Replace("\n", Environment.NewLine));
                Program.bluescreens[3].SetText("Stack trace table formatting", stringlist[20].Replace("\n", Environment.NewLine));
                Program.bluescreens[3].SetText("Memory address dump heading", stringlist[21].Replace("\n", Environment.NewLine));
                Program.bluescreens[3].SetText("Memory address dump table", stringlist[22].Replace("\n", Environment.NewLine));
                Program.bluescreens[3].SetText("Troubleshooting text", stringlist[23].Replace("\n", Environment.NewLine));

                // Windows 2000
                Program.bluescreens[4].SetText("Error code formatting", stringlist[24].Replace("\n", Environment.NewLine));
                Program.bluescreens[4].SetText("Troubleshooting introduction", stringlist[25].Replace("\n", Environment.NewLine));
                Program.bluescreens[4].SetText("Troubleshooting text", stringlist[27].Replace("\n", Environment.NewLine));
                Program.bluescreens[4].SetText("Additional troubleshooting information", (stringlist[28]).Replace("\n", Environment.NewLine));

                // Windows XP/Vista
                Program.bluescreens[5].SetText("A problem has been detected...", stringlist[26].Replace("\n", Environment.NewLine));
                Program.bluescreens[6].SetText("A problem has been detected...", stringlist[26].Replace("\n", Environment.NewLine));
                Program.bluescreens[5].SetText("Troubleshooting introduction", stringlist[29].Replace("\n", Environment.NewLine));
                Program.bluescreens[6].SetText("Troubleshooting introduction", stringlist[29].Replace("\n", Environment.NewLine));
                Program.bluescreens[5].SetText("Troubleshooting", stringlist[30].Replace("\n", Environment.NewLine));
                Program.bluescreens[6].SetText("Troubleshooting", stringlist[30].Replace("\n", Environment.NewLine));
                Program.bluescreens[5].SetText("Technical information", stringlist[31].Replace("\n", Environment.NewLine));
                Program.bluescreens[6].SetText("Technical information", stringlist[31].Replace("\n", Environment.NewLine));
                Program.bluescreens[5].SetText("Technical information formatting", stringlist[32].Replace("\n", Environment.NewLine));
                Program.bluescreens[6].SetText("Technical information formatting", stringlist[32].Replace("\n", Environment.NewLine));
                Program.bluescreens[5].SetText("Physical memory dump", stringlist[33].Replace("\n", Environment.NewLine));
                Program.bluescreens[6].SetText("Physical memory dump", stringlist[35].Replace("\n", Environment.NewLine));
                string xp_support = stringlist[34].Split('\n')[0] + "\n" + stringlist[34].Split('\n')[1];
                string vista_support = stringlist[34].Split('\n')[2];
                Program.bluescreens[5].SetText("Technical support", xp_support.Replace("\n", Environment.NewLine));
                Program.bluescreens[6].SetText("Technical support", vista_support.Replace("\n", Environment.NewLine));

                // Windows 8
                Program.bluescreens[7].SetText("Information text with dump", stringlist[36].Replace("\n", Environment.NewLine));
                Program.bluescreens[7].SetText("Information text without dump", stringlist[37].Replace("\n", Environment.NewLine));
                Program.bluescreens[7].SetText("Error code", stringlist[38].Replace("\n", Environment.NewLine));

                // Windows 10
                Program.bluescreens[8].SetText("Information text with dump", stringlist[40].Replace("\n", Environment.NewLine));
                Program.bluescreens[8].SetText("Information text without dump", stringlist[39].Replace("\n", Environment.NewLine));
                Program.bluescreens[8].SetText("Additional information", stringlist[41].Replace("\n", Environment.NewLine));
                Program.bluescreens[8].SetText("Culprit file", stringlist[42].Replace("\n", Environment.NewLine));
                Program.bluescreens[8].SetText("Progress", stringlist[43].Replace("\n", Environment.NewLine));
                Program.bluescreens[8].SetText("Error code", stringlist[44].Replace("\n", Environment.NewLine));
                if (!fontok)
                {
                    MessageBox.Show("The configuration file was loaded, but some fonts weren't changed due to an error.", "Config loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        public void LoadConfig(string filename)
        {
            string filedata = File.ReadAllText(filename);
            string version = filedata.Split('\n')[0];
            if (version.StartsWith("*** Blue screen simulator plus 1."))
            {
                LegacyLoad(File.ReadAllLines(filename));
            }
            else if (version.StartsWith("*** Blue screen simulator plus 2."))
            {
                string[] primary_section_tokens = filedata.Split('#');
                Program.bluescreens.Clear();
                foreach (string section in primary_section_tokens)
                {
                    Thread.Sleep(10);
                    string[] subsection_tokens = section.Split('[');
                    if (section.StartsWith("*")) { continue; }
                    string os_name = subsection_tokens[0].Replace("\n", "");
                    if (os_name == "") { continue; }
                    BlueScreen bs = new BlueScreen(os_name, false);
                    bs.ClearAllTitleTexts();
                    bs.ClearFiles();
                    foreach (string subsection in subsection_tokens)
                    {
                        if (subsection.IndexOf("]") > 0)
                        {
                            string type = subsection.Substring(0, subsection.IndexOf("]"));
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
                                            bs.SetString(key, value.Replace("::", ":/:/:").Replace(":h:", "#").Replace(":sc:", ";").Replace(":sb:", "[").Replace(":eb:", "]").Replace(":/:/:", ":"));
                                            break;
                                        case "integer":
                                            bs.SetInt(key, Convert.ToInt32(value));
                                            break;
                                        case "boolean":
                                            bs.SetBool(key, Convert.ToBoolean(value));
                                            break;
                                        case "title":
                                            bs.PushTitle(key, value.Replace("::", ":/:/:").Replace(":h:", "#").Replace(":sc:", ";").Replace(":sb:", "[").Replace(":eb:", "]").Replace(":/:/:", ":"));
                                            break;
                                        case "nt_codes":
                                            bs.PushFile(key, value.Split(','));
                                            break;
                                        case "text":
                                            bs.PushText(key, value.Replace("::", ":/:/:").Replace(":h:", "#").Replace(":sc:", ";").Replace(":sb:", "[").Replace(":eb:", "]").Replace(":/:/:", ":"));
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
                    }
                    Program.bluescreens.Add(bs);
                }
            }
        }

        private void ConfigLoader(string filename)
        {
            LoadConfig(filename);
            finished = true;
            Thread.CurrentThread.Abort();
        }

        private void BrowseConfig(object sender, EventArgs e)
        {
            if ((loadBsconfig.FileName != "")||(loadBsconfig.ShowDialog() == DialogResult.OK))
            {
                Thread t = new Thread(() => ConfigLoader(loadBsconfig.FileName));
                t.Start();
                finished = false;
                checkIfLoadedSaved.Enabled = true;
                this.Enabled = false;
            }
        }

        private void DevNewAll(object sender, EventArgs e)
        {
            Program.bluescreens.Clear();
            Program.ReRe();
            configList.ClearSelected();
            configList.Items.Clear();
            foreach (BlueScreen bs in Program.bluescreens)
            {
                configList.Items.Add(bs.GetString("friendlyname"));
            }
        }

        private void DevDictEdit(object sender, EventArgs e)
        {
            try
            {
                DictEdit de = new DictEdit
                {
                    me = Program.bluescreens[configList.SelectedIndex]
                };
                de.Show();
            } catch
            {
                MessageBox.Show("please select a configuration");
            }
        }

        private void DevNukeAll(object sender, EventArgs e)
        {
            Program.bluescreens.Clear();
            configList.ClearSelected();
            configList.Items.Clear();
            foreach (BlueScreen bs in Program.bluescreens)
            {
                configList.Items.Add(bs.GetString("friendlyname"));
            }
        }

        private void ChangeUpdateServer(object sender, EventArgs e)
        {
            Program.update_server = primaryServerBox.Text;
        }

        private void SetToPrimaryServer(object sender, EventArgs e)
        {
            primaryServerBox.Enabled = false;
            primaryServerBox.Text = "http://markustegelane.tk/app";
        }

        private void SetToBackupServer(object sender, EventArgs e)
        {
            primaryServerBox.Enabled = false;
            primaryServerBox.Text = "http://web-markustegelane.000webhostapp.com/app";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            primaryServerBox.Enabled = true;
        }

        private void UserManualButtonClick(object sender, EventArgs e)
        {
            if (Program.f1.DoWeHaveInternet(1000))
            {
                // online user manual
                Process p = new Process();
                p.StartInfo.FileName = "https://markustegelane.ml/bssp/help.pdf";
                p.Start();
            }
            else
            {
                File.WriteAllBytes(Environment.GetEnvironmentVariable("TEMP") + "\\bssp_manual.pdf", Properties.Resources.BSSP_manual);

                Process p = new Process();
                p.StartInfo.FileName = Environment.GetEnvironmentVariable("TEMP") + "\\bssp_manual.pdf";
                p.Start();
            }
        }

        private void DisplayDevSplashScreen(object sender, EventArgs e)
        {
            Splash spl = new Splash();
            spl.SplashText.Text = "Idling. Press ESC to exit.";
            spl.veriFileTimer.Enabled = false;
            spl.Show();
        }

        private void RestartAll(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void WaitUntilComplete(object sender, EventArgs e)
        {
            if (finished)
            {
                this.Enabled = true;
                configList.ClearSelected();
                configList.Items.Clear();
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    configList.Items.Add(bs.GetString("friendlyname"));
                }
                loadBsconfig.FileName = "";
                saveBsconfig.FileName = "";
                checkIfLoadedSaved.Enabled = false;
            }
        }
    }
}

using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using SimulatorDatabase;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Windows.Controls;

namespace UltimateBlueScreenSimulator
{
    partial class AboutSettingsDialog : MaterialForm
    {
        //If this flag is set, then help tabs are hidden and setting tabs are visible
        public bool SettingTab = false;
        public int tab_id = 0;
        public bool DevBuild = true;
        public bool finished = false;
        readonly Random r = new Random();
        public AboutSettingsDialog()
        {
            MaterialSkinManager materialSkinManager = Program.f1.materialSkinManager;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            //Get assembly information about the program
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = "Blue Screen Simulator Plus";
            if (DevBuild) { this.labelProductName.Text += " [Development Build]"; }
            string asmVer = AssemblyVersion.Replace(".0", "");
            if (!asmVer.Contains("."))
            {
                asmVer += ".0";
            }
            this.labelVersion.Text = String.Format("Version {0} with Verifile 1.1", asmVer);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = "Codename ModestIndigo\nLanguage: C# (.NET framework, Windows Forms)\nCreated by: Markus Maal a.k.a. mmaal (markustegelane)\n\nThis program can only be provided free of charge (if you had to pay for this, please ask for a refund). This program is provided as is, without a warranty.\n2022 Markuse tarkvara (Markus' software)";
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
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
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
            // legacy night mode
            /*if (Program.f1.nightThemeToolStripMenuItem.Checked)
            {
                aboutSettingsTabControl.Appearance = TabAppearance.FlatButtons;
                this.BackColor = Color.Black;
                this.ForeColor = Color.Gray;
                foreach (System.Windows.Forms.Panel p in aboutSettingsTabControl.TabPages)
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
                //configList.BorderStyle = BorderStyle.FixedSingle;
                helpDisplay.BackColor = Color.Black;
                helpDisplay.ForeColor = Color.Gray;
                commandLineHelpDisplay.BackColor = Color.Black;
                commandLineHelpDisplay.ForeColor = Color.Gray;
            }*/
            //Ping main form that the about box/help/settings dialog is open
            Program.f1.abopen = true;
            //Hide settings tabs
            if (!SettingTab)
            {
                updatePanel.Dispose();
                simulatorSettingsPanel.Dispose();
                appearancePanel.Dispose();
                rndFactButton.Visible = Program.gs.EnableEggs;
            }
            //Hide help/about tabs and get settings
            if (SettingTab)
            {
                aboutPanel.Dispose();
                commandLinePanel.Dispose();
                helpPanel.Dispose();
                eggHunterButton.Checked = Program.gs.EnableEggs;
                darkDetectCheck.Checked = Program.gs.AutoDark;
                accentBox.SelectedIndex = (int)Program.gs.ColorScheme;
                darkMode.Checked = Program.gs.NightTheme;
                if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.HighQualityBicubic) { scalingModeBox.SelectedIndex = 0; }
                if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.HighQualityBilinear) { scalingModeBox.SelectedIndex = 1; }
                if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.Bilinear) { scalingModeBox.SelectedIndex = 4; }
                if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.Bicubic) { scalingModeBox.SelectedIndex = 3; }
                if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.NearestNeighbour) { scalingModeBox.SelectedIndex = 2; }
                hideInFullscreenButton.Checked = !Program.gs.ShowCursor;
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
                autoUpdateRadio.Checked = Program.gs.AutoUpdate;
                noUpdatesRadio.Checked = !Program.gs.AutoUpdate;
                darkDetectCheck.Checked = Program.gs.AutoDark;
                hashBox.Checked = Program.gs.HashVerify;
                updateImmediatelyRadio.Checked = !Program.gs.PostponeUpdate;
                updateOnCloseRadio.Checked = Program.gs.PostponeUpdate;
                primaryServerBox.Text = Program.gs.UpdateServer;
                if (!((primaryServerBox.Text == "http://nossl.markustegelane.eu/app") || (primaryServerBox.Text == "http://markustegelane.eu/app")))
                {
                    primaryServerBox.Enabled = true;
                }
            }
            if (aboutSettingsTabControl.SelectedTab.Text == "Simulator settings")
            {
                //Loads simulator configuration
                eggHunterButton.Checked = Program.gs.EnableEggs;
                switch (Program.gs.ScaleMode)
                {
                    case GlobalSettings.ScaleModes.HighQualityBicubic:
                        scalingModeBox.SelectedIndex = 0;
                        break;
                    case GlobalSettings.ScaleModes.HighQualityBilinear:
                        scalingModeBox.SelectedIndex = 1;
                        break;
                    case GlobalSettings.ScaleModes.Bilinear:
                        scalingModeBox.SelectedIndex = 4;
                        break;
                    case GlobalSettings.ScaleModes.Bicubic:
                        scalingModeBox.SelectedIndex = 3;
                        break;
                    case GlobalSettings.ScaleModes.NearestNeighbour:
                        scalingModeBox.SelectedIndex = 2;
                        break;
                }
                switch (Program.gs.DisplayMode)
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
                hideInFullscreenButton.Checked = !Program.gs.ShowCursor;
                configList.Items.Clear();
                randomnessCheckBox.Checked = Program.gs.Randomness;
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
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
            helpDisplay.Text = "How to quickly get help?\n\nFor items that have [?] at the end, you can just hover over them for more information.".Replace("\n", Environment.NewLine);
        }

        private void QuickHelp_Purpose(object sender, EventArgs e)
        {
            helpDisplay.Text = "What is the purpose of this program?\n\nThis program can be used as a way of screenshotting bluescreens without actually crashing your computer or messing with virtual machines. You can also use this program for pranking purposes (no harm will be done to the system).".Replace("\n", Environment.NewLine);
        }

        private void QuickHelp_SystemRequirements(object sender, EventArgs e)
        {
            helpDisplay.Text = "We're no strangers to love\r\nYou know the rules and so do I (do I)\r\nA full commitment's what I'm thinking of\r\nYou wouldn't get this from any other guy\r\n\r\nI just wanna tell you how I'm feeling\r\nGotta make you understand\r\n\r\nNever gonna give you up\r\nNever gonna let you down\r\nNever gonna run around and desert you\r\nNever gonna make you cry\r\nNever gonna say goodbye\r\nNever gonna tell a lie and hurt you\r\n\r\nWe've known each other for so long\r\nYour heart's been aching, but you're too shy to say it (say it)\r\nInside, we both know what's been going on (going on)\r\nWe know the game and we're gonna play it\r\n\r\nAnd if you ask me how I'm feeling\r\nDon't tell me you're too blind to see\r\n\r\nNever gonna give you up\r\nNever gonna let you down\r\nNever gonna run around and desert you\r\nNever gonna make you cry\r\nNever gonna say goodbye\r\nNever gonna tell a lie and hurt you\r\n\r\nNever gonna give you up\r\nNever gonna let you down\r\nNever gonna run around and desert you\r\nNever gonna make you cry\r\nNever gonna say goodbye\r\nNever gonna tell a lie and hurt you\r\n\r\n(Ooh, give you up)\r\n(Ooh, give you up)\r\n(Ooh) Never gonna give, never gonna give (give you up)\r\n(Ooh) Never gonna give, never gonna give (give you up)\r\n\r\nWe've known each other for so long\r\nYour heart's been aching, but you're too shy to say it (to say it)\r\nInside, we both know what's been going on (going on)\r\nWe know the game and we're gonna play it\r\n\r\nI just wanna tell you how I'm feeling\r\nGotta make you understand\r\n\r\nNever gonna give you up\r\nNever gonna let you down\r\nNever gonna run around and desert you\r\nNever gonna make you cry\r\nNever gonna say goodbye\r\nNever gonna tell a lie and hurt you\r\n\r\nNever gonna give you up\r\nNever gonna let you down\r\nNever gonna run around and desert you\r\nNever gonna make you cry\r\nNever gonna say goodbye\r\nNever gonna tell a lie and hurt you\r\n\r\nNever gonna give you up\r\nNever gonna let you down\r\nNever gonna run around and desert you\r\nNever gonna make you cry\r\nNever gonna say goodbye\r\nNever gonna tell a lie and hurt you";
            //helpDisplay.Text = "System requirements:\n\nOS: Windows XP or later (Windows 8 or later recommended)\n150MB of available RAM (recommended minimum)\n50MB of available RAM (absolute minimum)\nx86 or compatible processor\nRead-Write storage media\nMicrosoft.NET Framework 4.0\n1000bps or  internet connection (for updates and online help functionality)\nScreen resolution: 1024x720 or higher (1280x720 or higher recommended)".Replace("\n", Environment.NewLine);
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
                if (File.Exists(Environment.GetEnvironmentVariable("USERPROFILE") + "\\bssp2_firstlaunch.txt"))
                {
                    File.Delete(Environment.GetEnvironmentVariable("USERPROFILE") + "\\bssp2_firstlaunch.txt");
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
            if (Program.DoWeHaveInternet(1000))
            {
                if (File.Exists("vercheck.txt"))
                {
                    File.Delete("vercheck.txt");
                }
                UpdateInterface ui = new UpdateInterface();
                ui.DownloadFile(Program.gs.UpdateServer + "/bssp_version.txt", "vercheck.txt");
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
            Program.gs.AutoUpdate = autoUpdateRadio.Checked;
        }

        private void UpdateWhenDoneSetup(object sender, EventArgs e)
        {
            Program.gs.PostponeUpdate = updateImmediatelyRadio.Checked;
        }

        private void HashcheckSetup(object sender, EventArgs e)
        {
            Program.gs.HashVerify = hashBox.Checked;
        }

        private void ScalingModeSetup(object sender, EventArgs e)
        {
            if (scalingModeBox.SelectedIndex == 0)
            {
                Program.gs.ScaleMode = GlobalSettings.ScaleModes.HighQualityBicubic;
            }
            else if (scalingModeBox.SelectedIndex == 1)
            {
                Program.gs.ScaleMode = GlobalSettings.ScaleModes.HighQualityBilinear;
            }
            else if (scalingModeBox.SelectedIndex == 2)
            {
                Program.gs.ScaleMode = GlobalSettings.ScaleModes.NearestNeighbour;
            }
            else if (scalingModeBox.SelectedIndex == 4)
            {
                Program.gs.ScaleMode = GlobalSettings.ScaleModes.Bilinear;
            }
            else if (scalingModeBox.SelectedIndex == 3)
            {
                Program.gs.ScaleMode = GlobalSettings.ScaleModes.Bicubic;
            }
        }

        private void CursorVisibilitySetup(object sender, EventArgs e)
        {
            Program.gs.ShowCursor = hideInFullscreenButton.Checked;
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
            Program.gs.EnableEggs = eggHunterButton.Checked;
        }

        private void OnMeResized(object sender, EventArgs e)
        {
        }

        private void ConfigSelector(object sender, MaterialListBoxItem e)
        {
            if (e != null)
            {
                osName.Text = string.Format("Selected configuration: {0}", Program.bluescreens[configList.SelectedIndex].GetString("friendlyname"));
            } else
            {
                osName.Text = "Select a configuration to modify/remove it";
            }
            resetButton.Enabled = (e != null);
            resetHackButton.Enabled = (e != null);
            removeCfg.Enabled = (e != null);
        }

        private void ConfigHackEraser(object sender, EventArgs e)
        {
            if (configList.SelectedItem != null)
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
            } else
            {
                if (MessageBox.Show("Would you restore default configurations?", "Seecret factory defaults option", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    configList.Items.Clear();
                    Program.bluescreens.Clear();
                    Program.ReRe();
                    foreach (BlueScreen bs in Program.bluescreens)
                    {
                        configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                    }
                    MessageBox.Show("Configurations were reset", "Seecret factory defaults", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No action was performed.", "Seecret factory defaults", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ResetConfig(object sender, EventArgs e)
        {
            if (configList.SelectedItem != null)
            {
                if (MessageBox.Show("Warning: This will remove any setting set under the 'additional options' menu. Other settings set in the main screen will remain the same. ANY UNSAVED CHANGES WILL BE LOST!!! Are you sure you want to continue?", "Reset hacks", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Program.bluescreens[configList.SelectedIndex].ClearAllTitleTexts();
                    Program.bluescreens[configList.SelectedIndex].SetOSSpecificDefaults();
                    MessageBox.Show("Hacks were reset", "Reset hacks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Reason: The user clicked no", "No changes were made", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } else
            {
                if (MessageBox.Show("Would you like to reset everything under the 'additional options' menu to defaults for all configurations?", "Seecret factory hacks defaults", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    configList.Items.Clear();
                    foreach (BlueScreen bs in Program.bluescreens)
                    {
                        bs.ClearAllTitleTexts();
                        bs.SetOSSpecificDefaults();
                    }
                    MessageBox.Show("Hacks were reset", "Seecret factory hacks defaults", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No action was performed.", "Seecret factory hacks defaults", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ConfigEraser(object sender, EventArgs e)
        {
            if (configList.SelectedItem != null)
            {
                if (MessageBox.Show("Warning: This will remove this configuration from the repository. ANY UNSAVED CHANGES WILL BE LOST!!! Are you sure you want to do that?", "Delete bugcheck", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    Program.bluescreens.Remove(Program.bluescreens[configList.SelectedIndex]);
                    configList.Items.Clear();
                    foreach (BlueScreen bs in Program.bluescreens)
                    {
                        configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                    }
                    MessageBox.Show("Config removed successfully", "Configuration deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Reason: The user clicked no", "No changes were made", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } else
            {
                if (MessageBox.Show("Would you like to remove all configurations?", "Nuke mode", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    configList.Items.Clear();
                    Program.bluescreens.Clear();
                    resetHackButton.Enabled = false;
                    resetButton.Enabled = false;
                    removeCfg.Enabled = false;
                    MessageBox.Show("Configurations erased. All configurations must be re-added manually.\nNote: Do not use the main interface before adding any configurations!", "Nuke mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("No action was performed.", "Nuke mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AddConfig(object sender, EventArgs e)
        {
            if (new AddBluescreen().ShowDialog() == DialogResult.OK)
            {
                configList.Items.Clear();
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                }
            }
        }

        private void MultiDisplaySetup(object sender, EventArgs e)
        {
            switch (multiDisplayBox.SelectedIndex)
            {
                case 0: Program.gs.DisplayMode = "none"; break;
                case 1: Program.gs.DisplayMode = "blank"; break;
                case 2: Program.gs.DisplayMode = "mirror"; break;
                case 3: Program.gs.DisplayMode = "freeze"; break;
            }
        }

        private bool CheckExist(string os1, string os2 = "", string os3 = "")
        {
            foreach (BlueScreen bs in Program.bluescreens)
            {
                if ((bs.GetString("os") == os1) || (bs.GetString("os") == os2) || (bs.GetString("os") == os3))
                {
                    return true;
                }
            }
            return false;
        }

        // This function is used create version 1.x compatible save file
        private string LegacySave()
        {
            string filedata = "*** Blue screen simulator plus 1.11 ***";
            BlueScreen winmodern = Program.bluescreens[0];
            BlueScreen wineight = Program.bluescreens[0];
            BlueScreen vista7 = Program.bluescreens[0];
            BlueScreen xp = Program.bluescreens[0];
            BlueScreen win2k = Program.bluescreens[0];
            BlueScreen winnt = Program.bluescreens[0];
            BlueScreen ninexme = Program.bluescreens[0];
            BlueScreen ce = Program.bluescreens[0];
            BlueScreen threeone = Program.bluescreens[0];
            bool bsdefined = false;
            // select winModern (Windows 10 or 11)
            if (!CheckExist("Windows 10", "Windows 11")) { return " * ERROR * "; }
            while (!bsdefined)
            {
                foreach (BlueScreen bs in Program.bluescreens) {if ((bs.GetString("os") == "Windows 11") || (bs.GetString("os") == "Windows 10")) { if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for modern blue screens and text data for Windows 10 blue screen:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { winmodern = bs; bsdefined = true; break; } } }
            }

            if (!CheckExist("Windows 8/8.1")) { return " * ERROR * "; }
            bsdefined = false;
            while (!bsdefined)
            {
                foreach (BlueScreen bs in Program.bluescreens) { if ((bs.GetString("os") == "Windows 11") || (bs.GetString("os") == "Windows 10") || (bs.GetString("os") == "Windows 8/8.1")) { if (MessageBox.Show(string.Format("Would you like to use the following blue screen's text data for Windows 8/8.1 blue screens:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { wineight = bs; bsdefined = true; break; } } }
            }


            if (!CheckExist("Windows Vista", "Windows 7")) { return " * ERROR * "; }
            bsdefined = false;
            while (!bsdefined)
            {
                foreach (BlueScreen bs in Program.bluescreens) { if ((bs.GetString("os") == "Windows Vista") || (bs.GetString("os") == "Windows 7")) { if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows Vista/7 blue screens:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { vista7 = bs; bsdefined = true; break; } } }
            }
            if (!CheckExist("Windows XP")) { return " * ERROR * "; }
            bsdefined = false;
            while (!bsdefined)
            {
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    if ((bs.GetString("os") == "Windows XP"))
                    {
                        if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows XP blue screen:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            xp = bs; bsdefined = true;  break;
                        }
                    }
                }
            }
            if (!CheckExist("Windows 2000")) { return " * ERROR * "; }
            bsdefined = false;
            while (!bsdefined)
            {
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    if ((bs.GetString("os") == "Windows 2000"))
                    {
                        if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows 2000 blue screen:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            win2k = bs; bsdefined = true; break;
                        }
                    }
                }
            }
            bsdefined = false;
            if (!CheckExist("Windows NT 3.x/4.0")) { return " * ERROR * "; }
            while (!bsdefined)
            {
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    if ((bs.GetString("os") == "Windows NT 3.x/4.0"))
                    {
                        if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows NT 3.x/4.0 blue screen:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            winnt = bs; bsdefined = true; break;
                        }
                    }
                }
            }
            bsdefined = false;
            if (!CheckExist("Windows 9x/Me")) { return " * ERROR * "; }
            while (!bsdefined)
            {
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    if ((bs.GetString("os") == "Windows 9x/Me"))
                    {
                        if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows 9x/Me blue screens:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ninexme = bs; bsdefined = true; break;
                        }
                    }
                }
            }
            bsdefined = false;
            if (!CheckExist("Windows CE")) { return " * ERROR * "; }
            while (!bsdefined)
            {
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    if ((bs.GetString("os") == "Windows CE"))
                    {
                        if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows CE blue screens:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ce = bs; bsdefined = true; break;
                        }
                    }
                }
            }
            bsdefined = false;
            if (!CheckExist("Windows 3.1x")) { return " * ERROR * "; }
            while (!bsdefined)
            {
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    if ((bs.GetString("os") == "Windows 3.1x"))
                    {
                        if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows 3.1x CTRL+ALT+DELETE screen:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            threeone = bs; bsdefined = true; break;
                        }
                    }
                }
            }
            filedata += string.Format("\nFACE {0}", winmodern.GetString("emoticon"));
            filedata += string.Format("\nMODERN {0}:{1}:{2},{3}:{4}:{5}", winmodern.GetTheme(true).R, winmodern.GetTheme(true).G, winmodern.GetTheme(true).B, winmodern.GetTheme(false).R, winmodern.GetTheme(false).G, winmodern.GetTheme(false).B);
            filedata += string.Format("\nW2K {0}:{1}:{2},{3}:{4}:{5}", win2k.GetTheme(true).R, win2k.GetTheme(true).G, win2k.GetTheme(true).B, win2k.GetTheme(false).R, win2k.GetTheme(false).G, win2k.GetTheme(false).B);
            filedata += string.Format("\nNT34 {0}:{1}:{2},{3}:{4}:{5}", winnt.GetTheme(true).R, winnt.GetTheme(true).G, winnt.GetTheme(true).B, winnt.GetTheme(false).R, winnt.GetTheme(false).G, winnt.GetTheme(false).B);
            filedata += string.Format("\nW9XME {0}:{1}:{2},{3}:{4}:{5}", ninexme.GetTheme(true).R, ninexme.GetTheme(true).G, ninexme.GetTheme(true).B, ninexme.GetTheme(false).R, ninexme.GetTheme(false).G, ninexme.GetTheme(false).B);
            filedata += string.Format("\nW9XME_HL {0}:{1}:{2},{3}:{4}:{5}", ninexme.GetTheme(true, true).R, ninexme.GetTheme(true, true).G, ninexme.GetTheme(true, true).B, ninexme.GetTheme(false, true).R, ninexme.GetTheme(false, true).G, ninexme.GetTheme(false, true).B);
            filedata += "\n--STRINGBUILD START--\n";
            filedata += string.Format("{0}//{1}//{2}//{3}//{4}//{5}//{6}//{7}//{8}//{9}//{10}//{11}//{12}//{13}//{14}//{15}//{16}//{17}//{18}//{19}//{20}//{21}//{22}//{23}//{24}//{25}//{26}//{27}//{28}//{29}//{30}//{31}//{32}//{33}//{34}//{35}//{36}//{37}//{38}//{39}//{40}//{41}//{42}//{43}//{44}//--STRINGBUILD END--",
                        ninexme.GetTitles()["Main"],
                        ninexme.GetTitles()["System is busy"],
                        ninexme.GetTitles()["Warning"],
                        ninexme.GetTexts()["System error"],
                        ninexme.GetTexts()["Prompt"],
                        threeone.GetTexts()["No unresponsive programs"],
                        ninexme.GetInt("blink_speed"),
                        ninexme.GetTexts()["Application error"],
                        ninexme.GetTexts()["Driver error"],
                        ninexme.GetTexts()["System is busy"],
                        ninexme.GetTexts()["System is unresponsive"],
                        ce.GetTexts()["A problem has occurred..."],
                        ce.GetTexts()["CTRL+ALT+DEL message"],
                        ce.GetTexts()["Technical information"],
                        ce.GetTexts()["Technical information formatting"],
                        ce.GetTexts()["Restart message"],
                        ce.GetInt("timer"),
                        winnt.GetTexts()["Error code formatting"],
                        winnt.GetTexts()["CPUID formatting"],
                        winnt.GetTexts()["Stack trace heading"],
                        winnt.GetTexts()["Stack trace table formatting"],
                        winnt.GetTexts()["Memory address dump heading"],
                        winnt.GetTexts()["Memory address dump table"],
                        winnt.GetTexts()["Troubleshooting text"],
                        win2k.GetTexts()["Error code formatting"],
                        win2k.GetTexts()["Troubleshooting introduction"],
                        xp.GetTexts()["A problem has been detected..."],
                        win2k.GetTexts()["Troubleshooting text"],
                        win2k.GetTexts()["Additional troubleshooting information"],
                        xp.GetTexts()["Troubleshooting introduction"],
                        xp.GetTexts()["Troubleshooting"],
                        xp.GetTexts()["Technical information"],
                        xp.GetTexts()["Technical information formatting"],
                        xp.GetTexts()["Physical memory dump"],
                        xp.GetTexts()["Technical support"] + "\n" + vista7.GetTexts()["Technical support"],
                        vista7.GetTexts()["Physical memory dump"],
                        wineight.GetTexts()["Information text with dump"],
                        wineight.GetTexts()["Information text without dump"],
                        wineight.GetTexts()["Error code"],
                        winmodern.GetTexts()["Information text without dump"],
                        winmodern.GetTexts()["Information text with dump"],
                        winmodern.GetTexts()["Additional information"],
                        winmodern.GetTexts()["Culprit file"],
                        winmodern.GetTexts()["Progress"],
                        winmodern.GetTexts()["Error code"]);
            filedata += "\n--FONT START--";
            Font textfont = winmodern.GetFont();
            float textsize = textfont.Size;
            Font emotifont = new Font(winmodern.GetFont().FontFamily, textsize * 5f, winmodern.GetFont().Style);
            Font modernDetailFont = new Font(winmodern.GetFont().FontFamily, textsize * 0.55f, winmodern.GetFont().Style);

            filedata += string.Format("\nemotiFont: {0},Bold={1},Italic={2},Underline={3}", emotifont.ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ","), winmodern.GetFont().Bold, winmodern.GetFont().Italic, winmodern.GetFont().Underline);
            filedata += string.Format("\nmodernTextFont: {0},Bold={1},Italic={2},Underline={3}", textfont.ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ","), winmodern.GetFont().Bold, winmodern.GetFont().Italic, winmodern.GetFont().Underline);
            filedata += string.Format("\nmodernDetailFont: {0},Bold={1},Italic={2},Underline={3}", modernDetailFont.ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ","), winmodern.GetFont().Bold, winmodern.GetFont().Italic, winmodern.GetFont().Underline);
            filedata += string.Format("\nlabel50: {0},Bold={1},Italic={2},Underline={3}", vista7.GetFont().ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ","), vista7.GetFont().Bold, vista7.GetFont().Italic, vista7.GetFont().Underline);
            filedata += string.Format("\nlabel49: {0},Bold={1},Italic={2},Underline={3}", xp.GetFont().ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ","), xp.GetFont().Bold, xp.GetFont().Italic, xp.GetFont().Underline);
            filedata += "\nlabel39: Lucida Console,Size=8,Units=3,GdiCharSet=1,GdiVerticalFont=False,Bold=True,Italic=False,Underline=False";
            filedata += string.Format("\nlabel26: {0},Bold={1},Italic={2},Underline={3}", ce.GetFont().ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ","), ce.GetFont().Bold, ce.GetFont().Italic, ce.GetFont().Underline);
            filedata += "\n--FONT END--";
            filedata += "\n--MISC START--";
            filedata += string.Format("\nqrSize: {0}", winmodern.GetInt("qr_size"));
            if (winmodern.GetString("qr_file").Contains("local:"))
            {
                if (winmodern.GetString("qr_file").Contains("local:0"))
                {
                    filedata += "\nqrType: Default";
                } else
                {
                    filedata += "\nqrType: Transparent";
                }
            } else
            {
                filedata += "\nqrType: Custom";
            }
            filedata += string.Format("\nqrPath: {0}", winmodern.GetString("qr_file"));
            filedata += "\n--MISC END--\n";
            return filedata;
        }

        private void SaveData(string filename)
        {
            string filedata;
            if (saveBsconfig.FilterIndex == 1)
            {
                filedata = "*** Blue screen simulator plus 2.1 ***";
            } else if (saveBsconfig.FilterIndex == 2)
            {
                filedata = "*** Blue screen simulator plus 2.0 ***";
            } else
            {
                filedata = LegacySave();
                if (filedata != " * ERROR * ")
                {
                    File.WriteAllText(filename, filedata, System.Text.Encoding.Unicode);
                    MessageBox.Show("Blue screen configuration saved successfully", "Blue screen simulator 1.x configuration file creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Blue screen configuration was not saved, because an error occoured.\n\nBefore attempting to save to 1.x format, make sure that the following operating systems exist in your configuration list:\n\nWindows 10 and/or 11\nWindows Vista or Windows 7\nWindows XP\nWindows CE\nWindows NT 3.x/4.0\nWindows 9x/Me\nWindows 3.1x", "Blue screen simulator 1.x configuration file creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finished = true;
                Thread.CurrentThread.Abort();
            }
            foreach (BlueScreen bs in Program.bluescreens)
            {
                if (saveBsconfig.FilterIndex == 1)
                {
                    filedata += "\n\n\n#" + bs.GetString("os") + "\n\n";
                } else
                {
                    filedata += "\n\n\n#" + bs.GetString("os").Replace("Windows Vista", "Windows Vista/7").Replace("Windows 7", "Windows Vista/7") + "\n\n";
                }
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
                if ((bs.AllProgress().Count > 0) && (saveBsconfig.FilterIndex == 1))
                {
                    filedata += "\n\n[progress]";
                    foreach (KeyValuePair<int, int> entry in bs.AllProgress())
                    {
                        filedata += string.Format("\n{0}={1};", entry.Key, entry.Value);
                    }
                }
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
                        if (!((entry.Key == "font_support") && (bs.GetString("os") == "Windows 2000") && (saveBsconfig.FilterIndex != 1)))
                        {
                            filedata += "\n" + entry.Key + "=" + entry.Value.ToString() + ";";
                        }
                        else
                        {
                            // makes sure that Windows 2k blue screens have font support if saving in older format
                            filedata += "\nfont_support=True;";
                        }
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

                if (bs.GetBool("font_support") || ((saveBsconfig.FilterIndex == 2) && (bs.GetString("os") == "Windows 2000")))
                {
                    if (bs.GetString("os") != "Windows 2000")
                    {
                        filedata += "\n\n[format]";
                        filedata += "\nfontfamily=" + bs.GetFont().FontFamily.Name + ";";
                        filedata += "\nsize=" + bs.GetFont().Size.ToString() + ";";
                        filedata += "\nstyle=" + bs.GetFont().Style.ToString() + ";";
                    } else
                    {
                        // Added to support saving to version 2.0 format
                        filedata += "\n\n[format]";
                        filedata += "\nfontfamily=Lucida Console;";
                        filedata += "\nsize=8;";
                        filedata += "\nstyle=Bold;";
                    }
                }
            }
            File.WriteAllText(filename, filedata);
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
                Program.bluescreens.Add(new BlueScreen("Windows 7"));
                Program.bluescreens.Add(new BlueScreen("Windows 8/8.1"));
                Program.bluescreens.Add(new BlueScreen("Windows 10"));
                foreach (string fileline in filelines)
                {
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
                Program.bluescreens[7].ClearProgress();
                Program.bluescreens[7].SetText("Information text with dump", stringlist[36].Replace("\n", Environment.NewLine));
                Program.bluescreens[7].SetText("Information text without dump", stringlist[37].Replace("\n", Environment.NewLine));
                Program.bluescreens[7].SetText("Error code", stringlist[38].Replace("\n", Environment.NewLine));
                if (randomnessCheckBox.Checked)
                {
                    Program.bluescreens[7].SetDefaultProgression();
                }

                // Windows 10
                Program.bluescreens[8].ClearProgress();
                Program.bluescreens[8].SetText("Information text with dump", stringlist[40].Replace("\n", Environment.NewLine));
                Program.bluescreens[8].SetText("Information text without dump", stringlist[39].Replace("\n", Environment.NewLine));
                Program.bluescreens[8].SetText("Additional information", stringlist[41].Replace("\n", Environment.NewLine));
                Program.bluescreens[8].SetText("Culprit file", stringlist[42].Replace("\n", Environment.NewLine));
                Program.bluescreens[8].SetText("Progress", stringlist[43].Replace("\n", Environment.NewLine));
                Program.bluescreens[8].SetText("Error code", stringlist[44].Replace("\n", Environment.NewLine));
                if (randomnessCheckBox.Checked)
                {
                    Program.bluescreens[8].SetDefaultProgression();
                }
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
            bool added_randomness = false;
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
                    // replace Windows Vista/7 with Windows 7 for backwards compatibility reasons
                    string os_name = subsection_tokens[0].Replace("\n", "").Replace("Windows Vista/7", "Windows 7");
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
                                        case "progress":
                                            added_randomness = true;
                                            bs.SetProgression(int.Parse(key), int.Parse(value));
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
                    if (!randomnessCheckBox.Checked)
                    {
                        added_randomness = true;
                    }
                    if (!added_randomness)
                    {
                        bs.SetDefaultProgression();
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
            configList.Items.Clear();
            foreach (BlueScreen bs in Program.bluescreens)
            {
                configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
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
            configList.Items.Clear();
            foreach (BlueScreen bs in Program.bluescreens)
            {
                configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
            }
        }

        private void ChangeUpdateServer(object sender, EventArgs e)
        {
            Program.gs.UpdateServer = primaryServerBox.Text;
        }

        private void SetToPrimaryServer(object sender, EventArgs e)
        {
            primaryServerBox.Enabled = false;
            primaryServerBox.Text = "http://markustegelane.eu/app";
        }

        private void SetToBackupServer(object sender, EventArgs e)
        {
            primaryServerBox.Enabled = false;
            primaryServerBox.Text = "http://nossl.markustegelane.eu/app";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            primaryServerBox.Enabled = true;
        }

        private void UserManualButtonClick(object sender, EventArgs e)
        {
            if (Program.DoWeHaveInternet(1000))
            {
                // online user manual
                Process p = new Process();
                p.StartInfo.FileName = "https://markustegelane.eu/bssp/help.pdf";
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
                configList.Items.Clear();
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                }
                loadBsconfig.FileName = "";
                saveBsconfig.FileName = "";
                checkIfLoadedSaved.Enabled = false;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "https://github.com/MarkusMaal/BlueScreenSimulatorPlus";
            p.Start();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            TextView tv = new TextView
            {
                Text = Properties.Resources.COPYING,
                Title = "Copying"
            };
            tv.ShowDialog();
            tv.Dispose();
        }

        /* DONE: Remove devbuild text from the stable release 2.1 */
        private void Button4_Click(object sender, EventArgs e)
        {
            if (Program.gs.EnableEggs)
            {
                string[] tips =
                {
                "Material Design is a design language developed by Google in 2014!",
                "You can close a blue screen by pressing ALT+F4",
                "There is a crash screen for a program that simulates crash screens, right?",
                "The codename came from a song that was playing in the background during the development process",
                "If Microsoft decides to change their error screens, I'll push an update that adds these changes",
                "Configuration files store every property about all error screens",
                "Windows Vista/7 blue screen scrolls, when there is too much information on screen",
                "There are rainbow easter eggs for Windows XP, Vista, 7, CE, and 1.x/2.x blue screens",
                "In prank mode, the watermark on a blue screen is disabled automatically",
                "There are two error screens in this program, that technically aren't blue screens",
                "This program, for the most part, also works in ReactOS, which is an open source Windows clone based on reverse engineering",
                "The first Windows XP bluescreen I ever saw displayed DRIVER_IRQL_NOT_LESS_OR_EQUAL as the error code",
                "You can also use the Enter key to close Windows 9x bluescreens",
                "Microsoft originally planned to replace a blue screen with a black one as early as Windows 8",
                "Every major Windows release, up until Windows 11, has had some sort of a blue screen",
                "Blue is a color that symbolises peace",
                "Initially, this version was going to be 2.2, but due to large changes was renamed to 3.0",
                "Windows 2000 blue screen didn't use rasterized fonts in previous versions, because I figured it looked 'close enough' to the original",
                "If you use the 'choose' button when setting a culprit file, you might see some weird filenames...",
                "The background of the logo graphic in the about screen displays two major colors used by bugcheck screens - black and blue",
                "This program isn't a copy of FlyTech's work, instead it was developed from scratch, because of the limitations I saw when trying out FlyTech's blue screen simulator.",
                "You can use progress tuner to make more realistic progress indicators for modern blue screens",
                "There is no random factoid here",
                "target: void"
            };
                Random r = new Random();
                MessageBox.Show(tips[r.Next(0, tips.Length - 1)], "Random fact", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            ProgressTuner pt = new ProgressTuner();
            pt.Show();
            MessageBox.Show("Testing ended");
        }

        private void RandomnessCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.Randomness = randomnessCheckBox.Checked;
        }

        private void SelectAllBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllBox.Checked)
            {
                resetHackButton.Enabled = true;
                resetButton.Enabled = true;
                removeCfg.Enabled = true;
                removeCfg.Text = "Remove configs [?]";
                configList.Enabled = false;
                configList.SelectedItem = null;
                helpTip.SetToolTip(resetHackButton, "Deletes everything under the 'additional options' menu for all configurations");
                helpTip.SetToolTip(resetButton, "Reset all settings within all configurations");
                helpTip.SetToolTip(removeCfg, "Removes all configurations. This is useful, if you're making your own custom skin packs and want only a few operating systems to be visible.");
                osName.Text = "All selected";
                configList.SelectedItems.Clear();
                return;
            }
            resetHackButton.Enabled = false;
            resetButton.Enabled = false;
            removeCfg.Enabled = false;
            configList.Enabled = true;
            configList.SelectedItems.Clear();
            removeCfg.Text = "Remove config [?]";
            helpTip.SetToolTip(resetHackButton, "Deletes everything under the 'additional options' menu for this configuration");
            helpTip.SetToolTip(resetButton, "Reset all settings in this configuration");
            helpTip.SetToolTip(removeCfg, "Removes the configuration, meaning it will no longer be accessible in the main menu or any other part of the program.");
            osName.Text = "Select a configuration to modify/remove it";
        }

        private void LogoPictureBox_Click(object sender, EventArgs e)
        {
            if (Program.gs.EnableEggs)
            {
                if (r.Next(0, 255) == 13)
                {
                    logoPictureBox.Image = Properties.Resources.success;
                    foreach (BlueScreen bs in Program.bluescreens)
                    {
                        if (bs.GetString("os") == "Windows 10")
                        {
                            bs.SetText("Information text with dump", "Your P");
                            bs.SetText("Information text without dump", "Your P");
                            bs.SetText("Additional information", "");
                            bs.SetText("Culprit file", "");
                            bs.SetText("Error code", "");
                            bs.SetText("Progress", "");
                            bs.SetBool("qr", false);
                        }
                    }
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(Program.changelog + "\n\nYou can find a more detailed changelog in the official BlueScreenSimulatorPlus GitHub page.", "What's new?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void darkDetectCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.AutoDark = darkDetectCheck.Checked;
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            Program.loadfinished = false;
            Gen g = new Gen();
            g.Show();
            Program.load_message = "Testing...";
            Thread dummyThread = new Thread(new ThreadStart(() => {
                for (int i = 0; i <= 100; i++)
                {
                    Program.load_progress = i;
                    Thread.Sleep(50);
                }
                Thread.Sleep(150);
                Program.loadfinished = true;
            }));
            dummyThread.Start();
        }

        private void accentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.gs.ColorScheme = (GlobalSettings.ColorSchemes)accentBox.SelectedIndex;
            Program.gs.ApplyScheme();
        }

        private void darkMode_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.NightTheme = darkMode.Checked;
            if (darkMode.Checked)
            {
                Program.f1.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                Program.f1.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            Program.f1.RelocateButtons();
        }

        private void rtlSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Program.f1.RightToLeft = rtlSwitch.Checked ? RightToLeft.Yes : RightToLeft.Inherit;
        }
    }
}

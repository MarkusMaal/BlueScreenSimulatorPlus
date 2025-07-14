using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin2Framework;
using MaterialSkin2Framework.Controls;
using Microsoft.Win32;
using SimulatorDatabase;
using UltimateBlueScreenSimulator.Forms.Interfaces;
using Control = System.Windows.Forms.Control;
using Panel = System.Windows.Forms.Panel;

namespace UltimateBlueScreenSimulator
{
    public partial class NewUI : MaterialForm
    {


        internal MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        public readonly bool betabuild = false;
        public bool abopen = false;
        private bool doubleCheck = false;

        public NewUI()
        {
            InitializeComponent();
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800, Primary.Blue900,
                Primary.Blue400, Accent.Indigo700,
                TextShade.WHITE
            );
            //Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
        }

        internal void RelocateButtons()
        {
            button1.Location = new Point(this.Width - button1.Width - 10, this.Height - button1.Height - 10);
            button3.Location = new Point(button1.Location.X - (button1.Width) - 5, button1.Location.Y);
            label7.Location = new Point(label7.Location.X, button1.Location.Y + label7.Height / 2);
            flowLayoutPanel1.BackColor = this.BackColor;
            nineXmessage.BackColor = this.BackColor;
            panel1.BackColor = this.BackColor;
            panel2.BackColor = this.BackColor;
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                c.BackColor = this.BackColor;
            }
        }

        private void NewUi1_Load(object sender, EventArgs e)
        {
            RelocateButtons();
            aboutSettingsButton.Visible = Program.gs.DevBuild;
            UIActions.InitializeForm(this);
            try
            {
                bool DarkMode = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1) == 0;
                Program.gs.NightTheme = Program.gs.AutoDark && DarkMode;
                if (Program.gs.AutoDark && DarkMode)
                {
                    materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                    RelocateButtons();
                }
            }
            catch
            {
                Program.gs.Log("Error", "Error detecting dark mode. It's possible that this host OS does not support dark mode.");
                Enabled = true;
            }
            Program.gs.ApplyScheme();
            if (Program.gs.AutoUpdate)
            {
                UIActions.CheckUpdates(this);
            }
            if (Program.gs.QuickHelp) { return; }
            UIActions.RemoveQuestionMark(materialTabControl1, Program.gs.QuickHelp);
        }

        private void NewUi1_ResizeEnd(object sender, EventArgs e)
        {
            int sub = 120;
            errorCode.Width = Width - sub;
            WXOptions.Width = Width - sub;
            ntPanel.Width = Width - sub;
            nineXmessage.Width = Width - sub;
            winPanel.Width = Width - sub;
            errorCode.Width = Width - sub;
            flowLayoutPanel4.Width = Width - sub;
            RelocateButtons();
        }


        private void WindowVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            quickHelp.Active = Program.gs.QuickHelp;
            if (Visible)
            {
                UIActions.HideSelection(this);
            }

            try
            {
                // set current bluescreen
                if (!Program.gs.DisplayOne)
                {
                    UIActions.me = Program.templates.GetAt(Program.templates.Count - 1 - windowVersion.SelectedIndex);
                }
                UIActions.ResetSelection(this, UIActions.me);
            }
            catch (Exception ex) when (!Debugger.IsAttached)
            {
                UIActions.me.Crash(ex, "OrangeScreen");
            }
        }

        public void ShowBlueScreen()
        {
            if (windowVersion.Items.Count < 1)
            {
                Program.loadfinished = true;
                if (Program.gs.EnableEggs && (Program.gs.ErrorCode != 500))
                {
                    MessageBox.Show("Please select a Windows version! Also, how in the world did you deselect a dropdown list?", "Error displaying crash screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Program.gs.ErrorCode == 500)
                {
                    Thread.CurrentThread.Abort();
                    return;
                }
                else
                {
                    MessageBox.Show("No configuration selected", "Error displaying crash screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            UIActions.me.Show();
            Thread.CurrentThread.Abort();
        }

        private BlueScreen CloneMe(BlueScreen bs)
        {
            string jsonString = JsonSerializer.Serialize(bs);
            BlueScreen cloned = JsonSerializer.Deserialize<BlueScreen>(jsonString);
            return cloned;
        }

        private void MaterialFloatingActionButton1_Click(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedTab.Text == "Prank mode")
            {
                PrankModeActions.OKClick(this, closePrank, bestMatchRadio, timeRadio, appRadio, triggerAppBox, friendlyMessageBox, letCloseBox);
                return;
            }
            Program.isScreensaver = false;
            if (ModifierKeys.HasFlag(Keys.Shift))
            {
                BlueScreen cloned = CloneMe(UIActions.me);
                cloned.ClearAllTitleTexts();
                cloned.SetOSSpecificDefaults();
                cloned.Show();
                return;
            } else if (Program.gs.EnableEggs && ModifierKeys.HasFlag(Keys.Alt))
            {
                BlueScreen cloned = CloneMe(UIActions.me);
                cloned.Crash(null, "GreenScreen");
            }
            if (Program.gs.EnableEggs)
            {
                if (textBox2.Text.ToLower().Contains("null"))
                {
                    foreach (Control c in this.Controls)
                    {
                        c.Text = "undefined";
                    }
                    foreach (Control c in flowLayoutPanel1.Controls)
                    {
                        c.Text = "undefined";
                        c.Dispose();
                    }
                    foreach (Control c in winPanel.Controls)
                    {
                        c.Text = "undefined";
                        c.Dispose();
                    }
                    foreach (Control c in ntPanel.Controls)
                    {
                        c.Text = "undefined";
                        c.Dispose();
                    }
                    foreach (Control c in errorCode.Controls)
                    {
                        c.Text = "undefined";
                        c.Dispose();
                    }
                    foreach (Control c in nineXmessage.Controls)
                    {
                        c.Text = "undefined";
                        c.Dispose();
                    }
                    this.Text = "";
                    this.HelpButton = false;
                    this.ShowIcon = false;
                    this.ShowInTaskbar = false;
                    return;
                }
            }
            if (Program.loadfinished && this.Visible)
            {
                Program.loadfinished = false;
                Program.load_progress = 100;
                Gen g;
                Thread gt;
                gt = new Thread(() => {
                    g = new Gen();
                    g.ShowDialog();
                });
                gt.Start();
            }
            Program.gs.PM_Lockout = false;
            UIActions.Crash(this);
        }

        private void MaterialButton3_Click(object sender, EventArgs e)
        {
            ChooseFile cf = new ChooseFile();
            if (cf.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = cf.fileBrowser.SelectedItems[0].Text;
            }
            cf.Dispose();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (Program.gs.EnableEggs)
            {
                if (textBox2.Text.Contains("one"))
                {
                    textBox2.Text = textBox2.Text.Replace("one", "sky");
                }
                if (textBox2.Text == "undefined")
                {
                    checkBox2.Checked = false;
                }
            }
            if (UIActions.me == null)
            {
                return;
            }
            UIActions.me.SetString("culprit", textBox2.Text);
            if ((UIActions.me.GetString("os") == "Windows XP") || (UIActions.me.GetString("os") == "Windows Vista") || (UIActions.me.GetString("os") == "Windows 7"))
            {
                try
                {
                    UIActions.me.RenameFile(0, textBox2.Text);
                }
                catch (Exception ex) when (!Debugger.IsAttached)
                {
                    if (Program.gs.EnableEggs)
                    {
                        UIActions.me.Crash(ex, "GreenScreen");
                    }
                    else
                    {
                        MessageBox.Show("An error has occoured.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MaterialFloatingActionButton2_Click(object sender, EventArgs e)
        {
            Program.loadfinished = false;
            UIActions.RandFunction(this, ModifierKeys.HasFlag(Keys.Shift));
            
            /*if (MessageBox.Show("Save this configuration?", "I'm feeling unlucky", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.templates.AddTemplate(me.GetString("os"));
                Program.templates.BlueScreens[Program.templates.Count - 1] = bs;
                GetOS();
                ReloadSelection();
            }*/
            //button1.PerformClick();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UIActions.me is null) { return; }
            UIActions.me.SetString("code", comboBox1.SelectedItem.ToString());
            if ((UIActions.me.GetString("os") == "Windows XP") && UIActions.me.GetBool("auto"))
            {
                string[] xpmsg = Properties.Resources.xpMsg.Split(';');
                if (UIActions.me.GetString("code").Contains("007F"))
                {
                    UIActions.me.SetText("Troubleshooting introduction", xpmsg[3]);
                    UIActions.me.SetText("Troubleshooting", string.Format("{0}\r\n\r\n{1}", xpmsg[9], xpmsg[10]));
                }
                else if (UIActions.me.GetString("code").Contains("00C5"))
                {
                    UIActions.me.SetText("Troubleshooting introduction", xpmsg[0]);
                    UIActions.me.SetText("Troubleshooting", string.Format("{0}\r\n\r\n{1}\r\n\r\n{2}\r\n\r\n{3}\r\n\r\n{4}", xpmsg[1], xpmsg[2], xpmsg[3], xpmsg[4], xpmsg[5]));
                }
                else if (UIActions.me.GetString("code").Contains("008E"))
                {
                    UIActions.me.SetText("Troubleshooting introduction", xpmsg[3]);
                    UIActions.me.SetText("Troubleshooting", string.Format("{0}\r\n\r\n{1}", xpmsg[7], xpmsg[8]));
                }
                else
                {
                    UIActions.me.SetText("Troubleshooting introduction", xpmsg[3]);
                    UIActions.me.SetText("Troubleshooting", string.Format("{0}\r\n\r\n{1}\r\n{2}", xpmsg[0], xpmsg[5], xpmsg[6]));
                }
            }
        }

        private void FilterLog()
        {
            string logData = Program.gs.GetLog();
            StringBuilder filteredLog = new StringBuilder();
            foreach (string line in logData.Split('\n'))
            {
                if ((traceErrorCheck.Checked && line.Contains("] Error")) ||
                    traceWarnCheck.Checked && line.Contains("] Warning") ||
                    traceInfoCheck.Checked && line.Contains("] Info") ||
                    traceFatalCheck.Checked && line.Contains("] Fatal"))
                {
                    filteredLog.AppendLine(line);
                }
            }
            logIf.Text = filteredLog.ToString();
        }

        private void MaterialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
            switch (materialTabControl1.SelectedIndex)
            {
                case 0:
                    label7.Visible = !winMode.Checked;
                    button1.Visible = true;
                    button3.Visible = true;
                    quickHelp.SetToolTip(button1, "Starts the simulation");
                    break;
                case 1:
                    PrankModeActions.InitPrankMode(UIActions.GenerateControlDictionary(new Control[] { bestMatchRadio, bestMatchRadio, matchAllRadio, letCloseBox }));
                    button1.Visible = true;
                    quickHelp.SetToolTip(button1, "Starts a simulation based on the conditions you set");
                    break;
                case 2:
                    //materialTabControl1.SelectedIndex = 0;
                    //materialTabControl1.TabPages[0].Show();
                    SettingsActions.Initialize(loadBsconfig, saveBsconfig, UIActions.GenerateControlDictionary(new Control[]
                    {
                        rtlSwitch, eggHunterButton, darkDetectCheck, materialSwitch1, accentBox, primaryColorBox, darkMode,
                        scalingModeBox, hideInFullscreenButton, updateImmediatelyRadio, updateOnCloseRadio, noUpdatesRadio,
                        autoUpdateRadio, primaryServerBox, legacyInterfaceCheck, hashBox
                    }), quickHelp);
                    break;
                case 3:
                    FilterLog();
                    break;
                case 4:
                    HelpTabChange(sender, e);
                    //materialTabControl1.SelectedIndex = 0;
                    //materialTabControl1.TabPages[0].Show();
                    /*if (!abopen)
                    {
                        AboutSettingsDialog ab1 = new AboutSettingsDialog
                        {
                            Text = "Help and about",
                            SettingTab = false
                        };
                        ab1.ShowDialog();
                        abopen = false;
                    }
                    else
                    {
                        MessageBox.Show("The window is already open", "Cannot open window", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }*/
                    break;
                case 5:
                    materialTabControl1.SelectedIndex = 0;
                    materialTabControl1.TabPages[0].Show();
                    if (MessageBox.Show("The old UI doesn't have all of the new features. Do you still want to continue?.", "Restore old layout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Hide();
                        Main m = new Main();
                        m.Show();
                    }
                    break;
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIActions.me.SetString("screen_mode", comboBox2.SelectedItem.ToString());
        }

        private void Win1startup_CheckedChanged(object sender, EventArgs e)
        {
            if (win1startup.Checked)
            {
                UIActions.me.SetString("qr_file", "local:0");
            }
            else if (win2startup.Checked)
            {
                UIActions.me.SetString("qr_file", "local:1");
            }
            else if (nostartup.Checked)
            {
                UIActions.me.SetString("qr_file", "local:null");
            }
        }

        private void AdvOptionsButton_Click(object sender, EventArgs e)
        {
            if (Program.gs.EnableEggs)
            {
                if (textBox2.Text == "blaster")
                {
                    foreach (Control c in this.Controls)
                    {
                        c.Text = "form";
                    }
                    foreach (Panel p in this.Controls.OfType<Panel>())
                    {
                        foreach (Control c in p.Controls)
                        {
                            c.Text = "panel";
                        }
                        foreach (Panel q in p.Controls.OfType<Panel>())
                        {
                            foreach (Panel r in q.Controls.OfType<Panel>())
                            {
                                foreach (Control f in r.Controls)
                                {
                                    foreach (Panel s in q.Controls.OfType<Panel>())
                                    {
                                        foreach (Control d in s.Controls)
                                        {
                                            d.Text = "spaghetti";
                                        }
                                        s.Text = "subsubsubpanel";
                                    }
                                    f.Text = "subsubpanel";
                                }
                            }
                            foreach (Control c in q.Controls)
                            {
                                c.Text = "subpanel";
                            }
                        }
                    }
                    return;
                }
            }
            StringEdit bh = new StringEdit
            {
                me = UIActions.me
            };
            bh.Show();
        }

        private void ECodeEditButton_Click(object sender, EventArgs e)
        {
            if (Program.gs.EnableEggs)
            {
                if (textBox1.Text == "RASTER_FONTS")
                {
                    BTS bts = new BTS();
                    bts.Show();
                    return;
                }
            }
            if (UIActions.me == null)
            {
                return;
            }

            ErrorCodeEditor iform = new ErrorCodeEditor
            {
                me = UIActions.me,
                c1 = UIActions.me.GetCodes()[0],
                c2 = UIActions.me.GetCodes()[1],
                c3 = UIActions.me.GetCodes()[2],
                c4 = UIActions.me.GetCodes()[3]
            };
            iform.Show();
        }

        private void AdvNTButton_Click(object sender, EventArgs e)
        {
            int backup = windowVersion.SelectedIndex;
            NTdtor iform = new NTdtor
            {
                me = UIActions.me
            };
            iform.ShowDialog();
            iform.Dispose();
            windowVersion.SelectedIndex = 0;
            windowVersion.SelectedIndex = backup;
        }

        private void ProgressTuneButton_Click(object sender, EventArgs e)
        {
            ProgressTuner pt = new ProgressTuner
            {
                KFrames = UIActions.me.AllProgress(),
                Text = string.Format("Progress tuner - {0}", UIActions.me.GetString("friendlyname"))
            };
            if (pt.KFrames.Count > 0)
            {
                pt.progressTrackBar.RangeMax = UIActions.me.GetInt("progressmillis");
            }
            pt.ReloadBitmap();
            pt.SetLabelText();
            pt.totalTimeText.Text = ((float)UIActions.me.GetInt("progressmillis") / 100f).ToString().Replace(",", ".");
            if (pt.ShowDialog() == DialogResult.OK)
            {
                UIActions.me.SetAllProgression(pt.KFrames.Keys.ToArray<int>(), pt.KFrames.Values.ToArray<int>());
                UIActions.me.SetInt("progressmillis", pt.progressTrackBar.RangeMax);
            }
            pt.Dispose();
        }

        private void QuickHelp_Popup(object sender, PopupEventArgs e)
        {
            if (e.AssociatedControl != null)
            {
                if (e.AssociatedControl is MaterialButton mb)
                {
                    quickHelp.ToolTipTitle = mb.Text.Replace(" [?]", "");
                }
                else if (e.AssociatedControl is MaterialLabel ml)
                {
                    quickHelp.ToolTipTitle = ml.Text.Replace(" [?]", "");
                }
                else if (e.AssociatedControl is MaterialCheckbox mc)
                {
                    quickHelp.ToolTipTitle = mc.Text.Replace(" [?]", "");
                }
                else if (e.AssociatedControl.Name == "button1")
                {
                    if (materialTabControl1.SelectedTab.Text == "Prank mode")
                    {
                        quickHelp.ToolTipTitle = "Start prank mode";
                        return;
                    }
                    quickHelp.ToolTipTitle = "Simulate";
                }
                else if (e.AssociatedControl.Name == "button3")
                {
                    quickHelp.ToolTipTitle = "I'm feeling unlucky";
                }
                else
                {
                    quickHelp.ToolTipTitle = "Quick help";
                }
            }
        }

        private void MaterialButton6_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, Program.gs.GetLog(false), Encoding.Unicode);
            }
        }

        private void NewUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.gs.Autosave)
            {
                if (Program.templates.qaddeTrip)
                {
                    if (!doubleCheck && (MessageBox.Show("Quick and dirty dictionary editor was tripped. Autosave will not be initiated. Are you sure you want to quit?", "Blue Screen Simulator Plus", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No))
                    {
                        doubleCheck = false;
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        doubleCheck = true;
                        e.Cancel = false;
                    }
                }
                else
                {
                    Program.templates.SaveData(Program.prefix + "bluescreens.json", 0);
                }
            }
            Program.gs.SaveSettings();
            try
            {
                if (Program.gs.UpdateAfterExit)
                {
                    UpdateInterface ui = new UpdateInterface();
                    ui.Show();
                    Hide();
                    Program.gs.UpdateAfterExit = false;
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            catch
            {
                e.Cancel = false;
            }
            if (!e.Cancel)
            {
                Application.Exit();
            }
        }

        private void PrankModeTimer_Tick(object sender, EventArgs e)
        {
            if (Program.gs.PM_Timecatch)
            {
                int hrs = Program.gs.PM_Time[0];
                int mins = Program.gs.PM_Time[1];
                int secs = Program.gs.PM_Time[2];
                if ((hrs == 0) && (mins == 0) && (secs == 0))
                {
                    UIActions.me.SetBool("watermark", false);
                    UIActions.me.SetBool("windowed", false);
                    UIActions.me.SetBool("autoclose", true);
                    UIActions.Crash(this);
                    waitPopup.Enabled = true;
                    prankModeTimer.Enabled = false;
                }
                if (secs == 0)
                {
                    mins -= 1;
                    secs = 60;
                }
                if (mins == -1)
                {
                    hrs -= 1;
                    mins = 59;
                }
                if (hrs == -1)
                {
                    hrs = 0;
                    mins = 0;
                    secs = 0;
                }
                else
                {
                    secs -= 1;
                }
                int[] timex = { hrs, mins, secs };
                Program.gs.PM_Time = timex;
            }
            else if (Program.gs.PM_UsbDevice.Length > 0)
            {
                foreach (USBDeviceInfo usb in USBDeviceInfo.GetUSBDevices())
                {
                    string usbinfo = usb.DeviceID;
                    if ((usbinfo == Program.gs.PM_UsbDevice[0]))
                    {
                        UIActions.me.SetBool("watermark", false);
                        UIActions.me.SetBool("windowed", false);
                        UIActions.me.SetBool("autoclose", true);
                        UIActions.Crash(this);
                        waitPopup.Enabled = true;
                        prankModeTimer.Enabled = false;
                        break;
                    }
                }
            }
            else
            {
                bool getcatch = false;
                if (Process.GetProcessesByName(Program.gs.PM_AppName.Replace(".exe", "")).Length != 0)
                {
                    getcatch = true;
                }
                if (getcatch)
                {
                    UIActions.me.SetBool("watermark", false);
                    UIActions.me.SetBool("windowed", false);
                    UIActions.me.SetBool("autoclose", true);
                    UIActions.Crash(this);
                    waitPopup.Enabled = true;
                    prankModeTimer.Enabled = false;
                }
            }
        }

        private void WaitPopup_Tick(object sender, EventArgs e)
        {
            if (!UIActions.bsod_starter.IsAlive)
            {
                if (!Program.gs.PM_CloseMainUI)
                {
                    waitPopup.Enabled = false;
                    this.WindowState = FormWindowState.Normal;
                    Program.F1.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void NewUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (Program.gs.EnableEggs)
            {
                if ((e.KeyCode == Keys.C) && e.Control && e.Alt)
                {
                    new ClickIt().Show();
                }
                else if ((e.KeyCode == Keys.K) && e.Control)
                {
                    MessageBox.Show("Karrots are good for your eyesight", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (!Program.gs.DevBuild && (e.KeyCode == Keys.F12))
            {
                Program.gs.DevBuild = true;
                MessageBox.Show("You are now a developer!", Assembly.GetExecutingAssembly().FullName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }

        private void NewUI_Shown(object sender, EventArgs e)
        {
            this.Enabled = Program.verificate;
            button1.Visible = Program.verificate;
            button3.Visible = Program.verificate;
            if (Program.verificate)
            {
                // to prevent race conditions
                Program.clip.ExitSplash();
            }
            this.TopMost = true;
            this.TopMost = false;
            if (Screen.AllScreens[0].Bounds.Width * Screen.AllScreens[0].Bounds.Height < 480000)
            {
                this.Size = this.MinimumSize;
            }
        }

        private void CustomizeCodesButton_Click(object sender, EventArgs e)
        {
            MessageTableEditor mte = new MessageTableEditor
            {
                nt_errors = true
            };
            mte.ShowDialog();
        }

        private void BlackScreenBox_MouseHover(object sender, EventArgs e)
        {
            if (sender is MaterialCheckbox)
            {
                if (UIActions.me.GetString("os") != "Windows 8/8.1")
                {
                    quickHelp.SetToolTip(blackScreenBox, "On older versions of Windows 11, the screen was black instead of blue.");
                }
                else
                {
                    quickHelp.SetToolTip(blackScreenBox, "On some later beta builds of Windows 8, the screen was black instead of blue.");
                }
            }
        }


        private void EmbedExeButton_Click(object sender, EventArgs e)
        {
            string filter_backup = saveFileDialog1.Filter;
            saveFileDialog1.Filter = "Windows Executables|*.exe|Windows screensaver files|*.scr";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Before continuing, please note the following things:\r\n\r\n" +
                "1. Clicking YES will start the save process. DO NOT INTERACT with this program until you see a confirmation message that the process has finished to avoid crashes\r\n" +
                "2. The created executable will contain the entire blue screen simulator plus program\r\n" +
                "3. You can re-use it as a regular simulator by renaming it to \"blue screen simulator plus\"\r\n" +
                "4. We will temporarily write a file called BSSP.temp to a temporary folder, which is basically a copy of this program\r\n" +
                "5. The created executable will perform Verifile checks, so transferring it to another computer will display a confirmation dialog if you launch it there for the first time\r\n" +
                "6. ALL of the settings for the actively SELECTED configuration will be applied, including watermark and windowed mode if they're turned on\r\n" +
                "7. The blue screen settings will be embedded to the end of the executable along with a header as minified JSON data (you can see this if you open the created executable with a hex editor). This means that the file size will be slightly bigger than regular blue screen simulator plus executable.\r\n" +
                "8. You will not be able to pass command line arguments to the created executable\r\n\r\nAre you sure you want to continue?", "Embed executable", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    saveFileDialog1.Filter = filter_backup;
                    MessageBox.Show("User cancelled operating. No file was saved.", "Embed executable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (string name in Program.validnames)
                {
                    if (saveFileDialog1.FileName.ToLower().EndsWith($"{name}.exe"))
                    {
                        MessageBox.Show($"Error: This filename is now allowed due to launch performance reasons. Please use different name.\r\n\r\nList of disallowed names:\r\n{string.Join("\r\n", Program.validnames)}", "Cannot embed executable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        saveFileDialog1.Filter = filter_backup;
                        return;
                    }
                }
                string filename = Process.GetCurrentProcess().MainModule.FileName;
                string tempname = Path.GetTempPath() + "\\BSSP.temp";
                File.Copy(filename, tempname);
                List<byte> data = new List<byte>();
                using (BinaryReader reader = new BinaryReader(new FileStream(tempname, FileMode.Open)))
                {
                    byte[] buffer = new byte[1];
                    while ((_ = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        data.AddRange(buffer);
                    }
                    reader.Close(); // always close your files :)
                    reader.Dispose();
                }
                File.Delete(tempname);
                foreach (byte b in Program.footerBytes)
                {
                    data.Add(b);
                }
                data.Add(0x00);
                string jsonEmbed = Program.templates.SaveSingleConfig(UIActions.me);
                data.AddRange(Encoding.UTF8.GetBytes(jsonEmbed));
                File.WriteAllBytes(saveFileDialog1.FileName, data.ToArray());
                data.Clear();
                MessageBox.Show("Executable saved successfully!", "Create embedded executable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            saveFileDialog1.Filter = filter_backup;
        }

        private void NineXErrorCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UIActions.me != null)
            {
                string[] c = UIActions.me.GetCodes();
                string code = nineXErrorCode.Text.Split(':')[0];
                if (c == null) { c = new string[] { "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR" }; }
                try
                {
                    UIActions.me.SetCodes(code + c[0].Substring(2), c[1], c[2], c[3]);
                } catch
                {
                    Program.gs.Log("Error", "Unable to set 9x error codes");
                }
            }
        }

        private void MaterialButton2_Click(object sender, EventArgs e)
        {
            new MessageTableEditor
            {
                nx_errors = true
            }.ShowDialog();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                foreach (string it in comboBox1.Items)
                {
                    if (it.Contains(textBox1.Text.Replace(" ", "_").ToUpper()))
                    {
                        comboBox1.SelectedItem = it;
                        break;
                    }
                }
                // refreshes the combobox to avoid the situation where the user has to hover over the error code combo box
                comboBox1.Refresh();
            }
        }

        private void TraceFatalCheck_CheckedChanged(object sender, EventArgs e)
        {
            FilterLog();
        }

        private void AboutSettingsButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Demo mode", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                aboutSettingsButton.Visible = false;
                AboutSettingsDialog abs = new AboutSettingsDialog
                {
                    SettingTab = true,
                    Demo = true,
                    WindowState = FormWindowState.Minimized,
                    Visible = false
                };
                TopMost = true;
                abs.ShowDialog();
                TopMost = false;
                aboutSettingsButton.Visible = Program.gs.DevBuild;
            }
        }

        private void GeneralCheckUncheck(object sender, EventArgs e)
        {
            UIActions.UpdateBool(this, (MaterialCheckbox)sender);
        }

        private void MaterialButton3_Click_1(object sender, EventArgs e)
        {

        }

        private void WhyNoDeviceButton_Click(object sender, EventArgs e)
        {
            PrankModeActions.USBTroubleshoot(sender, e);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Forms.Legacy.PrankMode pm = new Forms.Legacy.PrankMode();
            pm.Show();
        }

        private void HelpButtonClick(object sender, EventArgs e)
        {
            switch (((Control)sender).Text)
            {
                case "Source code":
                    AboutSettingsDialog.SourceCode(sender, e);
                    break;
                case "Copying":
                    AboutSettingsDialog.Copying(sender, e);
                    break;
                case "Random factoid":
                    AboutSettingsDialog.RandomFact(sender, e);
                    break;
                case "What's new?":
                    AboutSettingsDialog.Changelog(sender, e);
                    break;
                case "How to get help?":
                    AboutSettingsDialog.QuickHelp_Help(helpDisplay);
                    break;
                case "Purposes of this program":
                    AboutSettingsDialog.QuickHelp_Purpose(helpDisplay);
                    break;
                case "System requirements":
                    AboutSettingsDialog.QuickHelp_SystemRequirements(helpDisplay);
                    break;
                case "User manual":
                    AboutSettingsDialog.UserManualButtonClick();
                    break;
            }
        }

        private void HelpTabChange(object sender, EventArgs e)
        {
            switch (aboutTabControl.SelectedTab.Text)
            {
                case "About":
                    if (Program.gs.NightTheme)
                    {
                        markusSoftwareLogo.Image = Properties.Resources.msoftware_dm;
                        veriFileLogo.Image = Properties.Resources.verifile_dm;
                    }
                    rndFactButton.Visible = Program.gs.EnableEggs;
                    AboutSettingsDialog.GetAbout(new Dictionary<string, Control>
                    {
                        { "labelProductName", labelProductName },
                        { "labelVersion", labelVersion },
                        { "labelCopyright", labelCopyright },
                        { "labelCompanyName", labelCompanyName },
                    });
                    break;
                case "Help":
                    break;
                case "Command line help":
                    commandLineHelpDisplay.Text = string.Join(Environment.NewLine, Program.cmds);
                    break;
            }
        }

        private void PMBestAllMatch(object sender, EventArgs e)
        {
            PrankModeActions.BestAllMatchCheck(bestMatchRadio, matchAllRadio, letCloseBox);
        }

        private void PMToggleVisible(object sender, EventArgs e)
        {
            PrankModeActions.ToggleVisible(UIActions.GenerateControlDictionary(new Control[] { timePanel, timerBox, timeRadio, appRadio, triggerAppBox, usbRadio, usbPanel, resetDeviceButton, appPanel }), usbFinder);
        }

        private void UsbFinder_Tick(object sender, EventArgs e)
        {
            PrankModeActions.TimerTick(deviceInfoLabel, resetDeviceButton, usbFinder);
        }

        private void PMUpdateFriendlyMessage(object sender, EventArgs e)
        {
            PrankModeActions.UpdateFriendlyMessage(
                UIActions.GenerateControlDictionary(new Control[]
                {
                    friendlyMessageContentsBox, friendlyMessageTitleBox, friendlyMessageIconPanel,
                    friendlyMessageButtonsPanel, previewFriendlyMessageButton, timerBox
                }),
                UIActions.GenerateRadioButtonDictionary(new MaterialRadioButton[]
                {
                    errorRadio, warningRadio, questionRadio, infoRadio, noneRadio, okRadio, okCancelRadio,
                    retryIgnoreAboutRadio, yesNoRadio, yesNoCancelRadio, retryCancelRadio
                })
            );
        }

        private void PMToggleFriendlyMessage(object sender, EventArgs e)
        {
            PrankModeActions.ToggleFriendlyMessage(UIActions.GenerateControlDictionary(new Control[]
            {
                friendlyMessageBox, friendlyMessageContentsBox, friendlyMessageTitleBox,
                friendlyMessageIconPanel, friendlyMessageButtonsPanel, previewFriendlyMessageButton
            }));
        }

        private void PreviewFriendlyMessageButton_Click(object sender, EventArgs e)
        {
            PrankModeActions.ShowMessage();
        }

        private void ClosePrank_CheckedChanged(object sender, EventArgs e)
        {
            PrankModeActions.ReopenCheckedChanged(closePrank);
        }

        private void ResetDeviceButton_Click(object sender, EventArgs e)
        {
            PrankModeActions.USBReset(deviceInfoLabel, resetDeviceButton, usbFinder);
        }

        private void LetCloseBox_CheckedChanged(object sender, EventArgs e)
        {
            PrankModeActions.LetCloseBox_CheckedChanged(letCloseBox, true);
        }

        private void MaterialTabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingsActions.TabSwitcher(UIActions.GenerateControlDictionary(new Control[]
            {
                aboutSettingsTabControl, noticeLabel, unsignButton, updateCheckButton, autoUpdateRadio,
                noUpdatesRadio, darkDetectCheck, hashBox, updateImmediatelyRadio, updateOnCloseRadio,
                primaryServerBox, eggHunterButton, autosaveCheck, scalingModeBox, multiDisplayBox,
                hideInFullscreenButton, configList, randomnessCheckBox, devFlowPanel
            }));
        }

        private void UpdateCheckButton_Click(object sender, EventArgs e)
        {
            SettingsActions.CheckForUpdates(updateCheckButton);
        }

        private void UpdateSettings(object sender, EventArgs e)
        {
            SettingsActions.UpdateSettings(UIActions.GenerateControlDictionary(new Control[]
            {
                autoUpdateRadio, hashBox, updateOnCloseRadio, randomnessCheckBox,
                hideInFullscreenButton, eggHunterButton, autosaveCheck, multiDisplayBox,
                scalingModeBox, darkMode, darkDetectCheck, legacyInterfaceCheck, primaryColorBox,
                accentBox, materialSwitch1, primaryServerBox
            }));
            if (sender is MaterialCheckbox mcb)
            {
                if (mcb.Name != "legacyInterfaceCheck") { return; }
                if (!mcb.Checked) { return; }
                switch (MessageBox.Show("You must restart the application for the changes to take effect. Do you want to restart the app now?", AboutSettingsDialog.AssemblyProduct + " " + UIActions.Version, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                {
                    case DialogResult.Yes:
                        Program.gs.SaveSettings();
                        Application.Restart();
                        return;
                    case DialogResult.Cancel:
                        mcb.Checked = false;
                        break;
                    default:
                        break;
                }
            }
            if (sender is MaterialSwitch ms)
            {
                if (ms.Name != "materialSwitch1") { return; }
                UIActions.RemoveQuestionMark(materialTabControl1, materialSwitch1.Checked);
            }
        }

        private void MaterialButton24_Click(object sender, EventArgs e)
        {
            SettingsActions.RandomTheme(accentBox, primaryColorBox);
        }

        private void MaterialButton25_Click(object sender, EventArgs e)
        {
            SettingsActions.DefaultTheme(accentBox, primaryColorBox);
        }

        private void ConfigList_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {
            SettingsActions.ConfigSelector(resetButton, resetHackButton, removeCfg, configList, osName, selectedItem);
        }

        private void SetUpdateServer(object sender, EventArgs e)
        {
            SettingsActions.ChangeUpdateServer((Control)sender, primaryServerBox);
        }

        private void SelectAllBox_CheckedChanged(object sender, EventArgs e)
        {
            resetHackButton.Enabled = selectAllBox.Checked;
            resetButton.Enabled = selectAllBox.Checked;
            removeCfg.Enabled = selectAllBox.Checked;
            configList.Enabled = !selectAllBox.Checked;
            if (selectAllBox.Checked)
            {
                removeCfg.Text = "Remove configs [?]";
                configList.SelectedItem = null;
                quickHelp.SetToolTip(resetHackButton, "Deletes everything under the 'additional options' menu for all configurations");
                quickHelp.SetToolTip(resetButton, "Reset all settings within all configurations");
                quickHelp.SetToolTip(removeCfg, "Removes all configurations. This is useful, if you're making your own custom skin packs and want only a few operating systems to be visible.");
                osName.Text = "All selected";
                configList.SelectedItems.Clear();
                return;
            }
            configList.SelectedItems.Clear();
            removeCfg.Text = "Remove config [?]";
            quickHelp.SetToolTip(resetHackButton, "Deletes everything under the 'additional options' menu for this configuration");
            quickHelp.SetToolTip(resetButton, "Reset all settings in this configuration");
            quickHelp.SetToolTip(removeCfg, "Removes the configuration, meaning it will no longer be accessible in the main menu or any other part of the program.");
            osName.Text = "Select a configuration to modify/remove it";
        }

        private void SimulatorConfigActionButtonClick(object sender, EventArgs e)
        {
            SettingsActions.SimulatorSettingsAction(this, (Control)sender, configList, loadBsconfig, saveBsconfig);
        }

        private void RtlSwitch_CheckedChanged(object sender, EventArgs e)
        {
            this.RightToLeft = rtlSwitch.Checked ? RightToLeft.Yes : RightToLeft.Inherit;
        }

        private void DevButtonsClick(object sender, EventArgs e)
        {
            TextView tv;
            string jsonString;
            switch (((Control)sender).Name)
            {
                case "devPerformTest":
                    new TestSuite().Show();
                    break;
                case "devRestartApp":
                    Application.Restart();
                    break;
                case "devGen":
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
                    break;
                case "devEmbed":
                    this.Enabled = false;
                    string filename = "";
                    string backup = loadBsconfig.Filter;
                    loadBsconfig.Filter = "Executables|*.exe";
                    if (loadBsconfig.ShowDialog() == DialogResult.OK)
                    {
                        filename = loadBsconfig.FileName;
                    }
                    if ((filename != "") && MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Hide();
                        Program.F1.Hide();
                        jsonString = Program.GetEmbedded(filename);
                        if (jsonString != "")
                        {
                            if (MessageBox.Show("Embedded data found! Press Yes to preview error message. Press No to view embedded data.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Program.dr = new DrawRoutines();
                                Thread th = new Thread(new ThreadStart(() => {
                                    // initialize BlueScreen object
                                    UIActions.me = Program.templates.LoadSingleConfig(jsonString);
                                    // display the crash screen
                                    UIActions.me.Show();
                                }));
                                th.Start();
                                th.Join();
                            }
                            else
                            {
                                tv = new TextView
                                {
                                    Text = jsonString,
                                    Title = "JSON data"
                                };
                                tv.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No embedded data was found.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        Program.F1.Show();
                        Show();
                        BringToFront();
                    }
                    loadBsconfig.Filter = backup;
                    loadBsconfig.FileName = "";
                    Enabled = true;
                    break;
                case "devNewAllButton":
                        Program.templates.Reset();
                        configList.Items.Clear();
                        foreach (BlueScreen bs in Program.templates.GetAll())
                        {
                            configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                        }
                        break;
                case "devDictEditButton":
                    try
                    {
                        DictEdit de = new DictEdit
                        {
                            me = Program.templates.GetAt(configList.SelectedIndex)
                        };
                        de.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Please select a configuration, silly", AboutSettingsDialog.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case "devSplashButton":
                    Splash spl = new Splash();
                    spl.SplashText.Text = "Idling. Press ESC to exit.";
                    spl.Show();
                    break;
                case "devSerialize":
                    JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
                    jsonString = JsonSerializer.Serialize(Program.templates, options);
                    tv = new TextView
                    {
                        Title = "Output",
                        Text = jsonString.ToString()
                    };
                    tv.Show();
                    break;
                case "devWindowedSettings":
                    AboutSettingsDialog ab1 = new AboutSettingsDialog
                    {
                        Text = "Settings",
                        SettingTab = true
                    };
                    ab1.ShowDialog();
                    ab1.Dispose();
                    abopen = false;
                    break;
            }
        }

        private void ConfigList_DoubleClick(object sender, EventArgs e)
        {
            AddBluescreen ab = new AddBluescreen();
            BlueScreen me = Program.templates.GetAt(configList.SelectedIndex);
            ab.Preload(me);
            if (ab.ShowDialog() == DialogResult.OK)
            {
                configList.Items.Clear();
                foreach (BlueScreen bs in Program.templates.GetAll())
                {
                    configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                }
                osName.Text = string.Format("Selected configuration: {0}", Program.templates.GetAt(configList.SelectedIndex).GetString("friendlyname"));
            }
        }

        private void LetCloseBox_Click(object sender, EventArgs e)
        {
            PrankModeActions.LetCloseBox_CheckedChanged(letCloseBox, false);
        }

        private void MatchAllRadio_Click(object sender, EventArgs e)
        {
            PrankModeActions.BestAllMatchCheck(bestMatchRadio, matchAllRadio, letCloseBox, false);
        }

        private void UnsignButton_Click(object sender, EventArgs e)
        {
            SettingsActions.EraseSignature((Control)sender);
        }
    }
}

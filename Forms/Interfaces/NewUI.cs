using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
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
        bool doubleCheck = false;

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
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
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
            if (!Program.gs.DevBuild)
            {
                materialTabControl1.TabPages.Remove(materialTabControl1.TabPages["tabPage5"]);
            }
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
                this.Enabled = true;
            }
            Program.gs.ApplyScheme();
        }

        private void NewUi1_ResizeEnd(object sender, EventArgs e)
        {
            int sub = 70;
            this.errorCode.Width = this.Width - sub;
            WXOptions.Width = this.Width - sub;
            ntPanel.Width = this.Width - sub;
            nineXmessage.Width = this.Width - sub;
            winPanel.Width = this.Width - sub;
            errorCode.Width = this.Width - sub;
            flowLayoutPanel4.Width = this.Width - sub;
            RelocateButtons();
        }


        private void windowVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            quickHelp.Active = Program.gs.QuickHelp;
            if (this.Visible)
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
                    MessageBox.Show("Please select a Windows version! Also, how in the world did you deselect a dropdown list?", "Error displaying blue screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Program.gs.ErrorCode == 500)
                {
                    Thread.CurrentThread.Abort();
                    return;
                }
                else
                {
                    MessageBox.Show("No configuration selected", "Error displaying blue screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void materialFloatingActionButton1_Click(object sender, EventArgs e)
        {
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

        private void materialButton3_Click(object sender, EventArgs e)
        {
            ChooseFile cf = new ChooseFile();
            if (cf.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = cf.fileBrowser.SelectedItems[0].Text;
            }
            cf.Dispose();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void materialFloatingActionButton2_Click(object sender, EventArgs e)
        {
            Program.loadfinished = false;
            BlueScreen bs = UIActions.RandFunction(this, ModifierKeys.HasFlag(Keys.Shift));
            
            /*if (MessageBox.Show("Save this configuration?", "I'm feeling unlucky", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.templates.AddTemplate(me.GetString("os"));
                Program.templates.BlueScreens[Program.templates.Count - 1] = bs;
                GetOS();
                ReloadSelection();
            }*/
            //button1.PerformClick();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (materialTabControl1.SelectedIndex)
            {
                case 1:
                    FilterLog();
                    break;
                case 2:
                    materialTabControl1.SelectedIndex = 0;
                    materialTabControl1.TabPages[0].Show();
                    if (!abopen)
                    {
                        AboutSettingsDialog ab1 = new AboutSettingsDialog
                        {
                            Text = "Settings",
                            SettingTab = true
                        };
                        ab1.okButton.DialogResult = DialogResult.None;
                        ab1.ShowDialog();
                        ab1.Dispose();
                        abopen = false;
                    }
                    else
                    {
                        MessageBox.Show("Settings window is already open", "Cannot open settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case 3:
                    materialTabControl1.SelectedIndex = 0;
                    materialTabControl1.TabPages[0].Show();
                    if (!abopen)
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
                    }
                    break;
                case 4:
                    materialTabControl1.SelectedIndex = 0;
                    materialTabControl1.TabPages[0].Show();
                    PrankMode pm = new PrankMode();
                    pm.Show();
                    break;
                case 5:
                    materialTabControl1.SelectedIndex = 0;
                    materialTabControl1.TabPages[0].Show();
                    if (MessageBox.Show("The old UI doesn't have all of the new features. Do you still want to continue?.", "Restore old layout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        this.Hide();
                        Main m = new Main();
                        m.Show();
                    }
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIActions.me.SetString("screen_mode", comboBox2.SelectedItem.ToString());
        }

        private void win1startup_CheckedChanged(object sender, EventArgs e)
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

        private void advOptionsButton_Click(object sender, EventArgs e)
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

        private void eCodeEditButton_Click(object sender, EventArgs e)
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

        private void advNTButton_Click(object sender, EventArgs e)
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

        private void progressTuneButton_Click(object sender, EventArgs e)
        {
            ProgressTuner pt = new ProgressTuner();
            pt.KFrames = UIActions.me.AllProgress();
            pt.Text = string.Format("Progress tuner - {0}", UIActions.me.GetString("friendlyname"));
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

        private void quickHelp_Popup(object sender, PopupEventArgs e)
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

        private void materialButton6_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, Program.gs.GetLog(false), Encoding.Unicode);
            }
        }

        private void updateCheckerTimer_Tick(object sender, EventArgs e)
        {

            if (System.IO.File.Exists("BSSP.exe"))
            {
                updateCheckerTimer.Enabled = false;
                //MessageBox.Show("Thank you for installing the latest version of Blue screen simulator plus :)\n\nWhat's new?\n" + Program.changelog + "\n\nYou can find a more detailed changelog in the official BlueScreenSimulatorPlus GitHub page.", "Update was successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int tries = 0;
                while (System.IO.File.Exists("BSSP.exe"))
                {
                    tries += 1;
                    try
                    {
                        System.IO.File.Move("BSSP.exe", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BSSP_old.exe");
                        System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BSSP_old.exe");
                    }
                    catch
                    {
                        //yo
                    }
                    if (tries > 64)
                    {
                        break;
                    }
                }
            }
            try
            {
                if (System.IO.File.Exists(Program.prefix + "vercheck.txt"))
                {
                    string[] lines = System.IO.File.ReadAllLines(Program.prefix + "vercheck.txt");
                    if (Convert.ToDouble(lines[0].Replace(".", ",").Replace("\r", "").Replace("\n", "").Trim()) > Convert.ToDouble(UIActions.version.Replace(".", ",")))
                    {
                        updateCheckerTimer.Enabled = false;
                        System.IO.File.Delete(Program.prefix + "vercheck.txt");
                        if (MessageBox.Show("A new version of blue screen simulator is available. Would you like to update now?", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.IO.File.WriteAllText("hash.txt", lines[1].Trim());
                            if (Program.gs.PostponeUpdate == false)
                            {
                                UpdateInterface ui = new UpdateInterface();
                                ui.Show();
                                this.Hide();
                            }
                            else
                            {
                                Program.gs.UpdateAfterExit = true;
                                MessageBox.Show("The update has been postponed to install when the program is closed.");
                            }
                        }
                    }
                    else
                    {
                        if (updateCheckerTimer.Interval == 5999)
                        {
                            updateCheckerTimer.Interval = 6000;
                            updateCheckerTimer.Enabled = false;
                            System.IO.File.Delete(Program.prefix + "vercheck.txt");
                            if (MessageBox.Show("A new version of blue screen simulator is available. Would you like to update now?", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                System.IO.File.WriteAllText("hash.txt", lines[1].Trim());
                                if (Program.gs.PostponeUpdate == false)
                                {
                                    UpdateInterface ui = new UpdateInterface();
                                    ui.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    Program.gs.UpdateAfterExit = true;
                                    MessageBox.Show("The update has been postponed to install when the program is closed.");
                                }
                            }
                        }
                        else if (updateCheckerTimer.Interval == 5998)
                        {
                            updateCheckerTimer.Interval = 6000;
                            updateCheckerTimer.Enabled = false;
                            MessageBox.Show("This version of blue screen simulator plus is up to date", "Blue screens simulator plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            System.IO.File.Delete(Program.prefix + "vercheck.txt");
                        }
                    }
                }
            }
            catch (Exception ex) when (!Debugger.IsAttached)
            {

                if (updateCheckerTimer.Interval != 6000)
                {
                    MessageBox.Show("An error has occoured.\n\nFatal exception: " + ex.Message + "\n\nStack trace\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                updateCheckerTimer.Enabled = false;
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
                    this.Hide();
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

        private void prankModeTimer_Tick(object sender, EventArgs e)
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

        private void waitPopup_Tick(object sender, EventArgs e)
        {
            if (!UIActions.bsod_starter.IsAlive)
            {
                if (!Program.gs.PM_Lockout)
                {
                    waitPopup.Enabled = false;
                    this.WindowState = FormWindowState.Normal;
                    Program.f1.Show();
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
                Program.clip.ExitSplash(this);
            }
            this.TopMost = true;
            this.TopMost = false;
            if (Screen.AllScreens[0].Bounds.Width * Screen.AllScreens[0].Bounds.Height < 480000)
            {
                this.Size = this.MinimumSize;
            }
        }

        private void customizeCodesButton_Click(object sender, EventArgs e)
        {
            MessageTableEditor mte = new MessageTableEditor();
            mte.nt_errors = true;
            mte.ShowDialog();
        }

        private void blackScreenBox_MouseHover(object sender, EventArgs e)
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


        private void embedExeButton_Click(object sender, EventArgs e)
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
                    int bytesRead;
                    while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
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
                data = null;
                MessageBox.Show("Executable saved successfully!", "Create embedded executable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            saveFileDialog1.Filter = filter_backup;
        }

        private void nineXErrorCode_SelectedIndexChanged(object sender, EventArgs e)
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

        private void materialButton2_Click(object sender, EventArgs e)
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

        private void traceFatalCheck_CheckedChanged(object sender, EventArgs e)
        {
            FilterLog();
        }

        private void aboutSettingsButton_Click(object sender, EventArgs e)
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

        private void generalCheckUncheck(object sender, EventArgs e)
        {
            UIActions.UpdateBool(this, (MaterialCheckbox)sender);
        }
    }
}

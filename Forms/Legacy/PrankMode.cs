using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using Microsoft.Win32;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator.Forms.Legacy
{
    public partial class PrankMode : Form
    {
        readonly string releaseId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
        readonly int buildNumber = Convert.ToInt32(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", "0").ToString());

        string MsgBoxMessage = "Enter a message here.";
        string MsgBoxTitle = "Enter a title here";
        string[] time = { "00", "05", "00" };
        List<USBDeviceInfo> currentDevs = new List<USBDeviceInfo>();
        List<USBDeviceInfo> prevDevs = new List<USBDeviceInfo>();
        string[] devinfo = { };
        bool timecatch = true;
        int contain = 0;
        MessageBoxIcon MsgBoxIcon = MessageBoxIcon.Exclamation;
        MessageBoxButtons MsgBoxType = MessageBoxButtons.OK;
        BlueScreen me;
        readonly List<string> blackninja = new List<string>
        {
            "Windows Vista/7",
            "Windows XP",
            "Windows 2000",
            "Windows NT 3.x/4.0",
            "Windows 9x/Me",
            "Windows 3.1x",
            "Windows 1.x/2.x"
        };
        public PrankMode()
        {
            InitializeComponent();
        }

        private void PrankMode_Load(object sender, EventArgs e)
        {
            if (Program.f2.nightThemeToolStripMenuItem.Checked)
            {
                this.BackColor = System.Drawing.Color.Black;
                this.ForeColor = System.Drawing.Color.Gray;
                friendlyMessageContentsBox.BackColor = this.BackColor;
                friendlyMessageContentsBox.ForeColor = this.ForeColor;
                friendlyMessageContentsBox.BorderStyle = BorderStyle.FixedSingle;
                friendlyMessageTitleBox.BackColor = this.BackColor;
                friendlyMessageTitleBox.ForeColor = this.ForeColor;
                friendlyMessageTitleBox.BorderStyle = BorderStyle.FixedSingle;
                triggerAppBox.BackColor = this.BackColor;
                triggerAppBox.ForeColor = this.ForeColor;
                triggerAppBox.BorderStyle = BorderStyle.FixedSingle;
                timerBox.BackColor = this.BackColor;
                timerBox.ForeColor = this.ForeColor;
                timerBox.BorderStyle = BorderStyle.FixedSingle;

            }
            string winver = releaseId;
            if (bestMatchRadio.Checked == true)
            {
                Program.f2.winMode.Checked = false;
                //this code identifies Windows 11
                if (winver.Contains("Windows 11"))
                {
                    for (int i = 0; i < Program.f1.windowVersion.Items.Count; i++)
                    {
                        if (Program.f1.windowVersion.Items[i].ToString().Contains("Windows 11"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows 10
                else if (winver.Contains("Windows 10"))
                {
                    for (int i = 0; i < Program.f1.windowVersion.Items.Count; i++)
                    {
                        if (Program.f1.windowVersion.Items[i].ToString().Contains("Windows 10"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows 8 or Windows 8.1
                else if (winver.Contains("Windows 8"))
                {
                    for (int i = 0; i < Program.f1.windowVersion.Items.Count; i++)
                    {
                        if (Program.f1.windowVersion.Items[i].ToString().Contains("Windows 8"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows 7 or Windows Vista
                else if ((winver.Contains("Windows 7")) || (winver.Contains("Windows Vista")))
                {
                    for (int i = 0; i < Program.f1.windowVersion.Items.Count; i++)
                    {
                        if (Program.f1.windowVersion.Items[i].ToString().Contains("Windows Vista"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows XP
                else if (winver.Contains("Windows XP"))
                {
                    for (int i = 0; i < Program.f1.windowVersion.Items.Count; i++)
                    {
                        if (Program.f1.windowVersion.Items[i].ToString().Contains("Windows XP"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows 2000
                else if ((winver.Contains("Windows 2000")) || (winver.Contains("Windows NT 5")))
                {
                    for (int i = 0; i < Program.f1.windowVersion.Items.Count; i++)
                    {
                        if (Program.f1.windowVersion.Items[i].ToString().Contains("Windows 2000"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows 95 or Windows 98
                else if ((winver.Contains("Windows 95")) || (winver.Contains("Windows 98")))
                {
                    for (int i = 0; i < Program.f1.windowVersion.Items.Count; i++)
                    {
                        if (Program.f1.windowVersion.Items[i].ToString().Contains("Windows 9x"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies old Windows NT versions
                else if ((winver.Contains("Windows NT 4")) || (winver.Contains("Windows NT 3")))
                {
                    for (int i = 0; i < Program.f1.windowVersion.Items.Count; i++)
                    {
                        if (Program.f1.windowVersion.Items[i].ToString().Contains("Windows NT"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows 3.1x or unknown Windows versions
                else
                {
                    for (int i = 0; i < Program.f1.windowVersion.Items.Count; i++)
                    {
                        if (Program.f1.windowVersion.Items[i].ToString().Contains("Windows 3.1"))
                        {
                            contain = i;
                        }
                    }
                }
                me = Program.templates.BlueScreens[contain];
                if (contain == -1)
                {
                    bestMatchRadio.Checked = false;
                    bestMatchRadio.Enabled = false;
                    matchAllRadio.Checked = true;
                    matchAllRadio.Enabled = false;
                    MessageBox.Show("Due to blue screen simulator plus configuration or the specific version of Windows you are using, it is not possible to use a bluescreen similar to one that your Windows version uses. If this is what you want to do, please enable your Windows version in BSSP settings or settings file. If this message still pops up, then use a different Windows version.", "Unable to autodetect Windows version", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            letCloseBox.Enabled = !blackninja.Contains(Program.templates.BlueScreens[contain].GetString("os"));
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (timeRadio.Checked == true)
            {
                timePanel.Visible = true;
                timerBox.Enabled = true;
                timecatch = true;
            }
            else
            {
                timePanel.Visible = false;
                timerBox.Enabled = false;
                timecatch = false;
            }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (appRadio.Checked == true)
            {
                appPanel.Visible = true;
                triggerAppBox.Enabled = true;
            }
            else
            {
                appPanel.Visible = false;
                triggerAppBox.Enabled = false;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (friendlyMessageBox.Checked == true)
            {
                friendlyMessageContentsBox.Enabled = true;
                friendlyMessageTitleBox.Enabled = true;
                friendlyMessageIconPanel.Enabled = true;
                friendlyMessageButtonsPanel.Enabled = true;
                previewFriendlyMessageButton.Enabled = true;
            }
            else
            {
                friendlyMessageContentsBox.Enabled = false;
                friendlyMessageTitleBox.Enabled = false;
                friendlyMessageIconPanel.Enabled = false;
                friendlyMessageButtonsPanel.Enabled = false;
                previewFriendlyMessageButton.Enabled = false;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            MsgBoxMessage = friendlyMessageContentsBox.Text;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            MsgBoxTitle = friendlyMessageTitleBox.Text;
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (errorRadio.Checked == true)
            {
                MsgBoxIcon = MessageBoxIcon.Error;
            }
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (warningRadio.Checked == true)
            {
                MsgBoxIcon = MessageBoxIcon.Exclamation;
            }
        }

        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (questionRadio.Checked == true)
            {
                MsgBoxIcon = MessageBoxIcon.Question;
            }
        }

        private void RadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (infoRadio.Checked == true)
            {
                MsgBoxIcon = MessageBoxIcon.Information;
            }
        }

        private void RadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (noneRadio.Checked == true)
            {
                MsgBoxIcon = MessageBoxIcon.None;
            }
        }

        private void RadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (okRadio.Checked == true)
            {
                MsgBoxType = MessageBoxButtons.OK;
            }
        }

        private void RadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (okCancelRadio.Checked == true)
            {
                MsgBoxType = MessageBoxButtons.OKCancel;
            }
        }

        private void RadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (retryIgnoreAboutRadio.Checked == true)
            {
                MsgBoxType = MessageBoxButtons.AbortRetryIgnore;
            }
        }

        private void RadioButton13_CheckedChanged(object sender, EventArgs e)
        {
            if (yesNoRadio.Checked == true)
            {
                MsgBoxType = MessageBoxButtons.YesNo;
            }
        }

        private void RadioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (yesNoCancelRadio.Checked == true)
            {
                MsgBoxType = MessageBoxButtons.YesNoCancel;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MsgBoxMessage, MsgBoxTitle, MsgBoxType, MsgBoxIcon);
        }

        private void RadioButton2_Click(object sender, EventArgs e)
        {
            if (bestMatchRadio.Enabled == true)
            {
                if (matchAllRadio.Checked == true)
                {
                    if (MessageBox.Show("This option may not look legitimate. Are you sure you'd like to continue?", "This prank may not look legitimate", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        matchAllRadio.Checked = false;
                        bestMatchRadio.Checked = true;
                    }
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.gs.PM_CloseMainUI = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string messageA = "The program will now be hidden. Once the prank has been triggered, the program will reopen itself.";
            string messageB = "The program will now be hidden. Once the prank has been triggered, the program will reopen iteself and then close after exiting the blue screen.";
            string message = "You are not " + /* garbage, please trust me on this! */
                             "supposed " /*ly, they were hanging out... */ +
                             /*...*/ "to " + "see " /* who actually did this! */ +
                             "this " + /* message was for you */ ", John!";
            message = messageB;
            if (closePrank.Checked)
            {
                message = messageA;
            }
            //this confirms the action
            if (MessageBox.Show(message, "Prank mode will begin if you click OK", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                //this gets the Windows product name
                string winver = releaseId;

                //this makes sure that the blue screen type matches the OS
                if (bestMatchRadio.Checked == true)
                {
                    if (buildNumber >= 22000) { winver = "Windows 11"; }
                    Program.f1.winMode.Checked = false;
                    for (int i = 0; i < Program.templates.BlueScreens.Length; i++)
                    {
                        if (winver.Contains(Program.templates.BlueScreens[i].GetString("os")))
                        {
                            UIActions.me = Program.templates.BlueScreens[i];
                            Program.f2.windowVersion.SelectedIndex = Program.f2.windowVersion.Items.Count - 1 - i;
                        }
                    }
                }
                //this code handles blue screen triggers and final message, if exists
                string[] emptydev = { };
                if (timeRadio.Checked == true)
                {
                    Program.f2.timecatch = timecatch;
                    int hrs = Convert.ToInt32(time[0].Replace("00", "0").Replace("01", "1").Replace("02", "2").Replace("03", "3").Replace("04", "4").Replace("05", "5").Replace("06", "6").Replace("07", "7").Replace("08", "8").Replace("09", "9"));
                    int mins = Convert.ToInt32(time[1].Replace("00", "0").Replace("01", "1").Replace("02", "2").Replace("03", "3").Replace("04", "4").Replace("05", "5").Replace("06", "6").Replace("07", "7").Replace("08", "8").Replace("09", "9"));
                    int secs = Convert.ToInt32(time[2].Replace("00", "0").Replace("01", "1").Replace("02", "2").Replace("03", "3").Replace("04", "4").Replace("05", "5").Replace("06", "6").Replace("07", "7").Replace("08", "8").Replace("09", "9"));
                    int[] timex = { hrs, mins, secs };
                    Program.f2.time = timex;
                    Program.f2.usb_device = emptydev;
                    Program.f2.prankModeTimer.Interval = 1000;
                }
                else if (appRadio.Checked)
                {
                    Program.f2.timecatch = false;
                    Program.f2.appname = triggerAppBox.Text;
                    Program.f2.usb_device = emptydev;
                    Program.f2.prankModeTimer.Interval = 1000;
                }
                else
                {
                    Program.f2.timecatch = false;
                    Program.f2.usb_device = devinfo;
                    Program.f2.prankModeTimer.Interval = 100;
                }
                if (friendlyMessageBox.Checked == true)
                {
                    Program.f2.showmsg = true;
                    Program.f2.MsgBoxIcon = MsgBoxIcon;
                    Program.f2.MsgBoxType = MsgBoxType;
                    Program.f2.MsgBoxMessage = MsgBoxMessage;
                    Program.f2.MsgBoxTitle = MsgBoxTitle;
                }
                Program.f2.Hide();
                Program.f2.waterBox.Checked = false;
                Program.f2.prankModeTimer.Enabled = true;
                Program.f2.lockout = !letCloseBox.Checked;
                this.Close();
            }
        }

        private void MaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            time = timerBox.Text.Split(':');
        }

        private void RadioButton15_CheckedChanged(object sender, EventArgs e)
        {
            if (retryCancelRadio.Checked == true)
            {
                MsgBoxType = MessageBoxButtons.RetryCancel;
            }
        }

        private void RadioButton16_CheckedChanged(object sender, EventArgs e)
        {
            if (usbRadio.Checked == true)
            {
                usbPanel.Visible = true;
                if (devinfo.Length == 0)
                {
                    currentDevs = USBDeviceInfo.GetUSBDevices();
                    prevDevs = USBDeviceInfo.GetUSBDevices();
                    usbFinder.Enabled = true;
                    resetDeviceButton.Enabled = false;
                }
                else
                {
                    resetDeviceButton.Enabled = true;
                }
            }
            else
            {
                usbPanel.Visible = false;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string[] dinfo = { };
            deviceInfoLabel.Text = "No trigger device\r\n(Unplug and) plug in desired trigger device";
            devinfo = dinfo;
            currentDevs = USBDeviceInfo.GetUSBDevices();
            prevDevs = USBDeviceInfo.GetUSBDevices();
            resetDeviceButton.Enabled = false;
            usbFinder.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            prevDevs = currentDevs;
            currentDevs = USBDeviceInfo.GetUSBDevices();
            if ((currentDevs != prevDevs) && (currentDevs.Count >= prevDevs.Count))
            {
                for (int i = 0; i < currentDevs.Count; i++)
                {
                    if (!prevDevs.Contains(currentDevs[i]))
                    {
                        string[] usbinfo = { currentDevs[i].DeviceID, currentDevs[i].PnpDeviceID, currentDevs[i].Description };
                        devinfo = usbinfo;
                        deviceInfoLabel.Text = "Trigger device: " + devinfo[2] + "(Device ID: " + devinfo[0] + ")";
                        usbFinder.Enabled = false;
                        resetDeviceButton.Enabled = true;
                        break;
                    }
                }
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" - A standard user account doesn't have access to all devices plugged into the computer. Sometimes, certain devices are only detected when the program is started as an administrator.\r\n - Try a different USB port, such as the one on your case. USB hubs might not update the device properly sometimes.\r\n - Try a different trigger device", "Device troubleshooting", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LetCloseBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!letCloseBox.Checked)
            {
                if (MessageBox.Show("Warning: This feature is experimental and WILL NOT work with all error screens. If you are unable to close the blue screen, use task manager to end it. Do you still want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    letCloseBox.Checked = true;
                }
            }
        }

        private void MatchAllRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (matchAllRadio.Checked)
            {
                letCloseBox.Enabled = !blackninja.Contains(UIActions.me.GetString("os"));
                letCloseBox.Checked = true;
            }
            else
            {
                letCloseBox.Enabled = !blackninja.Contains(me.GetString("os"));
                letCloseBox.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Program.f2.closecuzhidden = !closePrank.Checked;
        }

        private void PrankMode_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.f2.Visible)
            {
                Program.f2.closecuzhidden = false;
            }
        }
    }
}

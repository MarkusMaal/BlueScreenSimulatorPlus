using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin2Framework.Controls;
using Microsoft.Win32;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator.Forms.Interfaces
{
    internal class PrankModeActions
    {
        private readonly static string releaseId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
        private readonly static int buildNumber = Convert.ToInt32(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", "0").ToString());

        private static string MsgBoxMessage = "Enter a message here.";
        private static string MsgBoxTitle = "Enter a title here";
        private static string[] time = { "00", "05", "00" };
        private static List<USBDeviceInfo> currentDevs = new List<USBDeviceInfo>();
        private static List<USBDeviceInfo> prevDevs = new List<USBDeviceInfo>();
        private static string[] devinfo = { };
        private static bool timecatch = true;
        private static int contain = 0;
        private static MessageBoxIcon MsgBoxIcon = MessageBoxIcon.Exclamation;
        private static MessageBoxButtons MsgBoxType = MessageBoxButtons.OK;
        private readonly static List<string> blackninja = new List<string>
        {
            "Windows Vista/7",
            "Windows XP",
            "Windows 2000",
            "Windows NT 3.x/4.0",
            "Windows 9x/Me",
            "Windows 3.1x",
            "Windows 1.x/2.x"
        };

        public static void InitPrankMode(Dictionary<string, Control> c)
        {
            Program.F1.tabPage4.Enabled = UIActions.me != null;
            if (UIActions.me == null)
            {
                MessageBox.Show("Failed to initialize prank mode! Reason: No configuration selected!", "Prank mode error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string winver = releaseId;
            if (((MaterialRadioButton)c["bestMatchRadio"]).Checked == true)
            {
                Program.F1.winMode.Checked = false;
                //this code identifies Windows 11
                if (winver.Contains("Windows 11"))
                {
                    for (int i = 0; i < Program.F1.windowVersion.Items.Count; i++)
                    {
                        if (Program.F1.windowVersion.Items[i].ToString().Contains("Windows 11"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows 10
                else if (winver.Contains("Windows 10"))
                {
                    for (int i = 0; i < Program.F1.windowVersion.Items.Count; i++)
                    {
                        if (Program.F1.windowVersion.Items[i].ToString().Contains("Windows 10"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows 8 or Windows 8.1
                else if (winver.Contains("Windows 8"))
                {
                    for (int i = 0; i < Program.F1.windowVersion.Items.Count; i++)
                    {
                        if (Program.F1.windowVersion.Items[i].ToString().Contains("Windows 8"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows 7 or Windows Vista
                else if ((winver.Contains("Windows 7")) || (winver.Contains("Windows Vista")))
                {
                    for (int i = 0; i < Program.F1.windowVersion.Items.Count; i++)
                    {
                        if (Program.F1.windowVersion.Items[i].ToString().Contains("Windows Vista"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows XP
                else if (winver.Contains("Windows XP"))
                {
                    for (int i = 0; i < Program.F1.windowVersion.Items.Count; i++)
                    {
                        if (Program.F1.windowVersion.Items[i].ToString().Contains("Windows XP"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows 2000
                else if ((winver.Contains("Windows 2000")) || (winver.Contains("Windows NT 5")))
                {
                    for (int i = 0; i < Program.F1.windowVersion.Items.Count; i++)
                    {
                        if (Program.F1.windowVersion.Items[i].ToString().Contains("Windows 2000"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows 95 or Windows 98
                else if ((winver.Contains("Windows 95")) || (winver.Contains("Windows 98")))
                {
                    for (int i = 0; i < Program.F1.windowVersion.Items.Count; i++)
                    {
                        if (Program.F1.windowVersion.Items[i].ToString().Contains("Windows 9x"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies old Windows NT versions
                else if ((winver.Contains("Windows NT 4")) || (winver.Contains("Windows NT 3")))
                {
                    for (int i = 0; i < Program.F1.windowVersion.Items.Count; i++)
                    {
                        if (Program.F1.windowVersion.Items[i].ToString().Contains("Windows NT"))
                        {
                            contain = i;
                        }
                    }
                }
                //this code identifies Windows 3.1x or unknown Windows versions
                else
                {
                    for (int i = 0; i < Program.F1.windowVersion.Items.Count; i++)
                    {
                        if (Program.F1.windowVersion.Items[i].ToString().Contains("Windows 3.1"))
                        {
                            contain = i;
                        }
                    }
                }
                // this is bad, don't uncomment
                //UIActions.me = Program.templates.GetAt(contain);
                if (contain == -1)
                {
                    ((MaterialCheckbox)c["bestMatchRadio"]).Checked = false;
                    ((MaterialCheckbox)c["bestMatchRadio"]).Enabled = false;
                    ((MaterialCheckbox)c["matchAllRadio"]).Checked = true;
                    ((MaterialCheckbox)c["matchAllRadio"]).Enabled = false;
                    MessageBox.Show("Due to blue screen simulator plus configuration or the specific version of Windows you are using, it is not possible to use a bluescreen similar to one that your Windows version uses. If this is what you want to do, please enable your Windows version in BSSP settings or settings file. If this message still pops up, then use a different Windows version.", "Unable to autodetect Windows version", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            c["letCloseBox"].Enabled = !blackninja.Contains(Program.templates.GetAt(contain).GetString("os"));
        }

        public static void ToggleVisible(Dictionary<string, Control> c, Timer usbFinder)
        {
            Control timePanel = c["timePanel"];
            Control timerBox = c["timerBox"];
            MaterialRadioButton timeRadio = (MaterialRadioButton)c["timeRadio"];
            MaterialRadioButton appRadio = (MaterialRadioButton)c["appRadio"];
            Control triggerAppBox = c["triggerAppBox"];
            MaterialRadioButton usbRadio = (MaterialRadioButton)c["usbRadio"];
            Control usbPanel = c["usbPanel"];
            MaterialButton resetDeviceButton = (MaterialButton)c["resetDeviceButton"];
            Control appPanel = c["appPanel"];
            timePanel.Visible = timeRadio.Checked;
            timerBox.Enabled = timeRadio.Checked;
            timecatch = timeRadio.Checked;
            usbPanel.Visible = usbRadio.Checked;
            if (usbPanel.Visible)
            {
                if (devinfo.Length == 0)
                {
                    currentDevs = USBDeviceInfo.GetUSBDevices();
                    prevDevs = USBDeviceInfo.GetUSBDevices();
                    usbFinder.Enabled = true;
                    resetDeviceButton.Enabled = false;
                } else
                {
                    resetDeviceButton.Enabled = true;
                }
            }
            appPanel.Visible = appRadio.Checked;
            triggerAppBox.Enabled = appRadio.Checked;
        }

        public static void ToggleFriendlyMessage(Dictionary<string, Control> c)
        {
            MaterialCheckbox friendlyMessageBox = (MaterialCheckbox)c["friendlyMessageBox"];
            Control friendlyMessageContentsBox = c["friendlyMessageContentsBox"];
            Control friendlyMessageTitleBox = c["friendlyMessageTitleBox"];
            Control friendlyMessageIconPanel = c["friendlyMessageIconPanel"];
            Control friendlyMessageButtonsPanel = c["friendlyMessageButtonsPanel"];
            Control previewFriendlyMessageButton = c["previewFriendlyMessageButton"];
            bool isVisible = friendlyMessageBox.Checked;
            friendlyMessageContentsBox.Enabled = isVisible;
            friendlyMessageTitleBox.Enabled = isVisible;
            friendlyMessageIconPanel.Enabled = isVisible;
            friendlyMessageButtonsPanel.Enabled = isVisible;
            previewFriendlyMessageButton.Enabled = isVisible;
        }

        public static void UpdateFriendlyMessage(Dictionary<string, Control> c, Dictionary<string, MaterialRadioButton> radioButtons)
        {
            Control friendlyMessageContentsBox = c["friendlyMessageContentsBox"];
            Control friendlyMessageTitleBox = c["friendlyMessageTitleBox"];
            MaterialRadioButton errorRadio = radioButtons["errorRadio"];
            MaterialRadioButton warningRadio = radioButtons["warningRadio"];
            MaterialRadioButton questionRadio = radioButtons["questionRadio"];
            MaterialRadioButton infoRadio = radioButtons["infoRadio"];
            MaterialRadioButton noneRadio = radioButtons["noneRadio"];
            MaterialRadioButton okRadio = radioButtons["okRadio"];
            MaterialRadioButton okCancelRadio = radioButtons["okCancelRadio"]; 
            MaterialRadioButton retryIgnoreAboutRadio = radioButtons["retryIgnoreAboutRadio"]; 
            MaterialRadioButton yesNoRadio = radioButtons["yesNoRadio"];
            MaterialRadioButton yesNoCancelRadio = radioButtons["yesNoCancelRadio"];
            MaterialRadioButton retryCancelRadio = radioButtons["retryCancelRadio"];
            Control timerBox = c["timerBox"];
            MsgBoxMessage = friendlyMessageContentsBox.Text;
            MsgBoxTitle = friendlyMessageTitleBox.Text;
            Dictionary<MaterialRadioButton, MessageBoxIcon> msgIcons = new Dictionary<MaterialRadioButton, MessageBoxIcon>()
            {
                { errorRadio, MessageBoxIcon.Error },
                { warningRadio, MessageBoxIcon.Exclamation },
                { questionRadio, MessageBoxIcon.Question },
                { infoRadio, MessageBoxIcon.Information },
                { noneRadio, MessageBoxIcon.None }
            };
            Dictionary<MaterialRadioButton, MessageBoxButtons> msgButtons = new Dictionary<MaterialRadioButton, MessageBoxButtons>()
            {
                { okRadio, MessageBoxButtons.OK },
                { okCancelRadio, MessageBoxButtons.OK },
                { retryIgnoreAboutRadio, MessageBoxButtons.AbortRetryIgnore },
                { yesNoRadio, MessageBoxButtons.YesNo },
                { yesNoCancelRadio, MessageBoxButtons.YesNoCancel },
                { retryCancelRadio, MessageBoxButtons.RetryCancel },
            };
            foreach (KeyValuePair<MaterialRadioButton, MessageBoxIcon> pair in msgIcons)
            {
                if (pair.Key.Checked)
                {
                    MsgBoxIcon = pair.Value;
                    break;
                }
            }
            foreach (KeyValuePair<MaterialRadioButton, MessageBoxButtons> pair in msgButtons)
            {
                if (pair.Key.Checked)
                {
                    MsgBoxType = pair.Value;
                    break;
                }
            }
            time = timerBox.Text.Split(':');
        }

        public static void ShowMessage()
        {
            MessageBox.Show(MsgBoxMessage, MsgBoxTitle, MsgBoxType, MsgBoxIcon);
        }

        public static void BestAllMatchCheck(MaterialRadioButton bestMatchRadio, MaterialRadioButton matchAllRadio, MaterialCheckbox letCloseBox)
        {
            letCloseBox.Enabled = !blackninja.Contains(UIActions.me.GetString("os"));
            letCloseBox.Checked = matchAllRadio.Checked;
            if (bestMatchRadio.Enabled && matchAllRadio.Checked && (MessageBox.Show("This option may not look legitimate. Are you sure you'd like to continue?", "This prank may not look legitimate", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No))
            {
                matchAllRadio.Checked = false;
                bestMatchRadio.Checked = true;
            }
        }

        public static void OKClick(Form f, MaterialCheckbox closePrank, MaterialRadioButton bestMatchRadio,
            MaterialRadioButton timeRadio, MaterialRadioButton appRadio, Control triggerAppBox, MaterialCheckbox friendlyMessageBox,
            MaterialCheckbox letCloseBox)
        {
            string messageA = "The program will now be hidden. Once the prank has been triggered, the program will reopen itself.";
            string messageB = "The program will now be hidden. Once the prank has been triggered, the program will reopen iteself and then close after exiting the blue screen.";
            string message = messageB;
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
                if (bestMatchRadio.Checked)
                {
                    if (buildNumber >= 22000) { winver = "Windows 11"; }
                    Program.F1.winMode.Checked = false;
                    for (int i = 0; i < Program.templates.Count; i++)
                    {
                        if (winver.Contains(Program.templates.GetAt(i).GetString("os")))
                        {
                            UIActions.me = Program.templates.GetAt(i);
                            Program.F1.windowVersion.SelectedIndex = Program.F1.windowVersion.Items.Count - 1 - i;
                        }
                    }
                }
                //this code handles blue screen triggers and final message, if exists
                string[] emptydev = { };
                if (timeRadio.Checked)
                {
                    Program.gs.PM_Timecatch = timecatch;
                    int hrs = Convert.ToInt32(time[0].Replace("00", "0").Replace("01", "1").Replace("02", "2").Replace("03", "3").Replace("04", "4").Replace("05", "5").Replace("06", "6").Replace("07", "7").Replace("08", "8").Replace("09", "9"));
                    int mins = Convert.ToInt32(time[1].Replace("00", "0").Replace("01", "1").Replace("02", "2").Replace("03", "3").Replace("04", "4").Replace("05", "5").Replace("06", "6").Replace("07", "7").Replace("08", "8").Replace("09", "9"));
                    int secs = Convert.ToInt32(time[2].Replace("00", "0").Replace("01", "1").Replace("02", "2").Replace("03", "3").Replace("04", "4").Replace("05", "5").Replace("06", "6").Replace("07", "7").Replace("08", "8").Replace("09", "9"));
                    int[] timex = { hrs, mins, secs };
                    Program.gs.PM_Time = timex;
                    Program.gs.PM_UsbDevice = emptydev;
                    Program.F1.prankModeTimer.Interval = 1000;
                }
                else if (appRadio.Checked)
                {
                    Program.gs.PM_Timecatch = false;
                    Program.gs.PM_AppName = triggerAppBox.Text;
                    Program.gs.PM_UsbDevice = emptydev;
                    Program.F1.prankModeTimer.Interval = 1000;
                }
                else
                {
                    Program.gs.PM_Timecatch = false;
                    Program.gs.PM_UsbDevice = devinfo;
                    Program.F1.prankModeTimer.Interval = 100;
                }
                if (friendlyMessageBox.Checked == true)
                {
                    Program.gs.PM_ShowMessage = true;
                    Program.gs.PM_MsgIcon = MsgBoxIcon;
                    Program.gs.PM_MsgType = MsgBoxType;
                    Program.gs.PM_MsgText = MsgBoxMessage;
                    Program.gs.PM_MsgTitle = MsgBoxTitle;
                }
                f.Hide();
                Program.F1.waterBox.Checked = false;
                Program.F1.prankModeTimer.Enabled = true;
                Program.gs.PM_Lockout = !letCloseBox.Checked;
            }
        }

        public static void USBReset(Control deviceInfoLabel, Control resetDeviceButton, Timer usbFinder)
        {
            string[] dinfo = { };
            deviceInfoLabel.Text = "No trigger device\r\n(Unplug and) plug in desired trigger device";
            devinfo = dinfo;
            currentDevs = USBDeviceInfo.GetUSBDevices();
            prevDevs = USBDeviceInfo.GetUSBDevices();
            resetDeviceButton.Enabled = false;
            usbFinder.Enabled = true;
        }

        public static void TimerTick(Control deviceInfoLabel, Control resetDeviceButton, Timer usbFinder)
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

        public static void USBTroubleshoot(object sender, EventArgs e)
        {
            MessageBox.Show(" - A standard user account doesn't have access to all devices plugged into the computer. Sometimes, certain devices are only detected when the program is started as an administrator.\r\n - Try a different USB port, such as the one on your case. USB hubs might not update the device properly sometimes.\r\n - Try a different trigger device", "Device troubleshooting", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void LetCloseBox_CheckedChanged(MaterialCheckbox letCloseBox)
        {
            if (!letCloseBox.Checked)
            {
                if (MessageBox.Show("Warning: This feature is experimental and WILL NOT work with all error screens. If you are unable to close the blue screen, use task manager to end it. Do you still want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    letCloseBox.Checked = true;
                }
            }
        }

        public static void ReopenCheckedChanged(MaterialCheckbox closePrank)
        {
            Program.gs.PM_CloseMainUI = !closePrank.Checked;
        }

        public static void PrankMode_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.F1.Visible)
            {
                Program.gs.PM_Lockout = false;
            }
        }
    }
}

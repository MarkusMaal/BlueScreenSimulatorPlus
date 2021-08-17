using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class PrankMode : Form
    {
        readonly string releaseId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();

        string MsgBoxMessage = "Enter a message here.";
        string MsgBoxTitle = "Enter a title here";
        string[] time = { "00", "05", "00" };
        List<USBDeviceInfo> currentDevs = new List<USBDeviceInfo>();
        List<USBDeviceInfo> prevDevs = new List<USBDeviceInfo>();
        string[] devinfo = { };
        bool timecatch = true;
        MessageBoxIcon MsgBoxIcon = MessageBoxIcon.Exclamation;
        MessageBoxButtons MsgBoxType = MessageBoxButtons.OK;
        public PrankMode()
        {
            InitializeComponent();
        }

        private void PrankMode_Load(object sender, EventArgs e)
        {

            string winver = releaseId;
            MessageBox.Show(releaseId);
            int contain = -1;
            if (radioButton1.Checked == true)
            {
                Program.f1.winMode.Checked = false;
                //this code identifies Windows 10
                if (winver.Contains("Windows 10"))
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
                if (contain == -1)
                {
                    radioButton1.Checked = false;
                    radioButton1.Enabled = false;
                    radioButton2.Checked = true;
                    radioButton2.Enabled = false;
                    MessageBox.Show("Due to blue screen simulator plus configuration or the specific version of Windows you are using, it is not possible to use a bluescreen similar to one that your Windows version uses. If this is what you want to do, please enable your Windows version in BSSP settings or settings file. If this message still pops up, then use a different Windows version.", "Unable to autodetect Windows version", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                panel3.Visible = true;
                maskedTextBox1.Enabled = true;
                timecatch = true;
            } else
            {
                panel3.Visible = false;
                maskedTextBox1.Enabled = false;
                timecatch = false;
            }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                panel4.Visible = true;
                textBox1.Enabled = true;
            }
            else
            {
                panel4.Visible = false;
                textBox1.Enabled = false;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                flowLayoutPanel1.Enabled = true;
                flowLayoutPanel2.Enabled = true;
                button1.Enabled = true;
            } else
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                flowLayoutPanel1.Enabled = false;
                flowLayoutPanel2.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            MsgBoxMessage = textBox2.Text;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            MsgBoxTitle = textBox3.Text;
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                MsgBoxIcon = MessageBoxIcon.Error;
            }
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                MsgBoxIcon = MessageBoxIcon.Exclamation;
            }
        }

        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                MsgBoxIcon = MessageBoxIcon.Question;
            }
        }

        private void RadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true)
            {
                MsgBoxIcon = MessageBoxIcon.Information;
            }
        }

        private void RadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked == true)
            {
                MsgBoxIcon = MessageBoxIcon.None;
            }
        }

        private void RadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked == true)
            {
                MsgBoxType = MessageBoxButtons.OK;
            }
        }

        private void RadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked == true)
            {
                MsgBoxType = MessageBoxButtons.OKCancel;
            }
        }

        private void RadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton12.Checked == true)
            {
                MsgBoxType = MessageBoxButtons.AbortRetryIgnore;
            }
        }

        private void RadioButton13_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton13.Checked == true)
            {
                MsgBoxType = MessageBoxButtons.YesNo;
            }
        }

        private void RadioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton14.Checked == true)
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
            if (radioButton1.Enabled == true)
            { 
                if (radioButton2.Checked == true)
                {
                    if (MessageBox.Show("This option may not look legitimate. Are you sure you'd like to continue?", "This prank may not look legitimate", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        radioButton2.Checked = false;
                        radioButton1.Checked = true;
                    }
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //this confirms the action
            if (MessageBox.Show("The program will now be hidden. Once the prank has been triggered, the program will reopen itself.", "Prank mode will begin if you click OK", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                //this gets the Windows product name
                string winver = releaseId;
                //this makes sure that the blue screen type matches the OS
                if (radioButton1.Checked == true)
                {
                    Program.f1.winMode.Checked = false;
                    for (int i = 0; i < Program.bluescreens.Count; i++)
                    {
                        if (winver.Contains(Program.bluescreens[i].GetString("os")))
                        {
                            Program.f1.me = Program.bluescreens[i];
                            Program.f1.windowVersion.SelectedIndex = Program.f1.windowVersion.Items.Count - 1 - i;
                        }
                    }
                }
                //this code handles blue screen triggers and final message, if exists
                string[] emptydev = { };
                if (radioButton3.Checked == true)
                {
                    Program.f1.timecatch = timecatch;
                    int hrs = Convert.ToInt32(time[0].Replace("00", "0").Replace("01", "1").Replace("02", "2").Replace("03", "3").Replace("04", "4").Replace("05", "5").Replace("06", "6").Replace("07", "7").Replace("08", "8").Replace("09", "9"));
                    int mins = Convert.ToInt32(time[1].Replace("00", "0").Replace("01", "1").Replace("02", "2").Replace("03", "3").Replace("04", "4").Replace("05", "5").Replace("06", "6").Replace("07", "7").Replace("08", "8").Replace("09", "9"));
                    int secs = Convert.ToInt32(time[2].Replace("00", "0").Replace("01", "1").Replace("02", "2").Replace("03", "3").Replace("04", "4").Replace("05", "5").Replace("06", "6").Replace("07", "7").Replace("08", "8").Replace("09", "9"));
                    int[] timex = { hrs, mins, secs };
                    Program.f1.time = timex;
                    Program.f1.usb_device = emptydev;
                    Program.f1.timer2.Interval = 1000;
                } else if (radioButton4.Checked)
                {
                    Program.f1.timecatch = false;
                    Program.f1.appname = textBox1.Text;
                    Program.f1.usb_device = emptydev;
                    Program.f1.timer2.Interval = 1000;
                } else
                {
                    Program.f1.timecatch = false;
                    Program.f1.usb_device = devinfo;
                    Program.f1.timer2.Interval = 100;
                }
                if (checkBox2.Checked == true)
                {
                    Program.f1.showmsg = true;
                    Program.f1.MsgBoxIcon = MsgBoxIcon;
                    Program.f1.MsgBoxType = MsgBoxType;
                    Program.f1.MsgBoxMessage = MsgBoxMessage;
                    Program.f1.MsgBoxTitle = MsgBoxTitle;
                }
                Program.f1.Hide();
                Program.f1.waterBox.Checked = false;
                Program.f1.timer2.Enabled = true;
                Program.f1.lockout = !checkBox1.Checked;
                this.Close();
            }
        }
     
        private void MaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            time = maskedTextBox1.Text.Split(':');
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton15_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton15.Checked == true)
            {
                MsgBoxType = MessageBoxButtons.RetryCancel;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton16.Checked == true)
            {
                panel5.Visible = true;
                if (devinfo.Length == 0)
                {
                    currentDevs = USBDeviceInfo.GetUSBDevices();
                    prevDevs = USBDeviceInfo.GetUSBDevices();
                    timer1.Enabled = true;
                    button4.Enabled = false;
                } else
                {
                    button4.Enabled = true;
                }
            }
            else
            {
                panel5.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] dinfo = { };
            label9.Text = "No trigger device\r\n(Unplug and) plug in desired trigger device";
            devinfo = dinfo;
            currentDevs = USBDeviceInfo.GetUSBDevices();
            prevDevs = USBDeviceInfo.GetUSBDevices();
            button4.Enabled = false;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
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
                        label9.Text = "Trigger device: " + devinfo[2] + "(Device ID: " + devinfo[0] + ")";
                        timer1.Enabled = false;
                        button4.Enabled = true;
                        break;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" - A standard user account doesn't have access to all devices plugged into the computer. Sometimes, certain devices are only detected when the program is started as an administrator.\r\n - Try a different USB port, such as the one on your case. USB hubs might not update the device properly sometimes.\r\n - Try a different trigger device", "Device troubleshooting", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

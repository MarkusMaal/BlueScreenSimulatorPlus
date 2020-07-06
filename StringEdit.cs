using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UltimateBlueScreenSimulator
{
    public partial class StringEdit : Form
    {
        //themes
        Color[] bsodmodern = { Color.FromArgb(16, 113, 170), Color.White };
        Color[] bsodxvs = { Color.Navy, Color.White };
        Color[] bsodnt = { Color.FromArgb(0, 0, 168), Color.FromArgb(170, 170, 170) };
        Color[] bsodold = { Color.FromArgb(0, 0, 170), Color.White, Color.FromArgb(170, 170, 170), Color.FromArgb(0, 0, 170) };
        //modern blue screen emoticon string
        string emoticon = ":(";

        public StringEdit()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //applies hacks
            Program.f1.emoticon = emoticon;
            Program.f1.bsodmodern = bsodmodern;
            Program.f1.bsodxvs = bsodxvs;
            Program.f1.bsodnt = bsodnt;
            Program.f1.bsodold = bsodold;
            Program.f1.blinkspeed = Convert.ToInt32(textBox7.Text);
            this.Close();
        }

        private void WinVers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //This code executes when Windows version is changed/deselected/selected
            ReloadIndex();
            if (winVers.SelectedItems.Count < 1)
            {
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    c.Visible = false;
                }
            }
        }

        void ReloadIndex(bool full = true)
        {
            try { 
            if (full) { MessageView.Items.Clear(); }
            if (winVers.Items[0].Selected == true)
            {
                if (full)
                { 
                    MessageView.Items.Add("Title", 3);
                    MessageView.Items.Add("Text: No unresponsive programs", 3);
                    MessageView.Items.Add("Prompt", 3);
                    MessageView.Items.Add("Blink speed", 4);
                    MessageView.Items.Add("Highlight background color", 5);
                    MessageView.Items.Add("Highlight foreground color", 5);
                    MessageView.Items.Add("Background color", 5);
                    MessageView.Items.Add("Foreground color", 5);
                    MessageView.Items[0].SubItems.Add("");
                    MessageView.Items[1].SubItems.Add("");
                    MessageView.Items[2].SubItems.Add("");
                    MessageView.Items[3].SubItems.Add("");
                    MessageView.Items[4].SubItems.Add("");
                    MessageView.Items[5].SubItems.Add("");
                    MessageView.Items[6].SubItems.Add("");
                    MessageView.Items[7].SubItems.Add("");
                }
                MessageView.Items[0].SubItems[1].Text = textBox1.Text;
                MessageView.Items[1].SubItems[1].Text = textBox6.Text;
                MessageView.Items[2].SubItems[1].Text = textBox5.Text;
                MessageView.Items[3].SubItems[1].Text = textBox7.Text + " ms";
                MessageView.Items[4].SubItems[1].Text = "RGB(" + bsodold[2].R.ToString() + "," + bsodold[2].G.ToString() + "," + bsodold[2].B.ToString() + ")";
                MessageView.Items[5].SubItems[1].Text = "RGB(" + bsodold[3].R.ToString() + "," + bsodold[3].G.ToString() + "," + bsodold[3].B.ToString() + ")";
                MessageView.Items[6].SubItems[1].Text = "RGB(" + bsodold[0].R.ToString() + "," + bsodold[0].G.ToString() + "," + bsodold[0].B.ToString() + ")";
                MessageView.Items[7].SubItems[1].Text = "RGB(" + bsodold[1].R.ToString() + "," + bsodold[1].G.ToString() + "," + bsodold[1].B.ToString() + ")";
            }
            else if (winVers.Items[1].Selected == true)
            {
                if (full)
                {
                    MessageView.Items.Clear();
                    MessageView.Items.Add("Main title", 3);
                    MessageView.Items.Add("Title: System is busy", 3);
                    MessageView.Items.Add("Title: WARNING!", 3);
                    MessageView.Items.Add("Text: System error", 3);
                    MessageView.Items.Add("Text: Application error", 3);
                    MessageView.Items.Add("Text: Driver error", 3);
                    MessageView.Items.Add("Text: System is busy", 3);
                    MessageView.Items.Add("Text: System is unresponsive", 3);
                    MessageView.Items.Add("Prompt", 3);
                    MessageView.Items.Add("Blink speed", 4);
                    MessageView.Items.Add("Highlight background color", 5);
                    MessageView.Items.Add("Highlight foreground color", 5);
                    MessageView.Items.Add("Background color", 5);
                    MessageView.Items.Add("Foreground color", 5);
                    MessageView.Items[0].SubItems.Add("");
                    MessageView.Items[1].SubItems.Add("");
                    MessageView.Items[2].SubItems.Add("");
                    MessageView.Items[3].SubItems.Add("");
                    MessageView.Items[4].SubItems.Add("");
                    MessageView.Items[5].SubItems.Add("");
                    MessageView.Items[6].SubItems.Add("");
                    MessageView.Items[7].SubItems.Add("");
                    MessageView.Items[8].SubItems.Add("");
                    MessageView.Items[9].SubItems.Add("");
                    MessageView.Items[10].SubItems.Add("");
                    MessageView.Items[11].SubItems.Add("");
                    MessageView.Items[12].SubItems.Add("");
                    MessageView.Items[13].SubItems.Add("");
                }
                MessageView.Items[0].SubItems[1].Text = textBox1.Text;
                MessageView.Items[1].SubItems[1].Text = textBox2.Text;
                MessageView.Items[2].SubItems[1].Text = textBox3.Text;
                MessageView.Items[3].SubItems[1].Text = textBox4.Text;
                MessageView.Items[4].SubItems[1].Text = textBox8.Text;
                MessageView.Items[5].SubItems[1].Text = textBox9.Text;
                MessageView.Items[6].SubItems[1].Text = textBox10.Text;
                MessageView.Items[7].SubItems[1].Text = textBox11.Text;
                MessageView.Items[8].SubItems[1].Text = textBox5.Text;
                MessageView.Items[9].SubItems[1].Text = textBox7.Text + " ms";
                MessageView.Items[10].SubItems[1].Text = "RGB(" + bsodold[2].R.ToString() + "," + bsodold[2].G.ToString() + "," + bsodold[2].B.ToString() + ")";
                MessageView.Items[11].SubItems[1].Text = "RGB(" + bsodold[3].R.ToString() + "," + bsodold[3].G.ToString() + "," + bsodold[3].B.ToString() + ")";
                MessageView.Items[12].SubItems[1].Text = "RGB(" + bsodold[0].R.ToString() + "," + bsodold[0].G.ToString() + "," + bsodold[0].B.ToString() + ")";
                MessageView.Items[13].SubItems[1].Text = "RGB(" + bsodold[1].R.ToString() + "," + bsodold[1].G.ToString() + "," + bsodold[1].B.ToString() + ")";
            }
            else if (winVers.Items[2].Selected == true)
            {
                if (full)
                {
                    MessageView.Items.Clear();
                    MessageView.Items.Add("Text: A problem has occurred...", 3);
                    MessageView.Items.Add("CTRL+ALT+DEL message", 3);
                    MessageView.Items.Add("Text: Technical information", 3);
                    MessageView.Items.Add("Technical information formatting", 3);
                    MessageView.Items.Add("Restart message", 3);
                    MessageView.Items.Add("Set restart timer", 4);
                    MessageView.Items.Add("Font", 4);
                    MessageView.Items.Add("Background color", 5);
                    MessageView.Items.Add("Foreground color", 5);
                    MessageView.Items[0].SubItems.Add("");
                    MessageView.Items[1].SubItems.Add("");
                    MessageView.Items[2].SubItems.Add("");
                    MessageView.Items[3].SubItems.Add("");
                    MessageView.Items[4].SubItems.Add("");
                    MessageView.Items[5].SubItems.Add("");
                    MessageView.Items[6].SubItems.Add("");
                    MessageView.Items[7].SubItems.Add("");
                    MessageView.Items[8].SubItems.Add("");
                }
                MessageView.Items[0].SubItems[1].Text = textBox12.Text;
                MessageView.Items[1].SubItems[1].Text = textBox13.Text;
                MessageView.Items[2].SubItems[1].Text = textBox14.Text;
                MessageView.Items[3].SubItems[1].Text = textBox15.Text;
                MessageView.Items[4].SubItems[1].Text = textBox16.Text;
                MessageView.Items[5].SubItems[1].Text = textBox17.Text + " sec";
                MessageView.Items[6].SubItems[1].Text = label26.Font.FontFamily.GetName(0).ToString() + ";" + label26.Font.Size.ToString() + " pt";
                MessageView.Items[7].SubItems[1].Text = "RGB(" + bsodxvs[0].R.ToString() + "," + bsodxvs[0].G.ToString() + "," + bsodxvs[0].B.ToString() + ")";
                MessageView.Items[8].SubItems[1].Text = "RGB(" + bsodxvs[1].R.ToString() + "," + bsodxvs[1].G.ToString() + "," + bsodxvs[1].B.ToString() + ")";
            }
            else if (winVers.Items[3].Selected == true)
            {
                if (full)
                {
                    MessageView.Items.Clear();
                    MessageView.Items.Add("Error code formatting", 3);
                    MessageView.Items.Add("CPUID formatting", 3);
                    MessageView.Items.Add("Stack trace heading formatting", 3);
                    MessageView.Items.Add("Stack trace table formatting", 3);
                    MessageView.Items.Add("Memory address dump heading", 3);
                    MessageView.Items.Add("Memory address dump table", 3);
                    MessageView.Items.Add("Troubleshooting text", 3);
                    MessageView.Items.Add("Blink speed", 4);
                    MessageView.Items.Add("Background color", 5);
                    MessageView.Items.Add("Foreground color", 5);
                    MessageView.Items[0].SubItems.Add("");
                    MessageView.Items[1].SubItems.Add("");
                    MessageView.Items[2].SubItems.Add("");
                    MessageView.Items[3].SubItems.Add("");
                    MessageView.Items[4].SubItems.Add("");
                    MessageView.Items[5].SubItems.Add("");
                    MessageView.Items[6].SubItems.Add("");
                    MessageView.Items[7].SubItems.Add("");
                    MessageView.Items[8].SubItems.Add("");
                    MessageView.Items[9].SubItems.Add("");
                }
                MessageView.Items[0].SubItems[1].Text = textBox18.Text;
                MessageView.Items[1].SubItems[1].Text = textBox19.Text;
                MessageView.Items[2].SubItems[1].Text = textBox20.Text;
                MessageView.Items[3].SubItems[1].Text = textBox21.Text;
                MessageView.Items[4].SubItems[1].Text = textBox22.Text;
                MessageView.Items[5].SubItems[1].Text = textBox23.Text;
                MessageView.Items[6].SubItems[1].Text = textBox24.Text;
                MessageView.Items[7].SubItems[1].Text = textBox7.Text + " ms";
                MessageView.Items[8].SubItems[1].Text = "RGB(" + bsodnt[0].R.ToString() + "," + bsodnt[0].G.ToString() + "," + bsodnt[0].B.ToString() + ")";
                MessageView.Items[9].SubItems[1].Text = "RGB(" + bsodnt[1].R.ToString() + "," + bsodnt[1].G.ToString() + "," + bsodnt[1].B.ToString() + ")";
            }
            else if (winVers.Items[4].Selected == true)
                {
                if (full)
                {
                    MessageView.Items.Clear();
                    MessageView.Items.Add("Error code formatting", 3);
                    MessageView.Items.Add("Troubleshooting introduction", 3);
                    MessageView.Items.Add("Troubleshooting text", 3);
                    MessageView.Items.Add("Additional troubleshooting information", 3);
                    MessageView.Items.Add("Font", 4);
                    MessageView.Items.Add("Background color", 5);
                    MessageView.Items.Add("Foreground color", 5);
                    MessageView.Items[0].SubItems.Add("");
                    MessageView.Items[1].SubItems.Add("");
                    MessageView.Items[2].SubItems.Add("");
                    MessageView.Items[3].SubItems.Add("");
                    MessageView.Items[4].SubItems.Add("");
                    MessageView.Items[5].SubItems.Add("");
                    MessageView.Items[6].SubItems.Add("");
                }
                MessageView.Items[0].SubItems[1].Text = textBox25.Text;
                MessageView.Items[1].SubItems[1].Text = textBox26.Text;
                MessageView.Items[2].SubItems[1].Text = textBox28.Text;
                MessageView.Items[3].SubItems[1].Text = textBox29.Text;
                MessageView.Items[4].SubItems[1].Text = label39.Font.FontFamily.GetName(0).ToString() + ";" + label39.Font.Size.ToString() + " pt";
                MessageView.Items[5].SubItems[1].Text = "RGB(" + bsodxvs[0].R.ToString() + "," + bsodxvs[0].G.ToString() + "," + bsodxvs[0].B.ToString() + ")";
                MessageView.Items[6].SubItems[1].Text = "RGB(" + bsodxvs[1].R.ToString() + "," + bsodxvs[1].G.ToString() + "," + bsodxvs[1].B.ToString() + ")";
            }
            else if (winVers.Items[5].Selected == true)
            {
                if (full)
                {
                    MessageView.Items.Clear();
                    MessageView.Items.Add("Text: A problem has been detected...", 3);
                    MessageView.Items.Add("Troubleshooting introduction", 3);
                    MessageView.Items.Add("Troubleshooting text", 3);
                    MessageView.Items.Add("Text: Technical information", 3);
                    MessageView.Items.Add("Technical information formatting", 3);
                    MessageView.Items.Add("Text: Physical memory dump", 3);
                    MessageView.Items.Add("Memory dump progress formatting", 3);
                    MessageView.Items.Add("Additional troubleshooting information", 3);
                    MessageView.Items.Add("Fonts", 4);
                    MessageView.Items.Add("Background color", 5);
                    MessageView.Items.Add("Foreground color", 5);
                    MessageView.Items[0].SubItems.Add("");
                    MessageView.Items[1].SubItems.Add("");
                    MessageView.Items[2].SubItems.Add("");
                    MessageView.Items[3].SubItems.Add("");
                    MessageView.Items[4].SubItems.Add("");
                    MessageView.Items[5].SubItems.Add("");
                    MessageView.Items[6].SubItems.Add("");
                    MessageView.Items[7].SubItems.Add("");
                    MessageView.Items[8].SubItems.Add("");
                    MessageView.Items[9].SubItems.Add("");
                    MessageView.Items[10].SubItems.Add("");
                }
                MessageView.Items[0].SubItems[1].Text = textBox27.Text;
                MessageView.Items[1].SubItems[1].Text = textBox30.Text;
                MessageView.Items[2].SubItems[1].Text = textBox31.Text;
                MessageView.Items[3].SubItems[1].Text = textBox32.Text;
                MessageView.Items[4].SubItems[1].Text = textBox33.Text;
                MessageView.Items[5].SubItems[1].Text = textBox34.Text;
                MessageView.Items[6].SubItems[1].Text = textBox36.Text;
                MessageView.Items[7].SubItems[1].Text = textBox35.Text;
                MessageView.Items[8].SubItems[1].Text = "Font[] Array";
                MessageView.Items[9].SubItems[1].Text = "RGB(" + bsodxvs[0].R.ToString() + "," + bsodxvs[0].G.ToString() + "," + bsodxvs[0].B.ToString() + ")";
                MessageView.Items[10].SubItems[1].Text = "RGB(" + bsodxvs[1].R.ToString() + "," + bsodxvs[1].G.ToString() + "," + bsodxvs[1].B.ToString() + ")";

            }
            else if (winVers.Items[6].Selected == true)
            {
                if (full)
                {
                    MessageView.Items.Clear();
                    MessageView.Items.Add("Information text", 3);
                    MessageView.Items.Add("Error code formatting", 3);
                    MessageView.Items.Add("Emoticon", 3);
                    MessageView.Items.Add("Font", 4);
                    MessageView.Items.Add("Background color", 5);
                    MessageView.Items.Add("Foreground color", 5);
                    MessageView.Items[0].SubItems.Add("");
                    MessageView.Items[1].SubItems.Add("");
                    MessageView.Items[2].SubItems.Add("");
                    MessageView.Items[3].SubItems.Add("");
                    MessageView.Items[4].SubItems.Add("");
                    MessageView.Items[5].SubItems.Add("");
                }
                MessageView.Items[0].SubItems[1].Text = textBox37.Text + ";" + textBox38.Text;
                MessageView.Items[1].SubItems[1].Text = textBox39.Text;
                MessageView.Items[2].SubItems[1].Text = emoticon;
                MessageView.Items[3].SubItems[1].Text = "Font[] Array";
                MessageView.Items[4].SubItems[1].Text = "RGB(" + bsodmodern[0].R.ToString() + "," + bsodmodern[0].G.ToString() + "," + bsodmodern[0].B.ToString() + ")";
                MessageView.Items[5].SubItems[1].Text = "RGB(" + bsodmodern[1].R.ToString() + "," + bsodmodern[1].G.ToString() + "," + bsodmodern[1].B.ToString() + ")";
            }
            else if (winVers.Items[7].Selected == true)
            {
                if (full)
                {
                    MessageView.Items.Clear();
                    MessageView.Items.Add("Information text", 3);
                    MessageView.Items.Add("Additional information", 3);
                    MessageView.Items.Add("Culprit file formatting", 3);
                    MessageView.Items.Add("Error code formatting", 3);
                    MessageView.Items.Add("Progress formatting", 3);
                    MessageView.Items.Add("Emoticon", 3);
                    MessageView.Items.Add("Font", 4);
                    MessageView.Items.Add("QR code image", 4);
                    MessageView.Items.Add("QR code size", 4);
                    MessageView.Items.Add("Background color", 5);
                    MessageView.Items.Add("Foreground color", 5);
                    MessageView.Items[0].SubItems.Add("");
                    MessageView.Items[1].SubItems.Add("");
                    MessageView.Items[2].SubItems.Add("");
                    MessageView.Items[3].SubItems.Add("");
                    MessageView.Items[4].SubItems.Add("");
                    MessageView.Items[5].SubItems.Add("");
                    MessageView.Items[6].SubItems.Add("");
                    MessageView.Items[7].SubItems.Add("");
                    MessageView.Items[8].SubItems.Add("");
                    MessageView.Items[9].SubItems.Add("");
                    MessageView.Items[10].SubItems.Add("");
                }
                MessageView.Items[0].SubItems[1].Text = textBox41.Text + ";" + textBox40.Text;
                MessageView.Items[1].SubItems[1].Text = textBox42.Text;
                MessageView.Items[2].SubItems[1].Text = textBox43.Text;
                MessageView.Items[3].SubItems[1].Text = textBox45.Text;
                MessageView.Items[4].SubItems[1].Text = textBox44.Text;
                MessageView.Items[5].SubItems[1].Text = emoticon;
                MessageView.Items[6].SubItems[1].Text = "Font[] Array";
                if (defactoQR.Checked == true) { MessageView.Items[7].SubItems[1].Text = "Default"; }
                if (transparentQR.Checked == true) { MessageView.Items[7].SubItems[1].Text = "Transparent"; }
                if (customQR.Checked == true) { MessageView.Items[7].SubItems[1].Text = "Custom"; }
                MessageView.Items[8].SubItems[1].Text = trackBar1.Value.ToString();
                MessageView.Items[9].SubItems[1].Text = "RGB(" + bsodmodern[0].R.ToString() + "," + bsodmodern[0].G.ToString() + "," + bsodmodern[0].B.ToString() + ")";
                MessageView.Items[10].SubItems[1].Text = "RGB(" + bsodmodern[1].R.ToString() + "," + bsodmodern[1].G.ToString() + "," + bsodmodern[1].B.ToString() + ")";
            }
            if (full)
            {
                if (winVers.SelectedItems.Count > 0)
                { 
                    MessageView.Items[0].Selected = true;
                }
            }
            } catch
            {

            }
        }
        private void MessageView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageView.SelectedItems.Count > 0)
            { 
                if (MessageView.SelectedItems[0].ImageIndex == 3)
                {
                    label3.Text = "String properties";
                }
                else if (MessageView.SelectedItems[0].ImageIndex == 4)
                {
                    label3.Text = "Attribute properties";
                }
                else if (MessageView.SelectedItems[0].ImageIndex == 5)
                {
                    label3.Text = "Color properties";
                }
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    c.Visible = false;
                }
                if (winVers.Items[0].Selected == true)
                {
                    if (MessageView.Items[0].Selected == true)
                    {
                        OldTitle.Visible = true;
                    }
                    if (MessageView.Items[1].Selected == true)
                    {
                        OldNopeText.Visible = true;
                    }
                    if (MessageView.Items[2].Selected == true)
                    {
                        ContinueText.Visible = true;
                    }
                    if (MessageView.Items[3].Selected == true)
                    {
                        BlinkSetting.Visible = true;
                    }
                    if (MessageView.Items[4].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                    if (MessageView.Items[5].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                    if (MessageView.Items[6].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                    if (MessageView.Items[7].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                }
                else if (winVers.Items[1].Selected == true)
                {
                    if (MessageView.Items[0].Selected == true)
                    {
                        OldTitle.Visible = true;
                    }
                    if (MessageView.Items[1].Selected == true)
                    {
                        OldBusyTitle.Visible = true;
                    }
                    if (MessageView.Items[2].Selected == true)
                    {
                        OldWarnTitle.Visible = true;
                    }
                    if (MessageView.Items[3].Selected == true)
                    {
                        SystemText.Visible = true;
                    }
                    if (MessageView.Items[4].Selected == true)
                    {
                        OldAppText.Visible = true;
                    }
                    if (MessageView.Items[5].Selected == true)
                    {
                        DriverText.Visible = true;
                    }
                    if (MessageView.Items[6].Selected == true)
                    {
                        BusyText.Visible = true;
                    }
                    if (MessageView.Items[7].Selected == true)
                    {
                        WarnText.Visible = true;
                    }
                    if (MessageView.Items[8].Selected == true)
                    {
                        ContinueText.Visible = true;
                    }
                    if (MessageView.Items[9].Selected == true)
                    {
                        BlinkSetting.Visible = true;
                    }
                    if (MessageView.Items[10].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                    if (MessageView.Items[11].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                    if (MessageView.Items[12].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                    if (MessageView.Items[13].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                }
                else if (winVers.Items[2].Selected == true)
                {
                    if (MessageView.Items[0].Selected == true)
                    {
                        CEIntroduction.Visible = true;
                    }
                    if (MessageView.Items[1].Selected == true)
                    {
                        CERebootText.Visible = true;
                    }
                    if (MessageView.Items[2].Selected == true)
                    {
                        CETechText.Visible = true;
                    }
                    if (MessageView.Items[3].Selected == true)
                    {
                        CETechFormat.Visible = true;
                    }
                    if (MessageView.Items[4].Selected == true)
                    {
                        CETimerFormat.Visible = true;
                    }
                    if (MessageView.Items[5].Selected == true)
                    {
                        CETimer.Visible = true;
                    }
                    if (MessageView.Items[6].Selected == true)
                    {
                        CEFont.Visible = true;
                    }
                    if (MessageView.Items[7].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                    if (MessageView.Items[8].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                }
                else if (winVers.Items[3].Selected == true)
                {
                    if (MessageView.Items[0].Selected == true)
                    {
                        NTCodeFormat.Visible = true;
                    }
                    if (MessageView.Items[1].Selected == true)
                    {
                        NTCPUIDFormat.Visible = true;
                    }
                    if (MessageView.Items[2].Selected == true)
                    {
                        NTHeadingFormat.Visible = true;
                    }
                    if (MessageView.Items[3].Selected == true)
                    {
                        NTTableFormat.Visible = true;
                    }
                    if (MessageView.Items[4].Selected == true)
                    {
                        NTDumpHeading.Visible = true;
                    }
                    if (MessageView.Items[5].Selected == true)
                    {
                        NTDumpFormat.Visible = true;
                    }
                    if (MessageView.Items[6].Selected == true)
                    {
                        NTTroubleshootText.Visible = true;
                    }
                    if (MessageView.Items[7].Selected == true)
                    {
                        BlinkSetting.Visible = true;
                    }
                    if (MessageView.Items[8].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                    if (MessageView.Items[9].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                }
                else if (winVers.Items[4].Selected == true)
                {
                    if (MessageView.Items[0].Selected == true)
                    {
                        W2kCodeFormat.Visible = true;
                    }
                    if (MessageView.Items[1].Selected == true)
                    {
                        W2kIntroText.Visible = true;
                    }
                    if (MessageView.Items[2].Selected == true)
                    {
                        W2kTroubleshootText.Visible = true;
                    }
                    if (MessageView.Items[3].Selected == true)
                    {
                        W2kMoreInfo.Visible = true;
                    }
                    if (MessageView.Items[4].Selected == true)
                    {
                        W2kFontSetup.Visible = true;
                    }
                    if (MessageView.Items[5].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                    if (MessageView.Items[6].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                }
                else if (winVers.Items[5].Selected == true)
                {
                    if (MessageView.Items[0].Selected == true)
                    {
                        XPProblem.Visible = true;
                    }
                    if (MessageView.Items[1].Selected == true)
                    {
                        XPTroubleIntro.Visible = true;
                    }
                    if (MessageView.Items[2].Selected == true)
                    {
                        XPTroubleText.Visible = true;
                    }
                    if (MessageView.Items[3].Selected == true)
                    {
                        XPTechInfo.Visible = true;
                    }
                    if (MessageView.Items[4].Selected == true)
                    {
                        XPCodeFormat.Visible = true;
                    }
                    if (MessageView.Items[5].Selected == true)
                    {
                        XPVistaDump.Visible = true;
                    }
                    if (MessageView.Items[6].Selected == true)
                    {
                        VistaMaxDumpFormat.Visible = true;
                    }
                    if (MessageView.Items[7].Selected == true)
                    {
                        XPVistaSupport.Visible = true;
                    }
                    if (MessageView.Items[8].Selected == true)
                    {
                        XPVistaFont.Visible = true;
                    }
                    if (MessageView.Items[9].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                    if (MessageView.Items[10].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                }
                else if (winVers.Items[6].Selected == true)
                {
                    if (MessageView.Items[0].Selected == true)
                    {
                        W8Message.Visible = true;
                    }
                    if (MessageView.Items[1].Selected == true)
                    {
                        W8CodeFormat.Visible = true;
                    }
                    if (MessageView.Items[2].Selected == true)
                    {
                        ModernEmoticon.Visible = true;
                    }
                    if (MessageView.Items[3].Selected == true)
                    {
                        ModernFont.Visible = true;
                    }
                    if (MessageView.Items[4].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                    if (MessageView.Items[5].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                }
                else if (winVers.Items[7].Selected == true)
                {
                    if (MessageView.Items[0].Selected == true)
                    {
                        WXMessage.Visible = true;
                    }
                    if (MessageView.Items[1].Selected == true)
                    {
                        WXMoreInfo.Visible = true;
                    }
                    if (MessageView.Items[2].Selected == true)
                    {
                        WXAddFile.Visible = true;
                    }
                    if (MessageView.Items[3].Selected == true)
                    {
                        WXStopFormat.Visible = true;
                    }
                    if (MessageView.Items[4].Selected == true)
                    {
                        WXProgressText.Visible = true;
                    }
                    if (MessageView.Items[5].Selected == true)
                    {
                        ModernEmoticon.Visible = true;
                    }
                    if (MessageView.Items[6].Selected == true)
                    {
                        ModernFont.Visible = true;
                    }
                    if (MessageView.Items[7].Selected == true)
                    {
                        WXQRTypes.Visible = true;
                    }
                    if (MessageView.Items[8].Selected == true)
                    {
                        WXQRSize.Visible = true;
                    }
                    if (MessageView.Items[9].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                    if (MessageView.Items[10].Selected == true)
                    {
                        ColorSetup.Visible = true;
                    }
                }
            } else
           {
                label3.Text = "";
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    c.Visible = false;
                }
            }
            ReloadIndex(false);
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval = Convert.ToInt32(textBox7.Text);
                ReloadIndex(false);
                if ((winVers.Items[0].Checked == true) || (winVers.Items[1].Checked == true))
                {
                    Program.f1.blinkspeed = Convert.ToInt32(textBox7.Text);
                }
            }
            catch
            {

            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (blinkText.Visible)
            {
                blinkText.Visible = false;
            }
            else
            {
                blinkText.Visible = true;
            }
        }

        private void Panel1_VisibleChanged(object sender, EventArgs e)
        {
            if (BlinkSetting.Visible)
            {
                try
                {
                    textBox7.Text = Program.f1.blinkspeed.ToString();
                    timer1.Interval = Convert.ToInt32(textBox7.Text);
                }
                catch
                {

                }
                timer1.Enabled = true;
            } else
            {
                timer1.Enabled = false;
            }
        }

        private void ColorSetup_VisibleChanged(object sender, EventArgs e)
        {
            if (ColorSetup.Visible)
            {
                if (winVers.Items[0].Selected == true)
                { 
                    if (MessageView.Items[6].Selected == true)
                    {
                        colorDot.BackColor = bsodold[0];
                    }
                    if (MessageView.Items[7].Selected == true)
                    {
                        colorDot.BackColor = bsodold[1];
                    }
                    if (MessageView.Items[4].Selected == true)
                    {
                        colorDot.BackColor = bsodold[2];
                    }
                    if (MessageView.Items[5].Selected == true)
                    {
                        colorDot.BackColor = bsodold[3];
                    }
                }
                if (winVers.Items[1].Selected == true)
                {
                    if (MessageView.Items[12].Selected == true)
                    {
                        colorDot.BackColor = bsodold[0];
                    }
                    if (MessageView.Items[13].Selected == true)
                    {
                        colorDot.BackColor = bsodold[1];
                    }
                    if (MessageView.Items[10].Selected == true)
                    {
                        colorDot.BackColor = bsodold[2];
                    }
                    if (MessageView.Items[11].Selected == true)
                    {
                        colorDot.BackColor = bsodold[3];
                    }
                }
                if (winVers.Items[2].Selected == true)
                {
                    if (MessageView.Items[7].Selected == true)
                    {
                        colorDot.BackColor = bsodxvs[0];
                    }
                    if (MessageView.Items[8].Selected == true)
                    {
                        colorDot.BackColor = bsodxvs[1];
                    }
                }
                if (winVers.Items[3].Selected == true)
                {
                    if (MessageView.Items[8].Selected == true)
                    {
                        colorDot.BackColor = bsodnt[0];
                    }
                    if (MessageView.Items[9].Selected == true)
                    {
                        colorDot.BackColor = bsodnt[1];
                    }
                }
                if (winVers.Items[4].Selected == true)
                {
                    if (MessageView.Items[5].Selected == true)
                    {
                        colorDot.BackColor = bsodxvs[0];
                    }
                    if (MessageView.Items[6].Selected == true)
                    {
                        colorDot.BackColor = bsodxvs[1];
                    }
                }
                if (winVers.Items[5].Selected == true)
                {
                    if (MessageView.Items[9].Selected == true)
                    {
                        colorDot.BackColor = bsodxvs[0];
                    }
                    if (MessageView.Items[10].Selected == true)
                    {
                        colorDot.BackColor = bsodxvs[1];
                    }
                }
                if (winVers.Items[6].Selected == true)
                {
                    if (MessageView.Items[4].Selected == true)
                    {
                        colorDot.BackColor = bsodmodern[0];
                    }
                    if (MessageView.Items[5].Selected == true)
                    {
                        colorDot.BackColor = bsodmodern[1];
                    }
                }
                if (winVers.Items[7].Selected == true)
                {
                    if (MessageView.Items[9].Selected == true)
                    {
                        colorDot.BackColor = bsodmodern[0];
                    }
                    if (MessageView.Items[10].Selected == true)
                    {
                        colorDot.BackColor = bsodmodern[1];
                    }
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MainColorDialog.Color = colorDot.BackColor;
            if (MainColorDialog.ShowDialog() == DialogResult.OK)
            {
                colorDot.BackColor = MainColorDialog.Color;
                if (winVers.Items[0].Selected == true)
                { 
                    if (MessageView.Items[6].Selected == true)
                    {
                        Color[] cols = { colorDot.BackColor, bsodold[1], bsodold[2], bsodold[3] };
                        bsodold = cols;
                    }
                    if (MessageView.Items[7].Selected == true)
                    {
                        Color[] cols = { bsodold[0], colorDot.BackColor, bsodold[2], bsodold[3] };
                        bsodold = cols;
                    }
                    if (MessageView.Items[4].Selected == true)
                    {
                        Color[] cols = { bsodold[0], bsodold[1], colorDot.BackColor, bsodold[3] };
                        bsodold = cols;
                    }
                    if (MessageView.Items[5].Selected == true)
                    {
                        Color[] cols = { bsodold[0], bsodold[1], bsodold[2], colorDot.BackColor };
                        bsodold = cols;
                    }
                }
                if (winVers.Items[1].Selected == true)
                {
                    if (MessageView.Items[12].Selected == true)
                    {
                        Color[] cols = { colorDot.BackColor, bsodold[1], bsodold[2], bsodold[3] };
                        bsodold = cols;
                    }
                    if (MessageView.Items[13].Selected == true)
                    {
                        Color[] cols = { bsodold[0], colorDot.BackColor, bsodold[2], bsodold[3] };
                        bsodold = cols;
                    }
                    if (MessageView.Items[10].Selected == true)
                    {
                        Color[] cols = { bsodold[0], bsodold[1], colorDot.BackColor, bsodold[3] };
                        bsodold = cols;
                    }
                    if (MessageView.Items[11].Selected == true)
                    {
                        Color[] cols = { bsodold[0], bsodold[1], bsodold[2], colorDot.BackColor };
                        bsodold = cols;
                    }
                }
                if (winVers.Items[2].Selected == true)
                {
                    if (MessageView.Items[7].Selected == true)
                    {
                        Color[] cols = { colorDot.BackColor, bsodxvs[1] };
                        bsodxvs = cols;
                    }
                    if (MessageView.Items[8].Selected == true)
                    {
                        Color[] cols = { bsodxvs[0], colorDot.BackColor };
                        bsodxvs = cols;
                    }
                }
                if (winVers.Items[3].Selected == true)
                {
                    if (MessageView.Items[8].Selected == true)
                    {
                        Color[] cols = { colorDot.BackColor, bsodnt[1] };
                        bsodnt = cols;
                    }
                    if (MessageView.Items[9].Selected == true)
                    {
                        Color[] cols = { bsodnt[0], colorDot.BackColor };
                        bsodnt = cols;
                    }
                }
                if (winVers.Items[4].Selected == true)
                {
                    if (MessageView.Items[5].Selected == true)
                    {
                        Color[] cols = { colorDot.BackColor, bsodxvs[1] };
                        bsodxvs = cols;
                    }
                    if (MessageView.Items[6].Selected == true)
                    {
                        Color[] cols = { bsodxvs[0], colorDot.BackColor };
                        bsodxvs = cols;
                    }
                }
                if (winVers.Items[5].Selected == true)
                {
                    if (MessageView.Items[9].Selected == true)
                    {
                        Color[] cols = { colorDot.BackColor, bsodxvs[1] };
                        bsodxvs = cols;
                    }
                    if (MessageView.Items[10].Selected == true)
                    {
                        Color[] cols = { bsodxvs[0], colorDot.BackColor };
                        bsodxvs = cols;
                    }
                }
                if (winVers.Items[6].Selected == true)
                {
                    if (MessageView.Items[4].Selected == true)
                    {
                        Color[] cols = { colorDot.BackColor, bsodmodern[1] };
                        bsodmodern = cols;
                    }
                    if (MessageView.Items[5].Selected == true)
                    {
                        Color[] cols = { bsodmodern[0], colorDot.BackColor };
                        bsodmodern = cols;
                    }
                }
                if (winVers.Items[7].Selected == true)
                {
                    if (MessageView.Items[9].Selected == true)
                    {
                        Color[] cols = { colorDot.BackColor, bsodmodern[1] };
                        bsodmodern = cols;
                    }
                    if (MessageView.Items[10].Selected == true)
                    {
                        Color[] cols = { bsodmodern[0], colorDot.BackColor };
                        bsodmodern = cols;
                    }
                }

                ReloadIndex(false);
                Program.f1.bsodold = bsodold;
            }
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            if (OpenHack.ShowDialog() == DialogResult.OK)
            {
                LoadHack(OpenHack.FileName);
            }
        }

        public void LoadHack(string loadable)
        {
            string[] filelines = File.ReadAllLines(loadable, Encoding.Unicode);
            RealLoad(filelines);
        }

        public void RealLoad(string[] filelines)
        {
            try
            { 
                Color me9xbsodbg = bsodold[0];
                Color me9xbsodfg = bsodold[1];
                Color me9xbsodhlbg = bsodold[2];
                Color me9xbsodhlfg = bsodold[3];
                foreach (string fileline in filelines)
                {
                    if (fileline.Contains("***")) { continue; }
                    if (fileline.StartsWith("FACE "))
                    {
                        emoticon = fileline.Replace("FACE ", "");
                    }
                    else if (fileline.StartsWith("MODERN "))
                    {
                        Color[] moderns = { Color.FromArgb(Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[0].ToString().Split(':')[2].ToString())), Color.FromArgb(Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[1].ToString().Split(':')[2].ToString())) };
                        bsodmodern = moderns;
                    }
                    else if (fileline.StartsWith("W2K "))
                    {
                        Color[] modests = { Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[2].ToString())), Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[2].ToString())) };
                        bsodxvs = modests;
                    }
                    else if (fileline.StartsWith("NT34 "))
                    {
                        Color[] modests = { Color.FromArgb(Convert.ToInt32(fileline.Replace("NT34 ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("NT34 ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[2].ToString())), Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[2].ToString())) };
                        bsodnt = modests;
                    }
                    else if (fileline.StartsWith("W9XME "))
                    {
                        me9xbsodbg = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[0].ToString().Split(':')[2].ToString()));
                        me9xbsodfg = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[1].ToString().Split(':')[2].ToString()));
                    }
                    else if (fileline.StartsWith("W9XME_HL "))
                    {
                        me9xbsodhlbg = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[0].ToString().Split(':')[2].ToString()));
                        me9xbsodhlfg = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[1].ToString().Split(':')[2].ToString()));
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
                string[] stringlist = strings.Substring(1, strings.Length - 1).Replace("http://", "\\\\").Replace("//", "\t").Replace("\\\\", "http://").Split('\t');
                string[] misclist = miscs.Substring(1, miscs.Length - 1).Split('\n');
                string[] fontlist = fonts.Substring(1, fonts.Length - 1).Split('\n');
                foreach (string element in fontlist)
                {
                    if (!element.Contains(",")) { continue; }
                    string[] subfont = element.Replace("label26: ", "").Replace("label39: ", "").Replace("label49: ", "").Replace("label50: ", "").Replace("modernDetailFont: ", "").Replace("emotiFont: ", "").Replace("modernTextFont: ", "").Replace(",4", "").Split(',');
                    FontStyle fs = new FontStyle();
                    fs = FontStyle.Regular;
                    if (subfont[5] == "Bold=True") { fs |= FontStyle.Bold; }
                    if (subfont[6] == "Italic=True") { fs |= FontStyle.Italic; }
                    if (subfont[7] == "Underline=True") { fs |= FontStyle.Underline; }
                    Font newFont = new Font(subfont[0].ToString(), Convert.ToInt32(subfont[1].Replace("Size=", "")), fs);
                    if (element.StartsWith("emotiFont: ")) { emotiFont.Font = newFont; }
                    if (element.StartsWith("modernTextFont: ")) { modernTextFont.Font = newFont; }
                    if (element.StartsWith("modernDetailFont: ")) { modernDetailFont.Font = newFont; }
                    if (element.StartsWith("label50: ")) { label50.Font = newFont; }
                    if (element.StartsWith("label49: ")) { label49.Font = newFont; }
                    if (element.StartsWith("label39: ")) { label39.Font = newFont; }
                    if (element.StartsWith("label26: ")) { label26.Font = newFont; }
                }
                try
                {
                    foreach (string element in misclist)
                    {
                        if (element.StartsWith("qrType: "))
                        {
                            string decide = element.Replace("qrType: ", "");
                            defactoQR.Checked = false;
                            transparentQR.Checked = false;
                            customQR.Checked = false;
                            if (decide == "Default") { defactoQR.Checked = true; }
                            if (decide == "Transparent") { transparentQR.Checked = true; }
                            if (decide == "Custom") { customQR.Checked = true; }
                        }
                        else if (element.StartsWith("qrPath: "))
                        {
                            qrFile.Text = element.Replace("qrPath: ", "");
                        }
                        else if (element.StartsWith("qrSize: "))
                        {
                            trackBar1.Value = Convert.ToInt32(element.Replace("qrSize: ", ""));
                        }
                    }
                }
                catch { }
                textBox1.Text = stringlist[1 - 1].Replace("\n", Environment.NewLine);
                textBox2.Text = stringlist[2 - 1].Replace("\n", Environment.NewLine);
                textBox3.Text = stringlist[3 - 1].Replace("\n", Environment.NewLine);
                textBox4.Text = stringlist[4 - 1].Replace("\n", Environment.NewLine);
                textBox5.Text = stringlist[5 - 1].Replace("\n", Environment.NewLine);
                textBox6.Text = stringlist[6 - 1].Replace("\n", Environment.NewLine);
                textBox7.Text = stringlist[7 - 1].Replace("\n", Environment.NewLine);
                textBox8.Text = stringlist[8 - 1].Replace("\n", Environment.NewLine);
                textBox9.Text = stringlist[9 - 1].Replace("\n", Environment.NewLine);
                textBox10.Text = stringlist[10 - 1].Replace("\n", Environment.NewLine);
                textBox11.Text = stringlist[11 - 1].Replace("\n", Environment.NewLine);
                textBox12.Text = stringlist[12 - 1].Replace("\n", Environment.NewLine);
                textBox13.Text = stringlist[13 - 1].Replace("\n", Environment.NewLine);
                textBox14.Text = stringlist[14 - 1].Replace("\n", Environment.NewLine);
                textBox15.Text = stringlist[15 - 1].Replace("\n", Environment.NewLine);
                textBox16.Text = stringlist[16 - 1].Replace("\n", Environment.NewLine);
                textBox17.Text = stringlist[17 - 1].Replace("\n", Environment.NewLine);
                textBox18.Text = stringlist[18 - 1].Replace("\n", Environment.NewLine);
                textBox19.Text = stringlist[19 - 1].Replace("\n", Environment.NewLine);
                textBox20.Text = stringlist[20 - 1].Replace("\n", Environment.NewLine);
                textBox21.Text = stringlist[21 - 1].Replace("\n", Environment.NewLine);
                textBox22.Text = stringlist[22 - 1].Replace("\n", Environment.NewLine);
                textBox23.Text = stringlist[23 - 1].Replace("\n", Environment.NewLine);
                textBox24.Text = stringlist[24 - 1].Replace("\n", Environment.NewLine);
                textBox25.Text = stringlist[25 - 1].Replace("\n", Environment.NewLine);
                textBox26.Text = stringlist[26 - 1].Replace("\n", Environment.NewLine);
                textBox27.Text = stringlist[27 - 1].Replace("\n", Environment.NewLine);
                textBox28.Text = stringlist[28 - 1].Replace("\n", Environment.NewLine);
                textBox29.Text = stringlist[29 - 1].Replace("\n", Environment.NewLine);
                textBox30.Text = stringlist[30 - 1].Replace("\n", Environment.NewLine);
                textBox31.Text = stringlist[31 - 1].Replace("\n", Environment.NewLine);
                textBox32.Text = stringlist[32 - 1].Replace("\n", Environment.NewLine);
                textBox33.Text = stringlist[33 - 1].Replace("\n", Environment.NewLine);
                textBox34.Text = stringlist[34 - 1].Replace("\n", Environment.NewLine);
                textBox35.Text = stringlist[35 - 1].Replace("\n", Environment.NewLine);
                textBox36.Text = stringlist[36 - 1].Replace("\n", Environment.NewLine);
                textBox37.Text = stringlist[37 - 1].Replace("\n", Environment.NewLine);
                textBox38.Text = stringlist[38 - 1].Replace("\n", Environment.NewLine);
                textBox39.Text = stringlist[39 - 1].Replace("\n", Environment.NewLine);
                textBox40.Text = stringlist[40 - 1].Replace("\n", Environment.NewLine);
                textBox41.Text = stringlist[41 - 1].Replace("\n", Environment.NewLine);
                textBox42.Text = stringlist[42 - 1].Replace("\n", Environment.NewLine);
                textBox43.Text = stringlist[43 - 1].Replace("\n", Environment.NewLine);
                textBox44.Text = stringlist[44 - 1].Replace("\n", Environment.NewLine);
                textBox45.Text = stringlist[45 - 1].Replace("\n", Environment.NewLine);
                emotiBox.Text = emoticon;
                MessageView.Update();
                Color[] olds = { me9xbsodbg, me9xbsodfg, me9xbsodhlbg, me9xbsodhlfg };
                bsodold = olds;
                Program.f1.bsodmodern = bsodmodern;
                Program.f1.bsodnt = bsodnt;
                Program.f1.bsodxvs = bsodxvs;
                Program.f1.bsodold = bsodold;
                Program.f1.emoticon = emoticon;
            }
            catch (Exception ex)
            {
                if (this.Visible == false)
                { 
                    Program.f1.error = 25;
                } else
                {
                    MessageBox.Show("An error occurred while trying to load this hack\n\nException: " + ex.Message + "\nStack trace:" + ex.StackTrace.ToString(), "Hack may be corrupted or incompatible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            if (SaveHack.ShowDialog() == DialogResult.OK)
            {
                string bscfg = "";
                bscfg = "*** Blue screen simulator plus 1.11 ***\nFACE " + emoticon + "\n";
                bscfg += "MODERN " + bsodmodern[0].R.ToString() + ":" + bsodmodern[0].G.ToString() + ":" + bsodmodern[0].B.ToString() + "," + bsodmodern[1].R.ToString() + ":" + bsodmodern[1].G.ToString() + ":" + bsodmodern[1].B.ToString() + "\n";
                bscfg += "W2K " + bsodxvs[0].R.ToString() + ":" + bsodxvs[0].G.ToString() + ":" + bsodxvs[0].B.ToString() + "," + bsodxvs[1].R.ToString() + ":" + bsodxvs[1].G.ToString() + ":" + bsodxvs[1].B.ToString() + "\n";
                bscfg += "NT34 " + bsodnt[0].R.ToString() + ":" + bsodnt[0].G.ToString() + ":" + bsodnt[0].B.ToString() + "," + bsodnt[1].R.ToString() + ":" + bsodnt[1].G.ToString() + ":" + bsodnt[1].B.ToString() + "\n";
                bscfg += "W9XME " + bsodold[0].R.ToString() + ":" + bsodold[0].G.ToString() + ":" + bsodold[0].B.ToString() + "," + bsodold[1].R.ToString() + ":" + bsodold[1].G.ToString() + ":" + bsodold[1].B.ToString() + "\n";
                bscfg += "W9XME_HL " + bsodold[2].R.ToString() + ":" + bsodold[2].G.ToString() + ":" + bsodold[2].B.ToString() + "," + bsodold[3].R.ToString() + ":" + bsodold[3].G.ToString() + ":" + bsodold[3].B.ToString() + "\n";
                bscfg += "--STRINGBUILD START--\n";
                bscfg += textBox1.Text + "//";
                bscfg += textBox2.Text + "//";
                bscfg += textBox3.Text + "//";
                bscfg += textBox4.Text + "//";
                bscfg += textBox5.Text + "//";
                bscfg += textBox6.Text + "//";
                bscfg += textBox7.Text + "//";
                bscfg += textBox8.Text + "//";
                bscfg += textBox9.Text + "//";
                bscfg += textBox10.Text + "//";
                bscfg += textBox11.Text + "//";
                bscfg += textBox12.Text + "//";
                bscfg += textBox13.Text + "//";
                bscfg += textBox14.Text + "//";
                bscfg += textBox15.Text + "//";
                bscfg += textBox16.Text + "//";
                bscfg += textBox17.Text + "//";
                bscfg += textBox18.Text + "//";
                bscfg += textBox19.Text + "//";
                bscfg += textBox20.Text + "//";
                bscfg += textBox21.Text + "//";
                bscfg += textBox22.Text + "//";
                bscfg += textBox23.Text + "//";
                bscfg += textBox24.Text + "//";
                bscfg += textBox25.Text + "//";
                bscfg += textBox26.Text + "//";
                bscfg += textBox27.Text + "//";
                bscfg += textBox28.Text + "//";
                bscfg += textBox29.Text + "//";
                bscfg += textBox30.Text + "//";
                bscfg += textBox31.Text + "//";
                bscfg += textBox32.Text + "//";
                bscfg += textBox33.Text + "//";
                bscfg += textBox34.Text + "//";
                bscfg += textBox35.Text + "//";
                bscfg += textBox36.Text + "//";
                bscfg += textBox37.Text + "//";
                bscfg += textBox38.Text + "//";
                bscfg += textBox39.Text + "//";
                bscfg += textBox40.Text + "//";
                bscfg += textBox41.Text + "//";
                bscfg += textBox42.Text + "//";
                bscfg += textBox43.Text + "//";
                bscfg += textBox44.Text + "//";
                bscfg += textBox45.Text + "//";
                bscfg += "--STRINGBUILD END--\n";
                bscfg += "--FONT START--\n";
                bscfg += "emotiFont: " + emotiFont.Font.ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ",") + FontMania(emotiFont.Font) +  "\n";
                bscfg += "modernTextFont: " + modernTextFont.Font.ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ",") + FontMania(modernTextFont.Font) + "\n";
                bscfg += "modernDetailFont: " + modernDetailFont.Font.ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ",") + FontMania(modernDetailFont.Font) + "\n";
                bscfg += "label50: " + label50.Font.ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ",") + FontMania(label50.Font) + "\n";
                bscfg += "label49: " + label49.Font.ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ",") + FontMania(label49.Font) + "\n";
                bscfg += "label39: " + label39.Font.ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ",") + FontMania(label39.Font) + "\n";
                bscfg += "label26: " + label26.Font.ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ",") + FontMania(label26.Font) + "\n";
                bscfg += "--FONT END--\n";
                bscfg += "--MISC START--\n";
                bscfg += "qrSize: " + trackBar1.Value.ToString() + "\n";
                if (defactoQR.Checked == true) { MessageView.Items[7].SubItems[1].Text = "Default"; }
                if (transparentQR.Checked == true) { MessageView.Items[7].SubItems[1].Text = "Transparent"; }
                if (customQR.Checked == true) { MessageView.Items[7].SubItems[1].Text = "Custom"; }
                bscfg += "qrType: " + MessageView.Items[7].SubItems[1].Text + "\n";
                bscfg += "qrPath: " + qrFile.Text + "\n";
                bscfg += "--MISC END--\n";
                File.WriteAllText(SaveHack.FileName, bscfg, Encoding.Unicode);
            }
        }

        string FontMania(Font tb)
        {
            string outstr = ",Bold=" + tb.Bold.ToString() + ",Italic=" + tb.Italic.ToString() + ",Underline=" + tb.Underline.ToString();
            return outstr;
        }

        private void StringEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void StringEdit_Shown(object sender, EventArgs e)
        {
        }

        private void StringEdit_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                ReRe();
            }
        }

        public void ReRe()
        {
            winVers.Items.Clear();
            bsodmodern = Program.f1.bsodmodern;
            bsodxvs = Program.f1.bsodxvs;
            bsodnt = Program.f1.bsodnt;
            bsodold = Program.f1.bsodold;
            winVers.Items.Add("Windows 3.1x", 0);
            winVers.Items.Add("Windows 9x/Me", 0);
            winVers.Items.Add("Windows CE", 1);
            winVers.Items.Add("Windows NT 3.x/4.0", 0);
            winVers.Items.Add("Windows 2000", 0);
            winVers.Items.Add("Windows XP/Vista/7", 1);
            winVers.Items.Add("Windows 8/8.1", 2);
            winVers.Items.Add("Windows 10", 2);
            pictureBox1.Image = AllIcons.Images[3];
            pictureBox2.Image = AllIcons.Images[4];
            pictureBox3.Image = AllIcons.Images[5];
            winVers.Items[0].Selected = true;
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void StringEdit_Load(object sender, EventArgs e)
        {
            if (Program.f1.fileio == false)
            {
                button14.Enabled = false;
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            RealLoad(Properties.Resources._default.Split('\n'));
        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox11_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox12_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox13_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox14_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox15_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox16_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox17_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = label26.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label26.Font = fontDialog1.Font;
                ReloadIndex(false);
            }
        }

        private void TextBox18_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox19_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox20_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox21_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox22_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox23_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox24_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }


        private void TextBox29_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = label39.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label39.Font = fontDialog1.Font;
                ReloadIndex(false);
            }
        }

        private void TextBox30_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox32_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox33_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox35_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = label49.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label49.Font = fontDialog1.Font;
                ReloadIndex(false);
            }
        }

        private void TextBox36_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = label50.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label50.Font = fontDialog1.Font;
                ReloadIndex(false);
            }
        }

        private void EmotiBox_TextChanged(object sender, EventArgs e)
        {
            emoticon = emotiBox.Text;
            ReloadIndex(false);
        }

        private void ModernEmoticon_VisibleChanged(object sender, EventArgs e)
        {
            if (ModernEmoticon.Visible)
            {
                emotiBox.Text = emoticon;
            }
        }

        private void TextBox37_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void W8CodeFormat_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox39_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = modernTextFont.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                modernTextFont.Font = fontDialog1.Font;
                ReloadIndex(false);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = modernDetailFont.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                modernDetailFont.Font = fontDialog1.Font;
                ReloadIndex(false);
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = emotiFont.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                emotiFont.Font = fontDialog1.Font;
                label60.Text = "Emoticon: " + emotiFont.Font.FontFamily.GetName(0).ToString() + ";" + emotiFont.Font.Size.ToString() + "pt";
                ReloadIndex(false);
            }
        }

        private void TextBox41_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox42_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox43_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox45_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void TextBox44_TextChanged(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void DefactoQR_Click(object sender, EventArgs e)
        {
            ReloadIndex(false);
        }

        private void CustomQR_CheckedChanged(object sender, EventArgs e)
        {
            if (customQR.Checked == true)
            {
                qrFile.Enabled = true;
            } else
            {
                qrFile.Enabled = false;
            }
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            label65.Text = trackBar1.Value.ToString() + "x" + trackBar1.Value.ToString();
            ReloadIndex(false);
        }

        private void Button12_VisibleChanged(object sender, EventArgs e)
        {

        }
    }
}

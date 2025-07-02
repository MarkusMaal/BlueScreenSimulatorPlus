using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator.Forms.Legacy
{
    public partial class ErrorCodeEditor : Form
    {
        internal BlueScreen me;
        internal string c1;
        internal string c2;
        internal string c3;
        internal string c4;
        private bool init = false;
        private string topText = "The following error code method will be used:\r\n\r\n{0}";
        public ErrorCodeEditor()
        {
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
        }

        private void SwitchCode1(object sender, EventArgs e)
        {
            if (chooseCode1.Checked == true)
            {
                topLabel.Text = string.Format(topText, DispCodes(c1, c2, c3, c4));
                if (sender is TextBox) { return; } // avoid updating the textbox content if user just modified the text on it
                SetupCodes(c1);
            }
        }

        private void SwitchCode2(object sender, EventArgs e)
        {
            if (chooseCode2.Checked == true)
            {
                topLabel.Text = string.Format(topText, DispCodes(c1, c2, c3, c4));
                if (sender is TextBox) { return; } // avoid updating the textbox content if user just modified the text on it
                SetupCodes(c2);
            }
        }
        private void SwitchCode3(object sender, EventArgs e)
        {
            if (chooseCode3.Checked == true)
            {
                topLabel.Text = string.Format(topText, DispCodes(c1, c2, c3, c4));
                if (sender is TextBox) { return; } // avoid updating the textbox content if user just modified the text on it
                SetupCodes(c3);
            }
        }

        private void SwitchCode4(object sender, EventArgs e)
        {
            if (chooseCode4.Checked == true)
            {
                topLabel.Text = string.Format(topText, DispCodes(c1, c2, c3, c4));
                if (sender is TextBox) { return; } // avoid updating the textbox content if user just modified the text on it
                SetupCodes(c4);
            }
        }


        private string DispCodes(string c1, string c2, string c3, string c4)
        {
            try
            {
                if ((me.GetString("os") == "Windows XP") || (me.GetString("os") == "Windows 2000") || (me.GetString("os") == "Windows NT 3.x/4.0"))
                {
                    try
                    {
                        return "0x" + c1.Substring(0, 8) + ", 0x" + c2.Substring(0, 8) + ", 0x" + c3.Substring(0, 8) + ", 0x" + c4.Substring(0, 8);
                    }
                    catch
                    {
                        return "0xDEADDEAD, 0xDEADDEAD, 0xDEADDEAD, 0xDEADDEAD";
                    }
                }
                else if (me.GetString("os") == "Windows CE")
                {
                    return "0x" + c1.Substring(0, 6) + ", 0x" + c2.Substring(0, 6) + ", 0x" + c3.Substring(0, 6) + ", 0x" + c4.Substring(0, 6);
                }
                else if (me.GetString("os") == "Windows 9x/Me")
                {
                    chooseCode4.Enabled = false;
                    return c1.Substring(0, 2) + " : " + c2.Substring(0, 4) + " : " + c3.Substring(0, 8);
                }
                return "0x" + c1 + ", 0x" + c2 + ", 0x" + c3 + ", 0x" + c4;
            }
            catch (Exception ex) when (!Debugger.IsAttached)
            {
                Program.gs.Log("Error", "Error displaying codes: " + ex.Message);
                return "0xDEADDEADDEADDEAD, 0xDEADDEADDEADDEAD, 0xDEADDEADDEADDEAD, 0xDEADDEADDEADDEAD";
            }
        }

        private void SetupCodes(string code)
        {
            codeContent.Text = code;
        }

        private string PadRand(string code)
        {
            string ret = code;
            while (ret.Length < 16)
            {
                ret += "R";
            }
            return ret;
        }

        private void ErrorCodeEditor_Load(object sender, EventArgs e)
        {
            c1 = PadRand(me.GetCodes()[0]);
            c2 = PadRand(me.GetCodes()[1]);
            c3 = PadRand(me.GetCodes()[2]);
            c4 = PadRand(me.GetCodes()[3]);
            codeContent.Text = c1;
            topLabel.Text = string.Format(topText, DispCodes(c1, c2, c3, c4));
            this.Text += " - " + me.GetString("friendlyname");
        }

        private bool ValidateField()
        {
            string whitelistedChars = "0123456789ABCDEFR";
            string filteredString = codeContent.Text.ToUpper();
            foreach (char ch in whitelistedChars)
            {
                filteredString = filteredString.Replace(ch.ToString(), "");
            }
            return (filteredString == "") && (codeContent.Text.Length == 16);
        }

        private int GetSelectedIndex()
        {
            if (chooseCode1.Checked) { return 0; }
            else if (chooseCode2.Checked) { return 1; }
            else if (chooseCode3.Checked) { return 2; }
            else if (chooseCode4.Checked) { return 3; }
            return -1;
        }

        private void codeContent_TextChanged(object sender, EventArgs e)
        {
            if (ValidateField())
            {
                int selected = GetSelectedIndex();
                c1 = chooseCode1.Checked ? codeContent.Text.ToUpper() : c1;
                c2 = chooseCode2.Checked ? codeContent.Text.ToUpper() : c2;
                c3 = chooseCode3.Checked ? codeContent.Text.ToUpper() : c3;
                c4 = chooseCode4.Checked ? codeContent.Text.ToUpper() : c4;
                if (init)
                {
                    me.SetCodes(c1, c2, c3, c4);
                }
                else
                {
                    init = true;
                }
                switch (selected)
                {
                    case 0:
                        SwitchCode1(sender, e);
                        break;
                    case 1:
                        SwitchCode2(sender, e);
                        break;
                    case 2:
                        SwitchCode3(sender, e);
                        break;
                    case 3:
                        SwitchCode4(sender, e);
                        break;
                }
            }
            else
            {
                if (init)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                }
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            codeContent.Text = "RRRRRRRRRRRRRRRR";
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            codeContent.Text = "0000000000000000";
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            if (ValidateField())
            {
                codeContent.Text = me.GenHex(16, codeContent.Text);
            }
            else
            {
                MessageBox.Show("Entered code is invalid. Cannot calculate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            if (ValidateField())
            {
                c1 = codeContent.Text;
                c2 = codeContent.Text;
                c3 = codeContent.Text;
                c4 = codeContent.Text;
                if (init)
                {
                    me.SetCodes(c1, c2, c3, c4);
                }
                topLabel.Text = string.Format(topText, DispCodes(c1, c2, c3, c4));
            }
            else
            {
                MessageBox.Show("Entered code is invalid. Cannot apply to all!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

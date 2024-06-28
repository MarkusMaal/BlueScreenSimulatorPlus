using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class IndexForm : MaterialForm
    {
        // NOTE: NT code editor is no longer available through this form. Please use NTdtor instead!
        internal BlueScreen me;
        public string c1 = "RRRRRRRRRRRRRRRR";
        public string c2 = "RRRRRRRRRRRRRRRR";
        public string c3 = "RRRRRRRRRRRRRRRR";
        public string c4 = "RRRRRRRRRRRRRRRR";

        public IndexForm()
        {
            MaterialSkinManager materialSkinManager = Program.f1.materialSkinManager;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
        }

        private void SwitchCode1(object sender, EventArgs e)
        {
            if (chooseCode1.Checked == true)
            {
                codeSelection.Text = "Code 1";
                SetupCodes(c1);
                DispCodes(c1, c2, c3, c4);
            }
        }

        private void SwitchCode2(object sender, EventArgs e)
        {
            if (chooseCode2.Checked == true)
            {
                codeSelection.Text = "Code 2";
                SetupCodes(c2);
                DispCodes(c1, c2, c3, c4);
            }
        }
        private void SwitchCode3(object sender, EventArgs e)
        {
            if (chooseCode3.Checked == true)
            {
                codeSelection.Text = "Code 3";
                SetupCodes(c3);
                DispCodes(c1, c2, c3, c4);
            }
        }

        private void SwitchCode4(object sender, EventArgs e)
        {
            if (chooseCode4.Checked == true)
            {
                codeSelection.Text = "Code 4";
                SetupCodes(c4);
                DispCodes(c1, c2, c3, c4);
            }
        }

        private void SetupCodes(string code)
        {
            for (int i = 0; i < 12; i++)
            {
                foreach (Control c in tableLayoutPanel1.Controls)
                {
                    if (c.Name == "c1_" + (i + 1).ToString())
                    {
                        try
                        {
                            c.Text = code.Substring(i, 1);
                        } catch { }
                    }
                }
            }
        }

        private void SetTempCode(object sender, EventArgs e)
        {
            switch (codeSelection.Text)
            {
                case "Code 1":
                    c1 = "";
                    for (int i = 1; i <= 16; i++)
                    {
                        c1 += tableLayoutPanel1.Controls["c1_" + i.ToString()].Text;
                    }
                    break;
                case "Code 2":
                    c2 = "";
                    for (int i = 1; i <= 16; i++)
                    {
                        c2 += tableLayoutPanel1.Controls["c1_" + i.ToString()].Text;
                    }
                    break;
                case "Code 3":
                    c3 = "";
                    for (int i = 1; i <= 16; i++)
                    {
                        c3 += tableLayoutPanel1.Controls["c1_" + i.ToString()].Text;
                    }
                    break;
                case "Code 4":
                    c4 = "";
                    for (int i = 1; i <= 16; i++)
                    {
                        c4 += tableLayoutPanel1.Controls["c1_" + i.ToString()].Text;
                    }
                    break;
            }
            methodLabel.Text = DispCodes(c1, c2, c3, c4);
        }


        private void SetRand1(object sender, EventArgs e) { textBox1.Text = ""; c1_1.Text = "R"; }
        private void SetRand2(object sender, EventArgs e) { textBox2.Text = ""; c1_2.Text = "R"; }
        private void SetRand3(object sender, EventArgs e) { textBox3.Text = ""; c1_3.Text = "R"; }
        private void SetRand4(object sender, EventArgs e) { textBox4.Text = ""; c1_4.Text = "R"; }
        private void SetRand5(object sender, EventArgs e) { textBox5.Text = ""; c1_5.Text = "R"; }
        private void SetRand6(object sender, EventArgs e) { textBox6.Text = ""; c1_6.Text = "R"; }
        private void SetRand7(object sender, EventArgs e) { textBox7.Text = ""; c1_7.Text = "R"; }
        private void SetRand8(object sender, EventArgs e) { textBox8.Text = ""; c1_8.Text = "R"; }
        private void SetRand9(object sender, EventArgs e) { textBox9.Text = ""; c1_9.Text = "R"; }
        private void SetRand10(object sender, EventArgs e) { textBox10.Text = ""; c1_10.Text = "R"; }
        private void SetRand11(object sender, EventArgs e) { textBox11.Text = ""; c1_11.Text = "R"; }
        private void SetRand12(object sender, EventArgs e) { textBox12.Text = ""; c1_12.Text = "R"; }
        private void SetRand13(object sender, EventArgs e) { textBox13.Text = ""; c1_13.Text = "R"; }
        private void SetRand14(object sender, EventArgs e) { textBox14.Text = ""; c1_14.Text = "R"; }
        private void SetRand15(object sender, EventArgs e) { textBox15.Text = ""; c1_15.Text = "R"; }
        private void SetRand16(object sender, EventArgs e) { textBox16.Text = ""; c1_16.Text = "R"; }



        private void SetZero1(object sender, EventArgs e) { textBox1.Text = ""; c1_1.Text = "0"; }
        private void SetZero2(object sender, EventArgs e) { textBox2.Text = ""; c1_2.Text = "0"; }
        private void SetZero3(object sender, EventArgs e) { textBox3.Text = ""; c1_3.Text = "0"; }
        private void SetZero4(object sender, EventArgs e) { textBox4.Text = ""; c1_4.Text = "0"; }
        private void SetZero5(object sender, EventArgs e) { textBox5.Text = ""; c1_5.Text = "0"; }
        private void SetZero6(object sender, EventArgs e) { textBox6.Text = ""; c1_6.Text = "0"; }
        private void SetZero7(object sender, EventArgs e) { textBox7.Text = ""; c1_7.Text = "0"; }
        private void SetZero8(object sender, EventArgs e) { textBox8.Text = ""; c1_8.Text = "0"; }
        private void SetZero9(object sender, EventArgs e) { textBox9.Text = ""; c1_9.Text = "0"; }
        private void SetZero10(object sender, EventArgs e) { textBox10.Text = ""; c1_10.Text = "0"; }
        private void SetZero11(object sender, EventArgs e) { textBox11.Text = ""; c1_11.Text = "0"; }
        private void SetZero12(object sender, EventArgs e) { textBox12.Text = ""; c1_12.Text = "0"; }
        private void SetZero13(object sender, EventArgs e) { textBox13.Text = ""; c1_13.Text = "0"; }
        private void SetZero14(object sender, EventArgs e) { textBox14.Text = ""; c1_14.Text = "0"; }
        private void SetZero15(object sender, EventArgs e) { textBox15.Text = ""; c1_15.Text = "0"; }
        private void SetZero16(object sender, EventArgs e) { textBox16.Text = ""; c1_16.Text = "0"; }

        private void SetText1(object sender, EventArgs e) { c1_1.Text = textBox1.Text; }
        private void SetText2(object sender, EventArgs e) { c1_2.Text = textBox2.Text; }
        private void SetText3(object sender, EventArgs e) { c1_3.Text = textBox3.Text; }
        private void SetText4(object sender, EventArgs e) { c1_4.Text = textBox4.Text; }
        private void SetText5(object sender, EventArgs e) { c1_5.Text = textBox5.Text; }
        private void SetText6(object sender, EventArgs e) { c1_6.Text = textBox6.Text; }
        private void SetText7(object sender, EventArgs e) { c1_7.Text = textBox7.Text; }
        private void SetText8(object sender, EventArgs e) { c1_8.Text = textBox8.Text; }
        private void SetText9(object sender, EventArgs e) { c1_9.Text = textBox9.Text; }
        private void SetText10(object sender, EventArgs e) { c1_10.Text = textBox10.Text; }
        private void SetText11(object sender, EventArgs e) { c1_11.Text = textBox11.Text; }
        private void SetText12(object sender, EventArgs e) { c1_12.Text = textBox12.Text; }
        private void SetText13(object sender, EventArgs e) { c1_13.Text = textBox13.Text; }
        private void SetText14(object sender, EventArgs e) { c1_14.Text = textBox14.Text; }
        private void SetText15(object sender, EventArgs e) { c1_15.Text = textBox15.Text; }
        private void SetText16(object sender, EventArgs e) { c1_16.Text = textBox16.Text; }

        private void PressAnyKeyOnTextBox(object sender, KeyEventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is MaterialTextBox box)
                {
                    if (c.Name.StartsWith("textBox") && c.Focused)
                    {
                        if (!((e.KeyCode == Keys.D0) || (e.KeyCode == Keys.D1) || (e.KeyCode == Keys.D2) || (e.KeyCode == Keys.D3) || (e.KeyCode == Keys.D4) || (e.KeyCode == Keys.D5) || (e.KeyCode == Keys.D6) || (e.KeyCode == Keys.D7) || (e.KeyCode == Keys.D8) || (e.KeyCode == Keys.D9) || (e.KeyCode == Keys.A) || (e.KeyCode == Keys.B) || (e.KeyCode == Keys.C) || (e.KeyCode == Keys.D) || (e.KeyCode == Keys.E) || (e.KeyCode == Keys.F)))
                        {
                            c.Text = "F";
                        } else
                        {
                            MakeText(box, e);
                        }
                    }
                }
            }
        }

        void MakeText (MaterialTextBox tb, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0: tb.Text = "0"; break;
                case Keys.D1: tb.Text = "1"; break;
                case Keys.D2: tb.Text = "2"; break;
                case Keys.D3: tb.Text = "3"; break;
                case Keys.D4: tb.Text = "4"; break;
                case Keys.D5: tb.Text = "5"; break;
                case Keys.D6: tb.Text = "6"; break;
                case Keys.D7: tb.Text = "7"; break;
                case Keys.D8: tb.Text = "8"; break;
                case Keys.D9: tb.Text = "9"; break;
                case Keys.A: tb.Text = "A"; break;
                case Keys.B: tb.Text = "B"; break;
                case Keys.C: tb.Text = "C"; break;
                case Keys.D: tb.Text = "D"; break;
                case Keys.E: tb.Text = "E"; break;
                case Keys.F: tb.Text = "F"; break;
            }
        }

        private void DiscardCodes(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SaveCodes(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            me.SetCodes(c1, c2, c3, c4);
            this.Close();
        }

        private void Initialize(object sender, EventArgs e)
        {
            // old method of setting night theme
            /*if (Program.f1.nightThemeToolStripMenuItem.Checked)
            {
                this.BackColor = System.Drawing.Color.Black;
                this.ForeColor = System.Drawing.Color.Gray;
                for (int i = 1; i <= 16; i++)
                {
                    tableLayoutPanel1.Controls["textBox" + i].BackColor = System.Drawing.Color.Black;
                    tableLayoutPanel1.Controls["textBox" + i].ForeColor = System.Drawing.Color.Gray;
                }
                for (int i = 1; i <= 8; i++)
                {
                    tableLayoutPanel2.Controls["ntt" + i].BackColor = System.Drawing.Color.Black;
                    tableLayoutPanel2.Controls["ntt" + i].ForeColor = System.Drawing.Color.Gray;
                }
                fileBox.BackColor = System.Drawing.Color.Black;
                fileBox.ForeColor = System.Drawing.Color.Gray;
                fileBox.BorderStyle = BorderStyle.FixedSingle;
            }*/
            List<string> blacklist = new List<string>();
            List<string> whitelist = new List<string>();
            string[] bl = { "Windows 3.1x", "Windows 1.x/2.x", "Windows CE" };
            string[] wl = { "Windows NT 3.x/4.0", "Windows Vista", "Windows 7", "Windows XP", "Windows 2000" };
            blacklist.AddRange(bl);
            whitelist.AddRange(wl);
            if (blacklist.Contains(me.GetString("os")))
            {
                MessageBox.Show("This operating system does not support error codes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }
            methodLabel.Text = DispCodes(c1, c2, c3, c4);
            this.Text = "Error code generation - " + me.GetString("friendlyname");
            chooseCode1.Checked = false;
            chooseCode1.Checked = true;
        }

        private string DispCodes(string c1, string c2, string c3, string c4)
        {
            if ((me.GetString("os") == "Windows XP") || (me.GetString("os") == "Windows 2000") || (me.GetString("os") == "Windows NT 3.x/4.0"))
            {
                for (var i = 16; i > 8; i--)
                {
                    MaterialButton btn = (MaterialButton)tableLayoutPanel1.Controls["button" + i.ToString()];
                    MaterialButton nullbtn = (MaterialButton)tableLayoutPanel1.Controls["null" + i.ToString()];
                    MaterialTextBox txtbox = (MaterialTextBox)tableLayoutPanel1.Controls["textBox" + i.ToString()];
                    btn.Enabled = false;
                    nullbtn.Enabled = false;
                    txtbox.Enabled = false;
                }
                try
                {
                    return "0x" + c1.Substring(0, 8) + ", 0x" + c2.Substring(0, 8) + ", 0x" + c3.Substring(0, 8) + ", 0x" + c4.Substring(0, 8);
                } catch
                {
                    return "0xDEADDEAD, 0xDEADDEAD, 0xDEADDEAD, 0xDEADDEAD";
                }
            }
            else if (me.GetString("os") == "Windows CE")
            {
                for (var i = 16; i > 6; i--)
                {
                    MaterialButton btn = (MaterialButton)tableLayoutPanel1.Controls["button" + i.ToString()];
                    MaterialButton nullbtn = (MaterialButton)tableLayoutPanel1.Controls["null" + i.ToString()];
                    MaterialTextBox txtbox = (MaterialTextBox)tableLayoutPanel1.Controls["textBox" + i.ToString()];
                    btn.Enabled = false;
                    nullbtn.Enabled = false;
                    txtbox.Enabled = false;
                }
                return "0x" + c1.Substring(0, 6) + ", 0x" + c2.Substring(0, 6) + ", 0x" + c3.Substring(0, 6) + ", 0x" + c4.Substring(0, 6);
            }
            else if (me.GetString("os") == "Windows 9x/Me")
            {
                int maximum = 8;
                if (codeSelection.Text == "Code 1") { maximum = 2; }
                else if (codeSelection.Text == "Code 2") { maximum = 4; }
                chooseCode4.Enabled = false;
                for (var i = 3; i <= 8; i++)
                {
                    MaterialButton btn = (MaterialButton)tableLayoutPanel1.Controls["button" + i.ToString()];
                    MaterialButton nullbtn = (MaterialButton)tableLayoutPanel1.Controls["null" + i.ToString()];
                    MaterialTextBox txtbox = (MaterialTextBox)tableLayoutPanel1.Controls["textBox" + i.ToString()];
                    btn.Enabled = true;
                    nullbtn.Enabled = true;
                    txtbox.Enabled = true;
                }
                for (var i = 16; i > maximum; i--)
                {
                    MaterialButton btn = (MaterialButton)tableLayoutPanel1.Controls["button" + i.ToString()];
                    MaterialButton nullbtn = (MaterialButton)tableLayoutPanel1.Controls["null" + i.ToString()];
                    MaterialTextBox txtbox = (MaterialTextBox)tableLayoutPanel1.Controls["textBox" + i.ToString()];
                    btn.Enabled = false;
                    nullbtn.Enabled = false;
                    txtbox.Enabled = false;
                }
                return c1.Substring(0, 2) + " : " + c2.Substring(0, 4) + " : " + c3.Substring(0, 8);
            }
            return "0x" + c1 + ", 0x" + c2 + ", 0x" + c3 + ", 0x" + c4;
        }

        private void RandomButtonClick(object sender, EventArgs e)
        {
            button1.PerformClick();
            button2.PerformClick();
            button3.PerformClick();
            button4.PerformClick();
            button5.PerformClick();
            button6.PerformClick();
            button7.PerformClick();
            button8.PerformClick();
            button9.PerformClick();
            button10.PerformClick();
            button12.PerformClick();
            button13.PerformClick();
            button14.PerformClick();
            button15.PerformClick();
            button16.PerformClick();
        }

        private void NullButtonClick(object sender, EventArgs e)
        {
            null1.PerformClick();
            null2.PerformClick();
            null3.PerformClick();
            null4.PerformClick();
            null5.PerformClick();
            null6.PerformClick();
            null7.PerformClick();
            null8.PerformClick();
            null9.PerformClick();
            null10.PerformClick();
            null11.PerformClick();
            null12.PerformClick();
            null13.PerformClick();
            null14.PerformClick();
            null15.PerformClick();
            null16.PerformClick();
        }

        private void NTOkButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileBox_TabStopChanged(object sender, EventArgs e)
        {

        }
    }
}

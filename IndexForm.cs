using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class IndexForm : Form
    {
        internal BlueScreen me;
        public string c1 = "RRRRRRRRRRRRRRRR";
        public string c2 = "RRRRRRRRRRRRRRRR";
        public string c3 = "RRRRRRRRRRRRRRRR";
        public string c4 = "RRRRRRRRRRRRRRRR";

        public IndexForm()
        {
            InitializeComponent();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label2.Text = "Code 1";
                SetupCodes(c1);
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label2.Text = "Code 2";
                SetupCodes(c2);
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
                        c.Text = code.Substring(i, 1);
                    }
                }
            }
        }
        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                label2.Text = "Code 3";
                SetupCodes(c3);
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                label2.Text = "Code 4";
                SetupCodes(c4);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            c1_1.Text = "R";
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            c1_1.Text = "0";
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            c1_1.Text = textBox1.Text;
        }

        private void C1_1_TextChanged(object sender, EventArgs e)
        {
            if (label2.Text == "Code 1")
            {
                c1 = c1_1.Text + c1_2.Text + c1_3.Text + c1_4.Text + c1_5.Text + c1_6.Text + c1_7.Text + c1_8.Text + c1_9.Text + c1_10.Text + c1_11.Text + c1_12.Text + c1_13.Text + c1_14.Text + c1_15.Text + c1_16.Text;
            }
            else if (label2.Text == "Code 2")
            {
                c2 = c1_1.Text + c1_2.Text + c1_3.Text + c1_4.Text + c1_5.Text + c1_6.Text + c1_7.Text + c1_8.Text + c1_9.Text + c1_10.Text + c1_11.Text + c1_12.Text + c1_13.Text + c1_14.Text + c1_15.Text + c1_16.Text;
            }
            else if (label2.Text == "Code 3")
            {
                c3 = c1_1.Text + c1_2.Text + c1_3.Text + c1_4.Text + c1_5.Text + c1_6.Text + c1_7.Text + c1_8.Text + c1_9.Text + c1_10.Text + c1_11.Text + c1_12.Text + c1_13.Text + c1_14.Text + c1_15.Text + c1_16.Text;
            }
            else if (label2.Text == "Code 4")
            {
                c4 = c1_1.Text + c1_2.Text + c1_3.Text + c1_4.Text + c1_5.Text + c1_6.Text + c1_7.Text + c1_8.Text + c1_9.Text + c1_10.Text + c1_11.Text + c1_12.Text + c1_13.Text + c1_14.Text + c1_15.Text + c1_16.Text;
            }
            label6.Text = DispCodes(c1, c2, c3, c4);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            c1_2.Text = "R";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            c1_3.Text = "R";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            c1_4.Text = "R";
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            c1_4.Text = "0";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            c1_5.Text = "R";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            c1_6.Text = "R";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            c1_7.Text = "R";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            c1_8.Text = "R";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
            c1_9.Text = "R";
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            c1_10.Text = "R";
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            textBox11.Text = "";
            c1_11.Text = "R";
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            textBox12.Text = "";
            c1_12.Text = "R";
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            c1_2.Text = "0";
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            c1_3.Text = "0";
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            c1_5.Text = "0";
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            c1_6.Text = "0";
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            c1_7.Text = "0";
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            c1_8.Text = "0";
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
            c1_9.Text = "0";
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            c1_10.Text = "0";
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            textBox11.Text = "";
            c1_11.Text = "0";
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            textBox12.Text = "";
            c1_12.Text = "0";
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            c1_2.Text = textBox2.Text;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            c1_3.Text = textBox3.Text;
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            c1_4.Text = textBox4.Text;
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            c1_5.Text = textBox5.Text;
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            c1_6.Text = textBox6.Text;
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            c1_7.Text = textBox7.Text;
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
            c1_8.Text = textBox8.Text;
        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {
            c1_9.Text = textBox9.Text;
        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {
            c1_10.Text = textBox10.Text;
        }

        private void TextBox11_TextChanged(object sender, EventArgs e)
        {
            c1_11.Text = textBox11.Text;
        }

        private void TextBox12_TextChanged(object sender, EventArgs e)
        {
            c1_12.Text = textBox12.Text;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.KeyCode == Keys.D0) || (e.KeyCode == Keys.D1) || (e.KeyCode == Keys.D2) || (e.KeyCode == Keys.D3) || (e.KeyCode == Keys.D4) || (e.KeyCode == Keys.D5) || (e.KeyCode == Keys.D6) || (e.KeyCode == Keys.D7) || (e.KeyCode == Keys.D8) || (e.KeyCode == Keys.D9) || (e.KeyCode == Keys.A) || (e.KeyCode == Keys.B) || (e.KeyCode == Keys.C) || (e.KeyCode == Keys.D) || (e.KeyCode == Keys.E) || (e.KeyCode == Keys.F)))
            {
                if (textBox1.Focused == true)
                {
                    textBox1.Text = "F";
                }
                else if (textBox2.Focused == true)
                {
                    textBox2.Text = "F";
                }
                else if (textBox3.Focused == true)
                {
                    textBox3.Text = "F";
                }
                else if (textBox4.Focused == true)
                {
                    textBox4.Text = "F";
                }
                else if (textBox5.Focused == true)
                {
                    textBox5.Text = "F";
                }
                else if (textBox6.Focused == true)
                {
                    textBox6.Text = "F";
                }
                else if (textBox7.Focused == true)
                {
                    textBox7.Text = "F";
                }
                else if (textBox8.Focused == true)
                {
                    textBox8.Text = "F";
                }
                else if (textBox9.Focused == true)
                {
                    textBox9.Text = "F";
                }
                else if (textBox10.Focused == true)
                {
                    textBox10.Text = "F";
                }
                else if (textBox11.Focused == true)
                {
                    textBox11.Text = "F";
                }
                else if (textBox12.Focused == true)
                {
                    textBox12.Text = "F";
                }
                else if (textBox13.Focused == true)
                {
                    textBox13.Text = "F";
                }
                else if (textBox14.Focused == true)
                {
                    textBox14.Text = "F";
                }
                else if (textBox15.Focused == true)
                {
                    textBox15.Text = "F";
                }
                else if (textBox16.Focused == true)
                {
                    textBox16.Text = "F";
                }
            } else
            {
                if (textBox1.Focused == true) { MakeText(textBox1, e); }
                if (textBox2.Focused == true) { MakeText(textBox2, e); }
                if (textBox3.Focused == true) { MakeText(textBox3, e); }
                if (textBox4.Focused == true) { MakeText(textBox4, e); }
                if (textBox5.Focused == true) { MakeText(textBox5, e); }
                if (textBox6.Focused == true) { MakeText(textBox6, e); }
                if (textBox7.Focused == true) { MakeText(textBox7, e); }
                if (textBox8.Focused == true) { MakeText(textBox8, e); }
                if (textBox9.Focused == true) { MakeText(textBox9, e); }
                if (textBox10.Focused == true) { MakeText(textBox10, e); }
                if (textBox11.Focused == true) { MakeText(textBox11, e); }
                if (textBox12.Focused == true) { MakeText(textBox12, e); }
                if (textBox13.Focused == true) { MakeText(textBox13, e); }
                if (textBox14.Focused == true) { MakeText(textBox14, e); }
                if (textBox15.Focused == true) { MakeText(textBox15, e); }
                if (textBox16.Focused == true) { MakeText(textBox16, e); }

            }
        }

        void MakeText (TextBox tb, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0) { tb.Text = "0"; }
            else if (e.KeyCode == Keys.D1) { tb.Text = "1"; }
            else if (e.KeyCode == Keys.D2) { tb.Text = "2"; }
            else if (e.KeyCode == Keys.D3) { tb.Text = "3"; }
            else if (e.KeyCode == Keys.D4) { tb.Text = "4"; }
            else if (e.KeyCode == Keys.D5) { tb.Text = "5"; }
            else if (e.KeyCode == Keys.D6) { tb.Text = "6"; }
            else if (e.KeyCode == Keys.D7) { tb.Text = "7"; }
            else if (e.KeyCode == Keys.D8) { tb.Text = "8"; }
            else if (e.KeyCode == Keys.D9) { tb.Text = "9"; }
            else if (e.KeyCode == Keys.A) { tb.Text = "A"; }
            else if (e.KeyCode == Keys.B) { tb.Text = "B"; }
            else if (e.KeyCode == Keys.C) { tb.Text = "C"; }
            else if (e.KeyCode == Keys.D) { tb.Text = "D"; }
            else if (e.KeyCode == Keys.E) { tb.Text = "E"; }
            else if (e.KeyCode == Keys.F) { tb.Text = "F"; }
        }

        private void Button26_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Button25_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            me.SetCodes(c1, c2, c3, c4);
            this.Close();
        }

        private void IndexForm_Load(object sender, EventArgs e)
        {
            if (me.GetString("os") == "Windows 3.1x")
            {
                MessageBox.Show("This operating system does not support error codes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            label6.Text = DispCodes(c1, c2, c3, c4);
            this.Text = "Error code generation (" + me.GetString("os") + ")";
            radioButton1.Checked = false;
            radioButton1.Checked = true;
        }

        private string DispCodes(string c1, string c2, string c3, string c4)
        {
            if ((me.GetString("os") == "Windows XP") || (me.GetString("os") == "Windows 2000") || (me.GetString("os") == "Windows NT 3.x/4.0"))
            {
                for (var i = 16; i > 8; i--)
                {
                    Button btn = (Button)tableLayoutPanel1.Controls["button" + i.ToString()];
                    Button nullbtn = (Button)tableLayoutPanel1.Controls["null" + i.ToString()];
                    TextBox txtbox = (TextBox)tableLayoutPanel1.Controls["textBox" + i.ToString()];
                    btn.Enabled = false;
                    nullbtn.Enabled = false;
                    txtbox.Enabled = false;
                }
                return "0x" + c1.Substring(0, 8) + ", 0x" + c2.Substring(0, 8) + ", 0x" + c3.Substring(0, 8) + ", 0x" + c4.Substring(0, 8);
            }
            else if (me.GetString("os") == "Windows CE")
            {
                for (var i = 16; i > 6; i--)
                {
                    Button btn = (Button)tableLayoutPanel1.Controls["button" + i.ToString()];
                    Button nullbtn = (Button)tableLayoutPanel1.Controls["null" + i.ToString()];
                    TextBox txtbox = (TextBox)tableLayoutPanel1.Controls["textBox" + i.ToString()];
                    btn.Enabled = false;
                    nullbtn.Enabled = false;
                    txtbox.Enabled = false;
                }
                return "0x" + c1.Substring(0, 6) + ", 0x" + c2.Substring(0, 6) + ", 0x" + c3.Substring(0, 6) + ", 0x" + c4.Substring(0, 6);
            }
            else if (me.GetString("os") == "Windows 9x/Me")
            {
                for (var i = 16; i > 4; i--)
                {
                    Button btn = (Button)tableLayoutPanel1.Controls["button" + i.ToString()];
                    Button nullbtn = (Button)tableLayoutPanel1.Controls["null" + i.ToString()];
                    TextBox txtbox = (TextBox)tableLayoutPanel1.Controls["textBox" + i.ToString()];
                    btn.Enabled = false;
                    nullbtn.Enabled = false;
                    txtbox.Enabled = false;
                }
                return c1.Substring(0, 4) + ", " + c2.Substring(0, 4) + ", " + c3.Substring(0, 4) + ", " + c4.Substring(0, 4);
            }
            return "0x" + c1 + ", 0x" + c2 + ", 0x" + c3 + ", 0x" + c4;
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button27_Click(object sender, EventArgs e)
        {
            textBox13.Text = "";
            c1_13.Text = "R";
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            textBox14.Text = "";
            c1_14.Text = "R";
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            textBox15.Text = "";
            c1_15.Text = "R";
        }

        private void Button30_Click(object sender, EventArgs e)
        {
            textBox16.Text = "";
            c1_16.Text = "R";
        }

        private void Button31_Click(object sender, EventArgs e)
        {
            textBox13.Text = "";
            c1_13.Text = "0";
        }

        private void Button32_Click(object sender, EventArgs e)
        {
            textBox14.Text = "";
            c1_14.Text = "0";
        }

        private void Button33_Click(object sender, EventArgs e)
        {
            textBox15.Text = "";
            c1_15.Text = "0";
        }

        private void Button34_Click(object sender, EventArgs e)
        {
            textBox16.Text = "";
            c1_16.Text = "0";
        }

        private void TextBox13_TextChanged(object sender, EventArgs e)
        {
            c1_13.Text = textBox13.Text;
        }

        private void TextBox14_TextChanged(object sender, EventArgs e)
        {
            c1_14.Text = textBox14.Text;
        }

        private void TextBox15_TextChanged(object sender, EventArgs e)
        {
            c1_15.Text = textBox15.Text;
        }

        private void TextBox16_TextChanged(object sender, EventArgs e)
        {
            c1_16.Text = textBox16.Text;
        }

        private void Button36_Click(object sender, EventArgs e)
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

        private void Button35_Click(object sender, EventArgs e)
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
    }
}

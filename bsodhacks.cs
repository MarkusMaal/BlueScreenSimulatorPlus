using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UltimateBlueScreenSimulator
{
    public partial class Bsodhacks : Form
    {
        //this form is depricated
        //please see StringEdit.cs for new hacks window
        public Bsodhacks()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = eightBSOD.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                eightBSOD.BackColor = colorDialog1.Color;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = eightBSOD.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                eightBSOD.ForeColor = colorDialog1.Color;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            eightBSOD.Text = textBox1.Text;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = nt51bsod.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                nt51bsod.BackColor = colorDialog1.Color;
                nt5bsod.BackColor = colorDialog1.Color;
                nt612bsod.BackColor = colorDialog1.Color;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = nt51bsod.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                nt51bsod.ForeColor = colorDialog1.Color;
                nt5bsod.ForeColor = colorDialog1.Color;
                nt612bsod.ForeColor = colorDialog1.Color;
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = me9xbsod.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                me9xbsod.BackColor = colorDialog1.Color;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = me9xbsod.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                me9xbsod.ForeColor = colorDialog1.Color;
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = me9xhlbsod.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                me9xhlbsod.BackColor = colorDialog1.Color;
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = me9xhlbsod.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                me9xhlbsod.ForeColor = colorDialog1.Color;
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = nt34bsod.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                nt34bsod.BackColor = colorDialog1.Color;
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = nt34bsod.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                nt34bsod.ForeColor = colorDialog1.Color;
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
            }
        }

        private void Bsodhacks_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Bsodhacks_Load(object sender, EventArgs e)
        {
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            eightBSOD.Text = ":(";
            eightBSOD.BackColor = Color.FromArgb(16, 113, 170);
            eightBSOD.ForeColor = Color.White;
            nt612bsod.BackColor = Color.Navy;
            nt612bsod.ForeColor = Color.White;
            nt51bsod.BackColor = Color.Navy;
            nt51bsod.ForeColor = Color.White;
            nt5bsod.BackColor = Color.Navy;
            nt5bsod.ForeColor = Color.White;
            me9xbsod.BackColor = Color.FromArgb(0, 0, 170);
            me9xbsod.ForeColor = Color.White;
            me9xhlbsod.BackColor = Color.FromArgb(170, 170, 170);
            me9xhlbsod.ForeColor = Color.FromArgb(0, 0, 170);
            nt34bsod.BackColor = Color.FromArgb(0, 0, 168);
            nt34bsod.ForeColor = Color.FromArgb(170, 170, 170);
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            this.Close();
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
            string[] filelines = File.ReadAllLines(loadable, Encoding.ASCII);
            foreach (string fileline in filelines)
            {
                if (fileline.Contains("***")) { continue; }
                if (fileline.StartsWith("FACE "))
                {
                    eightBSOD.Text = fileline.Replace("FACE ", "");
                }
                else if (fileline.StartsWith("MODERN "))
                {
                    eightBSOD.BackColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[0].ToString().Split(':')[2].ToString()));
                    eightBSOD.ForeColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[1].ToString().Split(':')[2].ToString()));
                }
                else if (fileline.StartsWith("W2K "))
                {
                    nt612bsod.BackColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[2].ToString()));
                    nt612bsod.ForeColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[2].ToString()));
                    nt51bsod.BackColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[2].ToString()));
                    nt51bsod.ForeColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[2].ToString()));
                    nt5bsod.BackColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[2].ToString()));
                    nt5bsod.ForeColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[2].ToString()));
                }
                else if (fileline.StartsWith("NT34 "))
                {
                    nt34bsod.BackColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("NT34 ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("NT34 ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("NT34 ", "").Split(',')[0].ToString().Split(':')[2].ToString()));
                    nt34bsod.ForeColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("NT34 ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("NT34 ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("NT34 ", "").Split(',')[1].ToString().Split(':')[2].ToString()));
                }
                else if (fileline.StartsWith("W9XME "))
                {
                    me9xbsod.BackColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[0].ToString().Split(':')[2].ToString()));
                    me9xbsod.ForeColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[1].ToString().Split(':')[2].ToString()));
                }
                else if (fileline.StartsWith("W9XME_HL "))
                {
                    me9xhlbsod.BackColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[0].ToString().Split(':')[2].ToString()));
                    me9xhlbsod.ForeColor = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[1].ToString().Split(':')[2].ToString()));
                }
            }
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            if (SaveHack.ShowDialog() == DialogResult.OK)
            {
                string bscfg;
                bscfg = "*** Blue screen simulator plus 1.11 ***\nFACE " + eightBSOD.Text + "\n";
                bscfg = bscfg + "MODERN " + eightBSOD.BackColor.R.ToString() + ":" + eightBSOD.BackColor.G.ToString() + ":" + eightBSOD.BackColor.B.ToString() + "," + eightBSOD.ForeColor.R.ToString() + ":" + eightBSOD.ForeColor.G.ToString() + ":" + eightBSOD.ForeColor.B.ToString() + "\n";
                bscfg = bscfg + "W2K " + nt5bsod.BackColor.R.ToString() + ":" + nt5bsod.BackColor.G.ToString() + ":" + nt5bsod.BackColor.B.ToString() + "," + nt5bsod.ForeColor.R.ToString() + ":" + nt5bsod.ForeColor.G.ToString() + ":" + nt5bsod.ForeColor.B.ToString() + "\n";
                bscfg = bscfg + "NT34 " + nt34bsod.BackColor.R.ToString() + ":" + nt34bsod.BackColor.G.ToString() + ":" + nt34bsod.BackColor.B.ToString() + "," + nt34bsod.ForeColor.R.ToString() + ":" + nt34bsod.ForeColor.G.ToString() + ":" + nt34bsod.ForeColor.B.ToString() + "\n";
                bscfg = bscfg + "W9XME " + me9xbsod.BackColor.R.ToString() + ":" + me9xbsod.BackColor.G.ToString() + ":" + me9xbsod.BackColor.B.ToString() + "," + me9xbsod.ForeColor.R.ToString() + ":" + me9xbsod.ForeColor.G.ToString() + ":" + me9xbsod.ForeColor.B.ToString() + "\n";
                bscfg = bscfg + "W9XME_HL " + me9xhlbsod.BackColor.R.ToString() + ":" + me9xhlbsod.BackColor.G.ToString() + ":" + me9xhlbsod.BackColor.B.ToString() + "," + me9xhlbsod.ForeColor.R.ToString() + ":" + me9xhlbsod.ForeColor.G.ToString() + ":" + me9xhlbsod.ForeColor.B.ToString();
                File.WriteAllText(SaveHack.FileName, bscfg, Encoding.ASCII);
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                textBox2.Enabled = true;
            } else
            {
                textBox2.Enabled = false;
            }
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            StringEdit se = new StringEdit();
            se.Show();
            this.Close();
        }
    }
}

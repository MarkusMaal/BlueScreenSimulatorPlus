using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
{
    public partial class NTBSOD : Form
    {
        public string ver = "4.0 (Service Pack 6)";
        public bool fullscreen = true;
        public bool stacktrace = true;
        public bool starterror = true;
        public bool blink = true;
        public string whatfail = "";
        public string processortype = "GenuineIntel";
        public string error = "User manually initiated crash (0xDEADDEAD)";
        WindowScreen ws = new WindowScreen();
        string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ":", ",", ".", "+", "*", "(", ")", "[", "]", "{", "}", "/", "\\", "-", "_", " " };
        public NTBSOD()
        {
            InitializeComponent();
        }

        string GenSpace(int spacecount)
        {
            string outspace = "";
            for (int i = 0; i < spacecount; i++)
            {
                outspace += " ";
            }
            return outspace;
        }

        private void NTBSOD_Load(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Program.f1.bsodnt[1];
            if (!blink) { pictureBox3.Visible = false; }

            errorCode.Image = WriteWord(Program.bh.textBox18.Text.Replace("{0}",error.Split(' ')[1].Replace(")", "").Replace("(", "").Replace(" ", "").ToString()).Replace("{1}", Program.f1.GenAddress(4, 8, false)).Trim(), Program.f1.bsodnt[0], Program.f1.bsodnt[1]);
            if (whatfail == "")
            {
                errorDescription.Image = WriteWord(error.Split(' ')[0].ToString(), Program.f1.bsodnt[0], Program.f1.bsodnt[1]);
            } else
            {
                errorDescription.Image = WriteWord(error.Split(' ')[0].ToString() + "*** Address " + Program.f1.GenHex(8, "RRRRRRRR").ToLower() + " has base at " + Program.f1.GenHex(8, "RRRRRRRR").ToLower() + " - " + whatfail.ToLower(), Program.f1.bsodnt[0], Program.f1.bsodnt[1]);
            }
            if (stacktrace)
            {
                cpuID.Image = WriteWord(Program.bh.textBox19.Text.Replace("{0}", processortype).Trim(), Program.f1.bsodnt[0], Program.f1.bsodnt[1]);
                tableHeader.Image = WriteWord(Program.bh.textBox20.Text.Trim() + GenSpace(40 - Program.bh.textBox20.Text.Trim().Length) + Program.bh.textBox20.Text.Trim(), Program.f1.bsodnt[0], Program.f1.bsodnt[1]);
                foreach (PictureBox ctrl in flowLayoutPanel2.Controls)
                {
                    string rnd1 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                    string rnd2 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                    ctrl.Image = WriteWord(Program.bh.textBox21.Text.Trim().Replace("{0}", rnd1).Replace("{1}", rnd2).Replace("{2}", Program.f1.GenFile()), Program.f1.bsodnt[0], Program.f1.bsodnt[1]);
                }
                foreach (PictureBox ctrl in flowLayoutPanel3.Controls)
                {
                    string rnd1 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                    string rnd2 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                    ctrl.Image = WriteWord(Program.bh.textBox21.Text.Trim().Replace("{0}", rnd1).Replace("{1}", rnd2).Replace("{2}", Program.f1.GenFile()), Program.f1.bsodnt[0], Program.f1.bsodnt[1]);
                }
                table2.Image = WriteWord(Program.bh.textBox22.Text, Program.f1.bsodnt[0], Program.f1.bsodnt[1]);
                string r1 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                string r2 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                string r3 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                string r4 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                string r5 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                string r6 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                tablerow_1.Image = WriteWord(Program.bh.textBox23.Text.Replace("{0}", r1).Replace("{1}", r2).Replace("{2}", r3).Replace("{3}", r4).Replace("{4}", r5).Replace("{5}", r6).Replace("{6}", Program.f1.GenFile()), Program.f1.bsodnt[0], Program.f1.bsodnt[1]);
                r1 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r2 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r3 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r4 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r5 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r6 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                tablerow_2.Image = WriteWord(Program.bh.textBox23.Text.Replace("{0}", r1).Replace("{1}", r2).Replace("{2}", r3).Replace("{3}", r4).Replace("{4}", r5).Replace("{5}", r6).Replace("{6}", Program.f1.GenFile()), Program.f1.bsodnt[0], Program.f1.bsodnt[1]);
                r1 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r2 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r3 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r4 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r5 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r6 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                tablerow_3.Image = WriteWord(Program.bh.textBox23.Text.Replace("{0}", r1).Replace("{1}", r2).Replace("{2}", r3).Replace("{3}", r4).Replace("{4}", r5).Replace("{5}", r6).Replace("{6}", Program.f1.GenFile()), Program.f1.bsodnt[0], Program.f1.bsodnt[1]);
                r1 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r2 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r3 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r4 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r5 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r6 = Program.f1.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                tablerow_4.Image = WriteWord(Program.bh.textBox23.Text.Replace("{0}", r1).Replace("{1}", r2).Replace("{2}", r3).Replace("{3}", r4).Replace("{4}", r5).Replace("{5}", r6).Replace("{6}", Program.f1.GenFile()), Program.f1.bsodnt[0], Program.f1.bsodnt[1]);
                Program.f1.label10.Text = "";


            }
            else
            {
                cpuID.Visible = false;
                tableLayoutPanel1.Visible = false;
                tableHeader.Visible = false;
                table2.Visible = false;
                tablerow_1.Visible = false;
                tablerow_2.Visible = false;
                tablerow_3.Visible = false;
                tablerow_4.Visible = false;
            }
            pictureBox1.Image = WriteWord(Program.bh.textBox24.Text.Split('\n')[0].Trim(), Program.f1.bsodnt[0], Program.f1.bsodnt[1]);
            pictureBox2.Image = WriteWord(Program.bh.textBox24.Text.Split('\n')[1].Trim(), Program.f1.bsodnt[0], Program.f1.bsodnt[1]);

            if (!fullscreen) { this.FormBorderStyle = FormBorderStyle.FixedSingle; }
            if (fullscreen)
            {
                ws.Show();
                this.TopMost = false;
            }
        }


        private Bitmap WriteWord(string word, Color bg, Color fg)
        {
            Bitmap bmpres;
            bmpres = GetSymbol(word.Substring(0, 1), bg, fg);
            for (int i = 1; i < word.Length; i++)
            {
                Bitmap two = GetSymbol(word.Substring(i, 1), bg, fg);
                bmpres = Merge(bmpres, two);
            }
            return bmpres;
        }
        private Bitmap GetSymbol(string symbol, Color bg, Color fg)
        {
            int index = 0;
            try
            {
                for (int i = 0; i < letters.Length + 1; i++)
                {
                    if (letters[i].ToString() == symbol)
                    {
                        index = i;
                        break;
                    }
                }
            }
            catch
            {

            }
            Rectangle cropRect = new Rectangle(index * 8, 0, 8, 8);
            try
            {
                Bitmap src = Properties.Resources.rasterNT as Bitmap;
               Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);
                using (Graphics g = Graphics.FromImage(target))
                {
                    g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                                     cropRect,
                                     GraphicsUnit.Pixel);
                }
                Bitmap tc = changecolor(bg, target, Color.FromArgb(0, 0, 0));
                Bitmap t = changecolor(fg, tc, Color.FromArgb(255, 255, 255));
                target = t;
                return target;
            }
            catch
            {
                MessageBox.Show("Internal character set seems to be corrupted\n\n0x015: NT_CHARSET_CORRUPTED", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Bitmap(1, 1);
            }
        }

        private Bitmap Merge(Bitmap bmp, Bitmap bmp2)
        {
            Bitmap ne = new Bitmap(bmp.Width + 8, bmp.Height);

            using (Graphics grfx = Graphics.FromImage(ne))
            {
                grfx.DrawImage(bmp, 0, 0);
                grfx.DrawImage(bmp2, ne.Width - 8, 0);
            }
            return ne;
        }
        private Bitmap changecolor(Color gc, Bitmap bmp, Color incol)
        {
            Color black = incol;
            Color white = gc;
            Bitmap img = bmp;
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixelColor = img.GetPixel(i, j);
                    if (pixelColor == black)
                        img.SetPixel(i, j, white);
                }
            }
            return img;
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval != Program.f1.blinkspeed) { timer1.Interval = Program.f1.blinkspeed; }
            if (fullscreen)
            {
                try { 
                var frm = ActiveForm;
                using (var bmp = new Bitmap(frm.Width, frm.Height))
                {
                    frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                    Bitmap newImage = new Bitmap(ws.Width, ws.Height);
                        using (Graphics g = Graphics.FromImage(newImage))
                        {
                            if (Program.f1.GMode == "HighQualityBicubic") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; }
                            if (Program.f1.GMode == "HighQualityBilinear") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear; }
                            if (Program.f1.GMode == "Bilinear") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear; }
                            if (Program.f1.GMode == "Bicubic") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic; }
                            if (Program.f1.GMode == "NearestNeighbour") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor; }
                            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                            g.DrawImage(bmp, new Rectangle(0, 0, ws.Width, ws.Height));
                        }
                        ws.pictureBox1.Image = newImage;
                }
                } catch
                {
                    this.Close();
                }
            }
            if (blink)
            {
                if (pictureBox3.Visible == false)
                {
                    pictureBox3.Visible = true;
                }
                else
                {
                    pictureBox3.Visible = false;
                }
            }
        }

        private void NTBSOD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fullscreen)
            {
                if (ws.Visible == true)
                {
                    ws.Close();
                }
            }
        }

        private void NTBSOD_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!fullscreen)
            {
                if (Program.f1.closecuzhidden == true)
                {
                    Program.f1.Close();
                }
            }
        }
    }
}

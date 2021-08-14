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
        internal BlueScreen me = Program.bluescreens[0];
        IDictionary<string, string> txt;
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
            txt = me.GetTexts();
            pictureBox3.BackColor = me.GetTheme(true, true);
            if (!blink) { pictureBox3.Visible = false; }

            errorCode.Image = WriteWord(txt["Error code formatting"].Replace("{0}",error.Split(' ')[1].Replace(")", "").Replace("(", "").Replace(" ", "").ToString()).Replace("{1}", me.GenAddress(4, 8, false)).Trim(), me.GetTheme(true), me.GetTheme(false));
            if (whatfail == "")
            {
                errorDescription.Image = WriteWord(error.Split(' ')[0].ToString(), me.GetTheme(true), me.GetTheme(false));
            } else
            {
                errorDescription.Image = WriteWord(error.Split(' ')[0].ToString() + "*** Address " + me.GenHex(8, "RRRRRRRR").ToLower() + " has base at " + me.GenHex(8, "RRRRRRRR").ToLower() + " - " + whatfail.ToLower(), me.GetTheme(true), me.GetTheme(false));
            }
            if (stacktrace)
            {
                cpuID.Image = WriteWord(txt["CPUID formatting"].Replace("{0}", processortype).Trim(), me.GetTheme(true), me.GetTheme(false));
                tableHeader.Image = WriteWord(txt["Stack trace heading"].Trim() + GenSpace(40 - txt["Stack trace heading"].Trim().Length) + txt["Stack trace heading"].Trim(), me.GetTheme(true), me.GetTheme(false));
                foreach (PictureBox ctrl in flowLayoutPanel2.Controls)
                {
                    string rnd1 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                    string rnd2 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                    ctrl.Image = WriteWord(txt["Stack trace table formatting"].Trim().Replace("{0}", rnd1).Replace("{1}", rnd2).Replace("{2}", me.GenFile()), me.GetTheme(true), me.GetTheme(false));
                }
                foreach (PictureBox ctrl in flowLayoutPanel3.Controls)
                {
                    string rnd1 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                    string rnd2 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                    ctrl.Image = WriteWord(txt["Stack trace table formatting"].Trim().Replace("{0}", rnd1).Replace("{1}", rnd2).Replace("{2}", me.GenFile()), me.GetTheme(true), me.GetTheme(false));
                }
                table2.Image = WriteWord(txt["Memory address dump heading"], me.GetTheme(true), me.GetTheme(false));
                string r1 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                string r2 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                string r3 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                string r4 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                string r5 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                string r6 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                tablerow_1.Image = WriteWord(txt["Memory address dump table"].Replace("{0}", r1).Replace("{1}", r2).Replace("{2}", r3).Replace("{3}", r4).Replace("{4}", r5).Replace("{5}", r6).Replace("{6}", me.GenFile()), me.GetTheme(true), me.GetTheme(false));
                r1 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r2 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r3 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r4 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r5 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r6 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                tablerow_2.Image = WriteWord(txt["Memory address dump table"].Replace("{0}", r1).Replace("{1}", r2).Replace("{2}", r3).Replace("{3}", r4).Replace("{4}", r5).Replace("{5}", r6).Replace("{6}", me.GenFile()), me.GetTheme(true), me.GetTheme(false));
                r1 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r2 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r3 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r4 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r5 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r6 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                tablerow_3.Image = WriteWord(txt["Memory address dump table"].Replace("{0}", r1).Replace("{1}", r2).Replace("{2}", r3).Replace("{3}", r4).Replace("{4}", r5).Replace("{5}", r6).Replace("{6}", me.GenFile()), me.GetTheme(true), me.GetTheme(false));
                r1 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r2 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r3 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r4 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r5 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                r6 = me.GenHex(8, "RRRRRRRRRRRRRRRR").ToLower();
                tablerow_4.Image = WriteWord(txt["Memory address dump table"].Replace("{0}", r1).Replace("{1}", r2).Replace("{2}", r3).Replace("{3}", r4).Replace("{4}", r5).Replace("{5}", r6).Replace("{6}", me.GenFile()), me.GetTheme(true), me.GetTheme(false));
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
            pictureBox1.Image = WriteWord(txt["Troubleshooting text"].Split('\n')[0].Trim(), me.GetTheme(true), me.GetTheme(false));
            pictureBox2.Image = WriteWord(txt["Troubleshooting text"].Split('\n')[1].Trim(), me.GetTheme(true), me.GetTheme(false));

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
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = Program.f1.lockout;
            }
            else
            {
                e.Cancel = false;
            }
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

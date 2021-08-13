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
    public partial class old_bluescreen : Form
    {
        public string errorCode = "0E : 016F : BFF9B3D4";
        public bool window = false;
        public string screenmode = "System error";
        WindowScreen ws = new WindowScreen();
        IDictionary<string, string> win31xtitles = Program.bluescreens[0].GetTitles();
        IDictionary<string, string> win31xtexts = Program.bluescreens[0].GetTexts();
        IDictionary<string, string> win9xtitles = Program.bluescreens[1].GetTitles();
        IDictionary<string, string> win9xtexts = Program.bluescreens[1].GetTexts();
        Color bg;
        Color fg;
        Color hlb;
        Color hlf;
        string[] letters = { "?", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ":", ",", ".", "+", "*", "!", "_" , "-", "(", ")", "/", "\\", " " };
        public old_bluescreen()
        {
            InitializeComponent();
        }

        private void Old_bluescreen_Load(object sender, EventArgs e)
        {
            string prompt = "";
            if (screenmode == "No unresponsive programs")
            {
                timer1.Interval = Program.bluescreens[0].GetInt("timer");
                bg = Program.bluescreens[0].GetTheme(true);
                fg = Program.bluescreens[0].GetTheme(false);
                hlb = Program.bluescreens[0].GetTheme(true, true);
                hlf = Program.bluescreens[0].GetTheme(false, true);
                prompt = win31xtexts["Prompt"];
            } else
            {
                timer1.Interval = Program.bluescreens[1].GetInt("timer");
                bg = Program.bluescreens[1].GetTheme(true);
                fg = Program.bluescreens[1].GetTheme(false);
                hlb = Program.bluescreens[1].GetTheme(true, true);
                hlf = Program.bluescreens[1].GetTheme(false, true);
                prompt = win9xtexts["Prompt"];
            }

            panel1.BackColor = Program.bluescreens[0].GetTheme(true, true);
            pictureBox2.BackColor = Program.bluescreens[0].GetTheme(true, true);
            if (screenmode == "System error")
            {
                pictureBox1.Image = WriteWord(win9xtitles["Main"], hlb, hlf);
                pictureBox1.Size = new Size(8 * win9xtitles["Main"].Length, pictureBox1.Height);
                panel1.Size = new Size(pictureBox1.Width + 20, panel1.Height);
                panel1.Location = new Point((this.Width / 2) - (panel1.Width / 2) - 8, panel1.Location.Y);
                pictureBox1.Location = new Point(10, 2);

                try { line1.Image = WriteWord(win9xtexts["System error"].Split('\n')[0].Replace("{0}", errorCode).Substring(0, win9xtexts["System error"].Split('\n')[0].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                try { line2.Image = WriteWord(win9xtexts["System error"].Split('\n')[1].Replace("{0}", errorCode).Substring(0, win9xtexts["System error"].Split('\n')[1].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                try { line3.Image = WriteWord(win9xtexts["System error"].Split('\n')[2].Replace("{0}", errorCode).Substring(0, win9xtexts["System error"].Split('\n')[2].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                try { line4.Image = WriteWord(win9xtexts["System error"].Split('\n')[3].Replace("{0}", errorCode).Substring(0, win9xtexts["System error"].Split('\n')[3].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                try { line5.Image = WriteWord(win9xtexts["System error"].Split('\n')[4].Replace("{0}", errorCode).Substring(0, win9xtexts["System error"].Split('\n')[4].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                try { line6.Image = WriteWord(win9xtexts["System error"].Split('\n')[5].Replace("{0}", errorCode).Substring(0, win9xtexts["System error"].Split('\n')[5].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                try { line7.Image = WriteWord(win9xtexts["System error"].Split('\n')[6].Replace("{0}", errorCode).Substring(0, win9xtexts["System error"].Split('\n')[6].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                try { line8.Image = WriteWord(win9xtexts["System error"].Split('\n')[7].Replace("{0}", errorCode).Substring(0, win9xtexts["System error"].Split('\n')[7].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
            }
            else if (screenmode == "Application error")
            {
                pictureBox1.Image = WriteWord(win9xtitles["Main"], hlb, hlf);
                pictureBox1.Size = new Size(8 * win9xtitles["Main"].Length, pictureBox1.Height);
                panel1.Size = new Size(pictureBox1.Width + 20, panel1.Height);
                panel1.Location = new Point((this.Width / 2) - (panel1.Width / 2) - 8, panel1.Location.Y);
                pictureBox1.Location = new Point(10, 2);

                try { line1.Image = WriteWord(win9xtexts["Application error"].Split('\n')[0].Substring(0, win9xtexts["Application error"].Split('\n')[0].Length - 1).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                try { line2.Image = WriteWord(win9xtexts["Application error"].Split('\n')[1].Substring(0, win9xtexts["Application error"].Split('\n')[1].Length - 1).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                try { line3.Image = WriteWord(win9xtexts["Application error"].Split('\n')[2].Substring(0, win9xtexts["Application error"].Split('\n')[2].Length - 1).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                try { line4.Image = WriteWord(win9xtexts["Application error"].Split('\n')[3].Substring(0, win9xtexts["Application error"].Split('\n')[3].Length - 1).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                try { line5.Image = WriteWord(win9xtexts["Application error"].Split('\n')[4].Substring(0, win9xtexts["Application error"].Split('\n')[4].Length - 1).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                try { line6.Image = WriteWord(win9xtexts["Application error"].Split('\n')[5].Substring(0, win9xtexts["Application error"].Split('\n')[5].Length - 1).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }

                /*          line1.Image = WriteWord("A fatal exception 0E has occurred at " + errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString() + ":" + errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString() + ". The current", bg, fg);
                          line2.Image = WriteWord("application will be terminated.", bg, fg);
                          line4.Image = WriteWord("*  Press any key to terminate current application.", bg, fg);
                          line5.Image = WriteWord("*  Press CTRL+ALT+DEL again to restart your computer. You will", bg, fg);
                          line6.Image = WriteWord("   lose any unsaved information in all applications.", bg, fg);*/
                line7.Visible = false;
                line8.Visible = false;
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + 20);
                anyKeyMsg.Location = new Point(anyKeyMsg.Location.X, anyKeyMsg.Location.Y - 30);
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 30);
            }
            else if (screenmode == "Driver error")
            {
                pictureBox1.Image = WriteWord(win9xtitles["Main"], hlb, hlf);
                pictureBox1.Size = new Size(8 * win9xtitles["Main"].Length, pictureBox1.Height);
                panel1.Size = new Size(pictureBox1.Width + 20, panel1.Height);
                panel1.Location = new Point((this.Width / 2) - (panel1.Width / 2) - 8, panel1.Location.Y);
                pictureBox1.Location = new Point(10, 2);

                try { line1.Image = WriteWord(win9xtexts["Driver error"].Split('\n')[0].Substring(0, win9xtexts["Driver error"].Split('\n')[0].Length - 1).Replace("{2}", Program.f1.GenHex(8, "RRRRRRRR")).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                try { line2.Image = WriteWord(win9xtexts["Driver error"].Split('\n')[1].Substring(0, win9xtexts["Driver error"].Split('\n')[1].Length - 1).Replace("{2}", Program.f1.GenHex(8, "RRRRRRRR")).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                try { line3.Image = WriteWord(win9xtexts["Driver error"].Split('\n')[2].Substring(0, win9xtexts["Driver error"].Split('\n')[2].Length - 1).Replace("{2}", Program.f1.GenHex(8, "RRRRRRRR")).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                try { line4.Image = WriteWord(win9xtexts["Driver error"].Split('\n')[3].Substring(0, win9xtexts["Driver error"].Split('\n')[3].Length - 1).Replace("{2}", Program.f1.GenHex(8, "RRRRRRRR")).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                try { line5.Image = WriteWord(win9xtexts["Driver error"].Split('\n')[4].Substring(0, win9xtexts["Driver error"].Split('\n')[4].Length - 1).Replace("{2}", Program.f1.GenHex(8, "RRRRRRRR")).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                try { line6.Image = WriteWord(win9xtexts["Driver error"].Split('\n')[5].Substring(0, win9xtexts["Driver error"].Split('\n')[5].Length - 1).Replace("{2}", Program.f1.GenHex(8, "RRRRRRRR")).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                /*line1.Image = WriteWord("A fatal exception 0E has occurred at " + Program.f1.GenHex(4, "RRRR") + ":" + Program.f1.GenHex(8, "RRRRRRRR") + " in VXD VMM(01) +", bg, fg);
                line2.Image = WriteWord(Program.f1.GenHex(8, "RRRRRRRR") + ". The current application will be terminated.", bg, fg);
                line4.Image = WriteWord("*  Press any key to terminate current application.", bg, fg);
                line5.Image = WriteWord("*  Press CTRL+ALT+DEL again to restart your computer. You will", bg, fg);
                line6.Image = WriteWord("   lose any unsaved information in all applications.", bg, fg);*/
                line7.Visible = false;
                line8.Visible = false;
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + 20);
                anyKeyMsg.Location = new Point(anyKeyMsg.Location.X, anyKeyMsg.Location.Y - 30);
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 30);
            }
            else if (screenmode == "System is unresponsive (Warning)")
            {
                pictureBox1.Image = WriteWord(win9xtitles["Warning"], hlb, hlf);
                pictureBox1.Size = new Size(8 * win9xtitles["Warning"].Length, pictureBox1.Height);
                panel1.Size = new Size(pictureBox1.Width + 20, panel1.Height);
                panel1.Location = new Point((this.Width / 2) - (panel1.Width / 2) - 8, panel1.Location.Y);
                pictureBox1.Location = new Point(10, 2);
                try { line1.Image = WriteWord(win9xtexts["System is unresponsive"].Split('\n')[0].Substring(0, win9xtexts["System is unresponsive"].Split('\n')[0].Length - 1), bg, fg); } catch { }
                try { line2.Image = WriteWord(win9xtexts["System is unresponsive"].Split('\n')[1].Substring(0, win9xtexts["System is unresponsive"].Split('\n')[1].Length - 1), bg, fg); } catch { }
                try { line3.Image = WriteWord(win9xtexts["System is unresponsive"].Split('\n')[2].Substring(0, win9xtexts["System is unresponsive"].Split('\n')[2].Length - 1), bg, fg); } catch { }
                try { line4.Image = WriteWord(win9xtexts["System is unresponsive"].Split('\n')[3].Substring(0, win9xtexts["System is unresponsive"].Split('\n')[3].Length - 1), bg, fg); } catch { }
                try { line5.Image = WriteWord(win9xtexts["System is unresponsive"].Split('\n')[4].Substring(0, win9xtexts["System is unresponsive"].Split('\n')[4].Length - 1), bg, fg); } catch { }
                try { line6.Image = WriteWord(win9xtexts["System is unresponsive"].Split('\n')[5].Substring(0, win9xtexts["System is unresponsive"].Split('\n')[5].Length - 1), bg, fg); } catch { }
                /*line1.Image = WriteWord("The system is either busy or has become unstable. You can wait and", bg, fg);
                line2.Image = WriteWord("see if it becomes available again, or you can restart your computer.", bg, fg);
                line4.Image = WriteWord("*  Press any key to return to Windows and wait.", bg, fg);
                line5.Image = WriteWord("*  Press CTRL+ALT+DEL again to restart your computer. You will", bg, fg);
                line6.Image = WriteWord("   lose any unsaved information in programs that are running.", bg, fg);*/
                line7.Visible = false;
                line8.Visible = false;
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + 20);
                anyKeyMsg.Location = new Point(anyKeyMsg.Location.X, anyKeyMsg.Location.Y - 30);
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 30);
            }
            else if (screenmode == "System is busy")
            {
                pictureBox1.Image = WriteWord(win9xtitles["System is busy"], hlb, hlf);
                pictureBox1.Size = new Size(8 * win9xtitles["System is busy"].Length, pictureBox1.Height);
                panel1.Size = new Size(pictureBox1.Width + 20, panel1.Height);
                panel1.Location = new Point((this.Width / 2) - (panel1.Width / 2) - 8, panel1.Location.Y);
                pictureBox1.Location = new Point(10, 2);
                try { line1.Image = WriteWord(win9xtexts["System is busy"].Split('\n')[0].Substring(0, win9xtexts["System is busy"].Split('\n')[0].Length - 1), bg, fg); } catch { }
                try { line2.Image = WriteWord(win9xtexts["System is busy"].Split('\n')[1].Substring(0, win9xtexts["System is busy"].Split('\n')[1].Length - 1), bg, fg); } catch { }
                try { line3.Image = WriteWord(win9xtexts["System is busy"].Split('\n')[2].Substring(0, win9xtexts["System is busy"].Split('\n')[2].Length - 1), bg, fg); } catch { }
                try { line4.Image = WriteWord(win9xtexts["System is busy"].Split('\n')[3].Substring(0, win9xtexts["System is busy"].Split('\n')[3].Length - 1), bg, fg); } catch { }
                try { line5.Image = WriteWord(win9xtexts["System is busy"].Split('\n')[4].Substring(0, win9xtexts["System is busy"].Split('\n')[4].Length - 1), bg, fg); } catch { }
                try { line6.Image = WriteWord(win9xtexts["System is busy"].Split('\n')[5].Substring(0, win9xtexts["System is busy"].Split('\n')[5].Length - 1), bg, fg); } catch { }
                try { line7.Image = WriteWord(win9xtexts["System is busy"].Split('\n')[6].Substring(0, win9xtexts["System is busy"].Split('\n')[6].Length - 1), bg, fg); } catch { }
               
                /*line1.Image = WriteWord("The system is busy waiting for the Close Program dialog box to be", bg, fg);
                line2.Image = WriteWord("displayed.  You can wait and see if it appears, or you can restart", bg, fg);
                line3.Image = WriteWord("your computer.", bg, fg);
                line5.Image = WriteWord("*  Press any key to return to Windows and wait.", bg, fg);
                line6.Image = WriteWord("*  Press CTRL+ALT+DEL again to restart your computer. You will", bg, fg);
                line7.Image = WriteWord("   lose any unsaved information in programs that are running.", bg, fg);*/
                line8.Visible = false;
                pictureBox1.Size = new Size(pictureBox1.Width + 70, pictureBox1.Height);
                pictureBox1.Location = new Point(10, 2);
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + 10);
                anyKeyMsg.Location = new Point(anyKeyMsg.Location.X, anyKeyMsg.Location.Y - 10);
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 10);

            }
            else if (screenmode == "No unresponsive programs")
            {
                pictureBox1.Image = WriteWord(win31xtitles["Main"], hlb, hlf);
                pictureBox1.Size = new Size(8 * win31xtitles["Main"].Length, pictureBox1.Height);
                panel1.Size = new Size(pictureBox1.Width + 20, panel1.Height);
                panel1.Location = new Point((this.Width / 2) - (panel1.Width / 2) - 8, panel1.Location.Y);
                pictureBox1.Location = new Point(10, 2);
                try { line1.Image = WriteWord(win31xtexts["No unresponsive programs"].Split('\n')[0].Substring(0, win31xtexts["No unresponsive programs"].Split('\n')[0].Length - 1), bg, fg); } catch { }
                try { line2.Image = WriteWord(win31xtexts["No unresponsive programs"].Split('\n')[1].Substring(0, win31xtexts["No unresponsive programs"].Split('\n')[1].Length - 1), bg, fg); } catch { }
                try { line3.Image = WriteWord(win31xtexts["No unresponsive programs"].Split('\n')[2].Substring(0, win31xtexts["No unresponsive programs"].Split('\n')[2].Length - 1), bg, fg); } catch { }
                try { line4.Image = WriteWord(win31xtexts["No unresponsive programs"].Split('\n')[3].Substring(0, win31xtexts["No unresponsive programs"].Split('\n')[3].Length - 1), bg, fg); } catch { }
                try { line5.Image = WriteWord(win31xtexts["No unresponsive programs"].Split('\n')[4].Substring(0, win31xtexts["No unresponsive programs"].Split('\n')[4].Length - 1), bg, fg); } catch { }
                try { line6.Image = WriteWord(win31xtexts["No unresponsive programs"].Split('\n')[5].Substring(0, win31xtexts["No unresponsive programs"].Split('\n')[5].Length - 1), bg, fg); } catch { }
                try { line7.Image = WriteWord(win31xtexts["No unresponsive programs"].Split('\n')[6].Substring(0, win31xtexts["No unresponsive programs"].Split('\n')[6].Length - 1), bg, fg); } catch { }
                try { line8.Image = WriteWord(win31xtexts["No unresponsive programs"].Split('\n')[7].Substring(0, win31xtexts["No unresponsive programs"].Split('\n')[7].Length - 1), bg, fg); } catch { }
                line4.Location = new Point(line4.Location.X, line4.Location.Y + 14);
                line5.Location = new Point(line5.Location.X, line5.Location.Y + 14);
                line6.Location = new Point(line6.Location.X, line6.Location.Y + 26);
                line7.Location = new Point(line7.Location.X, line7.Location.Y + 26);
                line8.Location = new Point(line8.Location.X, line8.Location.Y + 26);
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y - 15);
                anyKeyMsg.Location = new Point(anyKeyMsg.Location.X, anyKeyMsg.Location.Y + 26);
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 26);
            }
            anyKeyMsg.Image = WriteWord(prompt, bg, fg);
            anyKeyMsg.Size = new Size(prompt.Length * 8, anyKeyMsg.Height);
            anyKeyMsg.Location = new Point((this.Width / 2) - (anyKeyMsg.Width / 2) - 16, anyKeyMsg.Location.Y);
            pictureBox2.Location = new Point(anyKeyMsg.Location.X + anyKeyMsg.Width + 8, pictureBox2.Location.Y);
            if (!window)
            { 
                this.FormBorderStyle = FormBorderStyle.None;
                this.TopMost = false;
                ws.Show();
            } else
            {
                this.Size = new Size(640, 320);
            }
        }
        private Bitmap WriteWord (string word, Color bg, Color fg)
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
        private Bitmap GetSymbol (string symbol, Color bg, Color fg)
        {
            int index = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i].ToString() == symbol)
                {
                    index = i;
                    break;
                }
            }
            Rectangle cropRect = new Rectangle(index * 9, 0, 9, 14);
            try
            {
                Bitmap src = Properties.Resources.rasters3 as Bitmap;
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
                MessageBox.Show("Internal character set seems to be corrupted\n\n0x014: CHARSET_CORRUPTED", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!window)
            {
                if (ws.Visible == false)
                {
                    this.Close();
                }
                try
                {
                    var frm = Form.ActiveForm;
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
                }
                catch
                {
                    this.Close();
                }
            }
            if (pictureBox2.Visible == false)
            {
                pictureBox2.Visible = true;
                return;
            } else
            {
                pictureBox2.Visible = false;
                return;
            }
        }

        private void Old_bluescreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                try { if (ws.Visible == true) { ws.Close(); } }
                catch { }
                this.Close();
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Old_bluescreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!window)
            {
                if (ws.Visible)
                {
                    ws.Close();
                }
            }
        }

        private void Old_bluescreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (window)
            {
                if (Program.f1.closecuzhidden == true)
                {
                    Program.f1.Close();
                }
            }
        }
    }
}

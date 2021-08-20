using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class old_bluescreen : Form
    {
        public string errorCode = "0E : 016F : BFF9B3D4";
        public bool window = false;
        public string screenmode = "System error";
        internal BlueScreen me = Program.bluescreens[0];
        readonly List<WindowScreen> wss = new List<WindowScreen>();
        readonly List<Bitmap> freezescreens = new List<Bitmap>();
        IDictionary<string, string> titles;
        IDictionary<string, string> texts;
        Color bg;
        Color fg;
        Color hlb;
        Color hlf;
        readonly string[] letters = { "?", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ":", ",", ".", "+", "*", "!", "_" , "-", "(", ")", "/", "\\", "'", " " };
        public old_bluescreen()
        {
            InitializeComponent();
        }

        private void Old_bluescreen_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = me.GetIcon();
                this.Text = me.GetString("friendlyname");
                string prompt;
                titles = me.GetTitles();
                texts = me.GetTexts();
                if (screenmode == "No unresponsive programs")
                {
                    screenUpdater.Interval = me.GetInt("timer");
                    bg = me.GetTheme(true);
                    fg = me.GetTheme(false);
                    hlb = me.GetTheme(true, true);
                    hlf = me.GetTheme(false, true);
                    prompt = texts["Prompt"];
                }
                else
                {
                    screenUpdater.Interval = me.GetInt("timer");
                    bg = me.GetTheme(true);
                    fg = me.GetTheme(false);
                    hlb = me.GetTheme(true, true);
                    hlf = me.GetTheme(false, true);
                    prompt = texts["Prompt"];
                }

                titleBorder.BackColor = me.GetTheme(true, true);
                blinkingColor.BackColor = me.GetTheme(true, true);
                if (screenmode == "System error")
                {
                    titleText.Image = WriteWord(titles["Main"], hlb, hlf);
                    titleText.Size = new Size(8 * titles["Main"].Length, titleText.Height);
                    titleBorder.Size = new Size(titleText.Width + 20, titleBorder.Height);
                    titleBorder.Location = new Point((this.Width / 2) - (titleBorder.Width / 2) - 8, titleBorder.Location.Y);
                    titleText.Location = new Point(10, 2);

                    try { line1.Image = WriteWord(texts["System error"].Split('\n')[0].Replace("{0}", errorCode).Substring(0, texts["System error"].Split('\n')[0].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                    try { line2.Image = WriteWord(texts["System error"].Split('\n')[1].Replace("{0}", errorCode).Substring(0, texts["System error"].Split('\n')[1].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                    try { line3.Image = WriteWord(texts["System error"].Split('\n')[2].Replace("{0}", errorCode).Substring(0, texts["System error"].Split('\n')[2].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                    try { line4.Image = WriteWord(texts["System error"].Split('\n')[3].Replace("{0}", errorCode).Substring(0, texts["System error"].Split('\n')[3].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                    try { line5.Image = WriteWord(texts["System error"].Split('\n')[4].Replace("{0}", errorCode).Substring(0, texts["System error"].Split('\n')[4].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                    try { line6.Image = WriteWord(texts["System error"].Split('\n')[5].Replace("{0}", errorCode).Substring(0, texts["System error"].Split('\n')[5].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                    try { line7.Image = WriteWord(texts["System error"].Split('\n')[6].Replace("{0}", errorCode).Substring(0, texts["System error"].Split('\n')[6].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                    try { line8.Image = WriteWord(texts["System error"].Split('\n')[7].Replace("{0}", errorCode).Substring(0, texts["System error"].Split('\n')[7].Replace("{0}", errorCode).Length - 1), bg, fg); } catch { }
                }
                else if (screenmode == "Application error")
                {
                    titleText.Image = WriteWord(titles["Main"], hlb, hlf);
                    titleText.Size = new Size(8 * titles["Main"].Length, titleText.Height);
                    titleBorder.Size = new Size(titleText.Width + 20, titleBorder.Height);
                    titleBorder.Location = new Point((this.Width / 2) - (titleBorder.Width / 2) - 8, titleBorder.Location.Y);
                    titleText.Location = new Point(10, 2);

                    try { line1.Image = WriteWord(texts["Application error"].Split('\n')[0].Substring(0, texts["Application error"].Split('\n')[0].Length - 1).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                    try { line2.Image = WriteWord(texts["Application error"].Split('\n')[1].Substring(0, texts["Application error"].Split('\n')[1].Length - 1).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                    try { line3.Image = WriteWord(texts["Application error"].Split('\n')[2].Substring(0, texts["Application error"].Split('\n')[2].Length - 1).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                    try { line4.Image = WriteWord(texts["Application error"].Split('\n')[3].Substring(0, texts["Application error"].Split('\n')[3].Length - 1).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                    try { line5.Image = WriteWord(texts["Application error"].Split('\n')[4].Substring(0, texts["Application error"].Split('\n')[4].Length - 1).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                    try { line6.Image = WriteWord(texts["Application error"].Split('\n')[5].Substring(0, texts["Application error"].Split('\n')[5].Length - 1).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }

                    /*          line1.Image = WriteWord("A fatal exception 0E has occurred at " + errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString() + ":" + errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString() + ". The current", bg, fg);
                              line2.Image = WriteWord("application will be terminated.", bg, fg);
                              line4.Image = WriteWord("*  Press any key to terminate current application.", bg, fg);
                              line5.Image = WriteWord("*  Press CTRL+ALT+DEL again to restart your computer. You will", bg, fg);
                              line6.Image = WriteWord("   lose any unsaved information in all applications.", bg, fg);*/
                    line7.Visible = false;
                    line8.Visible = false;
                    simplePanel.Location = new Point(simplePanel.Location.X, simplePanel.Location.Y + 20);
                    anyKeyMsg.Location = new Point(anyKeyMsg.Location.X, anyKeyMsg.Location.Y - 30);
                    blinkingColor.Location = new Point(blinkingColor.Location.X, blinkingColor.Location.Y - 30);
                }
                else if (screenmode == "Driver error")
                {
                    titleText.Image = WriteWord(titles["Main"], hlb, hlf);
                    titleText.Size = new Size(8 * titles["Main"].Length, titleText.Height);
                    titleBorder.Size = new Size(titleText.Width + 20, titleBorder.Height);
                    titleBorder.Location = new Point((this.Width / 2) - (titleBorder.Width / 2) - 8, titleBorder.Location.Y);
                    titleText.Location = new Point(10, 2);

                    try { line1.Image = WriteWord(texts["Driver error"].Split('\n')[0].Substring(0, texts["Driver error"].Split('\n')[0].Length - 1).Replace("{2}", Program.bluescreens[3].GenHex(8, "RRRRRRRR")).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                    try { line2.Image = WriteWord(texts["Driver error"].Split('\n')[1].Substring(0, texts["Driver error"].Split('\n')[1].Length - 1).Replace("{2}", Program.bluescreens[3].GenHex(8, "RRRRRRRR")).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                    try { line3.Image = WriteWord(texts["Driver error"].Split('\n')[2].Substring(0, texts["Driver error"].Split('\n')[2].Length - 1).Replace("{2}", Program.bluescreens[3].GenHex(8, "RRRRRRRR")).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                    try { line4.Image = WriteWord(texts["Driver error"].Split('\n')[3].Substring(0, texts["Driver error"].Split('\n')[3].Length - 1).Replace("{2}", Program.bluescreens[3].GenHex(8, "RRRRRRRR")).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                    try { line5.Image = WriteWord(texts["Driver error"].Split('\n')[4].Substring(0, texts["Driver error"].Split('\n')[4].Length - 1).Replace("{2}", Program.bluescreens[3].GenHex(8, "RRRRRRRR")).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                    try { line6.Image = WriteWord(texts["Driver error"].Split('\n')[5].Substring(0, texts["Driver error"].Split('\n')[5].Length - 1).Replace("{2}", Program.bluescreens[3].GenHex(8, "RRRRRRRR")).Replace("{0}", errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString()).Replace("{1}", errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString()), bg, fg); } catch { }
                    /*line1.Image = WriteWord("A fatal exception 0E has occurred at " + Program.f1.GenHex(4, "RRRR") + ":" + Program.f1.GenHex(8, "RRRRRRRR") + " in VXD VMM(01) +", bg, fg);
                    line2.Image = WriteWord(Program.f1.GenHex(8, "RRRRRRRR") + ". The current application will be terminated.", bg, fg);
                    line4.Image = WriteWord("*  Press any key to terminate current application.", bg, fg);
                    line5.Image = WriteWord("*  Press CTRL+ALT+DEL again to restart your computer. You will", bg, fg);
                    line6.Image = WriteWord("   lose any unsaved information in all applications.", bg, fg);*/
                    line7.Visible = false;
                    line8.Visible = false;
                    simplePanel.Location = new Point(simplePanel.Location.X, simplePanel.Location.Y + 20);
                    anyKeyMsg.Location = new Point(anyKeyMsg.Location.X, anyKeyMsg.Location.Y - 30);
                    blinkingColor.Location = new Point(blinkingColor.Location.X, blinkingColor.Location.Y - 30);
                }
                else if (screenmode == "System is unresponsive (Warning)")
                {
                    titleText.Image = WriteWord(titles["Warning"], hlb, hlf);
                    titleText.Size = new Size(8 * titles["Warning"].Length, titleText.Height);
                    titleBorder.Size = new Size(titleText.Width + 20, titleBorder.Height);
                    titleBorder.Location = new Point((this.Width / 2) - (titleBorder.Width / 2) - 8, titleBorder.Location.Y);
                    titleText.Location = new Point(10, 2);
                    try { line1.Image = WriteWord(texts["System is unresponsive"].Split('\n')[0].Substring(0, texts["System is unresponsive"].Split('\n')[0].Length - 1), bg, fg); } catch { }
                    try { line2.Image = WriteWord(texts["System is unresponsive"].Split('\n')[1].Substring(0, texts["System is unresponsive"].Split('\n')[1].Length - 1), bg, fg); } catch { }
                    try { line3.Image = WriteWord(texts["System is unresponsive"].Split('\n')[2].Substring(0, texts["System is unresponsive"].Split('\n')[2].Length - 1), bg, fg); } catch { }
                    try { line4.Image = WriteWord(texts["System is unresponsive"].Split('\n')[3].Substring(0, texts["System is unresponsive"].Split('\n')[3].Length - 1), bg, fg); } catch { }
                    try { line5.Image = WriteWord(texts["System is unresponsive"].Split('\n')[4].Substring(0, texts["System is unresponsive"].Split('\n')[4].Length - 1), bg, fg); } catch { }
                    try { line6.Image = WriteWord(texts["System is unresponsive"].Split('\n')[5].Substring(0, texts["System is unresponsive"].Split('\n')[5].Length - 1), bg, fg); } catch { }
                    /*line1.Image = WriteWord("The system is either busy or has become unstable. You can wait and", bg, fg);
                    line2.Image = WriteWord("see if it becomes available again, or you can restart your computer.", bg, fg);
                    line4.Image = WriteWord("*  Press any key to return to Windows and wait.", bg, fg);
                    line5.Image = WriteWord("*  Press CTRL+ALT+DEL again to restart your computer. You will", bg, fg);
                    line6.Image = WriteWord("   lose any unsaved information in programs that are running.", bg, fg);*/
                    line7.Visible = false;
                    line8.Visible = false;
                    simplePanel.Location = new Point(simplePanel.Location.X, simplePanel.Location.Y + 20);
                    anyKeyMsg.Location = new Point(anyKeyMsg.Location.X, anyKeyMsg.Location.Y - 30);
                    blinkingColor.Location = new Point(blinkingColor.Location.X, blinkingColor.Location.Y - 30);
                }
                else if (screenmode == "System is busy")
                {
                    titleText.Image = WriteWord(titles["System is busy"], hlb, hlf);
                    titleText.Size = new Size(8 * titles["System is busy"].Length, titleText.Height);
                    titleBorder.Size = new Size(titleText.Width + 20, titleBorder.Height);
                    titleBorder.Location = new Point((this.Width / 2) - (titleBorder.Width / 2) - 8, titleBorder.Location.Y);
                    titleText.Location = new Point(10, 2);
                    try { line1.Image = WriteWord(texts["System is busy"].Split('\n')[0].Substring(0, texts["System is busy"].Split('\n')[0].Length - 1), bg, fg); } catch { }
                    try { line2.Image = WriteWord(texts["System is busy"].Split('\n')[1].Substring(0, texts["System is busy"].Split('\n')[1].Length - 1), bg, fg); } catch { }
                    try { line3.Image = WriteWord(texts["System is busy"].Split('\n')[2].Substring(0, texts["System is busy"].Split('\n')[2].Length - 1), bg, fg); } catch { }
                    try { line4.Image = WriteWord(texts["System is busy"].Split('\n')[3].Substring(0, texts["System is busy"].Split('\n')[3].Length - 1), bg, fg); } catch { }
                    try { line5.Image = WriteWord(texts["System is busy"].Split('\n')[4].Substring(0, texts["System is busy"].Split('\n')[4].Length - 1), bg, fg); } catch { }
                    try { line6.Image = WriteWord(texts["System is busy"].Split('\n')[5].Substring(0, texts["System is busy"].Split('\n')[5].Length - 1), bg, fg); } catch { }
                    try { line7.Image = WriteWord(texts["System is busy"].Split('\n')[6].Substring(0, texts["System is busy"].Split('\n')[6].Length - 1), bg, fg); } catch { }

                    /*line1.Image = WriteWord("The system is busy waiting for the Close Program dialog box to be", bg, fg);
                    line2.Image = WriteWord("displayed.  You can wait and see if it appears, or you can restart", bg, fg);
                    line3.Image = WriteWord("your computer.", bg, fg);
                    line5.Image = WriteWord("*  Press any key to return to Windows and wait.", bg, fg);
                    line6.Image = WriteWord("*  Press CTRL+ALT+DEL again to restart your computer. You will", bg, fg);
                    line7.Image = WriteWord("   lose any unsaved information in programs that are running.", bg, fg);*/
                    line8.Visible = false;
                    titleText.Size = new Size(titleText.Width + 70, titleText.Height);
                    titleText.Location = new Point(10, 2);
                    simplePanel.Location = new Point(simplePanel.Location.X, simplePanel.Location.Y + 10);
                    anyKeyMsg.Location = new Point(anyKeyMsg.Location.X, anyKeyMsg.Location.Y - 10);
                    blinkingColor.Location = new Point(blinkingColor.Location.X, blinkingColor.Location.Y - 10);

                }
                else if (screenmode == "No unresponsive programs")
                {
                    titleText.Image = WriteWord(titles["Main"], hlb, hlf);
                    titleText.Size = new Size(8 * titles["Main"].Length, titleText.Height);
                    titleBorder.Size = new Size(titleText.Width + 20, titleBorder.Height);
                    titleBorder.Location = new Point((this.Width / 2) - (titleBorder.Width / 2) - 8, titleBorder.Location.Y);
                    titleText.Location = new Point(10, 2);
                    try { line1.Image = WriteWord(texts["No unresponsive programs"].Split('\n')[0].Substring(0, texts["No unresponsive programs"].Split('\n')[0].Length - 1), bg, fg); } catch { }
                    try { line2.Image = WriteWord(texts["No unresponsive programs"].Split('\n')[1].Substring(0, texts["No unresponsive programs"].Split('\n')[1].Length - 1), bg, fg); } catch { }
                    try { line3.Image = WriteWord(texts["No unresponsive programs"].Split('\n')[2].Substring(0, texts["No unresponsive programs"].Split('\n')[2].Length - 1), bg, fg); } catch { }
                    try { line4.Image = WriteWord(texts["No unresponsive programs"].Split('\n')[3].Substring(0, texts["No unresponsive programs"].Split('\n')[3].Length - 1), bg, fg); } catch { }
                    try { line5.Image = WriteWord(texts["No unresponsive programs"].Split('\n')[4].Substring(0, texts["No unresponsive programs"].Split('\n')[4].Length - 1), bg, fg); } catch { }
                    try { line6.Image = WriteWord(texts["No unresponsive programs"].Split('\n')[5].Substring(0, texts["No unresponsive programs"].Split('\n')[5].Length - 1), bg, fg); } catch { }
                    try { line7.Image = WriteWord(texts["No unresponsive programs"].Split('\n')[6].Substring(0, texts["No unresponsive programs"].Split('\n')[6].Length - 1), bg, fg); } catch { }
                    try { line8.Image = WriteWord(texts["No unresponsive programs"].Split('\n')[7].Substring(0, texts["No unresponsive programs"].Split('\n')[7].Length - 1), bg, fg); } catch { }
                    line4.Location = new Point(line4.Location.X, line4.Location.Y + 14);
                    line5.Location = new Point(line5.Location.X, line5.Location.Y + 14);
                    line6.Location = new Point(line6.Location.X, line6.Location.Y + 26);
                    line7.Location = new Point(line7.Location.X, line7.Location.Y + 26);
                    line8.Location = new Point(line8.Location.X, line8.Location.Y + 26);
                    simplePanel.Location = new Point(simplePanel.Location.X, simplePanel.Location.Y - 15);
                    anyKeyMsg.Location = new Point(anyKeyMsg.Location.X, anyKeyMsg.Location.Y + 26);
                    blinkingColor.Location = new Point(blinkingColor.Location.X, blinkingColor.Location.Y + 26);
                }
                anyKeyMsg.Image = WriteWord(prompt, bg, fg);
                anyKeyMsg.Size = new Size(prompt.Length * 8, anyKeyMsg.Height);
                anyKeyMsg.Location = new Point((this.Width / 2) - (anyKeyMsg.Width / 2) - 16, anyKeyMsg.Location.Y);
                blinkingColor.Location = new Point(anyKeyMsg.Location.X + anyKeyMsg.Width + 8, blinkingColor.Location.Y);
                Program.loadfinished = true;
                if (!window)
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.TopMost = false;

                    if (Screen.AllScreens.Length > 1)
                    {
                        foreach (Screen s in Screen.AllScreens)
                        {
                            WindowScreen ws = new WindowScreen();
                            if (!s.Primary)
                            {
                                if (Program.multidisplaymode != "none")
                                {
                                    ws.StartPosition = FormStartPosition.Manual;
                                    ws.Location = s.WorkingArea.Location;
                                    ws.Size = new Size(s.WorkingArea.Width, s.WorkingArea.Height);
                                    ws.primary = false;

                                    if (Program.multidisplaymode == "freeze")
                                    {
                                        Bitmap screenshot = new Bitmap(s.Bounds.Width,
                                            s.Bounds.Height,
                                            System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                                        Graphics gfxScreenshot = Graphics.FromImage(screenshot);
                                        gfxScreenshot.CopyFromScreen(
                                            s.Bounds.X,
                                            s.Bounds.Y,
                                            0,
                                            0,
                                            s.Bounds.Size,
                                            CopyPixelOperation.SourceCopy
                                            );
                                        freezescreens.Add(screenshot);

                                    }
                                }
                            }
                            wss.Add(ws);
                        }
                    }
                    else
                    {
                        wss.Add(new WindowScreen());
                    }
                    for (int i = 0; i < wss.Count; i++)
                    {
                        WindowScreen ws = wss[i];
                        ws.Show();
                        if (!ws.primary)
                        {
                            if (Program.multidisplaymode == "freeze")
                            {
                                ws.screenDisplay.Image = freezescreens[i - 1];
                            }
                        }
                    }
                }
                else
                {
                    this.Size = new Size(640, 320);
                }
                int[] colors = { this.BackColor.R + 50, this.BackColor.R + 50, this.BackColor.B + 50 };
                if (colors[0] > 255) { colors[0] -= 255; }
                if (colors[1] > 255) { colors[1] -= 255; }
                if (colors[2] > 255) { colors[2] -= 255; }
                waterMarkText.ForeColor = Color.FromArgb(colors[0], colors[1], colors[2]);
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                MessageBox.Show("A blue screen couldn't be displayed due to an error\n\n" + ex.Message + "\n\n" + ex.StackTrace, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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
                Bitmap tc = Changecolor(bg, target, Color.FromArgb(0, 0, 0));
                Bitmap t = Changecolor(fg, tc, Color.FromArgb(255, 255, 255));
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
        private Bitmap Changecolor(Color gc, Bitmap bmp, Color incol)
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
            if (screenUpdater.Interval != me.GetInt("blink_speed")) { screenUpdater.Interval = me.GetInt("blink_speed"); }
            if (!window)
            {
                foreach (WindowScreen ws in wss)
                {
                    if (ws.Visible == false)
                    {
                        this.Close();
                    }
                    try
                    {
                        if (!ws.primary && Program.multidisplaymode == "blank")
                        {
                            continue;
                        }
                        Program.dr.Draw(ws);
                    }
                    catch
                    {
                        this.Close();
                    }
                }
                this.BringToFront();
                this.Activate();
            }
            if (blinkingColor.Visible == false)
            {
                blinkingColor.Visible = true;
                return;
            } else
            {
                blinkingColor.Visible = false;
                return;
            }
        }

        private void Old_bluescreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (WindowScreen ws in wss)
                {
                    try { if (ws.Visible == true) { ws.Close(); } }
                    catch { }
                }
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
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = Program.f1.lockout;
            }
            else
            {
                e.Cancel = false;
            }
            if (!window)
            {
                foreach (WindowScreen ws in wss)
                {
                    if (ws.Visible)
                    {
                        ws.Dispose();
                        ws.Close();
                    }
                }
                foreach (Bitmap bmp in freezescreens)
                {
                    bmp.Dispose();
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

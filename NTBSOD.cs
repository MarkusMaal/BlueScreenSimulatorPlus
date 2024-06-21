using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
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
        readonly List<WindowScreen> wss = new List<WindowScreen>();
        readonly List<Bitmap> freezescreens = new List<Bitmap>();
        internal BlueScreen me = Program.bluescreens[0];
        IDictionary<string, string> txt;
        readonly string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ":", ",", ".", "+", "*", "(", ")", "[", "]", "{", "}", "/", "\\", "-", "_", " " };
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
            try
            {
                this.Icon = me.GetIcon();
                this.Text = me.GetString("friendlyname");
                txt = me.GetTexts();
                blinkyThing.BackColor = me.GetTheme(false);
                if (!blink) { blinkyThing.Visible = false; }
                Program.load_progress = 2;
                Program.load_message = "Processing error code";
                errorCode.Image = WriteWord(txt["Error code formatting"].Replace("{0}", error.Split(' ')[1].Replace(")", "").Replace("(", "").Replace(" ", "").ToString()).Replace("{1}", me.GenAddress(4, 8, false)).Trim(), me.GetTheme(true), me.GetTheme(false));
                Program.load_progress = 10;
                if (whatfail == "")
                {
                    errorDescription.Image = WriteWord(error.Split(' ')[0].ToString(), me.GetTheme(true), me.GetTheme(false));
                }
                else
                {
                    errorDescription.Image = WriteWord(error.Split(' ')[0].ToString() + "*** Address " + me.GenHex(8, "RRRRRRRR").ToLower() + " has base at " + me.GenHex(8, "RRRRRRRR").ToLower() + " - " + whatfail.ToLower(), me.GetTheme(true), me.GetTheme(false));
                }

                Program.load_progress = 15;
                if (stacktrace)
                {
                    Program.load_message = "Processing CPUID";
                    cpuID.Image = WriteWord(txt["CPUID formatting"].Replace("{0}", processortype).Trim(), me.GetTheme(true), me.GetTheme(false));
                    Program.load_message = "Processing stack trace heading";
                    tableHeader.Image = WriteWord(txt["Stack trace heading"].Trim() + GenSpace(40 - txt["Stack trace heading"].Trim().Length) + txt["Stack trace heading"].Trim(), me.GetTheme(true), me.GetTheme(false));
                    int i = 0;

                    Program.load_progress += 5;
                    foreach (PictureBox ctrl in flowLayoutPanel2.Controls)
                    {

                        Program.load_message = "Processing table (column 1, row " + (i + 1).ToString() + ")";
                        if (me.GetFiles().Count < i + 1)
                        {
                            break;
                        }
                        if (me.GetFiles().Values.ElementAt(i).Length == 6)
                        {
                            break;
                        }
                        string file = me.GetFiles().Keys.ElementAt(i);
                        string rnd1 = me.GenHex(8, me.GetFiles().Values.ElementAt(i)[0]).ToLower();
                        string rnd2 = me.GenHex(8, me.GetFiles().Values.ElementAt(i)[1]).ToLower();
                        ctrl.Image = WriteWord(txt["Stack trace table formatting"].Trim().Replace("{0}", rnd1).Replace("{1}", rnd2).Replace("{2}", file), me.GetTheme(true), me.GetTheme(false));
                        i++;
                        Program.load_progress += 1;
                    }
                    int firstcol = i;
                    foreach (PictureBox ctrl in flowLayoutPanel3.Controls)
                    {
                        Program.load_message = "Processing table (column 2, row " + (i - firstcol + 1).ToString() + ")";
                        if (me.GetFiles().Count < i + 1)
                        {
                            break;
                        }
                        if (me.GetFiles().Values.ElementAt(i).Length == 6)
                        {
                            break;
                        }
                        string file = me.GetFiles().Keys.ElementAt(i);
                        string rnd1 = me.GenHex(8, me.GetFiles().Values.ElementAt(i)[0]).ToLower();
                        string rnd2 = me.GenHex(8, me.GetFiles().Values.ElementAt(i)[1]).ToLower();
                        ctrl.Image = WriteWord(txt["Stack trace table formatting"].Trim().Replace("{0}", rnd1).Replace("{1}", rnd2).Replace("{2}", file), me.GetTheme(true), me.GetTheme(false));
                        i++;
                        Program.load_progress += 1;
                    }
                    Program.load_message = "Processing memory address dump heading";
                    table2.Image = WriteWord(txt["Memory address dump heading"], me.GetTheme(true), me.GetTheme(false));
                    Program.load_progress = 90;
                    i = 0;
                    foreach (KeyValuePair<string, string[]> kvp in me.GetFiles())
                    {
                        if (me.GetFiles().Count < i + 1)
                        {
                            break;
                        }
                        if (kvp.Value.Length == 6)
                        {
                            break;
                        }
                        i++;
                    }
                    for (int n = 1; n < 5; n++)
                    {

                        Program.load_message = "Processing table (row " + n.ToString() + ")";
                        if (me.GetFiles().Count < i + 1)
                        {
                            break;
                        }
                        if (i < me.GetFiles().Count)
                        {
                            string file = me.GetFiles().Keys.ElementAt(i);
                            string r1 = me.GenHex(8, me.GetFiles().Values.ElementAt(i)[0]).ToLower();
                            string r2 = me.GenHex(8, me.GetFiles().Values.ElementAt(i)[1]).ToLower();
                            string r3 = me.GenHex(8, me.GetFiles().Values.ElementAt(i)[2]).ToLower();
                            string r4 = me.GenHex(8, me.GetFiles().Values.ElementAt(i)[3]).ToLower();
                            string r5 = me.GenHex(8, me.GetFiles().Values.ElementAt(i)[4]).ToLower();
                            string r6 = me.GenHex(8, me.GetFiles().Values.ElementAt(i)[5]).ToLower();
                            ((PictureBox)ntContainer.Controls["tablerow_" + n.ToString()]).Image = WriteWord(txt["Memory address dump table"].Replace("{0}", r1).Replace("{1}", r2).Replace("{2}", r3).Replace("{3}", r4).Replace("{4}", r5).Replace("{5}", r6).Replace("{6}", file), me.GetTheme(true), me.GetTheme(false));
                            i++;
                            Program.load_progress += 6;
                        }
                    }
                    Program.load_progress = 100;
                    Program.load_message = "";
                    // for older versions of BSSP that displayed "Please wait..." at the bottom right of main window while generating NT BSODs
                    //Program.f1.label10.Text = "";


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
                try
                {
                    troubleShoot1.Image = WriteWord(txt["Troubleshooting text"].Split('\n')[0].Trim(), me.GetTheme(true), me.GetTheme(false));
                    troubleShoot2.Image = WriteWord(txt["Troubleshooting text"].Split('\n')[1].Trim(), me.GetTheme(true), me.GetTheme(false));
                }
                catch { }

                if (!fullscreen) { this.FormBorderStyle = FormBorderStyle.FixedSingle; }
                if (fullscreen)
                {
                    if (Screen.AllScreens.Length > 1)
                    {
                        foreach (Screen s in Screen.AllScreens)
                        {
                            WindowScreen ws = new WindowScreen();
                            if (!s.Primary)
                            {
                                if (Program.gs.DisplayMode != "none")
                                {
                                    ws.StartPosition = FormStartPosition.Manual;
                                    ws.Location = s.WorkingArea.Location;
                                    ws.Size = new Size(s.WorkingArea.Width, s.WorkingArea.Height);
                                    ws.primary = false;

                                    if (Program.gs.DisplayMode == "freeze")
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
                            if (Program.gs.DisplayMode == "freeze")
                            {
                                ws.screenDisplay.Image = freezescreens[i - 1];
                            }
                        }
                    }
                    this.TopMost = false;
                }
                int[] colors = { this.BackColor.R + 50, this.BackColor.G + 50, this.BackColor.B + 50 };
                if (colors[0] > 255) { colors[0] -= 255; }
                if (colors[1] > 255) { colors[1] -= 255; }
                if (colors[2] > 255) { colors[2] -= 255; }
                waterMarkText.ForeColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                Program.loadfinished = true;
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                screenUpdater.Enabled = false;
                this.Hide();
                if (Program.gs.EnableEggs) { me.Crash(ex.Message, ex.StackTrace, "OrangeScreen"); }
                else { MessageBox.Show("The blue screen cannot be displayed due to an error.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                two.Dispose();
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
                Bitmap tc = Changecolor(bg, target, Color.FromArgb(0, 0, 0));
                Bitmap t = Changecolor(fg, tc, Color.FromArgb(255, 255, 255));
                target = t;
                //tc.Dispose();
                //t.Dispose();
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
            bmp.Dispose();
            bmp2.Dispose();
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
            if (fullscreen)
            {
                foreach (WindowScreen ws in wss)
                {
                    try
                    {
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
            if (blink)
            {
                if (blinkyThing.Visible == false)
                {
                    blinkyThing.Visible = true;
                }
                else
                {
                    blinkyThing.Visible = false;
                }
            }
        }

        private void NTBSOD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = Program.gs.PM_Lockout;
            }
            else
            {
                e.Cancel = false;
            }
            if (stackTrace1_1.Image != null)
            {
                try
                {
                    foreach (Control c in this.tableLayoutPanel1.Controls)
                    {
                        if (c is PictureBox box && box.Image != null) { box.Image.Dispose(); c.Dispose(); }
                    }
                    foreach (Control c in this.ntContainer.Controls)
                    {
                        if (c is PictureBox box && box.Image != null) { box.Image.Dispose(); c.Dispose(); }
                    }
                    foreach (Control c in this.flowLayoutPanel2.Controls)
                    {
                        if (c is PictureBox box && box.Image != null) { box.Image.Dispose(); c.Dispose(); }
                    }
                    foreach (Control c in this.flowLayoutPanel3.Controls)
                    {
                        if (c is PictureBox box && box.Image != null) { box.Image.Dispose(); c.Dispose(); }
                    }
                } catch
                {
                    Console.WriteLine("Warning: Failed to dispose images!!!");
                }
            }
            if (fullscreen)
            {
                foreach (WindowScreen ws in wss)
                {
                    if (ws.Visible == true)
                    {
                        ws.Close();
                    }
                    ws.Dispose();
                }
                foreach (Bitmap bmp in freezescreens)
                {
                    bmp.Dispose();
                }
            }
        }

        private void NTBSOD_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!fullscreen)
            {
                if (Program.gs.PM_CloseMainUI)
                {
                    Application.Exit();
                }
            }
            try
            {
                this.Dispose();
            } catch
            {
                Console.WriteLine("Warning: \"NTSOD\" forcibly closed from external source!!!");
            }
        }

        private void NTBSOD_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F7))
            {
                foreach (WindowScreen ws in wss)
                {
                    try { if (ws.Visible == true) { ws.Close(); } }
                    catch { }
                }
                Close();
            }
        }
    }
}

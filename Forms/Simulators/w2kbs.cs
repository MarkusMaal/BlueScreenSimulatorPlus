﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class W2kbs : Form
    {
        public bool fullscreen = true;
        private bool naturalclose = false;
        public string whatfail = "";
        internal BlueScreen me = Program.templates.GetAt(0);
        private string state = "0";
        private bool inr = false;
        private bool ing = false;
        private bool inb = false;
        internal string errorCode;
        private readonly string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ":", ",", ".", "+", "*", "(", ")", "[", "]", "{", "}", "/", "\\", "-", "_", " ", "'" };

        // NT4 specific options
        public string ver = "4.0 (Service Pack 6)";
        public bool stacktrace = true;
        public bool starterror = true;
        public bool blink = true;
        public string processortype = "GenuineIntel";
        public string error = "User manually initiated crash (0xDEADDEAD)";
        private int moves = 0;

        public W2kbs()
        {
            //
            // forcibly disable DPI scaling for these legacy configurations
            // otherwise, the character set will be rendered incorrectly
            //
            // to upscale on higher DPI settings, use fullscreen mode
            //
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            InitializeComponent();
        }

        private void W2kbs_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                try
                {
                    c.Dispose();
                }
                catch
                {

                }
            }
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = Program.gs.PM_Lockout;
            }
            else
            {
                e.Cancel = false;
            }
            if (!naturalclose)
            {
                Program.dr.Dispose();
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
                    {
                        img.SetPixel(i, j, white);
                    }
                }
            }
            return img;
        }


        private void W2kbs_Load(object sender, EventArgs e)
        {
            try
            {
                if (Program.TestDicts(letters, me))
                {
                    screenUpdater.Enabled = false;
                    Close();
                    return;
                }
                if (Program.gs.EnableEggs)
                {
                    if (BackColor == ForeColor)
                    {
                        BackColor = Color.Red;
                        rainBowScreen.Enabled = true;
                    }
                }
                Icon = me.GetIcon();
                Text = me.GetString("friendlyname");
                List<Bitmap> lines = new List<Bitmap>();
                if (!me.GetBool("threepointone"))
                {
                    lines.Add(WriteWord(" ", BackColor, ForeColor));
                }
                if (me.GetString("os").Equals("Windows 2000"))
                {
                    if (whatfail != "")
                    {
                        // set file information template to default value if not found for backwards compatibility with version 2.0 configuration formats
                        string addr = me.GetTexts().ContainsKey("File information") ? me.GetTexts()["File information"] : "*** Address {0} base at {1}, DateStamp {2} - {3}";
                        errorCode += "\n\n";
                        // apparently me.GetString("cuplrit") sometimes throws an exception if you change it to Beep.SYS?
                        // we do a try-catch here and just use the first value of GetFiles() dictionary if it fails
                        try
                        {
                            errorCode += string.Format(addr, me.GenHex(8, me.GetFiles()[0].Value[0]), me.GenHex(8, me.GetFiles()[0].Value[1]), me.GenHex(8, me.GetFiles()[0].Value[2]).ToLower(), whatfail.ToLower());
                        }
                        catch
                        {
                            errorCode += string.Format(addr, me.GenHex(8, me.GetFiles().First().Value[0]), me.GenHex(8, me.GetFiles().First().Value[1]), me.GenHex(8, me.GetFiles().First().Value[2]).ToLower(), whatfail.ToLower());
                        }
                    }

                    foreach (string l in SafeSplit(errorCode))
                    {
                        if (l.Replace("\r", "\n").Replace("\n", "") == "") { lines.Add(WriteWord(" ", BackColor, ForeColor)); continue; }
                        lines.Add(WriteWord(l.Replace("\r", "\n").Replace("\n", ""), BackColor, ForeColor));
                    }
                    lines.Add(WriteWord(" ", BackColor, ForeColor));

                    foreach (string l in SafeSplit(me.GetTexts()["Troubleshooting introduction"]))
                    {
                        if (l.Replace("\r", "\n").Replace("\n", "") == "") { lines.Add(WriteWord(" ", BackColor, ForeColor)); continue; }
                        lines.Add(WriteWord(l.Replace("\r", "\n").Replace("\n", ""), BackColor, ForeColor));
                    }
                    lines.Add(WriteWord(" ", BackColor, ForeColor));

                    foreach (string l in SafeSplit(me.GetTexts()["Troubleshooting text"]))
                    {
                        if (l.Replace("\r", "\n").Replace("\n", "") == "") { lines.Add(WriteWord(" ", BackColor, ForeColor)); continue; }
                        lines.Add(WriteWord(l.Replace("\r", "\n").Replace("\n", ""), BackColor, ForeColor));
                    }
                    lines.Add(WriteWord(" ", BackColor, ForeColor));

                    foreach (string l in SafeSplit(me.GetTexts()["Additional troubleshooting information"]))
                    {
                        if (l.Replace("\r", "\n").Replace("\n", "") == "") { lines.Add(WriteWord(" ", BackColor, ForeColor)); continue; }
                        lines.Add(WriteWord(l.Replace("\r", "\n").Replace("\n", ""), BackColor, ForeColor));
                    }
                }
                else
                {
                    IDictionary<string, string> txt = me.GetTexts();
                    blinkyThing.BackColor = me.GetTheme(false);
                    if (!blink) { blinkyThing.Visible = false; }
                    if (me.GetBool("threepointone") && me.GetBool("bootscreen"))
                    {
                        Program.load_progress = 1;
                        Program.load_message = "Processing bootscreen";
                        lines.AddRange(CreateBitmaps(txt["Bootscreen"] + "\n"));
                    }
                    if (!me.GetBool("bootscreen") && me.GetBool("threepointone"))
                    {
                        lines.Add(WriteWord(" ", BackColor, ForeColor));
                    }
                    Program.load_progress = 2;
                    Program.load_message = "Processing error code";
                    lines.AddRange(CreateBitmaps(txt["Error code formatting"].Replace("{0}", error.Split(' ')[1].Replace(")", "").Replace("(", "").Replace(" ", "").ToString()).Replace("{1}", me.GenAddress(4, 8, false).Replace(", ", ",")).Trim()));
                    if (whatfail == "")
                    {
                        lines.AddRange(CreateBitmaps(error.Split(' ')[0].ToString()));
                    } else
                    {
                        lines.AddRange(CreateBitmaps(error.Split(' ')[0].ToString() + "*** Address " + me.GenHex(8, "RRRRRRRR").ToLower() + " has base at " + me.GenHex(8, "RRRRRRRR").ToLower() + " - " + whatfail.ToLower()));
                    }
                    Program.load_progress = 10;

                    if (stacktrace)
                    {
                        // hell is loose here
                        if (!me.GetBool("threepointone"))
                        {
                            Program.load_message = "Processing CPUID";
                            lines.AddRange(CreateBitmaps("\n" + string.Format(txt["CPUID formatting"], processortype).Trim()));
                        }
                        Program.load_message = "Processing stack trace heading";
                        bool hasStHeader = false;
                        bool hasDwHeader = false;
                        foreach (KeyValuePair<string, string[]> file in me.GetFiles())
                        {
                            if (file.Value.Length == 2)
                            {
                                hasStHeader = true;
                            }
                            if (file.Value.Length == (me.GetBool("threepointone") ? 7 : 6))
                            {
                                hasDwHeader = true;
                            }
                        }
                        if (hasStHeader)
                        {
                            lines.AddRange(CreateBitmaps("\n" + txt["Stack trace heading"].Trim().PadRight(40, ' ') + txt["Stack trace heading"].Trim()));
                        }

                        Program.load_progress += 5;
                        for (int i = 0; i < me.GetFiles().Count; i+=2)
                        {
                            Program.load_message = "Processing table (file " + (i + 1).ToString() + ")";

                            if (me.GetFiles().Count < i)
                            {
                                break;
                            }
                            if (me.GetFiles()[i].Value.Length == 6)
                            {
                                continue;
                            }
                            string file1 = me.GetFiles()[i].Key;
                            string rnd1_1 = me.GenHex(8, me.GetFiles()[i].Value[0]).ToLower();
                            string rnd1_2 = me.GenHex(8, me.GetFiles()[i].Value[1]).ToLower();
                            string file2 = "";
                            string rnd2_1 = "";
                            string rnd2_2 = "";
                            string fullrow = string.Format(txt["Stack trace table formatting"].Trim(), rnd1_1, rnd1_2, file1).PadRight(40);
                            if (me.GetFiles().Count > i+1)
                            {
                                file2 = me.GetFiles()[i+1].Key;
                                rnd2_1 = me.GenHex(8, me.GetFiles()[i+1].Value[0]).ToLower();
                                rnd2_2 = me.GenHex(8, me.GetFiles()[i+1].Value[1]).ToLower();
                                fullrow += string.Format(txt["Stack trace table formatting"].Trim(), rnd2_1, rnd2_2, file2);
                            }
                            lines.AddRange(CreateBitmaps(fullrow));
                            Program.load_progress += 1;
                        }
                        Program.load_message = "Processing memory address dump heading";
                        if (hasDwHeader)
                        {
                            lines.AddRange(CreateBitmaps("\n" + txt["Memory address dump heading"]));
                        }
                        Program.load_progress = !me.GetBool("threepointone") ? 90 : 80;
                        int r = 1;
                        foreach (KeyValuePair<string, string[]> kvp in me.GetFiles())
                        {
                            if ((kvp.Value.Length != 6) && (kvp.Value.Length != 7))
                            {
                                continue;
                            }
                            Program.load_message = "Processing table (row " + r.ToString() + ")";
                            string file = kvp.Key;
                            string r1 = me.GenHex(8, kvp.Value[0]).ToLower();
                            string r2 = me.GenHex(8, kvp.Value[1]).ToLower();
                            string r3 = me.GenHex(8, kvp.Value[2]).ToLower();
                            string r4 = me.GenHex(8, kvp.Value[3]).ToLower();
                            string r5 = me.GenHex(8, kvp.Value[4]).ToLower();
                            string r6 = me.GenHex(8, kvp.Value[5]).ToLower();
                            string r7 = "";
                            string fullrow = "";
                            if (me.GetBool("threepointone"))
                            {
                                r7 = me.GenHex(8, kvp.Value[6]).ToLower();
                                fullrow = string.Format(txt["Memory address dump table"], r1, r2, r3, r4, r5, r6, r7, file);
                            } else
                            {
                                fullrow = string.Format(txt["Memory address dump table"], r1, r2, r3, r4, r5, r6, file);
                            }
                            lines.AddRange(CreateBitmaps(fullrow));
                            Program.load_progress += !me.GetBool("threepointone") ? 6 : 1;
                            r++;
                        }
                    }
                    string fulltext = !me.GetBool("threepointone") ? "\n" : "";
                    if (me.GetBool("troubleshoot"))
                    {
                        fulltext += txt["Troubleshooting text"];
                    }
                    lines.AddRange(CreateBitmaps(fulltext));
                }
                int z = 1;
                foreach (Bitmap line in lines)
                {
                    if (z < 50)
                    {
                        ((PictureBox)tableLayoutPanel1.Controls[string.Format("pictureBox{0}", z)]).Image = line;
                    }
                    z++;
                }
                if (!fullscreen) { FormBorderStyle = FormBorderStyle.FixedSingle; ShowInTaskbar = true; ShowIcon = true; }
                int[] colors = { BackColor.R + 50, BackColor.G + 50, BackColor.B + 50 };
                if (colors[0] > 255) { colors[0] -= 255; }
                if (colors[1] > 255) { colors[1] -= 255; }
                if (colors[2] > 255) { colors[2] -= 255; }
                waterMarkText.ForeColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                Program.loadfinished = true;

                if (fullscreen && (Opacity != 0.0))
                {
                    Program.dr.Init(this);
                }
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                screenUpdater.Enabled = false;
                Hide();
                if (Program.gs.EnableEggs && !Program.gs.DevBuild) { me.Crash(ex, "OrangeScreen"); }
                else { MessageBox.Show("The crash screen cannot be displayed due to an error.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                Close();
            }
        }

        private List<Bitmap> CreateBitmaps(string content)
        {
            List<Bitmap> lines = new List<Bitmap>();
            foreach (string l in SafeSplit(content))
            {
                if (l.Replace("\r", "\n").Replace("\n", "") == "") { lines.Add(WriteWord(" ", BackColor, ForeColor)); continue; }
                lines.Add(WriteWord(l.Replace("\r", "\n").Replace("\n", ""), BackColor, ForeColor));
            }
            return lines;
        }

        /// <summary>
        /// Splits the line to separate lines to make sure it's using 80 columns
        /// </summary>
        /// <param name="line">Line to split</param>
        /// <returns>Splitted line</returns>
        private string SplitLine80(string line)
        {
            if (line.Length > 80)
            {
                return line.Substring(0, 80) + "\n" + SplitLine80(line.Substring(80));
            }
            return line;
        }

        /// <summary>
        /// Splits the text by lines while making sure each line has a maximum of 80 columns
        /// </summary>
        /// <param name="lines">Text to split into lines</param>
        /// <returns>Array of lines</returns>
        private string[] SafeSplit(string lines)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string line in lines.Split('\n'))
            {
                stringBuilder.AppendLine(SplitLine80(line).Replace("\r\n", "\n"));
            }
            return stringBuilder.ToString().Substring(0, stringBuilder.ToString().Length - 1).Split('\n');
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 0.0) { return; }
            if (screenUpdater.Interval != me.GetInt("blink_speed")) { screenUpdater.Interval = me.GetInt("blink_speed"); }
            if (fullscreen)
            {
                foreach (WindowScreen ws in Program.dr.wss)
                {
                    if (ws.Visible == false)
                    {
                        naturalclose = true;
                        Close();
                    }
                    try
                    {
                        Color? clr = null;
                        if (me.GetBool("blink"))
                        {
                            clr = me.GetTheme(false);
                        }
                        Program.dr.Draw(ws, clr);
                    }
                    catch
                    {
                        naturalclose = true;
                        Close();
                    }
                }
                BringToFront();
                Activate();
            }
            if (blink && me.GetString("os").Equals("Windows NT 3.x/4.0"))
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

        private void W2kbs_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!fullscreen)
            {
                if (Program.gs.PM_CloseMainUI)
                {
                    Application.Exit();
                }
            }
        }

        private void RainBowScreen_Tick(object sender, EventArgs e)
        {
            int r = BackColor.R;
            int gr = BackColor.G;
            int b = BackColor.B;
            if (state == "1")
            {
                if (inr == false)
                {
                    gr += 1;
                    if (gr == 255)
                    {
                        inr = true;
                        b += 1;
                        r -= 1;
                        state = "2";
                    }
                }
            }
            else if (state == "3")
            {
                r += 1;
                if (r > 255)
                {
                    r = 255;
                }
                if (ing == true)
                {
                    gr -= 1;
                    if (gr == 0)
                    {
                        ing = false;
                    }
                }
                if ((r == 255) && (gr == 0))
                {
                    inb = true;
                    state = "4";
                }
            }
            else if (state == "2")
            {
                b += 1;
                if (b > 255)
                {
                    b = 255;
                }
                if (inr == true)
                {
                    r -= 1;
                    if (r == 0)
                    {
                        inr = false;
                    }
                }
                if ((r == 0) && (b == 255))
                {
                    ing = true;
                    r = 1;
                    state = "3";
                }
            }
            else if (state == "4")
            {
                state = "4";
                if (inb == true)
                {
                    b -= 1;
                    if (b == 0)
                    {
                        state = "0";
                        inb = false;
                    }
                }
            }
            else if ((r == 255) && (gr == 0) && (b == 0))
            {
                state = "1";
                gr += 1;
            }
            BackColor = Color.FromArgb(r, gr, b);
            foreach (Control c in Controls)
            {
                int[] colorsa = { BackColor.R - 100, BackColor.G - 100, BackColor.B - 100 };
                if (colorsa[0] < 0) { colorsa[0] += 255; }
                if (colorsa[1] < 0) { colorsa[1] += 255; }
                if (colorsa[2] < 0) { colorsa[2] += 255; }
                c.ForeColor = Color.FromArgb(colorsa[0], colorsa[1], colorsa[2]);
            }
            int[] colors = { BackColor.R + 20, BackColor.G + 20, BackColor.B + 20 };
            if (colors[0] > 255) { colors[0] -= 255; }
            if (colors[1] > 255) { colors[1] -= 255; }
            if (colors[2] > 255) { colors[2] -= 255; }
            waterMarkText.ForeColor = Color.FromArgb(colors[0], colors[1], colors[2]);
            Program.dr.DrawAll();
        }

        private void W2kbs_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F7))
            {
                Program.dr.Dispose();
                Close();
            }
            else if ((e.KeyCode == Keys.F2) && me.GetBool("windowed"))
            {
                string output = Program.dr.Screenshot(this);
                Cursor.Show();
                MessageBox.Show($"Image saved as {output}", "Screenshot taken", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void W2kbs_MouseMove(object sender, MouseEventArgs e)
        {
            moves++;
            if (moves > 50 && Program.isScreensaver && Program.gs.MouseMoveExit)
            {
                Close();
            }
        }
    }
}

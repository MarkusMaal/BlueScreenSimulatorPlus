using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class Old_bluescreen : Form
    {
        public string errorCode = "0E : 016F : BFF9B3D4";
        public bool window = false;
        public string screenmode = "System error";
        internal BlueScreen me = Program.templates.GetAt(0);
        IDictionary<string, string> titles;
        IDictionary<string, string> texts;
        Color bg;
        Color fg;
        Color hlb;
        Color hlf;
        readonly string[] letters = { "?", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ":", ",", ".", "+", "*", "!", "_" , "-", "(", ")", "/", "\\", "'", " " };
        public Old_bluescreen()
        {
            if (Program.verificate)
            {
                InitializeComponent();
            }
        }

        private void Old_bluescreen_Load(object sender, EventArgs e)
        {
            try
            {
                if (Program.TestDicts(letters, me))
                {
                    screenUpdater.Enabled = false;
                    this.Close();
                    return;
                }
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
                string formatted_text;
                switch (screenmode)
                {
                    case "System error":
                    case "System error (Windows Me beta)":
                        WriteTitle(titles["Main"]);
                        formatted_text = string.Format(texts[screenmode], errorCode);
                        WriteText(formatted_text);
                        break;
                    case "Application error (Windows 95 beta)":
                    case "Application error":
                        WriteTitle(titles["Main"]);
                        formatted_text = string.Format(texts[screenmode],
                            errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString(),
                            errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString(),
                            me.GenHex(2, me.GetString("ecode1"))
                        );
                        WriteText(formatted_text);
                        break;
                    case "Driver error":
                        WriteTitle(titles["Main"]);
                        formatted_text = string.Format(texts["Driver error"],
                            errorCode.ToString().Split(':')[1].ToString().Replace(" ", "").ToString(),
                            errorCode.ToString().Split(':')[2].ToString().Replace(" ", "").ToString(),
                            me.GenHex(2, me.GetString("ecode1"))
                        );
                        WriteText(formatted_text);
                        break;
                    case "System is unresponsive (Warning)":
                        WriteTitle(titles["Warning"]);
                        WriteText(texts["System is unresponsive"]);
                        break;
                    case "System is busy":
                        WriteTitle(titles["System is busy"]);
                        WriteText(texts["System is busy"]);
                        break;
                    case "No unresponsive programs":
                        WriteTitle(titles["Main"]);
                        WriteText(texts["No unresponsive programs"]);
                        break;
                    case "Unsafe eject":
                        WriteTitle(titles["Main"]);
                        WriteText(texts["Unsafe eject"]);
                        break;
                    case "Recoverable application error":
                        WriteTitle(titles["Main"]);
                        formatted_text = string.Format(texts["Recoverable application error"],
                            me.GenHex(2, me.GetString("ecode1")),
                            me.GenHex(4, me.GetString("ecode2")),
                            me.GenHex(8, me.GetString("ecode3")),
                            me.GenHex(8, me.GetString("ecode4")),
                            me.GenHex(4, me.GetString("ecode2")),
                            me.GenHex(8, me.GetString("ecode4")),
                            me.GenHex(8, me.GetString("ecode4"))) + " ";
                        WriteText(formatted_text);
                        break;
                    default:
                        WriteTitle(titles["Main"]);
                        WriteText(texts[screenmode] + " ");
                        break;
                    
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
                    Program.dr.Init(this);
                }
                else
                {
                    //this.Size = new Size(640, 320);
                }
                int[] colors = { this.BackColor.R + 50, this.BackColor.R + 50, this.BackColor.B + 50 };
                if (colors[0] > 255) { colors[0] -= 255; }
                if (colors[1] > 255) { colors[1] -= 255; }
                if (colors[2] > 255) { colors[2] -= 255; }
                waterMarkText.ForeColor = Color.FromArgb(colors[0], colors[1], colors[2]);
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                screenUpdater.Enabled = false;
                this.Hide();
                if (Program.gs.EnableEggs) { me.Crash(ex, "OrangeScreen"); }
                else { MessageBox.Show("The blue screen cannot be displayed due to an error.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                this.Close();
            }
        }

        private void WriteTitle(string title)
        {
            titleText.Image = WriteWord(title, hlb, hlf);
            titleText.Size = new Size(8 * title.Length, titleText.Height);
            titleBorder.Size = new Size(titleText.Width + 20, titleBorder.Height);
            titleBorder.Location = new Point((this.Width / 2) - (titleBorder.Width / 2) - 8, titleBorder.Location.Y);
            titleText.Location = new Point(10, 2);
        }

        private void WriteText(string text)
        {
            string[] lines = text.Split('\n');
            if ((lines.Length > 13) && (13 - lines.Length > 0))
            {
                lines = lines.Skip(13 - lines.Length).ToArray();
            }
            int i = 1;
            foreach (string line in lines)
            {
                if (i > 13)
                {
                    break;
                }
                try { ((PictureBox)simplePanel.Controls[$"line{i}"]).Image = WriteWord(line.Substring(0, line.Length - 1), bg, fg); } catch { }
                i++;
            }
            MoveControls(--i);
        }

        private void MoveControls(int linecount)
        {
            anyKeyMsg.Location = new Point(anyKeyMsg.Location.X, simplePanel.Controls[$"line{linecount}"].Location.Y + 40);
            blinkingColor.Location = new Point(blinkingColor.Location.X, anyKeyMsg.Location.Y + anyKeyMsg.Height - blinkingColor.Height);
            simplePanel.Location = new Point(simplePanel.Location.X, simplePanel.Location.Y + ((13 - linecount) * 15) / 2);
            for (int i = linecount + 1; i <= 13; i++)
            {
                simplePanel.Controls[$"line{i}"].Visible = false;
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
                Program.dr.DrawAll();
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
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F7))
            {
                Program.dr.Dispose();
                this.Close();
            }
            else if ((e.KeyCode == Keys.F2) && me.GetBool("windowed"))
            {
                string output = Program.dr.Screenshot(this);
                Cursor.Show();
                MessageBox.Show($"Image saved as {output}", "Screenshot taken", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                e.Cancel = Program.gs.PM_Lockout;
            }
            else
            {
                e.Cancel = false;
            }
            if (!window)
            {
                Program.dr.Dispose();
            }
        }

        private void Old_bluescreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (window)
            {
                if (Program.gs.PM_CloseMainUI)
                {
                    Application.Exit();
                }
            }
        }
    }
}

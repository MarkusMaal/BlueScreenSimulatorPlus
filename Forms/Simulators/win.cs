using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class Win : Form
    {
        public bool window = false;
        internal BlueScreen me = Program.templates.GetAt(0);
        private ThreadStart t;
        private Thread secondThread;
        private readonly List<Bitmap> image = new List<Bitmap>();
        private bool locked = true;
        private bool displaying = false;
        internal Random r;
        private readonly SoundPlayer sp = new SoundPlayer();
        private Bitmap splash = Properties.Resources.win1_splash;
        private int moves = 0;
        private Point initialCursorPosition;
        public Win()
        {
            //
            // forcibly disable DPI scaling for these legacy configurations
            // otherwise, the character set will be rendered incorrectly
            //
            // to upscale on higher DPI settings, use fullscreen mode
            //
            //Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            InitializeComponent();
        }

        private void WriteWord()
        {
            while (true)
            {
                while (displaying)
                {
                    Thread.Sleep(2);
                }
                Color bg = me.GetTheme(true); Color fg = me.GetTheme(false);
                if (Program.gs.EnableEggs && (BackColor == ForeColor))
                {
                    bg = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                    fg = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                }
                Bitmap bmpres = GetSymbol(bg, fg);
                for (int i = 0; i < r.Next(20, 77); i++)
                {
                    Bitmap two = GetSymbol(bg, fg);
                    bmpres = Merge(bmpres, two);
                }
                image.Add(bmpres);
                //bmpres.Dispose();
                locked = false;
                displaying = true;
            }
        }
        private Bitmap GetSymbol(Color bg, Color fg)
        {
            int index = r.Next(0, 255);
            Rectangle cropRect = new Rectangle(index * 8, 0, 8, 12);
            try
            {
                Bitmap src = Properties.Resources.doscii as Bitmap;
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
                    {
                        img.SetPixel(i, j, white);
                    }
                }
            }
            return img;
        }

        public Bitmap CreateNonIndexedImage(Image src)
        {
            Bitmap newBmp = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics gfx = Graphics.FromImage(newBmp))
            {
                gfx.PageUnit = GraphicsUnit.Pixel;
                gfx.DrawImage(src, 0, 0, src.Width, src.Height);
            }
            src.Dispose();
            return newBmp;
        }
        private void Win_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = me.GetIcon();
                Text = me.GetString("friendlyname");
                if (me.GetBool("halfres"))
                {
                    Height = (int)(Height / 2);
                    for (int i = 1; i <= 9; i++)
                    {
                        tableLayoutPanel1.Controls[$"pictureBox{i}"].Visible = false;
                    }
                }
                Program.load_progress = 101;
                watermark.Visible = me.GetBool("watermark");
                if (me.GetString("qr_file") != "local:null")
                {
                    switch (me.GetString("qr_file"))
                    {
                        case "local:0":
                            splash = Properties.Resources.win1_splash;
                            break;
                        case "local:1":
                            splash = Properties.Resources.win2_splash;
                            break;
                        default:
                            splash = (Bitmap)Image.FromFile(me.GetString("qr_file"));
                            break;
                    }

                    if (Program.gs.EnableEggs && (BackColor == ForeColor))
                    {
                        Color bg = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                        Color fg = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                        splash = Changecolor(fg, Changecolor(bg, CreateNonIndexedImage(splash), Color.FromArgb(19, 19, 19)), Color.FromArgb(255, 255, 255));
                    } else
                    {
                        splash = Changecolor(me.GetTheme(false), Changecolor(me.GetTheme(true), CreateNonIndexedImage(splash), Color.FromArgb(19, 19, 19)), Color.FromArgb(255, 255, 255));
                    }
                    // forces the bitmap to be resized to window dimensions
                    if (!me.GetBool("halfres"))
                    {
                        splash = new Bitmap(splash, Width, Height);
                    } else
                    {
                        splash = new Bitmap(splash, Width, Height / 2);
                    }
                    int z = 1;
                    for (int y = 0; y < 224; y += 12)
                    {
                        int wdth = splash.Width;
                        int hght = 12;
                        Bitmap bmp = new Bitmap(wdth, hght);

                        Rectangle cropRect = new Rectangle(0, y, wdth, hght);
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.DrawImage(splash, new Rectangle(0, 0, Width, bmp.Height), cropRect, GraphicsUnit.Pixel);
                        }
                        ((PictureBox)tableLayoutPanel1.Controls["pictureBox" + z.ToString()]).Image = bmp;
                        z++;
                    }
                }
                if (me.GetBool("playsound") && (Opacity != 0.0))
                {
                    sp.Stream = Properties.Resources.beep;
                    sp.PlayLooping();
                }
                int[] colors = { BackColor.R + 50, BackColor.G + 50, BackColor.B + 50 };
                if (colors[0] > 255) { colors[0] -= 255; }
                if (colors[1] > 255) { colors[1] -= 255; }
                if (colors[2] > 255) { colors[2] -= 255; }
                watermark.ForeColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                Program.loadfinished = true;
                if (!me.GetBool("windowed") && (Opacity != 0.0))
                {
                    FormBorderStyle = FormBorderStyle.None;
                    TopMost = false;
                    Program.dr.Init(this);
                }
                else
                {
                    //this.Size = new Size(640, 320);
                }
                t = new ThreadStart(WriteWord);
                secondThread = new Thread(t);
                secondThread.Start();
                initialCursorPosition = Cursor.Position;
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                screenUpdater.Enabled = false;
                Hide();
                if (Program.gs.EnableEggs) { me.Crash(ex, "OrangeScreen"); }
                else { MessageBox.Show("The crash screen cannot be displayed due to an error.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                Close();
            }
            Program.load_progress = 100;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 0.0)
            {
                return;
            }

            if (screenUpdater.Interval != me.GetInt("blink_speed")) { screenUpdater.Interval = me.GetInt("blink_speed"); }
            if (!window && (Opacity != 0.0))
            {
                foreach (WindowScreen ws in Program.dr.wss)
                {
                    if (ws.Visible == false)
                    {
                        Close();
                    }
                    try
                    {
                        if (!ws.primary && Program.gs.DisplayMode == "blank")
                        {
                            continue;
                        }
                        Program.dr.Draw(ws, me.GetBool("watermark"));
                    }
                    catch
                    {
                        Close();
                    }
                }
                BringToFront();
                Activate();
            }
            if (!locked)
            {
                foreach (Image img in image)
                {
                    if ((img != null) || (pictureBox19 != null))
                    {
                        if (pictureBox19.Image.Width + img.Width > pictureBox19.Width)
                        {
                            try
                            {
                                Bitmap partone = new Bitmap(pictureBox19.Width - img.Width, img.Height);
                                Graphics g;
                                g = Graphics.FromImage(partone);
                                g.DrawImage(img, 0, 0);
                                Bitmap bmp = new Bitmap(pictureBox19.Width, pictureBox19.Image.Height);
                                g = Graphics.FromImage(bmp);
                                g.DrawImage(pictureBox19.Image, 0, 0);
                                g.DrawImage(partone, new Point(pictureBox19.Image.Width + 1, 0));
                                pictureBox19.Image = bmp;
                                pictureBox1.Image?.Dispose();
                                for (int i = 1; i < 19; i++)
                                {
                                    try
                                    {
                                        ((PictureBox)tableLayoutPanel1.Controls["pictureBox" + i.ToString()]).Image = ((PictureBox)tableLayoutPanel1.Controls["pictureBox" + (i + 1).ToString()]).Image;
                                    }
                                    catch
                                    {

                                    }
                                }
                                pictureBox19.Image = Properties.Resources.dummy;
                                partone.Dispose();
                            }
                            catch
                            {

                            }
                            img.Dispose();
                        }
                        else
                        {
                            Bitmap bmp = new Bitmap(pictureBox19.Image.Width + img.Width, pictureBox19.Image.Height);
                            Graphics g = Graphics.FromImage(bmp);
                            g.DrawImage(pictureBox19.Image, 0, 0);
                            g.DrawImage(img, new Point(pictureBox19.Image.Width + 1, 0));
                            pictureBox19.Image = bmp;
                            img.Dispose();
                        }
                    }
                }
                image.Clear();
                displaying = false;
                locked = true;
            }
            if (Program.isScreensaver && Program.gs.MouseMoveExit && (Cursor.Position.X != initialCursorPosition.X) && (Cursor.Position.Y != initialCursorPosition.Y))
            {
                Close();
            }
        }

        private void Win_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                foreach (Control c in tableLayoutPanel1.Controls)
                {
                    c.Dispose();
                }
                Dispose();
                if (Program.gs.PM_CloseMainUI)
                {
                    Application.Exit();
                }
            }
            catch
            {
                Console.WriteLine("Warning: \"Win\" forcibly closed from external source!!!");
            }
        }

        private void Win_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                screenUpdater.Enabled = false;
                if (Program.F1 != null)
                {
                    secondThread?.Abort();
                    Program.dr.Dispose();
                    foreach (Image img in image)
                    {
                        img.Dispose();
                    }
                    splash.Dispose();

                    if (me.GetBool("playsound"))
                    {
                        sp.Stop();
                        sp.Dispose();
                    }
                    try
                    {
                        Dispose();
                    } catch { }
                }
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                MessageBox.Show("An error has occoured.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
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

        private void Win_MouseMove(object sender, MouseEventArgs e)
        {
            moves++;
            if (moves > 50 && Program.isScreensaver && Program.gs.MouseMoveExit)
            {
                Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class Win : Form
    {
        public bool window = false;
        internal BlueScreen me = Program.bluescreens[0];
        readonly List<WindowScreen> wss = new List<WindowScreen>();
        readonly List<Bitmap> freezescreens = new List<Bitmap>();
        ThreadStart t;
        Thread secondThread;
        readonly List<Bitmap> image = new List<Bitmap>();
        bool locked = true;
        bool displaying = false;
        readonly Random r = new Random();
        readonly SoundPlayer sp = new SoundPlayer();
        Bitmap splash = Properties.Resources.win1_splash;
        public Win()
        {
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
                if (this.BackColor == this.ForeColor)
                {
                    bg = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                    fg = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                }
                Bitmap bmpres = GetSymbol(bg, fg);
                for (int i = 0; i < new Random().Next(20, 77); i++)
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
                        img.SetPixel(i, j, white);
                }
            }
            return img;
        }

        public Bitmap CreateNonIndexedImage(Image src)
        {
            Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics gfx = Graphics.FromImage(newBmp))
            {
                gfx.DrawImage(src, 0, 0);
            }
            src.Dispose();
            return newBmp;
        }
        private void Win_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = me.GetIcon();
                this.Text = me.GetString("friendlyname");
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

                    if (this.BackColor == this.ForeColor)
                    {
                        Color bg = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                        Color fg = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                        splash = Changecolor(fg, Changecolor(bg, CreateNonIndexedImage(splash), Color.FromArgb(19, 19, 19)), Color.FromArgb(255, 255, 255));
                    } else
                    {
                        splash = Changecolor(me.GetTheme(false), Changecolor(me.GetTheme(true), CreateNonIndexedImage(splash), Color.FromArgb(19, 19, 19)), Color.FromArgb(255, 255, 255));
                    }
                    int z = 1;
                    for (int y = 0; y < 224; y += 12)
                    {
                        Bitmap bmp = new Bitmap(pictureBox1.Width, 12);

                        Rectangle cropRect = new Rectangle(0, y, pictureBox1.Width, 12);
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.DrawImage(splash, new Rectangle(0, 0, bmp.Width, bmp.Height), cropRect, GraphicsUnit.Pixel);
                        }
                        ((PictureBox)tableLayoutPanel1.Controls["pictureBox" + z.ToString()]).Image = bmp;
                        z++;
                    }
                }
                if (me.GetBool("playsound"))
                {
                    sp.Stream = Properties.Resources.beep;
                    sp.PlayLooping();
                }
                int[] colors = { this.BackColor.R + 50, this.BackColor.G + 50, this.BackColor.B + 50 };
                if (colors[0] > 255) { colors[0] -= 255; }
                if (colors[1] > 255) { colors[1] -= 255; }
                if (colors[2] > 255) { colors[2] -= 255; }
                watermark.ForeColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                Program.loadfinished = true;
                if (!me.GetBool("windowed"))
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
                    //this.Size = new Size(640, 320);
                }
                t = new ThreadStart(WriteWord);
                secondThread = new Thread(t);
                secondThread.Start();
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                screenUpdater.Enabled = false;
                this.Hide();
                if (Program.f1.enableeggs) { me.Crash(ex.Message, ex.StackTrace, "OrangeScreen"); }
                else { MessageBox.Show("The blue screen cannot be displayed due to an error.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                this.Close();
            }
            Program.load_progress = 100;
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
            if (!locked)
            {
                foreach (Image img in image)
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
                            if (pictureBox1.Image != null)
                            {
                                pictureBox1.Image.Dispose();
                            }
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
                        } catch
                        {

                        }
                        img.Dispose();
                    } else
                    {
                        Bitmap bmp = new Bitmap(pictureBox19.Image.Width + img.Width, pictureBox19.Image.Height);
                        Graphics g = Graphics.FromImage(bmp);
                        g.DrawImage(pictureBox19.Image, 0, 0);
                        g.DrawImage(img, new Point(pictureBox19.Image.Width + 1, 0));
                        pictureBox19.Image = bmp;
                        img.Dispose();
                    }
                }
                image.Clear();
                displaying = false;
                locked = true;
            }
        }

        private void Win_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                c.Dispose();
            }
            this.Dispose();
        }

        private void Win_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (secondThread != null)
                {
                    secondThread.Abort();
                }
                foreach (WindowScreen ws in wss)
                {
                    ws.Close();
                }
                foreach (Image img in freezescreens)
                {
                    img.Dispose();
                }
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
                this.Dispose();
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                MessageBox.Show("An error has occoured.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}

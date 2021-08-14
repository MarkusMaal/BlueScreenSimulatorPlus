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
    public partial class cebsod : Form
    {
        public bool fullscreen = true;
        private int progress = 30;
        bool inr = false;
        bool ing = false;
        bool inb = false;
        internal BlueScreen me = Program.bluescreens[0];
        List<WindowScreen> wss = new List<WindowScreen>();
        List<Bitmap> freezescreens = new List<Bitmap>();

        string state = "0";
        public cebsod()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (fullscreen)
            {
                foreach (WindowScreen ws in wss) { 
                    if (ws.Visible == false)
                    {
                        this.Close();
                    }
                    try
                    {
                        if (ws.primary || Program.multidisplaymode == "mirror") 
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
                    }
                    catch
                    {
                        this.Close();
                    }
                }
            }
            if (progress == 0) { this.Close(); }
            timeOut.Text = timeOut.Text.Replace(progress.ToString(), (progress - 1).ToString());
            progress--;
        }

        private void Cebsod_Load(object sender, EventArgs e)
        {
            if (Program.f1.enableeggs)
            {
                if (Program.bluescreens[2].GetTheme(true) == Program.bluescreens[2].GetTheme(false))
                {
                    this.BackColor = Color.FromArgb(255, 0, 0);
                    rainBowScreen.Enabled = true;
                }
            }
            try { progress = me.GetInt("timer"); }catch { progress = 30; }
            timeOut.Text = me.GetTexts()["Restart message"].Replace("{0}", progress.ToString());
            string[] codez = technicalCode.Text.Replace("*** STOP: ", "").Replace(" (", "-").Replace(")", "").Split('-');
            technicalCode.Text = me.GetTexts()["Technical information formatting"].Replace("{0}", codez[0].ToString()).Replace("{1}", codez[1]).ToString();
            label2.Text = me.GetTexts()["Technical information"];
            label1.Text = me.GetTexts()["A problem has occurred..."] + "\n" + me.GetTexts()["CTRL+ALT+DEL message"];
            foreach (Control c in this.Controls)
            {
                if (c is Label)
                {
                    if (c.Name != "waterMarkText")
                    { 
                        c.Font = me.GetFont();
                    }
                }
            }
            if (!fullscreen) { this.FormBorderStyle = FormBorderStyle.FixedSingle; }
            if (fullscreen)
            {
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
                            ws.pictureBox1.Image = freezescreens[i - 1];
                        }
                    }
                }
                try
                {
                    foreach (WindowScreen ws in wss) { 
                        var frm = Form.ActiveForm;
                        if (ws.primary || Program.multidisplaymode == "mirror") { 
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
                    }
                }
                catch
                {
                }
            }
        }

        private void Cebsod_FormClosing(object sender, FormClosingEventArgs e)
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
                foreach (WindowScreen ws in wss)
                {
                    if (ws.Visible) { ws.Close(); }
                    ws.Dispose();
                }
                foreach (Bitmap bmp in freezescreens)
                {
                    bmp.Dispose();
                }
            }
        }

        private void Cebsod_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!fullscreen)
            { 
                if (Program.f1.closecuzhidden == true)
                {
                    Program.f1.Close();
                }
            }
        }

        private void RainBowScreen_Tick(object sender, EventArgs e)
        {

            int r = this.BackColor.R;
            int gr = this.BackColor.G;
            int b = this.BackColor.B;
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
            this.BackColor = Color.FromArgb(r, gr, b);
            try
            {
                foreach (WindowScreen ws in wss) {
                    if (ws.primary || Program.multidisplaymode == "mirror")
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
                }
            }
            catch
            {
                this.Close();
            }
        }
    }
}

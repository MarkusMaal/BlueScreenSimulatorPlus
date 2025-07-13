using System;
using System.Drawing;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class Cebsod : Form
    {
        public bool fullscreen = true;
        private int progress = 30;
        private bool inr = false;
        private bool ing = false;
        private bool inb = false;
        internal BlueScreen me = Program.templates.GetAt(0);

        private string state = "0";
        private int moves = 0;
        private Point initialCursorPosition;

        public Cebsod()
        {
            InitializeComponent();
        }

        private void TimeoutProgression(object sender, EventArgs e)
        {
            if (fullscreen)
            {
                Program.dr.DrawAll();
                BringToFront();
                Activate();
            }
            if (!Program.isScreensaver && (progress == 0)) { Close(); }
            timeOut.Text = timeOut.Text.Replace(progress.ToString(), (progress - 1).ToString());
            if (progress > 1)
            {
                progress--;
            }
            if (Program.isScreensaver && Program.gs.MouseMoveExit && (Cursor.Position.X != initialCursorPosition.X) && (Cursor.Position.Y != initialCursorPosition.Y))
            {
                Close();
            }
        }

        private void Initialize(object sender, EventArgs e)
        {
            try
            {
                Icon = me.GetIcon();
                Text = me.GetString("friendlyname");
                if (Program.gs.EnableEggs)
                {
                    if (BackColor == ForeColor)
                    {
                        BackColor = Color.FromArgb(255, 0, 0);
                        rainBowScreen.Enabled = true;
                    }
                }
                try { progress = me.GetInt("timer"); } catch { progress = 30; }
                timeOut.Text = me.GetTexts()["Restart message"].Replace("{0}", progress.ToString());
                string[] codez = technicalCode.Text.Replace("*** STOP: ", "").Replace(" (", "-").Replace(")", "").Split('-');
                technicalCode.Text = me.GetTexts()["Technical information formatting"].Replace("{0}", codez[0].ToString()).Replace("{1}", codez[1]).ToString();
                techinfoLabel.Text = me.GetTexts()["Technical information"];
                infoLabel.Text = me.GetTexts()["A problem has occurred..."] + "\n" + me.GetTexts()["CTRL+ALT+DEL message"];
                Font commonFont = new Font(me.GetFont().FontFamily, me.GetFont().Size * 96f / CreateGraphics().DpiX, me.GetFont().Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
                foreach (Control c in Controls)
                {
                    if (c is Label)
                    {
                        if (c.Name != "waterMarkText")
                        {
                            c.Font = commonFont;
                        }
                    }
                }
                if (me.GetBool("rainbow"))
                {
                    Program.dr.DrawRainbow(this);
                }
                Program.loadfinished = true;
                if (!fullscreen) { FormBorderStyle = FormBorderStyle.FixedSingle; }
                if (fullscreen && (Opacity != 0.0))
                {
                    TopMost = false;
                    Program.dr.Init(this);
                    Program.loadfinished = true;
                }
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
            int[] colors = { BackColor.R + 50, BackColor.G + 50, BackColor.B + 50 };
            if (colors[0] > 255) { colors[0] -= 255; }
            if (colors[1] > 255) { colors[1] -= 255; }
            if (colors[2] > 255) { colors[2] -= 255; }
            waterMarkText.ForeColor = Color.FromArgb(colors[0], colors[1], colors[2]);
        }

        private void Unload(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (progress > 0)
                {
                    e.Cancel = Program.gs.PM_Lockout;
                } else
                {
                    e.Cancel = false;
                }
            }
            else
            {
                e.Cancel = false;
            }
            if (!e.Cancel)
            {
                if (fullscreen)
                {
                    Program.dr.Dispose();
                }
                screenUpdater.Enabled = false;
            }
        }

        private void AfterUnload(object sender, FormClosedEventArgs e)
        {
            if (!fullscreen)
            { 
                if (Program.gs.PM_CloseMainUI)
                {
                    Application.Exit();
                }
            }
        }

        private void DoubleRainbow(object sender, EventArgs e)
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
            try
            {
                if (Opacity != 0.0)
                {
                    Program.dr.DrawAll();
                }
            }
            catch
            {
                Close();
            }
        }

        private void Cebsod_KeyDown(object sender, KeyEventArgs e)
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

        private void Cebsod_MouseMove(object sender, MouseEventArgs e)
        {
            moves++;
            if (moves > 50 && Program.isScreensaver && Program.gs.MouseMoveExit)
            {
                Close();
            }
        }
    }
}

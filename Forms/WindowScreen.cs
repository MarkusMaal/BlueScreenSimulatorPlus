using System;
using System.Drawing;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
{
    public partial class WindowScreen : Form
    {
        public Bitmap bmp;
        public bool primary = true;
        private int moves = 0;
        public WindowScreen()
        {
            if (Program.verificate)
            {
                InitializeComponent();
            }
        }

        private void WindowScreen_Load(object sender, EventArgs e)
        {
            if (!Program.gs.ShowCursor) { Cursor.Hide(); }
            if (primary) { Text += " (primary)"; }
            else { Text += " (secondary)"; }
        }

        internal void ShowCursor()
        {
            Cursor.Show();
        }

        private void WindowScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.gs.PM_Lockout) { Hide(); }
            // Prevent closing when Alt + F4 is pressed
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = Program.gs.PM_Lockout;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void WindowScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.gs.PM_CloseMainUI)
            {
                try
                {
                    Application.Exit();
                } catch { }
            }
            if ((screenDisplay != null) && (screenDisplay.Image != null))
            { 
                screenDisplay.Image.Dispose();
                screenDisplay.Dispose();
            }
            Dispose();
        }

        private void WindowScreen_MouseMove(object sender, MouseEventArgs e)
        {
            moves++;
            if (moves > 50 && Program.isScreensaver && Program.gs.MouseMoveExit)
            {
                Close();
            }
        }

        private void WindowScreen_MouseHover(object sender, EventArgs e)
        {
            moves++;
            if (moves > 50 && Program.isScreensaver && Program.gs.MouseMoveExit)
            {
                Close();
            }
        }
    }
}

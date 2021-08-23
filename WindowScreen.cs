using System;
using System.Drawing;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
{
    public partial class WindowScreen : Form
    {
        public Bitmap bmp;
        public bool primary = true;
        public WindowScreen()
        {
            InitializeComponent();
        }

        private void WindowScreen_Load(object sender, EventArgs e)
        {
            if (!Program.f1.showcursor) { Cursor.Hide(); }
            if (this.primary) { this.Text += " (primary)"; }
            else { this.Text += " (secondary)"; }
        }

        private void WindowScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.f1.lockout) { this.Hide(); }
            // Prevent closing when Alt + F4 is pressed
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!Program.f1.showcursor && !Program.f1.lockout)
                {
                    Cursor.Show();
                }
                e.Cancel = Program.f1.lockout;
            }
            else
            {
                if (!Program.f1.showcursor)
                {
                    Cursor.Show();
                }
                e.Cancel = false;
            }
        }

        private void WindowScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.f1.closecuzhidden == true)
            {
                Program.f1.Close();
            }
            if (Program.f1.showmsg == true)
            {
                MessageBox.Show(Program.f1.MsgBoxMessage, Program.f1.MsgBoxTitle, Program.f1.MsgBoxType, Program.f1.MsgBoxIcon);
                Program.f1.showmsg = false;
            }
            if ((screenDisplay != null) && (screenDisplay.Image != null))
            { 
                this.screenDisplay.Image.Dispose();
                this.screenDisplay.Dispose();
            }
            this.Dispose();
        }
    }
}

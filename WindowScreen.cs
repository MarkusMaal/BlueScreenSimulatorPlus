using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        }

        private void WindowScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            // Prevent closing when Alt + F4 is pressed
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = Program.f1.lockout;
            }
            else
            {
                e.Cancel = false;
            }
            if (!Program.f1.showcursor)
            {
                Cursor.Show();
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
            Program.f1.Show();
        }
    }
}

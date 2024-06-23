using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using System.Threading;

namespace UltimateBlueScreenSimulator
{
    public partial class Splash : Form
    {
        internal string[] args = { " " };
        public Splash()
        {
            Program.gs.Log("Info", "Initializing splash screen");
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            SplashText.Text = Program.load_message;
            if (Program.load_message == "Enabling visual styles")
            {
                Program.load_message = "Splash screen preview. Press ESC to exit.";
            }
        }

        private void Splash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            Program.gs.Log("Info", "Enabling visual styles");
            Application.EnableVisualStyles();
        }
    }
}

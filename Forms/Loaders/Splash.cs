using System;
using System.Windows.Forms;
using System.Drawing;

namespace UltimateBlueScreenSimulator
{
    public partial class Splash : Form
    {
        internal string[] args = { " " };
        private readonly Color[] colors = new Color[] { Color.FromArgb(255, 198, 0), Color.Blue, Color.Cyan, Color.OrangeRed, Color.Purple, Color.Green, Color.Indigo, Color.LightBlue, Color.LightGreen, Color.Lime, Color.Orange, Color.Pink, Color.Purple, Color.Red, Color.Teal, Color.Yellow };
        public Splash()
        {
            InitializeComponent();
        }

        public void UpdateMsg()
        {
            SplashText.Text = Program.load_message;
            appMarketedVersionLabel.ForeColor = colors[(int)Program.gs.ColorScheme];
        }

        private void Splash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
                FormBorderStyle = FormBorderStyle.None;
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            SplashText.Text = Program.load_message;
            //Program.gs.Log("Info", "Displaying splash screen");
            label2.Visible = Program.gs.DevBuild;
            if (!Program.gs.EnableEggs) {
                return;
            }
            if ((DateTime.Now.Month == 10) && (DateTime.Now.Day == 31))
            {
                splashEmoticon.Text = ":(";
            }
            if ((DateTime.Now.Month == 7) && (DateTime.Now.Day == 19))
            {
                label1.Text = "advanced crowstrike ssimulation technology";
            }
        }
    }
}

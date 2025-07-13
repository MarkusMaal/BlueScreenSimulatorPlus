using System;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
{
    public partial class SupportEditor : Form
    {
        public SupportEditor()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Program.gs.SupportText = textBox1.Text;
        }

        private void SupportEditor_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.gs.SupportText;
        }

        private void SupportEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}

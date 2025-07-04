using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace UltimateBlueScreenSimulator
{
    public partial class BTS : MaterialForm
    {
        public BTS()
        {
            MaterialSkinManager materialSkinManager = Program.f1.materialSkinManager;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
        }

        private void CloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeAllSizeMode()
        {
            switch (charSetB.SizeMode)
            {
                case PictureBoxSizeMode.Zoom:
                    charSetC.SizeMode = PictureBoxSizeMode.CenterImage;
                    charSetB.SizeMode = PictureBoxSizeMode.CenterImage;
                    charSetA.SizeMode = PictureBoxSizeMode.CenterImage;
                    break;
                case PictureBoxSizeMode.CenterImage:
                    charSetC.SizeMode = PictureBoxSizeMode.StretchImage;
                    charSetB.SizeMode = PictureBoxSizeMode.StretchImage;
                    charSetA.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case PictureBoxSizeMode.StretchImage:
                    charSetC.SizeMode = PictureBoxSizeMode.Zoom;
                    charSetB.SizeMode = PictureBoxSizeMode.Zoom;
                    charSetA.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
            }
        }

        private void ChangeSizeModeB(object sender, EventArgs e)
        {
            ChangeAllSizeMode();
        }

        private void ChangeSizeModeA(object sender, EventArgs e)
        {
            ChangeAllSizeMode();
        }

        private void ChangeSizeModeC(object sender, EventArgs e)
        {
            ChangeAllSizeMode();
        }

        private void BTS_Load(object sender, EventArgs e)
        {

        }

        private void BTS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}

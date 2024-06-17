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
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = Program.f2.darkMode.Checked ? MaterialSkinManager.Themes.DARK : MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo400, Primary.Indigo500,
                Primary.Indigo500, Accent.Orange400,
                TextShade.WHITE
            );
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
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
{
    public partial class BTS : Form
    {
        public BTS()
        {
            InitializeComponent();
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
    }
}

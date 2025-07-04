using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace UltimateBlueScreenSimulator
{
    public partial class ProgressTuner : MaterialForm
    {
        internal IDictionary<int, int> KFrames = new Dictionary<int, int>();
        Bitmap bmp = new Bitmap(1000, 10);
        int last = 0;
        public ProgressTuner()
        {
            MaterialSkinManager materialSkinManager = Program.f1.materialSkinManager;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                progressTrackBar.RangeMax = Convert.ToInt32(100 * float.Parse(totalTimeText.Text, CultureInfo.InvariantCulture.NumberFormat));
                ReloadBitmap();
            } catch {}
        }

        internal void ReloadBitmap()
        {
            progressVisualization.Image = null;
            try
            {
                bmp.Dispose();
            } catch { }
            bmp = new Bitmap((int)((float)progressTrackBar.RangeMax / 10f), 10);
            foreach (float position in KFrames.Keys)
            {
                for (int i = 0; i < 10; i++)
                {
                    if ((float)position / 10f >= bmp.Width) { break; }
                    bmp.SetPixel((int)((float)position / 10f), i, Color.Red);
                }
            }
            progressVisualization.Image = bmp;

        }

        internal void SetLabelText()
        {
            int totalpercent = 0;
            foreach (int perc in KFrames.Values)
            {
                totalpercent += perc;
            }
            progressPositionLabel.Text = string.Format("total: {0}%, position: {1}s", totalpercent, ((float)progressTrackBar.Value / 100.0f).ToString().Replace(",", "."));
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            incPercent.Text = r.Next(0, 10).ToString();
        }

        private void nextKeyFrameButton_Click(object sender, EventArgs e)
        {
            foreach (int position in KFrames.Keys)
            {
                if (position > (progressTrackBar.Value))
                {
                    try
                    {
                        progressTrackBar.Value = position;
                        progressTrackBar_Scroll(sender, progressTrackBar.Value);
                    } catch { }
                    break;
                }
            }
        }

        private void previousKeyFrameButton_Click(object sender, EventArgs e)
        {
            int minimum = 0;
            foreach (int position in KFrames.Keys)
            {
                if (position < progressTrackBar.Value)
                {
                    minimum = position;
                }
            }
            progressTrackBar.Value = minimum;
            progressTrackBar_Scroll(sender, progressTrackBar.Value);
        }

        private void AddKeyFrame_Click(object sender, EventArgs e)
        {
            deleteKeyFrame.PerformClick();
            KFrames.Add(progressTrackBar.Value, int.Parse(incPercent.Text));
            ReloadBitmap();
            last = progressTrackBar.Value - last;
            SetLabelText();
            repeatButton.Enabled = true;
        }

        private void deleteKeyFrame_Click(object sender, EventArgs e)
        {
            if (KFrames.ContainsKey(progressTrackBar.Value))
            {
                KFrames.Remove(progressTrackBar.Value);
                ReloadBitmap();
            }
            SetLabelText();
        }

        private void repeatButton_Click(object sender, EventArgs e)
        {
            if (KFrames.ContainsKey(progressTrackBar.Value + last))
            {
                KFrames.Remove(progressTrackBar.Value + last);
            }
            KFrames.Add(progressTrackBar.Value + last, int.Parse(incPercent.Text));
            ReloadBitmap();
            SetLabelText();
            try
            {
                progressTrackBar.Value += last;
                progressTrackBar_Scroll(sender, progressTrackBar.Value);
            }
            catch { }
            repeatButton.Enabled = true;
        }

        private void OKClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ClearAll(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will remove all keyframes. This cannot be undone. Do you still want to continue?", "Clear all keyframes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                KFrames.Clear();
                ReloadBitmap();
                SetLabelText();
            }
        }

        private void ProgressTuner_Load(object sender, EventArgs e)
        {
        }

        private void progressTrackBar_Scroll(object sender, int newValue)
        {
            SetLabelText();
            if (KFrames.ContainsKey(progressTrackBar.Value))
            {
                incPercent.Text = KFrames[progressTrackBar.Value].ToString();
            }
            else
            {
                incPercent.Text = "0";
            }
        }

        private void ProgressTuner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}

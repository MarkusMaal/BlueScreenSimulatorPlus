using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator.Forms.Legacy
{
    public partial class ProgressTuner : Form
    {
        internal IDictionary<int, int> KFrames = new Dictionary<int, int>();
        private Bitmap bmp = new Bitmap(1000, 10);
        private int last = 0;
        public ProgressTuner()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                progressTrackBar.Maximum = Convert.ToInt32(100 * float.Parse(totalTimeText.Text, CultureInfo.InvariantCulture.NumberFormat));
                ReloadBitmap();
            }
            catch { }
        }

        internal void ReloadBitmap()
        {
            progressVisualization.Image = null;
            try
            {
                bmp.Dispose();
            }
            catch { }
            bmp = new Bitmap((int)((float)progressTrackBar.Maximum / 10f), 10);
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

        private void ProgressTrackBar_Scroll(object sender, EventArgs e)
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

        internal void SetLabelText()
        {
            int totalpercent = 0;
            foreach (int perc in KFrames.Values)
            {
                totalpercent += perc;
            }
            progressPositionLabel.Text = string.Format("total: {0}%, position: {1}s", totalpercent, ((float)progressTrackBar.Value / 100.0f).ToString().Replace(",", "."));
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            incPercent.Text = r.Next(0, 10).ToString();
        }

        private void NextKeyFrameButton_Click(object sender, EventArgs e)
        {
            foreach (int position in KFrames.Keys)
            {
                if (position > (progressTrackBar.Value))
                {
                    try
                    {
                        progressTrackBar.Value = position;
                    }
                    catch { }
                    break;
                }
            }
        }

        private void PreviousKeyFrameButton_Click(object sender, EventArgs e)
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

        private void DeleteKeyFrame_Click(object sender, EventArgs e)
        {
            if (KFrames.ContainsKey(progressTrackBar.Value))
            {
                KFrames.Remove(progressTrackBar.Value);
                ReloadBitmap();
            }
            SetLabelText();
        }

        private void RepeatButton_Click(object sender, EventArgs e)
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
            }
            catch { }
            repeatButton.Enabled = true;
        }

        private void OKClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
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

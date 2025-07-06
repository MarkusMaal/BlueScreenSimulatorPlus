using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator.Forms.Loaders
{
    // Based on a tutorial found here: https://sites.harding.edu/fmccown/screensaver/screensaver.html
    // This is a "dummy preview", meaning it just shows some logos and the name of the selected OS/template

    // TODO: In the future, I want to replace this with an actual preview of the crash screen.
    // Maybe something like this can be implemented with invisible simulator window and modified
    // version of Forms.WindowScreen and SimulatorDatabase.DrawRoutines? That would be similar to
    // how multi-monitor in mirror mode already works.

    public partial class ScreensaverPreview : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        public ScreensaverPreview(IntPtr PreviewWndHandle)
        {
            InitializeComponent();

            SetParent(this.Handle, PreviewWndHandle);

            // Make this a child window so it will close when the parent dialog closes
            // GWL_STYLE = -16, WS_CHILD = 0x40000000
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle ParentRect;
            GetClientRect(PreviewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);

            settingsPreview.Text = $"Selected OS: {UIActions.me.GetString("os")}\nTemplate: {UIActions.me.GetString("friendlyname")}";

            new Thread(() => {
                this.BeginInvoke(new MethodInvoker(delegate {
                    screenSaverPreviewImage.Visible = false;
                }));
                UIActions.me.ShowSpecial(screenSaverPreviewImage);
                Thread.Sleep(1000);
                this.BeginInvoke(new MethodInvoker(delegate {
                    screenSaverPreviewImage.Visible = true;
                }));
            }).Start();
        }
    }
}

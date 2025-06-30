using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator.Forms.Simulators
{
    public partial class SunValleyBSOD : Form
    {
        public BlueScreen me;

        public SunValleyBSOD()
        {
            InitializeComponent();
        }

        private void SunValleyBSOD_Load(object sender, System.EventArgs e)
        {
            if (!me.GetBool("windowed"))
                Cursor.Hide();
        }
    }
}

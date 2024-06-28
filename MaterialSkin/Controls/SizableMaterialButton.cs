using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    public class SizableMaterialButton : Panel
    {
        // WARNING
        // Do not open this component in Visual Studio design view!
        // If you do, bad things will happen...
        private Label label1;
        private MaterialButton button1;

        [Category("Material Skin"),
            DefaultValue("SizableMaterialButton")]
        public string Content { get; set; }

        [Category("Material Skin")]
        public override Font Font { get; set; }

        public SizableMaterialButton()
        {
            this.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.Content = base.Name;
            InitializeComponent();
            Reload();
            Controls.Add(label1);
            Controls.Add(button1);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Reload();
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            Reload();
            base.OnResize(eventargs);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            label1.BackColor = button1.SkinManager.ColorScheme.LightPrimaryColor;
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            label1.BackColor = button1.SkinManager.ColorScheme.PrimaryColor;
            base.OnMouseLeave(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        protected void Reload()
        {
            label1.Text = Content;
            label1.Font = Font;
            label1.BackColor = button1.SkinManager.ColorScheme.PrimaryColor;
            label1.ForeColor = button1.SkinManager.ColorScheme.TextColor;
            button1.Size = new Size(base.Size.Width - 5, base.Size.Height - 5);
            label1.Location = new Point(base.Size.Width / 2 - label1.Size.Width / 2, base.Size.Height / 2 - label1.Size.Height / 2);
        }

        private void InitializeComponent()
        {
            this.button1 = new MaterialSkin.Controls.MaterialButton();
            this.label1 = new Label();
            // 
            // label1
            // 
            this.label1.BackColor = Color.Transparent;
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.AutoSize = true;
            this.label1.Click += new EventHandler((object sender, EventArgs e) => {
                this.button1.PerformClick();
            });
            // 
            // button1
            // 
            this.button1.AutoSize = false;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button1.Depth = 0;
            this.button1.HighEmphasis = true;
            this.button1.Icon = null;
            this.button1.MouseMove += new MouseEventHandler((object sender, MouseEventArgs e) => {
                this.OnMouseMove(e);
            });
            this.button1.MouseLeave += new EventHandler((object sender, EventArgs e) => {
                this.OnMouseLeave(e);
            });
            this.button1.Click += new EventHandler((object sender, EventArgs e) => {
                this.OnClick(e);
            });
        }
    }
}
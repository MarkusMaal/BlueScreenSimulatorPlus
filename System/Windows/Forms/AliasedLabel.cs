namespace System.Windows.Forms
{
    public partial class AliasedLabel : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            this.UseCompatibleTextRendering = true;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            base.OnPaint(e);
        }
    }
}
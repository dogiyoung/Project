using System;
using System.Drawing;
using System.Windows.Forms;

namespace LottoProject
{

    public class CustomPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int borderWidth = 1;
            Color borderColor = Color.Black;

            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid);


        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }
    }
}

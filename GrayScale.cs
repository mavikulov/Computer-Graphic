using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class GrayScale: Filters
    {
        protected override Color calculateNewPixelColor(Bitmap img, int x, int y)
        {
            Color currentColor = img.GetPixel(x, y);
            double intensity = 0.299 * currentColor.R + 0.587 * currentColor.G + 0.114 * currentColor.B;
            return Color.FromArgb(
                Clamp((int)(intensity), 0, 255),
                Clamp((int)(intensity), 0, 255),
                Clamp((int)(intensity), 0, 255)
                );
        }
    }
}

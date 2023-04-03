using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class Sepia: Filters
    {
        protected override Color calculateNewPixelColor(Bitmap img, int x, int y)
        {
            Random rnd = new Random();
            Color currentColor = img.GetPixel(x, y);
            Color intensity = Color.FromArgb((int)(0.299 * currentColor.R), (int)(0.587 * currentColor.G), (int)(0.114 * currentColor.B));
            int k = rnd.Next(30, 60);
            return Color.FromArgb(
                Clamp((int)(intensity.R + 2 * k), 0, 255),
                Clamp((int)(intensity.G + 0.5 * k), 0, 255),
                Clamp((int)(intensity.B - 1 * k), 0, 255)
                );
        }
    }
}

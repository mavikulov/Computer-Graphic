using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class GlassesFilter : Filters
    {
        Random rnd = new Random();
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            x = x + (int)((rnd.NextDouble() - 0.5) * 10);
            y = y + (int)((rnd.NextDouble() - 0.5) * 10);

            if (x >= sourceImage.Width || x < 0 || y >= sourceImage.Height || y < 0)
                return Color.White;
            return Color.FromArgb(Clamp((int)(sourceImage.GetPixel(x, y).R), 0, 255), Clamp((int)(sourceImage.GetPixel(x, y).G), 0, 255), Clamp((int)(sourceImage.GetPixel(x, y).B), 0, 255));
        }
    }
}

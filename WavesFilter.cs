using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class WavesFilter: Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            
            x = x + (int)(20 * Math.Sin(2 * Math.PI * y / 128.0f));
            if (x >= sourceImage.Width || x < 0)
                return Color.FromArgb(0, 0, 0);
            return Color.FromArgb(Clamp((int)(sourceImage.GetPixel(x, y).R), 0, 255), Clamp((int)(sourceImage.GetPixel(x, y).G), 0, 255), Clamp((int)(sourceImage.GetPixel(x, y).B), 0, 255)); ;
        }
    }
}

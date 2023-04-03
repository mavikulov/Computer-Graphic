using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class PerfectReflector : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color currentColor = sourceImage.GetPixel(x, y);
            Color maxBrightness = GetMaxPixel(sourceImage);
            return Color.FromArgb(
                Clamp(currentColor.R * 255 / maxBrightness.R, 0, 255),
                Clamp(currentColor.G * 255 / maxBrightness.G, 0, 255),
                Clamp(currentColor.B * 255 / maxBrightness.B, 0, 255)
                );
        }
    }


}

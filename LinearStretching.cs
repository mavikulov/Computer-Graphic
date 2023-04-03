using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class LinearStretching : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap img, int x, int y)
        {
            Color currentColor = img.GetPixel(x, y);
            Color minBrightness = GetMinPixel(img);
            Color maxBrightness = GetMaxPixel(img);
            int stretchedRed = Clamp((int)((currentColor.R - minBrightness.R) * 255.0 / (maxBrightness.R - minBrightness.R)), 0, 255);
            int stretchedGreen = Clamp((int)((currentColor.G - minBrightness.G) * 255.0 / (maxBrightness.G - minBrightness.G)), 0, 255);
            int stretchedBlue = Clamp((int)((currentColor.B - minBrightness.B) * 255.0 / (maxBrightness.B - minBrightness.B)), 0, 255);

            return Color.FromArgb(stretchedRed, stretchedGreen, stretchedBlue);
        }
    }
}

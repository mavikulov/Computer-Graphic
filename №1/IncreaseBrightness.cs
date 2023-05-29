using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class IncreaseBrightness: Filters
    {
        protected override Color calculateNewPixelColor(Bitmap img, int x, int y)
        {
            Color currentColor = img.GetPixel(x, y);
            Random rnd = new Random();
            int brightness = rnd.Next(0, 100);
            return Color.FromArgb(
                Clamp((int)(currentColor.R + brightness), 0, 255),
                Clamp((int)(currentColor.G + brightness), 0, 255),
                Clamp((int)(currentColor.B + brightness), 0, 255)
                );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class MedianFlilter: MatrixFilter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int[,] window = new int[5, 5];

            int halfWindow = 5 / 2;

            for (int i = halfWindow; i < sourceImage.Width - halfWindow; i++)
            {
                for (int j = halfWindow; j < sourceImage.Height - halfWindow; j++)
                {
                    int[] pixelValues = new int[5 * 5];
                    int index = 0;

                    for (int k = -halfWindow; k <= halfWindow; k++)
                    {
                        for (int l = -halfWindow; l <= halfWindow; l++)
                        {
                            Color pixel = sourceImage.GetPixel(i + k, j + l);
                            int grayScale = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                            pixelValues[index++] = grayScale;
                        }
                    }

                    Array.Sort(pixelValues);
                    int medianValue = pixelValues[pixelValues.Length / 2];
                    return Color.FromArgb(medianValue, medianValue, medianValue);
                }
            }
        }
        

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class MathMorphology : Filters
    {
        protected int[,] mask = null;
        protected int MH;
        protected int MW;

        public MathMorphology() { }

        public MathMorphology(int[,] mask, int mH, int mW)
        {
            this.mask = mask;
            MH = mH;
            MW = mW;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }
    }


    class Dilation: MathMorphology
    {
        public Dilation() 
        {
            MH = 3;
            MW = 3;
            mask = new int[3, 3] {{0, 1, 0},
                                  {1, 1, 1},
                                  {0, 1, 0}};
        }

        public Dilation(int[,] mask, int MH, int MW)
        {
            this.mask = mask;
            this.MH = MH;
            this.MW = MW;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color max = Color.FromArgb(0, 0, 0);
            for (int j = -MH / 2; j <= MH / 2; ++j)
            {
                for (int i = -MW / 2; i <= MW / 2; ++i)
                {
                    Color sourceColor = sourceImage.GetPixel(Clamp(x + i, 0, sourceImage.Width - 1), Clamp(y + j, 0, sourceImage.Height - 1));
                    if (mask[i + MW / 2, j + MH / 2] == 1 && sourceColor.R > max.R)
                    {
                        max = sourceColor;
                    }
                }
            }
            return max;
        }
    }


    class Erosion : MathMorphology
    {
        public Erosion()
        {
            MH = 3;
            MW = 3;
            mask = new int[3, 3] {{ 0, 1, 0 },
                                  { 1, 1, 1 },
                                  { 0, 1, 0 }};
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color min = Color.FromArgb(255, 255, 255);
            for (int j = -MH / 2; j <= MH / 2; ++j)
            {
                for (int i = -MW / 2; i <= MW / 2; ++i)
                {
                    Color sourceColor = sourceImage.GetPixel(Clamp(x + i, 0, sourceImage.Width - 1), Clamp(y + j, 0, sourceImage.Height - 1));
                    if (mask[i + MW / 2, j + MH / 2] == 1 && sourceColor.R < min.R)
                    {
                        min = sourceColor;
                    }
                }
            }
            return min;
        }
    }


    class Gradient: MathMorphology
    {
        public Gradient()
        {
            MH = 3;
            MW = 3;
            mask = new int[3, 3] {{ 0, 1, 0 },
                                  { 1, 1, 1 },
                                  { 0, 1, 0 } };
        }

        override public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; ++i)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;

                for (int j = 0; j < sourceImage.Height; ++j)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color min = Color.FromArgb(255, 255, 255);
            Color max = Color.FromArgb(0, 0, 0);
            for (int j = -MH / 2; j <= MH / 2; ++j)
            {
                for (int i = -MW / 2; i <= MW / 2; ++i)
                {
                    Color sourceColor = sourceImage.GetPixel(Clamp(x + i, 0, sourceImage.Width - 1), Clamp(y + j, 0, sourceImage.Height - 1));
                    if (mask[i + MW / 2, j + MH / 2] == 1 && sourceColor.R < min.R)
                    {
                        min = sourceColor;
                    }
                    if (mask[i + MW / 2, j + MH / 2] == 1 && sourceColor.R > max.R)
                    {
                        max = sourceColor;
                    }
                }
            }
            return Color.FromArgb(Clamp(max.R - min.R, 0, 255), Clamp(max.G - min.G, 0, 255), Clamp(max.B - min.B, 0, 255));
        }
    }


    class MedianFilter : MathMorphology
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int size = 3;
            int radius = 1;
            int[] reds = new int[size * size];
            int[] greens = new int[size * size];
            int[] blues = new int[size * size];
            int pos = 0;

            for (int i = -radius; i <= radius; i++)
                for (int j = -radius; j <= radius; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(Clamp(x + i, 0, sourceImage.Width - 1), Clamp(y + j, 0, sourceImage.Height - 1));
                    reds[pos] = sourceColor.R;
                    greens[pos] = sourceColor.G;
                    blues[pos] = sourceColor.B;
                    pos++;
                }

            Array.Sort(reds);
            Array.Sort(greens);
            Array.Sort(blues);

            int mid = (int)(size * size / 2);

            int medianRed = reds[mid];
            int medianGreen = greens[mid];
            int medianBlue = blues[mid];

            Color resultColor = Color.FromArgb(medianRed, medianGreen, medianBlue);
            return resultColor;
        }
    }
}

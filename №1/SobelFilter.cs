using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class SobelFilter : MatrixFilter
    {
        protected float[,] kernelX = null;
        protected float[,] kernelY = null;
        public SobelFilter()
        {
            kernelX = new float[3, 3] {{-1,  0,   1},
                                       {-2,  0,   2},
                                       {-1,  0,   1}};

            kernelY = new float[3, 3] {{-1,  -2,   -1},
                                       { 0,   0,    0},
                                       { 1,   2,    1}};
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernelX.GetLength(0) / 2;
            int radiusY = kernelX.GetLength(1) / 2;
            float xR = 0;
            float xG = 0;
            float xB = 0;
            float yR = 0;
            float yG = 0;
            float yB = 0;

            for (int l = -radiusY; l <= radiusY; ++l)
            {
                for (int k = -radiusX; k <= radiusX; ++k)
                {
                    int idx = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idy = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idx, idy);
                    xR += neighborColor.R * kernelX[k + radiusX, l + radiusY];
                    xG += neighborColor.G * kernelX[k + radiusX, l + radiusY];
                    xB += neighborColor.B * kernelX[k + radiusX, l + radiusY];

                    yR += neighborColor.R * kernelY[k + radiusX, l + radiusY];
                    yG += neighborColor.G * kernelY[k + radiusX, l + radiusY];
                    yB += neighborColor.B * kernelY[k + radiusX, l + radiusY];
                }
            }
            return Color.FromArgb(Clamp((int)Math.Sqrt((xR * xR) + (yR * yR)), 0, 255), Clamp((int)Math.Sqrt((xG * xG) + (yG * yG)), 0, 255), Clamp((int)Math.Sqrt((xB * xB) + (yB * yB)), 0, 255));
        }
    }
}

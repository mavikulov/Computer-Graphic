using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class CustomFilter: Filters
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Random rnd = new Random();
            n = rnd.Next(1, 10);
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
            }
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double h = (double)sourceImage.Height;
            Color currentColor = sourceImage.GetPixel(x, y);
            if (Math.Ceiling(x / (h / n)) % 2 == 0)
            {
                Color intensity = Color.FromArgb((int)(0.299 * currentColor.R), (int)(0.587 * currentColor.G), (int)(0.114 * currentColor.B));
                int k = rnd.Next(30, 60);
                return Color.FromArgb(
                    Clamp((int)(intensity.R + 2 * k), 0, 255),
                    Clamp((int)(intensity.G + 0.5 * k), 0, 255),
                    Clamp((int)(intensity.B - 1 * k), 0, 255)
                    );
            }
            
            return Color.FromArgb(currentColor.R, currentColor.G, currentColor.B);
        }
    }
}

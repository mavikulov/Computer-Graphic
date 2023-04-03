using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class Sharpening: MatrixFilter
    {
        public Sharpening()
        {
            this.kernel = new float[,]{
                {0, -1, 0},
                {-1, 5, -1},
                {0, -1, 0}
            };
        }
    }
}

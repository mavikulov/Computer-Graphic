using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class BorderSelection: MatrixFilter
    {
        public BorderSelection()
        {
            this.kernel = new float[,]{
                {3, 10, 3},
                {0, 0, 0},
                {-3, -10, -3}
            };
        }
    }
}

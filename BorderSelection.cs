using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    internal class BorderSelection: SobelFilter
    {

        public BorderSelection()
        {
            kernelX = new float[3, 3] {{3,  0,   -3},
                                       {10,  0,  -10},
                                       {3,  0,   -3}};

            kernelY = new float[3, 3] {{3,  10,   3},
                                       {0,   0,   0},
                                       {-3, -10, -3}};
        }
    }
}

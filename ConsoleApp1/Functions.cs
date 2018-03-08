using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinealAlg;

namespace ArtificialInt
{
    public static class Functions
    {
        public static Matrix Sigmoid(Matrix a)
        {
            for (int i = 0; i < a.row; i++)
            {
                for (int j = 0; j < a.column; j++)
                {
                    a[i, j] = (1 / (1 + Math.Exp(a[i, j] * -1)));
                }
            }
            return a;
        }
    }
}

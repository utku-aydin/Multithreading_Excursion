using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Matrixes
{
    public interface IMatrixMultiplier
    {
        /// <summary>
        /// Multiplies two pseudorandom matrices of size m*p and p*m.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="p"></param>
        public void MultiplyMatrices(int m, int p, bool parallelFlag);
    }
}

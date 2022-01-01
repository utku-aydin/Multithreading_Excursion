using Algorithms.Matrixes;
using Algorithms.Matrixes.Implementations;
using Utilities.Timing;
using Utilities.Timing.Implementations;

namespace Multithreading_Excursion
{
    class App
    {
        static void Main(string[] args)
        {
            ITimeAggregator timeAggregator = new TimeAggregator();
            IMatrixMultiplier matrixMultiplier = new MatrixMultiplier(timeAggregator);

            matrixMultiplier.MultiplyMatrices(50, 100, true);
        }
    }
}

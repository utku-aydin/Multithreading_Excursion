using System;
using System.Threading.Tasks;
using Utilities.Timing;

namespace Algorithms.Matrixes.Implementations
{
    public class MatrixMultiplier : IMatrixMultiplier
    {
        readonly ITimeAggregator _timeAggregator;

        public MatrixMultiplier(ITimeAggregator timeAggregator)
        {
            _timeAggregator = timeAggregator;
        }

        public void MultiplyMatrices(int m, int p, bool parallelFlag)
        {
            int[,] a = new int[m, p];
            int[,] b = new int[p, m];

            Random random = new();

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = random.Next(1, 10);
                    b[j, i] = random.Next(1, 10);
                }

            // Abstract this altogether?
            Action MatrixMultiplyAction = parallelFlag ? () => MultiplyMatricesParallel(a, b) : () => MultiplyMatrices(a, b);
            Console.WriteLine("Average time elapsed: {0}", _timeAggregator.TimeMethod(1000, MatrixMultiplyAction));
        }

        private int[,] MultiplyMatrices(int[,] a, int[,] b)
        {
            int[,] c = new int[a.GetLength(0), b.GetLength(1)];

            // Order of loops (for cache-friendliness) doesn't work as expected.
            // Appears as if the compiler expects/optimises the "natural" order.
            for (int m = 0; m < a.GetLength(0); m++)
                for (int p = 0; p < b.GetLength(1); p++)
                    for (int i = 0; i < a.GetLength(0); i++)
                        c[m, p] += a[m, i] * b[i, p];

            return c;
        }

        private int[,] MultiplyMatricesParallel(int[,] a, int[,] b)
        {
            int[,] c = new int[a.GetLength(0), b.GetLength(1)];

            Parallel.For(0, a.GetLength(0), m =>
            {
                for (int p = 0; p < b.GetLength(1); p++)
                    for (int i = 0; i < a.GetLength(0); i++)
                        c[m, p] += a[m, i] * b[i, p];
            });

            return c;
        }
    }
}

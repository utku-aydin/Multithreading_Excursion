using System;
using System.Diagnostics;

namespace Utilities.Timing.Implementations
{
    public class TimeAggregator : ITimeAggregator
    {
        public TimeSpan TimeMethod(int numRuns, Action method)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < numRuns; i++)
                method();

            sw.Stop();
            return sw.Elapsed / numRuns;
        }
    }
}

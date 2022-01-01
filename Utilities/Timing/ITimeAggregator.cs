using System;

namespace Utilities.Timing
{
    public interface ITimeAggregator
    {
        /// <summary>
        /// Time a method.
        /// </summary>
        /// <param name="numRuns">Number of runs to time and average</param>
        /// <param name="method">Method to time</param>
        /// <returns></returns>
        public TimeSpan TimeMethod(int numRuns, Action method);
    }
}

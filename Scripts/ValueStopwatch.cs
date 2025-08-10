using System;
using Unity.Profiling.LowLevel.Unsafe;

namespace redwyre.Core
{
    /// <summary>
    /// A lightweight stopwatch that measures elapsed time in nanoseconds. You can use either the `ElapsedNs` property 
    /// for high precision or the `Elapsed` property for a more traditional <see cref="TimeSpan"/> representation.
    /// 
    /// To use this, you can create an instance using `ValueStopwatch.StartNew()`
    /// 
    /// example:
    /// var stopwatch = ValueStopwatch.StartNew();
    /// DoSomething();
    /// var elapsed = stopwatch.Elapsed;
    /// Debug.Log($"Elapsed time: {elapsed.TotalMilliseconds} ms");
    /// 
    /// </summary>
    public struct ValueStopwatch
    {
        const int nanosecondsPerTick = 100;

        long startTime;

        public static ValueStopwatch StartNew()
        {
            return new ValueStopwatch() { startTime = ProfilerUnsafeUtility.Timestamp };
        }

        /// <summary>
        /// Returns the elapsed time in nanoseconds since the stopwatch was started.
        /// </summary>
        public long ElapsedNs
        {
            get
            {
                var conversionRatio = ProfilerUnsafeUtility.TimestampToNanosecondsConversionRatio;
                long elapsed = ProfilerUnsafeUtility.Timestamp - startTime;
                return (elapsed * conversionRatio.Numerator) / conversionRatio.Denominator;
            }
        }

        /// <summary>
        /// Returns the elapsed time in the form of a <see cref="TimeSpan"/>. Note that this is technically not
        /// as accurate as the <see cref="ElapsedNs"/> property, since it converts nanoseconds to ticks.
        /// </summary>
        public TimeSpan Elapsed
        {
            get
            {
                return new TimeSpan(ElapsedNs / nanosecondsPerTick);
            }
        }
    }
}

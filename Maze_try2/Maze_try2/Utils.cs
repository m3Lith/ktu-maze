using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maze_try2
{
    static class Utils
    {
        private static readonly Stopwatch SleepStopwatch = new Stopwatch();
        public static void Sleep(double msDelay)
        {
            if (msDelay > 100)
                Thread.Sleep((int)(msDelay/1000 - 10));
            else
            {
                var freq = Stopwatch.Frequency/1000d;
                SleepStopwatch.Restart();
                while (SleepStopwatch.ElapsedTicks / freq < msDelay)
                {
                    // Active waiting.
                }
            }
        }
    }
}

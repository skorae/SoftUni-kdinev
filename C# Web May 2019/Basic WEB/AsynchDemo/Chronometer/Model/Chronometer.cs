using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Chronometer.IO;
using Chronometer.Model.Contracts;

namespace Chronometer.Model
{
    public class Chronometer : IChronometer
    {
        private readonly List<string> laps;
        private Stopwatch stopWatch;

        public Chronometer(Stopwatch stopwatch)
        {
            this.laps = new List<string>();
            this.stopWatch = stopwatch;
        }

        public string GetTime
            => GetMillisecond();

        public IReadOnlyCollection<string> Laps
            => this.laps.AsReadOnly();

        public string Lap()
        {
            if (!this.stopWatch.IsRunning)
            {
                throw new System.ArgumentException(ErrorMessage.ChronometerNotRunning);
            }

            this.laps.Add(this.GetTime.ToString());

            return this.GetTime;
        }

        public void Reset()
        {
            this.laps.Clear();
            this.stopWatch.Reset();
        }

        public void Start()
        {
            this.stopWatch.Start();
        }

        public void Stop()
        {
            this.stopWatch.Stop();
        }

        private string GetMillisecond()
        {
            var milliseconds = this.stopWatch.ElapsedMilliseconds;

            var result = $"{(milliseconds / 60000):D2}:{milliseconds / 1000:D2}:{(milliseconds % 1000):D4}";

            return result;
        }
    }
}

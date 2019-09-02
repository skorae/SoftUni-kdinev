﻿namespace Chronometer.Model.Contracts
{
    using System.Collections.Generic;

    public interface IChronometer
    {
        string GetTime { get; }

        IReadOnlyCollection<string> Laps { get; }

        void Start();

        void Stop();

        string Lap();

        void Reset();
    }
}

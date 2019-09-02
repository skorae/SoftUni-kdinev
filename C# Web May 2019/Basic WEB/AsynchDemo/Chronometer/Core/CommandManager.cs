using System;
using System.Text;

using Chronometer.Core.Contracts;
using Chronometer.IO;
using Chronometer.Model.Contracts;

namespace Chronometer.Core
{
    public class CommandManager : ICommandManager
    {
        private IChronometer chronometer;

        public CommandManager(IChronometer chronometer)
            : base()
        {
            this.chronometer = chronometer;
        }

        public string Lap()
        {
            var lap = this.chronometer.Lap();

            return lap;
        }

        public string Laps()
        {
            if (this.chronometer.Laps.Count == 0)
            {
                throw new System.ArgumentException(ErrorMessage.NoLapsEntered);
            }

            var sb = new StringBuilder();

            sb.AppendLine("Laps:");

            int counter = 0;

            foreach (var lap in this.chronometer.Laps)
            {
                string time = lap;

                sb.AppendLine($"{counter++}. {time}");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public string Reset()
        {
            this.chronometer.Reset();

            var result = "chronometer is reset!";

            return result;
        }

        public string Start()
        {
            this.chronometer.Start();

            var result = "Chronometer started!";

            return result;
        }

        public string Stop()
        {
            this.chronometer.Stop();

            var result = "Chronometer stopped!";

            return result;
        }

        public string Time()
        {
            var time = this.chronometer.GetTime;

            return time;
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}

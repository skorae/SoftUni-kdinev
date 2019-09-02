using Chronometer.Core;
using Chronometer.Core.Contracts;
using Chronometer.IO;
using Chronometer.IO.Contracts;
using Chronometer.Model.Contracts;
using System.Diagnostics;

namespace Chronometer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            IChronometer chronometer = new Model.Chronometer(stopwatch);

            IReader reader = new Reader();
            IWriter writer = new Writer();
            
            ICommandManager manager = new CommandManager(chronometer);
            ICommandInterpreter interpreter = new CommandInterpreter(manager);

            IEngine engine = new Engine(reader, writer, interpreter);

            engine.Run();
        }
    }
}

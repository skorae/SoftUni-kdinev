namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using IO.Contracts;
    using System.Reflection;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader,
            IWriter writer,
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            IList<string> input = reader.ReadLine().Split();

            while (!isRunning)
            {
                try
                {
                    if (input[0] == "Terminate")
                    {
                        writer.WriteLine(commandInterpreter.ProcessInput(input));
                        break;
                    }

                    writer.WriteLine(commandInterpreter.ProcessInput(input));
                }
                catch (TargetInvocationException ex)
                {
                    writer.WriteLine(ex.InnerException.Message);
                }
                catch (InvalidOperationException ex)
                {
                    writer.WriteLine(ex.Message);
                }

                input = reader.ReadLine().Split();
            }
        }
    }
}
using Chronometer.Core.Contracts;
using Chronometer.IO;
using Chronometer.IO.Contracts;
using Chronometer.Model.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace Chronometer.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter interpreter;

        public Engine(IReader reader, IWriter writer, ICommandInterpreter interpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.interpreter = interpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var command = ProccessCommand();

                    var result = this.interpreter.Interpret(command);

                    if (result == null)
                    {
                        throw new ArgumentException(ErrorMessage.InvalidCommand);
                    }

                    writer.Write(result);
                }
                catch (TargetInvocationException ex)
                {
                    writer.Write(ex.InnerException.Message);
                }
                catch (Exception ex)
                {
                    writer.Write(ex.Message);
                }
            }
        }

        private string ProccessCommand()
        {
            var commandArray = reader.Read().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var command = commandArray[0];

            return command;
        }
    }
}

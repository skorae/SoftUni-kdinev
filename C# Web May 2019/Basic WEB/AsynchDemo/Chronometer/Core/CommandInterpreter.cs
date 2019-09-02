using Chronometer.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chronometer.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandManager manager;

        public CommandInterpreter(ICommandManager manager)
        {
            this.manager = manager;
        }

        public string Interpret(string command)
        {
            string result = null;

            var methodInfo = this.manager.GetType().GetMethods().FirstOrDefault(method => method.Name.ToLower() == command.ToLower());

            if (methodInfo == null)
            {
                return result;
            }

            result = (string)methodInfo.Invoke(this.manager, new object[] { });
            
            return result;
        }
        
    }
}

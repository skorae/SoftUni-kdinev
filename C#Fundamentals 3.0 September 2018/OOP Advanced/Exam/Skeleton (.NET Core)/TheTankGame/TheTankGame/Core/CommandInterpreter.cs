namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            MethodInfo methodInfo = this.tankManager.GetType().GetMethods().FirstOrDefault(x => x.Name.Contains(inputParameters[0]));

            string result = (string)methodInfo.Invoke(this.tankManager, new object[] { inputParameters.Skip(1).ToList() });
            
            return result;
        }
    }
}
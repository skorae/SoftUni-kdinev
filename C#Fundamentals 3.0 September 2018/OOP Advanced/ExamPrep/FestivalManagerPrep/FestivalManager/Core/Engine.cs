
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Core.IO;
    using IO.Contracts;

	class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;
        private IFestivalController festivalController;
        private ISetController setController;
        
        public Engine(
            IFestivalController festivalController, 
            ISetController setController, 
            IWriter writer, 
            IReader reader) 
        {
            this.writer = writer;
            this.reader = reader;
            this.festivalController = festivalController;
            this.setController = setController;
        }

        public void Run()
		{
            string input = reader.ReadLine();

			while (input != "END")
			{
				try
				{
					string result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
                catch (InvalidOperationException ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
                catch (TargetInvocationException ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
                }
                
                input = reader.ReadLine();
			}

			string end = this.festivalController.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			string[] arr = input.Split();

			string first = arr[0];
			string[] args = arr.Skip(1).ToArray();
            string result;

			if (first == "LetsRock")
			{
				result = this.setController.PerformSets();
            }
            else
            {
                var methodInfo = this.festivalController.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == first);

                result = (string)methodInfo.Invoke(this.festivalController, new object[] { args });
            }

            return result;
		}
	}
}
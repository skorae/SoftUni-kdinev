namespace Travel.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAirportController airportController;
        private readonly IFlightController flightController;

        public Engine(
            IReader reader,
            IWriter writer,
            IAirportController airportController,
            IFlightController flightController)
        {
            this.reader = reader;
            this.writer = writer;
            this.airportController = airportController;
            this.flightController = flightController;
        }

        public void Run()
        {
            string input = this.reader.ReadLine();
            string result;

            while (input != "END")
            {
                try
                {
                    result = this.ProcessCommand(input);
                }
                catch (InvalidOperationException ex)
                {
                    result = "ERROR: " + ex.Message;
                }
                catch (TargetInvocationException ex)
                {
                    result = "ERROR: " + ex.InnerException.Message;
                }

                writer.WriteLine(result);
                input = reader.ReadLine();
            }
        }

        public string ProcessCommand(string input)
        {
            var arr = input.Split();

            var command = arr.First();
            var args = arr.Skip(1).ToArray();

            MethodInfo methodInfo = typeof(Engine)
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(x => x.Name == command + "Command");

            if (methodInfo == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            string result = (string)methodInfo.Invoke(this, new object[] { args });
            return result;
        }

        private string RegisterPassengerCommand(string[] args)
        {
            string name = args[0];

            string output = this.airportController.RegisterPassenger(name);
            return output;
        }

        private string RegisterTripCommand(string[] args)
        {
            string source = args[0];
            string destination = args[1];
            string planeType = args[2];

            string output = this.airportController.RegisterTrip(source, destination, planeType);
            return output;
        }

        private string RegisterBagCommand(string[] args)
        {
            string username = args[0];
            var bagItems = args.Skip(1);

            string output = this.airportController.RegisterBag(username, bagItems);
            return output;
        }

        private string CheckInCommand(string[] args)
        {
            string username = args[0];
            string tripId = args[1];
            var bagCheckInIndices = args.Skip(2).Select(int.Parse);

            string output = this.airportController.CheckIn(username, tripId, bagCheckInIndices);
            return output;
        }

        private string TakeOffCommand(string[] args)
        {
            string output = this.flightController.TakeOff();
            return output;
        }
    }
}
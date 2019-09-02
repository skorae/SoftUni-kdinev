namespace Travel
{
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;
    
	public static class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader = new Reader();
			IWriter writer = new Writer();

			IAirport airport = new Airport();
			IAirportController airportController = new AirportController(airport);
			IFlightController flightController = new FlightController(airport);

			IEngine engine = new Engine(reader, writer, airportController, flightController);

			engine.Run();
		}
	}
}
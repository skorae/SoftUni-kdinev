namespace Travel.Tests
{
	using NUnit.Framework;
    using Travel.Core.Controllers;
    using Travel.Entities;
    using Travel.Entities.Airplanes;

    [TestFixture]
    public class FlightControllerTests
    {
        [Test]
	    public void HopeCanDoItInOne()
	    {
            Airport airport = new Airport();
            FlightController flightController = new FlightController(airport);

            Airplane airplane = new LightAirplane();
            Trip trip = new Trip("Sofia", "London", airplane);

            

            Airplane airplane1 = new LightAirplane();
            Trip comletedTrip = new Trip("London", "Sofia", airplane1);
            comletedTrip.Complete();
        }
    }
}

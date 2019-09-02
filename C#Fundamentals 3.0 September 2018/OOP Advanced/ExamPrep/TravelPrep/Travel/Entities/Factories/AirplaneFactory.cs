namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System;
    using System.Reflection;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string typeName)
		{
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == typeName);

            IAirplane airplane = (IAirplane)Activator.CreateInstance(type);

            return airplane;
		}
	}
}
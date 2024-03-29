﻿namespace Travel.Entities
{
	using Airplanes.Contracts;
	using Contracts;

	public class Trip : ITrip
	{
		private static int id = 1;

		public Trip(string source, string destination, IAirplane airplane)
		{
			this.Source = source;
			this.Destination = destination;
			this.Airplane = airplane;
            this.IsCompleted = false;

			this.Id = GenerateId(source, destination);
		}

		public string Id { get; }

		public string Source { get; }

		public string Destination { get; }

		public bool IsCompleted { get; private set; }

		public IAirplane Airplane { get; }

		public void Complete() => this.IsCompleted = true;

		private static string GenerateId(string departure, string destination)
		{
			return $"{departure}{destination}{id++}";
		}
	}
}
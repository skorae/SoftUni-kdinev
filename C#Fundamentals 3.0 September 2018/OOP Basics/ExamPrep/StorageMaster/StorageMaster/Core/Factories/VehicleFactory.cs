using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Core.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string name)
        {
            Vehicle vehicle;

            switch (name)
            {
                case "Van":
                    vehicle = new Van();
                    break;
                case "Semi":
                    vehicle = new Semi();
                    break;
                case "Truck":
                    vehicle = new Truck();
                    break;
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}

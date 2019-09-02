using System;
using System.Collections.Generic;
using System.Text;
using Vihicles.Vihicles;

namespace Vihicles.Factories
{
    public class VihicleFactory
    {
        public double Calculate(string[] arr, Vihicle vihicle)
        {
            string action = arr[0];
            string typeVihicle = arr[1];
            double distanceOrFuel = double.Parse(arr[2]);

            if (action == "Drive")
            {
                return VihicleDrive(vihicle, distanceOrFuel,action);
            }
            else if (action == "DriveEmpty")
            {
                return VihicleDrive(vihicle, distanceOrFuel,action);
            }
            return VihicleRefuel(vihicle, distanceOrFuel);
        }

        private double VihicleRefuel(Vihicle vihicle, double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return vihicle.Quantity;
            }
            if (vihicle.Tank < vihicle.Quantity + fuel)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return vihicle.Quantity;
            }
            switch (vihicle.GetType().Name)
            {
                case "Car":
                case "Bus":
                    return vihicle.Quantity + fuel;
                case "Truck":
                    vihicle.Quantity += fuel * 0.95;
                    return vihicle.Quantity;
            }
            return vihicle.Quantity;
        }

        private double VihicleDrive(Vihicle vihicle, double distance, string action)
        {
            if (vihicle.GetType().Name == "Bus" && !action.Contains("Empty"))
            {
                if (vihicle.Quantity - (distance * (vihicle.Consuption + 1.4)) < 0)
                {
                    Console.WriteLine($"{vihicle.GetType().Name} needs refueling");
                    return vihicle.Quantity;
                }
                vihicle.Quantity -= distance * (vihicle.Consuption + 1.4);
                Console.WriteLine($"{vihicle.GetType().Name} travelled {distance} km");
                return vihicle.Quantity;
            }
            if (vihicle.Quantity - (distance * vihicle.Consuption) < 0)
            {
                Console.WriteLine($"{vihicle.GetType().Name} needs refueling");
                return vihicle.Quantity;
            }
            vihicle.Quantity -= (distance * vihicle.Consuption);
            Console.WriteLine($"{vihicle.GetType().Name} travelled {distance} km");
            return vihicle.Quantity;
        }
    }
}

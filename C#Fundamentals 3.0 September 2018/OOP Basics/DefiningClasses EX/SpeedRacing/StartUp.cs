using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] auto = Console.ReadLine().Split();

                string model = auto[0];
                double fuelAmmount = double.Parse(auto[1]);
                double fuelConsuptionFor1Km = double.Parse(auto[2]);

                Car car = new Car(model, fuelAmmount, fuelConsuptionFor1Km);

                if (cars.ContainsKey(model) == false)
                {
                    cars.Add(car.Model, car);
                }
            }
            
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] arr = command.Split();

                if (command.Contains("Drive") == false)
                {
                    continue;
                }
                
                string carName = arr[1];
                int distance = int.Parse(arr[2]);

                double possibleTravelDistance = cars[carName].FuelAmmount / cars[carName].FuelConsumptionFor1Km;

                if (distance > possibleTravelDistance)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                    command = Console.ReadLine();
                    continue;
                }

                Calculate.Calculator(distance, cars[carName]);

                command = Console.ReadLine();
            }

            foreach (var c in cars)
            {
                Console.WriteLine($"{c.Key} {c.Value.FuelAmmount:f2} {c.Value.DistanceTraveled}");
            }
        }
    }
}

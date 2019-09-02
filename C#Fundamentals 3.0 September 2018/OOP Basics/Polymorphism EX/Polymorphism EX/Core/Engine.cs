using System;
using System.Collections.Generic;
using System.Text;
using Vihicles.Factories;
using Vihicles.Vihicles;

namespace Vihicles.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] c = Console.ReadLine().Split();
            string[] t = Console.ReadLine().Split();
            string[] b = Console.ReadLine().Split();
            VihicleFactory factory = new VihicleFactory();

            Vihicle car = new Car(double.Parse(c[1]), double.Parse(c[2]), double.Parse(c[3]));
            Vihicle truck = new Truck(double.Parse(t[1]), double.Parse(t[2]), double.Parse(t[3]));
            Vihicle bus = new Bus(double.Parse(b[1]), double.Parse(b[2]), double.Parse(b[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();

                switch (arr[1])
                {
                    case "Car":
                        car.Quantity = factory.Calculate(arr, car);
                        continue;
                    case "Truck":
                        truck.Quantity = factory.Calculate(arr, truck);
                        continue;
                    case "Bus":
                        bus.Quantity = factory.Calculate(arr, bus);
                        continue;
                }

            }

            Console.WriteLine($"Car: {car.Quantity:f2}");
            Console.WriteLine($"Truck: {truck.Quantity:f2}");
            Console.WriteLine($"Bus: {bus.Quantity:f2}");
        }
    }
}

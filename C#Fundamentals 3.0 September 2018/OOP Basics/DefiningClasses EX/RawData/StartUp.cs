using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();
                List<Tire> tires = new List<Tire>();

                string model = arr[0];
                int speed = int.Parse(arr[1]);
                int power = int.Parse(arr[2]);
                int weight = int.Parse(arr[3]);
                string type = arr[4];

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(weight, type);

                for (int y = 5; y < arr.Length; y += 2)
                {
                    double pressure = double.Parse(arr[y]);
                    int age = int.Parse(arr[y + 1]);

                    Tire tire = new Tire(pressure, age);
                    tires.Add(tire);
                }

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            switch (command)
            {
                case "fragile":
                    foreach (var c in cars)
                    {
                        if (c.Cargo.Type == "fragile")
                        {
                            foreach (var t in c.Tires)
                            {
                                if (t.Pressure < 1)
                                {
                                    Console.WriteLine($"{c.Model}");
                                    break;
                                }
                            }

                        }
                    }
                    break;
                case "flamable":
                    foreach (var c in cars)
                    {
                        if (c.Cargo.Type == "flamable")
                        {
                            if (c.Engine.Power > 250)
                            {
                                Console.WriteLine($"{c.Model}");
                            }
                        }
                    }
                    break;
            }
        }
    }
}

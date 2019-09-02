using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            List<string> cars = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string engineModel = arr[0];
                string power = arr[1];
                string displacement = "n/a";
                string efficiency = "n/a";

                if (arr.Length == 3)
                {
                    if (int.TryParse(arr[2],out int x))
                    {
                        displacement = arr[2];
                    }
                    else
                    {
                        efficiency = arr[2];
                    }
                }
                else if(arr.Length == 4)
                {
                    displacement = arr[2];
                    efficiency = arr[3];
                }

                Engine engine = new Engine(engineModel, power, displacement, efficiency);
                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = arr[0];
                string engineModel = arr[1];
                Engine engine = engines.FirstOrDefault(e => e.EngineModel == engineModel);
                string weight = "n/a";
                string color = "n/a";

                if (arr.Length == 3)
                {
                    if (int.TryParse(arr[2], out int x))
                    {
                        weight = arr[2];
                    }
                    else
                    {
                        color = arr[2];
                    }
                }
                else if (arr.Length == 4)
                {
                    weight = arr[2];
                    color = arr[3];
                }

                Car car = new Car(carModel, engine, weight, color);
                cars.Add(car.ToString());
                
            }
            foreach (var c in cars)
            {
                Console.WriteLine(c);
            }
        }
    }
}

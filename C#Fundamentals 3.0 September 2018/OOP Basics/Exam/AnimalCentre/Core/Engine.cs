using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private AnimalCentre centre;

        public Engine()
        {
            this.centre = new AnimalCentre();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();
                string type = args[0];

                string[] arr = args.Skip(1).ToArray();

                try
                {
                    switch (type)
                    {
                        case "RegisterAnimal":
                            Console.WriteLine(centre.RegisterAnimal(arr[0], arr[1], int.Parse(arr[2]), int.Parse(arr[3]), int.Parse(arr[4])));
                            break;
                        case "Chip":
                            Console.WriteLine(centre.Chip(arr[0],int.Parse(arr[1])));
                            break;
                        case "Vaccinate":
                            Console.WriteLine(centre.Vaccinate(arr[0], int.Parse(arr[1])));
                            break;
                        case "Fitness":
                            Console.WriteLine(centre.Fitness(arr[0], int.Parse(arr[1])));
                            break;
                        case "Play":
                            Console.WriteLine(centre.Play(arr[0], int.Parse(arr[1])));
                            break;
                        case "DentalCare":
                            Console.WriteLine(centre.DentalCare(arr[0], int.Parse(arr[1])));
                            break;
                        case "NailTrim":
                            Console.WriteLine(centre.NailTrim(arr[0], int.Parse(arr[1])));
                            break;
                        case "Adopt":
                            Console.WriteLine(centre.Adopt(arr[0], arr[1]));
                            break;
                        case "History":
                            Console.WriteLine(centre.History(arr[0]));
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("InvalidOperationException: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("ArgumentException: " + ex.Message);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(centre.ToString());
        }
    }
}

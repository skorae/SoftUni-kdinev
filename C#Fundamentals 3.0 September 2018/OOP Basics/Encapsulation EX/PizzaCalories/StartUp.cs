using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{

    class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dough dough = new Dough();
            string name = "";

            try
            {
                string[] arr = command.Split();
                name = arr[1];

                arr = Console.ReadLine().Split();

                string flowerType = arr[1];
                string technique = arr[2];
                decimal weight = decimal.Parse(arr[3]);

                Pizza pizza = new Pizza(name, new Dough(flowerType, technique, weight));

                command = Console.ReadLine();

                while (command != "END")
                {
                    arr = command.Split();
                    string type = arr[0];

                    switch (type)
                    {
                        case "Topping":
                            string toppingType = arr[1];
                            decimal toppingWeight = decimal.Parse(arr[2]);

                            Topping topping = new Topping(toppingType, toppingWeight);
                            pizza.AddTopping(topping);
                            break;
                    }
                    command = Console.ReadLine();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
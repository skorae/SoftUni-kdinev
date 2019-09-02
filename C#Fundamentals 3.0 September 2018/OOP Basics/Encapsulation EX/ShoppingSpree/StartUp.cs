using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();
            string product = Console.ReadLine();

            var people = new Dictionary<string, Person>();
            List<Product> products = new List<Product>();

            string[] arrNames = names.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] arrProducts = product.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                Person.AddPeople(arrNames, people);
                Product.AddProduct(arrProducts, products);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] arr = command.Split();

                    string name = arr[0];
                    string prodFORNOW = arr[1];

                    Product currentProduct = products.FirstOrDefault(x => x.Name == prodFORNOW);

                    if (people.ContainsKey(name))
                    {
                        if (people[name].Money >= currentProduct.Cost)
                        {
                            Console.WriteLine($"{name} bought {prodFORNOW}");
                            people[name].Products.Add(currentProduct);
                            people[name].Money -= currentProduct.Cost;
                        }
                        else
                        {
                            Console.WriteLine($"{name} can't afford {prodFORNOW}");
                        }
                    }
                    command = Console.ReadLine();
                }

                foreach (var p in people)
                {
                    if (p.Value.Products.Count != 0)
                    {
                        Console.WriteLine($"{p.Key} - " + string.Join(", ", p.Value.Products.Select(x => x.Name)));
                    }
                    else
                    {
                        Console.WriteLine($"{p.Key} - Nothing bought");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var people = new Dictionary<string, Person>();

            while (input != "End")
            {
                string[] arr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = arr[0];
                string @object = arr[1].ToLower();
                string name = "";
                string birthday = "";

                switch (@object)
                {
                    case "company":
                        name = arr[2];
                        string department = arr[3];
                        decimal salary = decimal.Parse(arr[4]);

                        Company company = new Company(name, department, salary);

                        Person.Contains(personName, people);

                        people[personName].Company = new KeyValuePair<string, Company>("Company:", company);

                        break;
                    case "pokemon":
                        name = arr[2];
                        string type = arr[3];

                        Pokemon pokemon = new Pokemon(name, type);

                        Person.Contains(personName, people);

                        people[personName].Pokemons.Value.Add(pokemon);
                        break;
                    case "parents":
                        name = arr[2];
                        birthday = arr[3];

                        Parents parents = new Parents(name, birthday);

                        Person.Contains(personName, people);

                        people[personName].Parents.Value.Add(parents);
                        break;
                    case "children":
                        name = arr[2];
                        birthday = arr[3];

                        Children children = new Children(name, birthday);

                        Person.Contains(personName, people);

                        people[personName].Children.Value.Add(children);
                        break;
                    case "car":
                        string model = arr[2];
                        string speed = arr[3];

                        Car car = new Car(model, speed);

                        Person.Contains(personName, people);

                        people[personName].Car = new KeyValuePair<string, Car>("Car:", car);
                        break;
                }
                input = Console.ReadLine();
            }

            string printPerson = Console.ReadLine();

            Console.WriteLine(printPerson);

            Console.WriteLine(people[printPerson].ToString());
            
        }
    }
}

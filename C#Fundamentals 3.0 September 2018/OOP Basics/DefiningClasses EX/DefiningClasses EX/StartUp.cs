using DefiningClasses;
using DefiningClasses_EX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Over30 peopleOver30 = new Over30();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();

                string name = arr[0];
                int age = int.Parse(arr[1]);

                Person person = new Person(name,age);
                if (person.Age > 30)
                {
                    peopleOver30.AddPeopleOver30(person);
                }
            }

            foreach (var p in peopleOver30.PeopleOver30.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }
        }
    }
}

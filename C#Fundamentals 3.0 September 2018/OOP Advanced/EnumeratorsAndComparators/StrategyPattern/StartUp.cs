using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> nameSorted = new SortedSet<Person>(new NameSorted());
            HashSet<Person> ageSorted = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();

                string name = arr[0];
                int age = int.Parse(arr[1]);

                Person person = new Person(name, age);

                nameSorted.Add(person);
                ageSorted.Add(person);
            }

            Console.WriteLine(nameSorted.Count);
            Console.WriteLine(ageSorted.Count);
        }
    }
}

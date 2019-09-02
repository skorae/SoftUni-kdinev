using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Person<string> person = new Person<string>();

            while (command != "END")
            {
                person.People.Add(command);

                command = Console.ReadLine();
            }

            int comparer = int.Parse(Console.ReadLine());

            try
            {
                int equal = person.Compare(comparer);
                int notEqual = person.People.Count - equal;
                int total = person.People.Count;

                Console.WriteLine($"{equal} {notEqual} {total}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}

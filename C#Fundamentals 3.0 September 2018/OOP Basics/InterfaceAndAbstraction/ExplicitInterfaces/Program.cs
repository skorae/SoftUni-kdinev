using System;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] arr = command.Split();
                string name = arr[0];
                string coutry = arr[1];
                int age = int.Parse(arr[2]);

                IResident resident = new Citizen(name, coutry, age);
                IPerson person = new Citizen(name, coutry, age);

                person.GetName();
                resident.GetName();
                command = Console.ReadLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();
            HashSet<string> set = new HashSet<string>();

            while (data != "END")
            {
                string[] arr = data.Split(", ");
                string command = arr[0];
                string number = arr[1];

                switch (command)
                {
                    case "IN":
                        set.Add(number);
                        break;
                    case "OUT":
                        set.Remove(number);
                        break;
                }
                data = Console.ReadLine();
            }

            if (set.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }
            foreach (var c in set)
            {
                Console.WriteLine(c);
            }
        }
    }
}

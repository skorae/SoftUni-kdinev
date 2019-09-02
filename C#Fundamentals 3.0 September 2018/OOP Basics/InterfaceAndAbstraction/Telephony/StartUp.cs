using System;
using System.Collections.Generic;
using Telephony.Phone;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone(numbers, sites);

            smartphone.Call();
            smartphone.Browse();
        }
    }
}

using System;
using System.Numerics;

namespace Problem_2._Number_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            bool lOng = BigInteger.TryParse(num, out BigInteger result);
           
            if (lOng)
            {
                Console.WriteLine("integer");
            }
            else
            {
                Console.WriteLine("floating-point"); 
            } 
        }
    }
}

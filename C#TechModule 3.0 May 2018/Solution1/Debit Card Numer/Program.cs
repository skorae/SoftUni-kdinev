using System;

namespace Debit_Card_Numer
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int num4 = int.Parse(Console.ReadLine());

            Console.Write("{0:D4}" , num1);
            Console.Write(" {0:D4}" , num2);
            Console.Write(" {0:D4}" , num3);
            Console.Write(" {0:D4}" , num4);
        }
    }
}

using System;
using System.Numerics;

namespace Problem_8._House_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();

            sbyte @sbyte = 0;
            int @int = 0;

            if(sbyte.TryParse(firstNumber, out sbyte x))
            {
                @sbyte = x;
                @int = int.Parse(secondNumber);
            }
            else
            {
                @sbyte = sbyte.Parse(secondNumber);
                @int = int.Parse(firstNumber);
            }
            int sbytePrice = @sbyte * 4;
            long intprice = @int * 10L;
            long price = sbytePrice + intprice;

            Console.WriteLine(price);
        }
    }    
}

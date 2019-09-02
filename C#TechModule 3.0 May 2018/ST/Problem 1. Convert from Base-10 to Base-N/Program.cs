using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problem_1._Convert_from_Base_10_to_Base_N
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] input = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();

            BigInteger baseNum = input[0];
            BigInteger numToConvert = input[1];
            List<BigInteger> result = new List<BigInteger>();
            
            while (numToConvert != 0)
            {
                BigInteger temp = 0;

                temp = numToConvert % baseNum;
                result.Add(temp);
                numToConvert /= baseNum;
            }
            StringBuilder final = new StringBuilder();
            for (int i = result.Count - 1; i >= 0; i--)
            {
                final.Append(result[i]);
            }
            
            Console.WriteLine(final);
        }
    }
}

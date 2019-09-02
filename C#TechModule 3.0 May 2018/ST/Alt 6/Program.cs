using System;
using System.Text;

namespace Alt_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine();
            string num2 = Console.ReadLine();

            int maxLenght = Math.Max(num1.Length, num2.Length);
            num1.PadLeft(maxLenght, '0');
            num2.PadLeft(maxLenght, '0');
            int remainder = 0;

            StringBuilder result = new StringBuilder();
            for (int i = maxLenght - 1; i >= 0; i--)
            {
                int first = int.Parse(num1[i].ToString());
                int second = int.Parse(num2[i].ToString());
                int temp = first + second + remainder;
                remainder = 0;

                if (temp > 9)
                {
                    temp -= 10;
                    remainder++;
                }
                result.Append(temp);
            }
            result.Append(remainder);
            string output = result.ToString().TrimEnd('0');

            for (int i = output.Length - 1; i >= 0; i--)
            {
                Console.Write($"{output[i]}");
            }

        }
    }
}

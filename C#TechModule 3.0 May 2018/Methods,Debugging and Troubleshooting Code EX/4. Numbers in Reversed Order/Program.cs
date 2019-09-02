using System;

namespace _4._Numbers_in_Reversed_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string result = ReversedOrder(num);

            Console.WriteLine(result);

        }
        static string ReversedOrder(double num)
        {
            string number = num.ToString();
            string result = "";

            while (number.Length != 0)
            {
                string last = number.Substring(number.Length - 1);
                result += last;
                number = number.Remove(number.Length - 1);
            }
            return result;

        }
    }
}

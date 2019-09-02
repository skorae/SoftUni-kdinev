using System;
using System.Text;
using System.Linq;

namespace Problem_6._Sum_Big_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine();
            string num2 = Console.ReadLine();

            StringBuilder sum = new StringBuilder();
            int remain = 0;
            
            int max = Math.Max(num1.Length, num2.Length);

            string first = num1.PadLeft(max, '0');
            string second = num2.PadLeft(max, '0');

            for (int i = max - 1; i >= 0; i--)
            {
                int temp = int.Parse(first[i].ToString()) + int.Parse(second[i].ToString()) + remain;
                remain = 0;
                if (temp > 9)
                {
                    sum.Append(temp % 10);
                    remain += temp / 10;
                }
                else
                {
                    sum.Append(temp);
                }
            }
            sum.Append(remain);
            string result = sum.ToString().TrimEnd('0');
            result = string.Join("", result.Reverse());
            Console.WriteLine(result);
        }
    }
}

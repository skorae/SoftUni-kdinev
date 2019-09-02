using System;
using System.Linq;
using System.Text;

namespace Problem_7._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int power = int.Parse(Console.ReadLine());

            if (num.Equals("0") || power == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int remain = 0;
            StringBuilder final = new StringBuilder();

            for (int i = num.Length - 1; i >= 0; i--)
            {
                int temp = remain + (int.Parse(num[i].ToString()) * power);
                remain = 0;

                if (temp > 9)
                {
                    final.Append(temp % 10);
                    remain = temp / 10;
                }
                else
                {
                    final.Append(temp);
                }
            }
            final.Append(remain);
            string result = final.ToString().TrimEnd('0');
            result = string.Join("", result.Reverse());
            Console.WriteLine(result);
        }
    }
}

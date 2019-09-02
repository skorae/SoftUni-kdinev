using System;

namespace _5._Boolean_Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            bool isTrue = Convert.ToBoolean(str);

            if (isTrue)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}

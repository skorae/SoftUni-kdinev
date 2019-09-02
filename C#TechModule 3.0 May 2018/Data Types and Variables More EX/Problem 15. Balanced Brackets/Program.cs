using System;

namespace Problem_15._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string temp = "";

            for (int i = 0; i < n; i++)
            {
                string @string = Console.ReadLine();

                if (@string == "(")
                {
                    temp += @string;
                }
                else if (@string == ")")
                {
                    temp += @string;
                }
                if (temp == "()")
                {
                    temp = "";
                }
                else if (temp == ")" || temp == "((")
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
            }
            if (temp == "")
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}

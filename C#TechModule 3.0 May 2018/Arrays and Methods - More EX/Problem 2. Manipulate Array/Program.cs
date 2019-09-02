using System;
using System.Linq;

namespace Problem_2._Manipulate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                string[] temp = new string[text.Length];

                if (command[0] == "Distinct")
                {
                    temp = text.Distinct().ToArray();
                    text = temp;
                }
                else if (command[0] == "Reverse")
                {
                    temp = text.Reverse().ToArray();
                    text = temp;
                }
                else if (command[0] == "Replace")
                {
                    text[int.Parse(command[1])] = command[2];
                }
            }
            Console.WriteLine(string.Join(", ", text));
        }
    }
}

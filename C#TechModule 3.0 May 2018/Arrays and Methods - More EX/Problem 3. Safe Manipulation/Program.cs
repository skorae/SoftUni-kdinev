using System;
using System.Linq;

namespace Problem_2._Manipulate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();

            while (true)
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
                    if (int.Parse(command[1]) < 0 || int.Parse(command[1]) > text.Length - 1)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    text[int.Parse(command[1])] = command[2];
                }
                else if (command[0] == "END")
                {
                    Console.WriteLine(string.Join(", ", text));
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
           
        }
    }
}

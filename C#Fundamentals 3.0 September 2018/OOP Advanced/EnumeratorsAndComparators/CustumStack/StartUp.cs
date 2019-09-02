using System;
using System.Collections.Generic;
using System.Linq;

namespace CustumStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            string command = Console.ReadLine();


            while (command != "END")
            {
                string[] temp = command.Split(new char[] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries);
                string com = temp[0];

                switch (com)
                {
                    case "Push":
                        int[] arr = temp.Skip(1).Select(int.Parse).ToArray();
                        stack.Push(arr);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
                command = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(stack.ToString());
            }
        }
    }
}

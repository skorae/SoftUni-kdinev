using System;
using System.Linq;

namespace ListIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string[] arr = command.Split();
            ListyIterator<string> list = new ListyIterator<string>(arr.Skip(1).ToArray());

            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", list));
                        break;
                    case "Print":
                        try
                        {
                            Console.WriteLine(list.Print());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}

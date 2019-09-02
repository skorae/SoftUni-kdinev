using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    public void Run()
    {
        bool isRunning = true;
        string command = Console.ReadLine();
        DraftManager manager = new DraftManager();

        while (isRunning)
        {
            string[] args = command.Split();

            string execute = args[0];
            List<string> arr = args.Skip(1).ToList();
            try
            {
                switch (execute)
                {
                    case "RegisterHarvester":
                        Console.WriteLine(manager.RegisterHarvester(arr));
                        break;
                    case "RegisterProvider":
                        Console.WriteLine(manager.RegisterProvider(arr));
                        break;
                    case "Check":
                        Console.WriteLine(manager.Check(arr));
                        break;
                    case "Day":
                        Console.WriteLine(manager.Day());
                        break;
                    case "Mode":
                        Console.WriteLine(manager.Mode(arr));
                        break;
                    case "Shutdown":
                        Console.WriteLine(manager.ShutDown());
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            command = Console.ReadLine();
        }
    }
}


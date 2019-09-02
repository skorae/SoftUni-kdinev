using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        public void Run()
        {
            string command = Console.ReadLine();
            StorageMaster master = new StorageMaster();

            while (command != "END")
            {
                string[] arr = command.Split();

                try
                {
                    switch (arr[0])
                    {
                        case "AddProduct":
                            string type = arr[1];
                            double price = double.Parse(arr[2]);
                            Console.WriteLine(master.AddProduct(type, price));
                            break;
                        case "RegisterStorage":
                            type = arr[1];
                            string name = arr[2];
                            Console.WriteLine(master.RegisterStorage(type, name));
                            break;
                        case "SelectVehicle":
                            Console.WriteLine(master.SelectVehicle(storageName: arr[1], garageSlot: int.Parse(arr[2])));
                            break;
                        case "LoadVehicle":
                            IEnumerable<string> productNames = arr.Skip(1).ToArray();
                            Console.WriteLine(master.LoadVehicle(productNames));
                            break;
                        case "SendVehicleTo":
                            Console.WriteLine(master.SendVehicleTo(sourceName: arr[1], sourceGarageSlot: int.Parse(arr[2]), destinationName: arr[3]));
                            break;
                        case "UnloadVehicle":
                            Console.WriteLine(master.UnloadVehicle(storageName: arr[1], garageSlot: int.Parse(arr[2])));
                            break;
                        case "GetStorageStatus":
                            Console.WriteLine(master.GetStorageStatus(storageName: arr[1]));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(master.GetSummary());
        }
    }
}

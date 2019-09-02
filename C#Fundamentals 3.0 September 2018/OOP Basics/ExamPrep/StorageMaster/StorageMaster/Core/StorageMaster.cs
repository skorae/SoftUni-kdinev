using StorageMaster.Core.Factories;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storages;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        ProductFactory productFactory = new ProductFactory();
        StorageFactory storageFactory = new StorageFactory();

        List<Product> productPool = new List<Product>();
        List<Storage> storages = new List<Storage>();

        Vehicle currentVehicle;

        public string AddProduct(string type, double price)
        {
            Product product = productFactory.CreateProduct(type, price);
            productPool.Add(product);

            string result = $"Added {type} to pool";

            return result;
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = storageFactory.CreateStorage(type, name);
            storages.Add(storage);

            string result = $"Registered {name}";

            return result;
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = storages.FirstOrDefault(x => x.Name == storageName);
            currentVehicle = storage.GetVehicle(garageSlot);

            string output = $"Selected {currentVehicle.GetType().Name}";

            return output;
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int count = 0;
            foreach (var productName in productNames)
            {
                if (!this.productPool.Any(p => p.GetType().Name == productName) ||
                    this.productPool.Count == 0)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }
                currentVehicle.LoadProduct(this.productPool.Last(p => p.GetType().Name == productName));
                int index = this.productPool.LastIndexOf(this.productPool.Last(p => p.GetType().Name == productName));
                this.productPool.RemoveAt(index);
                count++;
                if (currentVehicle.IsFull)
                {
                    break;
                }
            }
            string output = $"Loaded {count}/{productNames.Count()} products into {currentVehicle.GetType().Name}";

            return output;
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage sourceStorage = storages.FirstOrDefault(x => x.Name == sourceName);
            Storage destinationstorage = storages.FirstOrDefault(x => x.Name == destinationName);

            if (sourceStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (destinationstorage == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            int index = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationstorage);

            string output = $"Sent {vehicle.GetType().Name} to {destinationstorage.Name} (slot {index})";

            return output;

        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = storages.FirstOrDefault(x => x.Name == storageName);
            Vehicle vehicle = storage.GetVehicle(garageSlot);
            int productsInVehicle = vehicle.Trunk.Count;
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            string output = $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";

            return output;
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = storages.FirstOrDefault(x => x.Name == storageName);
            StringBuilder builder = new StringBuilder();

            List<Product> products = storage.Products
                .OrderByDescending(x => storage.Products.Count)
                .ThenBy(x => x.GetType().Name)
                .ToList();

            Vehicle[] vehicles = storage.Garage.ToArray();

            double sumWeightProducts = products.Sum(x => x.Weight);

            builder.AppendLine($"Stock ({sumWeightProducts}/{storage.Capacity}): [{PrintProducts(products)}]");
            builder.AppendLine($"Garage: [{string.Join("|", vehicles.Select(x => (x != null) ? x.GetType().Name.ToString() : "empty"))}]");

            string output = builder.ToString().Trim();

            return output;
        }
        
        public string GetSummary()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var s in storages.OrderByDescending(x => x.Products.Sum(y => y.Price)))
            {
                builder.AppendLine($"{s.Name}:");
                builder.AppendLine($"Storage worth: ${s.Products.Sum(x => x.Price):F2}");
            }

            return builder.ToString().Trim();
        }

        private string PrintProducts(List<Product> products)
        {
            var dict = new Dictionary<string, List<Product>>();
            
            foreach (var p in products)
            {
                if (!dict.ContainsKey(p.GetType().Name))
                {
                    dict.Add(p.GetType().Name, new List<Product>());
                    dict[p.GetType().Name].Add(p);
                    continue;
                }
                dict[p.GetType().Name].Add(p);
            }

            string[] arr = new string[dict.Keys.Count];
            int count = 0;
            foreach (var kvp in dict.OrderByDescending(x => x.Value.Count))
            {
                arr[count++] = $"{kvp.Key} ({kvp.Value.Count})";
            }

            string output = string.Join(", ", arr);
            return output;
        }
    }
}

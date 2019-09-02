using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Storages
{
    public abstract class Storage
    {
        private List<Product> products;
        private Vehicle[] garage;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;

            products = new List<Product>();
            garage = new Vehicle[this.GarageSlots];

            AddVehicleToGarage(vehicles);
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public bool IsFull => this.products.Sum(x => x.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);

        public Vehicle GetVehicle(int garageSlot)
        {
            IsSlotEmpty(garageSlot);

            Vehicle vehicle = this.garage[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = GetVehicle(garageSlot);

            if (!deliveryLocation.garage.Any(x => x == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            int freeSpotIndex = Array.IndexOf(deliveryLocation.garage, null);

            deliveryLocation.garage[freeSpotIndex] = vehicle;
            this.garage[garageSlot] = null;

            return freeSpotIndex;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }
            Vehicle vehicle = GetVehicle(garageSlot);

            int counter = 0;

            while (!vehicle.IsEmpty && !IsFull)
            {
                this.products.Add(vehicle.Unload());
                counter++;
            }

            return counter;
        }

        private void AddVehicleToGarage(IEnumerable<Vehicle> vehicles)
        {
            int count = 0;
            foreach (var v in vehicles)
            {
                this.garage[count++] = v;
            }
        }

        private void IsSlotEmpty(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
        }

    }
}

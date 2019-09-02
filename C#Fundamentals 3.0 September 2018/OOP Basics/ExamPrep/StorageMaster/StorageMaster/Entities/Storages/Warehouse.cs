using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
    public class Warehouse : Storage
    {
        public Warehouse(string name)
            : base(name, capacity: 10, garageSlots: 10, vehicles: new Vehicle[3] { new Semi(), new Semi(), new Semi() })
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
    public class DistributionCenter : Storage
    {
        public DistributionCenter(string name)
            : base(name, capacity: 2, garageSlots: 5, vehicles: new Vehicle[3] { new Van(), new Van(), new Van() })
        {
        }
    }
}

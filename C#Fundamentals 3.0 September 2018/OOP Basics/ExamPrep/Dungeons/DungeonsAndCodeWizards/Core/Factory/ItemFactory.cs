using DungeonsAndCodeWizards.Entity.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Core.Factory
{
   public class ItemFactory
    {
        public Item CreateItem(string type)
        {
            Item item;

            switch (type)
            {
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                case "PoisonPotion":
                    item = new PoisonPotion();
                    break;
                case "ArmorRepairKit":
                    item = new ArmorRepairKit();
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{ type }\"!");
            }

            return item;
        }
    }
}

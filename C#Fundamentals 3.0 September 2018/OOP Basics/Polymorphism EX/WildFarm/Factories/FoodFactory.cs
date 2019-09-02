using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Objects.Foods;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public Food GetFood(string[] info)
        {
            string type = info[0].ToLower();
            int quantity = int.Parse(info[1]);

            switch (type)
            {
                case "vegetable":
                    return new Vegetable(quantity);
                case "fruit":
                    return new Fruit(quantity);
                case "seeds":
                    return new Seeds(quantity);
                case "meat":
                    return new Meat(quantity);
            }
            return null;
        }
    }
}

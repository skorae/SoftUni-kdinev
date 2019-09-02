using System;
namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private decimal toppingWeight;
        private decimal calories;

        public Topping(string toppingType, decimal toppingWeight)
        {
            this.ToppingType = toppingType;
            this.ToppingWeight = toppingWeight;
            this.Calories = (toppingWeight * 2) * GetModifier(this.ToppingType);
        }

        public string ToppingType
        {
            get { return this.toppingType; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || IsValid(value))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.toppingType = value;
            }
        }

        public decimal ToppingWeight
        {
            get { return this.toppingWeight; }
            set
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }
                this.toppingWeight = value;
            }
        }
        
        public decimal Calories
        {
            get { return calories; }
            set { calories = value; }
        }
        
        private decimal GetModifier(string toppingType)
        {
            decimal temp = 0;
            switch (toppingType.ToLower())
            {
                case "meat":
                    temp = 1.2m;
                    break;
                case "veggies":
                    temp = 0.8m;
                    break;
                case "cheese":
                    temp = 1.1m;
                    break;
                case "sauce":
                    temp = 0.9m;
                    break;
            }
            return temp;
        }

        private bool IsValid(string value)
        {
            switch (value.ToLower())
            {
                case "meat":
                case "veggies":
                case "cheese":
                case "sauce":
                    return false;
            }
            return true;
        }
    }
}
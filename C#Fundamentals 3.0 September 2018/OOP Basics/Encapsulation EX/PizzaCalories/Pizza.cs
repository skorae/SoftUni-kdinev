using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new List<Topping>();
        }
        public string Name
        {

            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15 || value == "  ")
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            private set
            {
                this.dough = value;
            }
        }

        public List<Topping> Toppings
        {
            get { return this.toppings; }
            private set
            {
                if (value.Count > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                this.toppings = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.Toppings.Add(topping);
        }

        public decimal GetCalories()
        {
            decimal sum = 0;

            sum += this.Dough.Calories;
            sum += this.Toppings.Sum(x => x.Calories);

            return sum;
        }
    }
}

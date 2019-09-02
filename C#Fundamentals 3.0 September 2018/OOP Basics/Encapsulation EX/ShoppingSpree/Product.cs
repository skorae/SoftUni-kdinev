using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value == "   ")
                {
                    throw new ArgumentException("Name cannot be empty");//Name cannot be empty
                }
                this.name = value;
            }
        }

        public decimal Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
            }
        }

        internal static void AddProduct(string[] arrProducts, List<Product> products)
        {
            foreach (var n in arrProducts)
            {
                string[] temp = n.Split("=",StringSplitOptions.RemoveEmptyEntries);

                string name = temp[0];
                decimal cost = decimal.Parse(temp[1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }
        }
    }
}

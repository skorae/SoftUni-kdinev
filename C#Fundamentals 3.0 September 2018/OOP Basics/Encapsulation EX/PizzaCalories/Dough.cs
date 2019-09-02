using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flowerType;
        private string technique;
        private decimal weight;
        private decimal calories;

        public Dough()
        {
            
        }

        public Dough(string flowerType, string technique, decimal weight)
        {
            this.FlowerType = flowerType;
            this.Technique = technique;
            this.Weight = weight;
            this.Calories = weight * 2 * GetModifier(this.FlowerType, this.Technique);
        }

        public string FlowerType
        {
            get { return flowerType; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || IsValid(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flowerType = value;
            }
        }
        
        public string Technique
        {
            get { return technique; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value) || IsValid(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                technique = value;
            }
        }

        public decimal Weight
        {
            get { return weight; }
            set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public decimal Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        private decimal GetModifier(string flowerType, string technique)
        {
            decimal flower = 0;
            decimal tech = 0;

            switch (flowerType.ToLower())
            {
                case "white":
                    flower = 1.5m;
                    break;
                case "wholegrain":
                    flower = 1.0m;
                    break;
            }
            switch (technique.ToLower())
            {
                case "crispy":
                    tech = 0.9m;
                    break;
                case "chewy":
                    tech = 1.1m;
                    break;
                case "homemade":
                    tech = 1.0m;
                    break;
            }

            return flower * tech;
        }
        private bool IsValid(string value)
        {
            switch (value.ToLower())
            {
                case "white":
                case "wholegrain":
                case "crispy":
                case "chewy":
                case "homemade":
                    return false;
            }
            return true;
        }
    }
}

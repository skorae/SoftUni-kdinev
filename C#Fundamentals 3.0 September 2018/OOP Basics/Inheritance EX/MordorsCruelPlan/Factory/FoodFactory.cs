using MordorsCruelPlan.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MordorsCruelPlan.Factory
{
    public class FoodFactory
    {
        private List<Food> foods;

        public FoodFactory()
        {
            this.Foods = new List<Food>();
        }
        public List<Food> Foods { get; set; }

        public int GetHappines(string[] input)
        {
            foreach (var f in input)
            {
                switch (f.ToLower())
                {
                    case "cram":
                        this.Foods.Add(new Cram());
                        break;
                    case "lembas":
                        this.Foods.Add(new Lembas());
                        break;
                    case "apple":
                        this.Foods.Add(new Apple());
                        break;
                    case "melon":
                        this.Foods.Add(new Melon());
                        break;
                    case "honeycake":
                        this.Foods.Add(new HoneyCake());
                        break;
                    case "mushrooms":
                        this.Foods.Add(new Mushrooms());
                        break;
                    default:
                        this.Foods.Add(new Other());
                        break;
                }
            }

            return this.Foods.Sum(x => x.Happines);
        }
    }
}

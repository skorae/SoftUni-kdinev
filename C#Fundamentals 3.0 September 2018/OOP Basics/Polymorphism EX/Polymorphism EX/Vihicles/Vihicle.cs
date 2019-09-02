using System;
using System.Collections.Generic;
using System.Text;

namespace Vihicles.Vihicles
{
    public class Vihicle
    {
        private double quantity;

        public Vihicle(double quantity, double consuption, double tank)
        {
            this.Tank = tank;
            this.Quantity = quantity;
            this.Consuption = consuption;
        }

        public virtual double Quantity
        {
            get { return this.quantity; }
            set
            {
                if (value > Tank)
                {
                    this.Quantity = 0;
                }
                else
                {
                    this.quantity = value;
                }
            }
        }
        public virtual double Consuption { get; set; }
        public virtual double Tank { get; set; }
    }
}
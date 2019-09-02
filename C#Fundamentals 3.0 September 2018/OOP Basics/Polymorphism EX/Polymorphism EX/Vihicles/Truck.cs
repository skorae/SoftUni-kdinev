using System;
using System.Collections.Generic;
using System.Text;

namespace Vihicles.Vihicles
{
    public class Truck : Vihicle
    {
        public Truck(double quantity, double consuption, double tank)
            : base(quantity, consuption, tank)
        {
            this.Consuption = consuption;
        }

        public override double Consuption { get => base.Consuption; set => base.Consuption = value + 1.6; }
    }
}

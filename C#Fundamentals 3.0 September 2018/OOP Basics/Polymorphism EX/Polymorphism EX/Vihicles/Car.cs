using System;
using System.Collections.Generic;
using System.Text;

namespace Vihicles.Vihicles
{
    public class Car : Vihicle
    {
        public Car(double quantity, double consuption, double tank)
            : base(quantity, consuption, tank)
        {
            this.Consuption = consuption;
        }

        public override double Consuption { get => base.Consuption; set => base.Consuption = value + 0.9; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
   public class Calculate
    {
        public static void Calculator(int distance, Car car)
        {
            car.FuelAmmount -= distance * car.FuelConsumptionFor1Km;
            car.DistanceTraveled += distance;
        }
    }
}

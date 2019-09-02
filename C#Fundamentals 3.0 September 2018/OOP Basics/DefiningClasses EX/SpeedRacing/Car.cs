using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmmount;
        private double fuelConsuptionFor1Km;
        private int distanceTraveled;

        public Car(string model, double fuelAmmount, double fuelConsumptionFor1Kmk)
        {
            this.Model = model;
            this.FuelAmmount= fuelAmmount;
            this.FuelConsumptionFor1Km = fuelConsumptionFor1Kmk;
            this.distanceTraveled = 0;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double FuelAmmount
        {
            get { return this.fuelAmmount; }
            set { this.fuelAmmount = value; }
        }

        public double FuelConsumptionFor1Km
        {
            get { return this.fuelConsuptionFor1Km; }
            set { this.fuelConsuptionFor1Km = value; }
        }

        public int DistanceTraveled
        {
            get { return this.distanceTraveled; }
            set { this.distanceTraveled = value; }
        }
    }
}

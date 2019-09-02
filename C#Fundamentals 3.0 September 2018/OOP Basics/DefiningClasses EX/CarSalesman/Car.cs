using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string carModel;
        private Engine engine;
        private string weight;
        private string color;

        public Car(string carModel,Engine engine,string weight,string color)
        {
            this.CarModel = carModel;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string CarModel
        {
            get { return carModel; }
            set { carModel = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public override string ToString()
        {
            string input = $"{this.CarModel}:\n" +
                $"  {engine.EngineModel}:\n" +
                $"    Power: {engine.Power}\n" +
                $"    Displacement: {engine.Displacement}\n" +
                $"    Efficiency: {engine.Efficiency}\n" +
                $"  Weight: {this.Weight}\n" +
                $"  Color: {this.Color}".Replace("\n", Environment.NewLine);

            return input;
        }
    }
}

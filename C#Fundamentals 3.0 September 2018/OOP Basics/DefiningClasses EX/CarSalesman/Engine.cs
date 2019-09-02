using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        private string engineModel;
        private string power;
        private string displacement;
        private string efficiency;
        
        public Engine(string engineModel, string power, string displacement,string efficiency)
        {
            this.EngineModel = engineModel;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string EngineModel
        {
            get { return engineModel; }
            set { engineModel = value; }
        }

        public string Power
        {
            get { return power; }
            set { power = value; }
        }

        public string Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }
    }
}

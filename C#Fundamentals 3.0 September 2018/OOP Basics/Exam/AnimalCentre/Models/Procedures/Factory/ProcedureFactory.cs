using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures.Factory
{
   public class ProcedureFactory
    {
        public Procedure GetProcedure(string type)
        {
            Procedure procedure;

            switch (type)
            {
                case "Chip":
                    procedure = new Chip();
                    break;
                case "DentalCare":
                    procedure = new DentalCare();
                    break;
                case "Fitness":
                    procedure = new Fitness();
                    break;
                case "NailTrim":
                    procedure = new NailTrim();
                    break;
                case "Play":
                    procedure = new Play();
                    break;
                case "Vaccinate":
                    procedure = new Vaccinate();
                    break; 
                default:
                    return null;
            }

            return procedure;
        }
    }
}


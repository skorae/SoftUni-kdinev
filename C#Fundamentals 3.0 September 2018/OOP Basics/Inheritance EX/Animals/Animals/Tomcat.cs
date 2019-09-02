using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender)
            : base(name, age, gender)
        {
            base.Gender = "Male";
        }

        public override string ProduceSound()
        {
             return "MEOW";
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender)
            : base(name, age, gender)
        {
            base.Gender = "Female";
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}

﻿using PetClinic.Core;
using System;

namespace PetClinic
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}

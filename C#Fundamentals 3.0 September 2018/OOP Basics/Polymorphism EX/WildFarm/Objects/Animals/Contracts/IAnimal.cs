using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Objects.Animals.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }
    }
}

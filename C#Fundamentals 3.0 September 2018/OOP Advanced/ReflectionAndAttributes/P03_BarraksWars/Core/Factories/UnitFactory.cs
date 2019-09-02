namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Models.Units;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var type = assembly.GetTypes().FirstOrDefault(x => x.Name == unitType);

            IUnit unit = (Unit)Activator.CreateInstance(type,true);

            return unit;
        }
    }
}

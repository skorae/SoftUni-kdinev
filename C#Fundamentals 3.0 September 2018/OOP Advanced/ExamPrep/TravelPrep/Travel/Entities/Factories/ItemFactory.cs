namespace Travel.Entities.Factories
{
	using Contracts;
    using System.Linq;
	using Items.Contracts;
    using System;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string typeName)
		{
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == typeName);

            IItem item = (IItem)Activator.CreateInstance(type);

            return item;
		}
	}
}

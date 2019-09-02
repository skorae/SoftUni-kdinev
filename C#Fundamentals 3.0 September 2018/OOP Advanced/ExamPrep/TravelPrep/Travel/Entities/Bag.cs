namespace Travel.Entities
{
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	using Items.Contracts;
    
	public class Bag : IBag
	{
		private List<IItem> items;

		public Bag(IPassenger owner, IEnumerable<IItem> items)
		{
            this.items = new List<IItem>();
			this.Owner = owner;
			this.items.AddRange(items.ToList());
		}

		public IPassenger Owner { get; }

		public IReadOnlyCollection<IItem> Items => this.items.AsReadOnly();
	}
}
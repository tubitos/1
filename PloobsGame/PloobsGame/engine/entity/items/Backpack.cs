using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PloobsGame.engine.entity.items
{
	class Backpack
	{
		List<BaseItem> items;

		public Backpack ()
		{
			items = new List<BaseItem> ();
		}

		public Backpack (int maxSize)
		{
			items = new List<BaseItem> (maxSize);
		}

		public void AddItem (BaseItem item)
		{
			items.Add (item);
		}

		public void DeleteItem (BaseItem item)
		{
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].Equals (item))
				{
					items.RemoveAt (i);
				}
			}
		}

		public void AddItemAt (BaseItem item, int index)
		{
			items.Insert (index, item);
		}

		public void DeleteItemAt (int index)
		{
			items.RemoveAt (index);
		}
	}
}

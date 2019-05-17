using System;
using System.Collections;
using System.Collections.Generic;

namespace jrpg {
	abstract class Inventory {
		private string name;
		private Dictionary<Item, Item> items;

		public Inventory() {
		}

		/// <summary>
		/// Deep Copy constructor
		/// </summary>
		/// <param name="inv"></param>
		public Inventory(Inventory inv) {
		}

		public string GetName() {
			return name;
		}
	}	
}

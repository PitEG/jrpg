using System;

namespace jrpg {
	abstract class Item {
		private string name;

		private static readonly string DEFAULT_NAME = "default";

		public Item() : this(DEFAULT_NAME){
		}

		public Item(string n) {
			this.name = n;
		}

		public string GetName() {
			return this.name;
		}
	}

}

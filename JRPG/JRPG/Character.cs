using System;

namespace JRPG {
	internal abstract class Character {

		private Stats stats;
		private Inventory inventory;
		private string name;

		internal Stats Stats{
			get { return this.stats; }
		}

		internal Inventory Inventory {
			get { return this.inventory; }
		}

		internal string Name {
			get { return this.name; }
		}

		Character() : this("") {
		}

		Character(string name) {
			this.name = name;
		}

		Character(string name, Stats stats) : this(name, stats, new Inventory()) {
			this.stats = new Stats();
		}

		Character(string name, Stats stats, Inventory inventory) {
			this.inventory = inventory;
		}

	}
}

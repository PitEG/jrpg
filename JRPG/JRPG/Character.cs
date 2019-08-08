using System;

namespace JRPG {
	public abstract class Character {

		private Stats stats;
		private Inventory inventory;
		private string name;

		public virtual Stats Stats{
			get { return this.stats; }
		}

		public virtual Inventory Inventory {
			get { return this.inventory; }
		}

		public virtual string Name {
			get { return this.name; }
		}

		internal Character() : this("") {
		}

		internal Character(string name) : this (name, new Stats()){
		}

		internal Character(string name, Stats stats) : this(name, stats, new Inventory()) {
		}

		internal Character(string name, Stats stats, Inventory inventory) {
			this.inventory = inventory;
			this.name = name;
			this.stats = stats;
		}

		public override string ToString() {
			return this.name;
		}

	}
}

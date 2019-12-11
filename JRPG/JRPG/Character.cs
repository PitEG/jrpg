using System;

namespace JRPG {
	[Serializable]
	public class Character {

		protected string name;
		protected Stats stats;
		protected Inventory inventory;
		protected Equipment equipment;
		protected AbilityList abilities;

		//Properties
		public string Name {
			get { return this.name; }
			set { this.name = value; }
		}

		public Stats Stats{
			get { return this.stats; }
		}

		public Inventory Inventory {
			get { return this.inventory; }
		}

		public Character() : this("") {
		}

		public Character(string name) : this (name, new Stats(), new Inventory()){
		}

		public Character(string name, Stats stats, Inventory inventory) {
			this.inventory = inventory;
			this.name = name;
			this.stats = stats;
		}

		public override string ToString() {
			return this.name;
		}

	}

}

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

		public Stats Stats {
			get { return this.stats; }
			set { this.stats = value; }
		}

		public Inventory Inventory {
			get { return this.inventory; }
			set { this.inventory = value; }
		}

		public Equipment Equipment {
			get { return this.equipment; }
			set { this.equipment = value; }
		}

		public AbilityList Abilities {
			get { return this.abilities; }
			set { this.abilities = value; }
		}

		public Character() : this(null) {
		}

		public Character(string name) : 
			this(name, new Stats(), new Inventory()) {
		}

		public Character(string name, Stats stats, Inventory inventory) : 
			this(name, stats, inventory, new Equipment(), new AbilityList()){

		}

		public Character(string name, Stats stats, Inventory inventory, Equipment equipment, AbilityList abilities) {
			this.name = name;
			this.stats = stats;
			this.inventory = inventory;
			this.equipment = equipment;
			this.abilities = abilities;
		}

		public override string ToString() {
			return this.name + "; health: " + stats.Health.Current;
		}

	}

}

using System;
using System.Collections.Generic;

namespace JRPG {
	[Serializable]
	public class Ability {

		protected string name;
		protected string displayName;
		protected Element element;
		protected int power;
		
		public string Name {
			get { return this.name; }
			set { this.name = value; }
		}

		public string DisplayName {
			get { return this.displayName; }
			set { this.displayName = value; }
		}

		public Element Element {
			get { return this.element; }
			set { this.element = value; }
		}

		public int Power {
			get { return this.power; }
			set { this.power = value; }
		}

		public Ability() : this(String.Empty, String.Empty, 0, 0){
		}

		public Ability(string name, string displayName, int power, Element element) {
			this.name = name;
			this.displayName = displayName;
			this.power = power;
			this.element = element;
		}

		public virtual void Use(params Character[] target) {
			//example
			Console.WriteLine("USED ABILITY");
			StatValues health = target[0].Stats.Health;
			Console.WriteLine(health.Current);
			Console.WriteLine(power);
			target[0].Stats.Health =
				new StatValues(health.current - this.power, health.Base);
		}

		public override string ToString() {
			return this.displayName;
		}

		public override int GetHashCode() {
			return this.name.GetHashCode();
		}

		public override bool Equals(object obj) {
			if (((Ability)obj).Name.Equals(this.name)) {
				return true;
			} else {
				return false;
			}
		}

	}

	//example elements
	public enum Element {
		None, Physical, Fire, Water, Earth, Air, Pierce, Blunt
	}

	//example move
	[Serializable]
	public class ExampleMove : Ability {

		public ExampleMove(string name) : base(name, name, 0, Element.None) {
		}

		public override void Use(params Character[] target) {
			Console.WriteLine("example move used");
		}
	}
}

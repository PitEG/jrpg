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
		}

		public string DisplayName {
			get { return this.displayName; }
		}

		public Element Element {
			get { return this.element; }
			set { this.element = value; }
		}

		public int Power {
			get { return this.power; }
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
			//unemplemented
		}

		public override string ToString() {
			return this.name;
		}

		public override int GetHashCode() {
			return name.GetHashCode();
		}

	}

	//example elements
	public enum Element {
		None, Physical, Fire, Water, Earth, Air 
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

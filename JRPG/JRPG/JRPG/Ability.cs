using System;
using System.Collections.Generic;

namespace JRPG {
	public abstract class Ability {

		protected string name = "";
		protected Element element;
		protected int power; 
		
		public string Name {
			get { return this.name; }
		}

		public Element Element {
			get { return this.element; }
			set { this.element = value; }
		}

		protected Ability() : this("", 0, 0){
		}

		protected Ability(string name, int power, Element element) {
			this.name = name;
			this.power = power;
			this.element = element;
		}

		public abstract void Use(params Character[] target);

		public override string ToString() {
			return this.name;
		}

	}

	//example elements
	public enum Element {
		None, Physical, Fire, Water, Earth, Air 
	}

	//example move
	public class ExampleMove : Ability {

		public ExampleMove(string name) : base(name, 0, Element.None) {
		}

		public override void Use(params Character[] target) {
			Console.WriteLine("example move used");
		}
	}
}

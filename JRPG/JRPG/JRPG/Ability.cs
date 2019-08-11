using System;
using System.Collections.Generic;

namespace JRPG {
	public abstract class Ability {

		private string name = "";
		
		string Name {
			get { return this.name; }
		}

		protected Ability() : this(""){
		}

		protected Ability(string name) {
			this.name = name;
		}

		public abstract void Use(params Character[] target);

		public override string ToString() {
			return this.name;
		}

	}

	//example move
	public class ExampleMove : Ability {

		public ExampleMove(string name) : base(name) {
		}

		public override void Use(params Character[] target) {
			Console.WriteLine("example move used");
		}
	}
}

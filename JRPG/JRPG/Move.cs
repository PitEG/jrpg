using System;
using System.Collections.Generic;

namespace JRPG {
	public abstract class Move {

		private string name = "";
		
		string Name {
			get { return this.name; }
		}

		protected Move() : this(""){
		}

		protected Move(string name) {
			this.name = name;
		}

		public abstract void Use(params Character[] target);

		public override string ToString() {
			return this.name;
		}

	}

	//example move
	public class ExampleMove : Move {

		public ExampleMove(string name) : base(name) {
		}

		public override void Use(params Character[] target) {
			Console.WriteLine("example move used");
		}
	}
}

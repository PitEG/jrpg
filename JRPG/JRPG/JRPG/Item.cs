using System;

namespace JRPG {
	public abstract class Item {

		protected string name;

		protected Item() : this("") {
		}

		protected Item(string name) {
			this.name = name;
		}

		public abstract void Use();

		public override string ToString() {
			return this.name;
		}
	}


	public class ItemExample : Item {

		public ItemExample(string name) {
			this.name = name;
		}

		public override void Use() {
			Console.WriteLine("Used ItemExample");
		}
	}
}

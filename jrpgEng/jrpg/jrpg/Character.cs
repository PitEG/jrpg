using System;

namespace jrpg {
	abstract class Character {
		private string name;
		private Inventory inv;
		

		public string GetName() {
			return name;
		}
	}
}

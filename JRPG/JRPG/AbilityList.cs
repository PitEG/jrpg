using System;

namespace JRPG{

	[Serializable]
	public class AbilityList {
		protected Ability[] abilities;
		private static readonly int DEFAULT_SIZE = 25;
	
		public Ability[] Abilities {
			get {return this.abilities; }
		}

		public AbilityList() : this(DEFAULT_SIZE) {
		}

		public AbilityList(int size) {
			this.abilities = new Ability[size];
		}
	}
}

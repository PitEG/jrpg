using System;

namespace JRPG{

	[Serializable]
	public class AbilityList {
		protected Ability[] abilities; //possibly degenerate
		protected string[] list;
		private static readonly int DEFAULT_SIZE = 10;

		private Ability[] Abilities { //possible degenerate
			get { return this.abilities; }
			set { this.abilities = value; }
		}

		public string[] List {
			get { return this.list; }
			set { this.list = value; }
		}

		public AbilityList() : this(DEFAULT_SIZE) {
		}

		public AbilityList(int size) {
			this.abilities = new Ability[size];
			this.list = new string[size];
		}

		/// <summary>
		/// Returns true if the ability is not in the list already and can be
		/// added. Returns false if the list is full or if the ability exists
		/// in the list
		/// </summary>
		/// <param name="abilityName"></param>
		/// <returns></returns>
		public bool Add(string abilityName) {
			for (int i = 0; i < list.Length; i++) {
				if (list[i] != null && list[i].Equals(abilityName)) {
					return false;
				}
			}
			for (int i = 0; i < list.Length; i++) {
				if (list[i] == null) {
					abilities[i] = AbilityCatalog.Get(abilityName);
					list[i] = abilityName;
					return true;
				}
			}
			return false;
		}
	}
}

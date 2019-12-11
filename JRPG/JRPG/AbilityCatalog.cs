using System;
using System.Collections.Generic;

namespace JRPG {
	[Serializable]
	public static class AbilityCatalog {
		private static Dictionary<Ability,Ability> abilities; 
		
		public static Dictionary<Ability, Ability> Abilities {
			get { return abilities; }
			set { abilities = value; }
		}

		static AbilityCatalog() {
			abilities = new Dictionary<Ability, Ability>();
		}

		/// <summary>
		/// return true if the ability was not already added and adds it,
		/// returns false otherwise and will not add the ability
		/// </summary>
		/// <param name="ability"></param>
		/// <returns></returns>
		public static bool Add(Ability ability) {
			if (abilities.ContainsKey(ability)) {
				return false;
			} else {
				abilities.Add(ability, ability);
				return true;
			}
		}

		/// <summary>
		/// Returns true if the ability is in the list, false otherwise
		/// </summary>
		/// <param name="ability"></param>
		/// <returns></returns>
		public static bool Remove(Ability ability) {
			if (!abilities.ContainsKey(ability)) {
				return false;
			} else {
				abilities.Add(ability, ability);
				return true;
			}
		}

		//Get an ability
		public static Ability Get(Ability ability) {
			if (abilities.ContainsKey(ability)) {
				return abilities[ability];
			} else {
				return null;
			}
		}

		//I think this creates garbage
		public static void GetListNonAlloc(Ability[] abilityArray) {
			int index = 0;
			foreach (Ability ability in abilities.Values) {
				if (abilityArray[abilityArray.Length - 1] == null) {
					abilityArray[index] = ability;
				} else {
					break;
				}
			}
		}
	}
}

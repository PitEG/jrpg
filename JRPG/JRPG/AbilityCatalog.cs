using System;
using System.Collections.Generic;

namespace JRPG {
	[Serializable]
	public static class AbilityCatalog {
		private static Dictionary<int, Ability> abilities;
		
		public static Dictionary<int, Ability> Abilities {
			get { return abilities; }
			set { abilities = value; }
		}

		static AbilityCatalog() {
			abilities = new Dictionary<int, Ability>();
		}

		/// <summary>
		/// return true if the ability was not already added and adds it,
		/// returns false otherwise and will not add the ability
		/// </summary>
		/// <param name="ability"></param>
		/// <returns></returns>
		public static bool Add(Ability ability) {
			if (abilities.ContainsKey(ability.GetHashCode())){
				return false;
			} else {
				abilities.Add(ability.GetHashCode(), ability);
				return true;
			}
		}

		/// <summary>
		/// Returns true if the ability is in the list, false otherwise
		/// </summary>
		/// <param name="ability"></param>
		/// <returns></returns>
		public static bool Remove(Ability ability) {
			if (!abilities.ContainsKey(ability.GetHashCode())) {
				return false;
			} else {
				abilities.Remove(ability.GetHashCode());
				return true;
			}
		}

		//Get an ability
		public static Ability Get(string ability) {
			if (abilities.ContainsKey(ability.GetHashCode())) {
				return abilities[ability.GetHashCode()];
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

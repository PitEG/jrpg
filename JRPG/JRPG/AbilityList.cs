using System;
using System.Collections.Generic;

namespace JRPG {
	public class AbilityList {
		protected Dictionary<Ability,Ability> abilities; 

		public AbilityList() {
			abilities = new Dictionary<Ability, Ability>();
		}

		/// <summary>
		/// return true if the ability was not already added and adds it,
		/// returns false otherwise and will not add the ability
		/// </summary>
		/// <param name="ability"></param>
		/// <returns></returns>
		public bool Add(Ability ability) {
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
		public bool Remove(Ability ability) {
			if (!abilities.ContainsKey(ability)) {
				return false;
			} else {
				abilities.Add(ability, ability);
				return true;
			}
		}

		public Ability Get(Ability ability) {
			if (abilities.ContainsKey(ability)) {
				return abilities[ability];
			} else {
				return null;
			}
		}

		//I think this creates garbage
		public void GetListNonAlloc(Ability[] abilityArray) {
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

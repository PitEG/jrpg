using System;
namespace JRPG {
	internal class Stats {

		private static int NumberOfStats = 3;
		enum StatNames {
			//example stats			
			Health, Mana, Attack
		}

		//The stat values must be ordered in the array as it is ordered
		//in the enumeration above.
		private	StatValues[] statValues;

		internal StatValues Health {
			 get { return statValues[(int)StatNames.Health]; }
		}

		internal StatValues Mana {
			get { return statValues[(int)StatNames.Mana]; }
		}

		internal StatValues Attack {
			get { return statValues[(int)StatNames.Mana]; }
		}

		internal Stats() {
			statValues = new StatValues[NumberOfStats];
		}

	}

	public struct StatValues {
		public int current;
		public int baseValue;
	}
}

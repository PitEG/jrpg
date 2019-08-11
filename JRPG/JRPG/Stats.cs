using System;
namespace JRPG {
	public class Stats {

		private static readonly int NumberOfStats = 3;
		enum StatNames {
			//example stats			
			Health, Mana, Attack
		}

		//The stat values must be ordered in the array as it is ordered
		//in the enumeration above.
		private	StatValues[] statValues;

		public StatValues Health {
			 get { return statValues[(int)StatNames.Health]; }
		}

		public StatValues Mana {
			get { return statValues[(int)StatNames.Mana]; }
		}

		public StatValues Attack {
			get { return statValues[(int)StatNames.Mana]; }
		}

		public Stats() {
			statValues = new StatValues[NumberOfStats];
		}

	}

	public struct StatValues {
		public int current;
		public int baseValue;
	}
}

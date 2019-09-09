using System;
namespace JRPG {

	public struct StatValues {
		public int current;
		public int baseValue;
	}

	public class Stats {

		//this number MUST match the number of enumerator values
		//must represent the number of stats in the statValue 
		//instance variable
		private static readonly int NumberOfStats = 3;
		public enum StatName {
			//example stats			
			Health, Mana, Attack
		}

		//The stat values must be ordered in the array as it is ordered
		//in the enumeration above.
		private	StatValues[] statValues;

		#region Properties
		public StatValues Health {
			 get { return statValues[(int)StatName.Health]; }
		}

		public StatValues Mana {
			get { return statValues[(int)StatName.Mana]; }
		}

		public StatValues Attack {
			get { return statValues[(int)StatName.Mana]; }
		}
		#endregion

		public Stats() {
			statValues = new StatValues[NumberOfStats];
		}

		public void SetStatCurrent(StatName stat, int n) {
			this.statValues[(int)stat].current = n;
		}

		public void SetStatBaseValue(StatName stat, int n) {
			this.statValues[(int)stat].baseValue = n;
		}

	}

}

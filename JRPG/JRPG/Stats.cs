using System;
namespace JRPG {

	public struct StatValues {
		public int current;
		public int baseValue;
	}

	public struct StatusEffect {
		public bool enabled;
		public int duration; 
	}

	public class Stats {

		private StatValues health;
		private StatValues mana;
		private StatValues attack;
		
		private StatusEffect poisoned;
		private StatusEffect weakened;
		private StatusEffect strengthened;

		private static readonly int NumberOfStats = 3;
		public enum StatName {
			//example stats			
			Health, Mana, Attack
		}

		private static readonly int NumberOfDebufs = 3;
		public enum StatusEffectName {
			Poisoned, Weakened, Strengthened
		}

		#region Properties
		public StatValues Health {
			get { return health; }
		}

		public StatValues Mana {
			get { return health; }
		}

		public StatValues Attack {
			get { return attack; }
		}

		#endregion

		public Stats() {
			//stats
			health = new StatValues();
			mana = new StatValues();
			attack = new StatValues();

			//status effects
			poisoned = new StatusEffect();
			weakened = new StatusEffect();
			strengthened = new StatusEffect();
		}

	}

}

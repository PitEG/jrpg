﻿using System;

namespace JRPG {
	[Serializable]
	public struct StatValues {
		public int current;
		public int baseValue;
	}

	[Serializable]
	public struct StatusEffect {
		public bool enabled;
		public int duration; 
	}

	[Serializable]
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

		public StatusEffect Poisoned {
			get { return poisoned; }
		}

		public StatusEffect Weakened {
			get { return weakened; }
		}

		public StatusEffect Strengthened {
			get { return strengthened; }
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

		public Stats(Stats stats) {
			CopyStats(stats);
		}

		private void CopyStats(Stats stats) {
			this.health = stats.health;
			this.mana = stats.mana;
			this.attack = stats.attack;
			this.poisoned = stats.poisoned;
			this.weakened = stats.weakened;
			this.strengthened = stats.strengthened;
		}

	}

}

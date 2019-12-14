using System;

namespace JRPG {
	[Serializable]
	public struct StatValues {
		public int current;
		public int baseValue;

		public int Current {
			get { return this.current; }
			set { this.current = value; }
		}

		public int Base {
			get { return this.baseValue; }
			set { this.baseValue = value; }
		}

		public StatValues(int current, int baseValue) {
			this.current = current;
			this.baseValue = baseValue;
		}

		public void Add(int amount) {
			this.current += amount;
		}

		public void AddBase(int amount) {
			this.baseValue = amount;
		}
	}

	[Serializable]
	public struct StatusEffect {
		public bool enabled;
		public int duration;

		public bool Enabled {
			get { return this.enabled; }
			set { this.enabled = value; }
		}

		public int Duration {
			get { return this.duration; }
			set { this.duration = value; }
		}

		public StatusEffect(bool enabled, int duration) {
			this.enabled = enabled;
			this.duration = duration;
		}

		public void Enable(int duration) {
			this.enabled = true;
			this.duration = duration;
		}

		public void Disable() {
			this.enabled = false;
			this.duration = 0;
		}

		public void Tick() {
			this.duration--;
		}
	}

	[Serializable]
	public class Stats {

		private int level;

		private StatValues health;
		private StatValues mana;
		private StatValues attack;
		private StatValues aptitude;
		private StatValues defense;
		private StatValues speed;

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
		public int Level {
			get { return this.level; }
			set { this.level = value; }
		}

		public StatValues Health {
			get { return health; }
			set { this.health = value; }
		}

		public StatValues Mana {
			get { return mana; }
			set { this.mana = value; }
		}

		public StatValues Attack {
			get { return attack; }
			set { this.attack = value; }
		}

		public StatValues Aptitude {
			get { return this.aptitude; }
			set { this.aptitude = value; }
		}

		public StatValues Speed {
			get { return this.speed; }
			set { this.speed = value; }
		}

		public StatusEffect Poisoned {
			get { return poisoned; }
			set { this.poisoned = value; }
		}

		public StatusEffect Weakened {
			get { return weakened; }
			set { this.weakened = value; }
		}

		public StatusEffect Strengthened {
			get { return strengthened; }
			set { this.strengthened = value; }
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

		public void LevelUp() {
			this.level++;
		}

		private void CopyStats(Stats stats) {
			this.health = stats.health;
			this.mana = stats.mana;
			this.attack = stats.attack;
			this.aptitude = stats.aptitude;
			this.defense = stats.defense;
			this.speed = stats.speed;
			this.poisoned = stats.poisoned;
			this.weakened = stats.weakened;
			this.strengthened = stats.strengthened;
		}
	}
}

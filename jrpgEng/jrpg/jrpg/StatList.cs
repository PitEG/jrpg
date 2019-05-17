using System;
using System.Collections.Generic;

namespace jrpg {
	class StatList {
		private Dictionary<String, Stat> stats;
		private Stat defaultStat;

		public StatList() {
			this.stats = new Dictionary<String, Stat>();
			defaultStat = new Stat();
		}

		/// <summary>
		/// Copy Constructor
		/// </summary>
		/// <param name="stats"></param>
		public StatList(StatList stats) {
		}

		/// <summary>
		/// Add a particular stat to the list
		/// </summary>
		/// <param name="stat"></param>
		public bool AddStat(Stat stat) {
			if (!(stats.ContainsKey(stat.GetName()))) {
				return false;
			}

			//add stat to hashmap
			stats.Add(stat.GetName(), stat);

			return true;
		}

		public Stat GetStat(String stat) {
			if (stats.ContainsKey(stat)) {
				return stats[stat];
			} else {
				return null;
			}
		}


	}
}

using System;

namespace JRPG {
	class Program {
		static void Main(string[] args) {
			testStats();
		}

		static void testStats() {
			Stats stats = new Stats();
			StatValues health = stats.Health;
			health.current = 10;
			health.baseValue = 20;
			Console.WriteLine("{0} {1}", health.current, health.baseValue);
		}
	}
}

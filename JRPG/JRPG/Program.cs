using System;

namespace JRPG {
	class Program {
		static void Main(string[] args) {
			//testStats();
			//testCharacterAndTeams();
			testBattle();
		}

		static void testStats() {
			Stats stats = new Stats();
			StatValues health = stats.Health;
			health.current = 10;
			health.baseValue = 20;
			Console.WriteLine("{0} {1}", health.current, health.baseValue);
		}

		static void testCharacterAndTeams() {
			Character character1 = new CharacterExample("Jerma1", new Stats(), new Inventory());
			Character character2 = new CharacterExample("Jerma2", new Stats(), new Inventory());
			Character character3 = new CharacterExample("Jerma3", new Stats(), new Inventory());
			Character character4 = new CharacterExample("Jerma4", new Stats(), new Inventory());
			Character character5 = new CharacterExample("Jerma5", new Stats(), new Inventory());

			Character[] characterArray1 = { character1, character2 };
			Team team1 = new Team(characterArray1);
			Team team2 = new Team();
			team2.AddMember(character3);
			Character[] characterArray2 = { character4, character5 };
			team2.AddMembers(characterArray2);
			Console.WriteLine(team1);
			Console.WriteLine(team2);
			team2.RemoveMember(character4);
			Console.WriteLine(team2);

		}

		static void testBattle() {
			Character character1 = new CharacterExample("Jerma1", new Stats(), new Inventory());
			Character character2 = new CharacterExample("Jerma2", new Stats(), new Inventory());
			Character character3 = new CharacterExample("Jerma3", new Stats(), new Inventory());
			Character character4 = new CharacterExample("Jerma4", new Stats(), new Inventory());
			Character character5 = new CharacterExample("Jerma5", new Stats(), new Inventory());

			Character[] characterArray1 = { character1, character2 };
			Character[] characterArray2 = { character3, character4, character5 };

			Team team1 = new Team(characterArray1);
			Team team2 = new Team(characterArray2);

			Battle battle = new Battle();
			battle.AddTeam(team1);
			battle.AddTeam(team2);
			battle.SortTurnsRandomly();

			Console.WriteLine("{0}\n{1}", team1, team2);
			Console.WriteLine("{0}\n", battle);
		}
	}
}

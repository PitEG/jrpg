using System;

namespace JRPG {
	class Program {
		static void Main(string[] args) {
			Tester.TestInventory();
		}
	}

	//Testing Purposes only
	public static class Tester {

		static Character character = new Character("Jerma");
		static Inventory inv = new Inventory(4);

		public static void TestMove() {
			Move move = new ExampleMove("example move");
			Console.WriteLine(move);
			move.Use(character, character);
			move.Use();

		}

		public static void TestInventory() {
			inv.AddItem(new ItemExample("item 1"));
			inv.AddItem(new ItemExample("item 2"));
			inv.AddItem(new ItemExample("item 3"));
			inv.AddItem(new ItemExample("item 4"));

			Console.WriteLine(inv);

			Item[] spillOver = inv.ChangeSize(2);

			Console.WriteLine(inv.Size);
			Console.WriteLine(inv);
			for (int i = 0; i < spillOver.Length; i++)
				Console.WriteLine("excess " + spillOver[0]);
		}

	}
}

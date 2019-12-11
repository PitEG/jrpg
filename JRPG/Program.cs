using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using JRPG;
using JRPG.SampleGame;

namespace JRPG.Sample {
	class Program {
		static void Main(string[] args) {
			Tester.TestAbilityCatalogSave();
		}
	}

	//Testing Classes 
	public static class Tester {

		static Character character = new Character("Jerma");
		static Inventory inv = new Inventory(4);

		public static void TestMove() {
			Ability move = new ExampleMove("example move");
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

		public static void TestSave() {
			Character character = new Character("simon");
			BinaryFormatter formatter = new BinaryFormatter();
			//save
			using (Stream fs = File.Create("test.char")) {
				formatter.Serialize(fs, character);
				Console.WriteLine("save");
			}
			Console.WriteLine(character.Name);
			character = null;
			//load
			using (Stream fs = File.Open("test.char", FileMode.Open)) {
				character = (Character)formatter.Deserialize(fs);
				Console.WriteLine("load");
			}
			Console.WriteLine(character.Name);
			character.Name = "something new";
			Console.WriteLine(character.Name);
			//load
			using (Stream fs = File.Open("test.char", FileMode.Open)) {
				character = (Character)formatter.Deserialize(fs);
				Console.WriteLine("load");
			}
			Console.WriteLine(character.Name);

		}

		public static void TestAbilityCatalogSave() {
			Ability a1 = new Ability("1", "one", 1, Element.Air);
			//Ability a2 = new Ability("2", "two", 1, Element.Fire);
			//Ability a3 = new Ability("3", "three", 1, Element.Earth);
			//Ability a4 = new Ability("4", "four", 1, Element.Water);
			AbilityCatalog.Add(a1);
			//AbilityCatalog.Add(a2);
			//AbilityCatalog.Add(a3);
			//AbilityCatalog.Add(a4);

			JsonSaver.SaveAbilityCatalog("abilitycatalog");
			JsonSaver.LoadAbilityCatalog("abilitycatalog");
		}
	}

	public class Game {

		public Game() {
		}
	}
}

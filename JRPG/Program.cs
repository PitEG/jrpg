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
			Game game = new Game();
			game.Play();
			/*
			Tester.TestAbilityCatalogSave();
			Tester.TestCharacterSave();
			Console.WriteLine(AbilityCatalog.Abilities.Count);
			*/
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
			Ability a2 = new Ability("2", "two", 1, Element.Fire);
			Ability a3 = new Ability("3", "three", 1, Element.Earth);
			Ability a4 = new Ability("4", "four", 1, Element.Water);
			AbilityCatalog.Add(a1);
			AbilityCatalog.Add(a2);
			AbilityCatalog.Add(a3);
			AbilityCatalog.Add(a4);

			JsonSaver.SaveAbilityCatalog("abilitycatalog.data");
			JsonSaver.LoadAbilityCatalog("abilitycatalog.data");
		}

		public static void TestCharacterSave() {
			Character c1 = new Character("Jerma");		
			Character c2 = new Character("Steven");
			c1.Abilities.Add("1");
			c2.Abilities.Add("2");
			c1.Stats.Health = new StatValues(10, 10);
			Character[] cList = { c1, c2 };

			JsonSaver.SaveCharacters(cList, "characters.data");
			cList = JsonSaver.LoadCharacters("characters.data");
			Console.WriteLine("SECOND SAAAAAAAAAAAAVE");
			JsonSaver.SaveCharacters(cList, "characters.data");
		}
	}

	class Game {
		Character[] characters;

		public Game() {

		}

		public void Play() {
			Console.WriteLine("Hello!");
			characters = new Character[2];

			//Read Files
			JsonSaver.LoadAbilityCatalog("swordofthewanderer/abilitycatalog.json");
			Console.WriteLine("loaded abilities");
			characters = JsonSaver.LoadCharacters("swordofthewanderer/playablecharacters.json");
			Console.WriteLine("loaded characters");

			Battle battle = new Battle();
			Team goodGuys = new Team(characters[0]);
			Console.WriteLine("Created Team: " + goodGuys.Members[0]);
			Team badGuys = new Team(characters[1]);
			Console.WriteLine("Created Team: " + badGuys.Members[0]);

			battle.AddTeam(goodGuys);
			battle.AddTeam(badGuys);
			battle.SortTurnTemp();
			while (characters[0].Stats.Health.Current > 0 &&
				characters[1].Stats.Health.Current > 0) {
				Console.WriteLine("Current Character: " + battle.CurrentCharacter);
				TakeTurn(battle.CurrentCharacter, battle.NextCharacter());
				Console.WriteLine("Stats Now:\n" + characters[0] + "\n" + characters[1]);
			}
			Console.WriteLine("Game Over");

		}

		private void TakeTurn(Character character, Character other) {
			Console.WriteLine("What move do you want to do?");
			for (int i = 0; i < character.Abilities.List.Length; i++) {
				if (character.Abilities.List[i] == null) {
					break;
				}
				Console.WriteLine(character.Abilities.List[i].ToString());
			}
			string move = Console.ReadLine();
			if (move.Equals(character.Abilities.List[0]) ||
				move.Equals(character.Abilities.List[1])) {
				Ability ability = AbilityCatalog.Get(move);
				ability.Use(other);
			} else {
				TakeTurn(character, other);
			}
		}
	}
}

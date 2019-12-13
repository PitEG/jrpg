using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JRPG.SampleGame {
	public static class JsonSaver {
		private static JsonSerializerOptions options;

		static JsonSaver() {
			options = new JsonSerializerOptions();
			options.WriteIndented = true;
		}

		//Ability Catalog
		public static void SaveAbilityCatalog(string path) {
			Dictionary<int, Ability> abilityCatalog = AbilityCatalog.Abilities;
			Ability[] abilities = new Ability[abilityCatalog.Count];
			string jsonString;

			File.Delete(path);
			File.CreateText(path).Close();
			int i = 0;
			foreach (var a in abilityCatalog) {
				abilities[i] = a.Value;
				i++;
			}
			jsonString = JsonSerializer.Serialize<Ability[]>(abilities, options);
			//Console.WriteLine(jsonString);
			File.AppendAllText(path, jsonString);
		}

		public static void LoadAbilityCatalog(string path) {
			string jsonString = File.ReadAllText(path);
			Console.WriteLine(jsonString);
			Ability[] abilities = JsonSerializer.Deserialize<Ability[]>(jsonString, options);
			for (int i = 0; i < abilities.Length; i++) {
				AbilityCatalog.Add(abilities[i]);
			}
		}

		public static void SaveCharacters(Character[] character, string path) {
			string jsonString;
			File.Delete(path);
			File.CreateText(path).Close();
			jsonString = JsonSerializer.Serialize<Character[]>(character, options);
			Console.WriteLine(jsonString);
			File.AppendAllText(path, jsonString);
		}

		public static Character[] LoadCharacters(string path) {
			string jsonString = File.ReadAllText(path);
			Console.WriteLine(jsonString);
			return JsonSerializer.Deserialize<Character[]>(jsonString, options);
		}

		private static void debug(Character[] characters) {
			for (int i = 0; i < characters.Length; i++) {
				Console.WriteLine(characters[i]);
			}
		}
	}
}

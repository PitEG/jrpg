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
			Dictionary<Ability, Ability> abilityCatalog = AbilityCatalog.Abilities;
			string jsonString;

			File.Delete(path);

			foreach (var a in abilityCatalog) {
				jsonString = JsonSerializer.Serialize<Ability>(a.Value, options);
				File.AppendAllText(path, jsonString + "\n");
			}
		}

		private static readonly int SIZE_OF_ABILITY_OBJECT = 6;
		public static void LoadAbilityCatalog(string path) {
			using (StreamReader sr = new StreamReader(path)) {
				string currentObject;
				while ((currentObject = sr.ReadLine()) != null) {
					for (int i = 0; i < SIZE_OF_ABILITY_OBJECT; i++) {
						currentObject += sr.ReadLine() + "\n";
					}
					Ability ability = JsonSerializer.Deserialize<Ability>(currentObject, options);
					AbilityCatalog.Add(ability);
				}
			}
		}

		//Character
		public static void SaveCharacters(Character character, string path) {

		}

		public static void LoadCharacters(string path) {

		}

		public static void LoadNewCharacters(string path) {

		}

	}
}

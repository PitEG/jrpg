using System;
using System.Collections.Generic;

namespace JRPG {
	public class Battle {

		protected List<Team> teams;
		protected Character currentCharacter;
		protected List<Character> turnOrder;

		public List<Team> Teams {
			get { return teams; }
		}

		public Character CurrentCharacter {
			get { return currentCharacter; }
		}

		public List<Character> TurnOrder {
			get { return turnOrder; }
		}

		public Battle() {
			this.teams = new List<Team>();
			turnOrder = new List<Character>();
			SortTurnsRandomly(); //placeholder sorting method
			ResetToFirstCharacter();
		}

		public void AddTeam(Team team) {
			this.teams.Add(team);
		}

		private void RemoveAll() {
			teams.Clear();
			turnOrder.Clear();
			currentCharacter = null;
		}

		public void ResetToFirstCharacter() {
			if (turnOrder.Count > 0) {
				currentCharacter = turnOrder[0];
			}
		}

		#region Sorting

		//sorting methods
		public void SortTurnsRandomly() {
			int numberOfCharacters = 0;
			foreach (Team team in teams) {
				foreach (Character character in team.Members) {
					numberOfCharacters++;
				}
			}

			List<Character> charactersUnordered = new List<Character>();
			foreach (Team team in teams) {
				foreach (Character character in team.Members) {
					charactersUnordered.Add(character);
				}
			}

			Random random = new Random();
			for (int i = 0; i < numberOfCharacters; i++) {
				int indexToRemoveAt = random.Next(charactersUnordered.Count);
				turnOrder.Add(charactersUnordered[indexToRemoveAt]);
				charactersUnordered.RemoveAt(indexToRemoveAt);
			}
		}

		#endregion

		public override string ToString() {
			string orderOfCharacters = "";
			foreach (Character character in turnOrder) {
				orderOfCharacters += character + "; ";
			}

			return orderOfCharacters;
		}
	}
}

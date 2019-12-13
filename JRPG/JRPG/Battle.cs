using System;
using System.Collections.Generic;

namespace JRPG {
	public class Battle {

		protected List<Team> teams;
		protected Character currentCharacter;
		protected List<Character> turnOrder;
		protected Queue<Character> turnQueue;

		public List<Team> Teams {
			get { return teams; }
		}

		public Character CurrentCharacter {
			get {
				if (currentCharacter == null) {
					throw new Exception("Null Character Reference");
				}
				return currentCharacter;
			}
		}

		public List<Character> TurnOrder {
			get { return turnOrder; }
		}

		public Battle() {
			this.teams = new List<Team>();
			this.turnOrder = new List<Character>();
			this.turnQueue = new Queue<Character>();
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

		public Character NextCharacter() {
			turnQueue.Enqueue(currentCharacter); 
			turnQueue.Dequeue();
			currentCharacter = turnQueue.Peek();
			return turnQueue.Peek();
		}

		#region Sorting

		//sorting methods
		public void SortTurnTemp() {
			turnOrder.Add(teams[0].Members[0]);
			turnQueue.Enqueue(teams[0].Members[0]);
			turnOrder.Add(teams[1].Members[0]);
			turnQueue.Enqueue(teams[1].Members[0]);
			currentCharacter = teams[0].Members[0];
		}
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

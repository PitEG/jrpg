﻿using System;
using System.Collections.Generic;

namespace JRPG {
	public class Team {

		private List<Character> members;

		public List<Character> Members {
			get { return members; }
		}

		public Team() {
			this.members = new List<Character>();
		}

		public Team(Character member) : this() {
			AddMember(member);
		}

		public Team(Character[] members) : this() {
			AddMembers(members);
		}

		public void AddMember(Character member) {
			this.members.Add(member);
		}

		public void AddMembers(Character[] members) {
			for (int i = 0; i < members.Length; i++) {
				if (members[i] is Character) {
					this.members.Add(members[i]);
				}
			}
		}
		
		/// <summary>
		///This method removes the character given that both the passed object
		///and the object you wish to remove are the same object referenced in 
		///the heap
		/// </summary>
		/// <param name="character"></param>
		public void RemoveMember(Character character) {
			members.Remove(character);
		}

		public override string ToString() {
			string listOfCharacters = "";
			foreach (Character member in members) {
				listOfCharacters += member.ToString() + "; ";
			}
			return listOfCharacters;
		}
	}
}

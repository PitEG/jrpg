using System;
using System.Collections.Generic;

namespace jrpg {
	class Stat {
		private int currentValue;
		private int defaultValue;
		private string name;

		private readonly static String DEFAULT_NAME = "default";

		public Stat() : this(DEFAULT_NAME, 0){
		}

		public Stat(string name, int dValue) {
			this.defaultValue = dValue;
			this.name = name;
		}

		/// <summary>
		/// Stat Hash Function
		/// </summary>
		/// <returns></returns>
		override public int GetHashCode() {
			return name.GetHashCode();
		}

		public string GetName() {
			return name;
		}

		public int GetCurrent() {
			return currentValue;
		}

		public int GetDefault() {
			return defaultValue;
		}

		public void SetCurrent(int v) {
			this.currentValue = v;
		}

		public void SetDefualt(int v) {
			this.defaultValue = v;
		}

	}
}

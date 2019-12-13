using System;

namespace JRPG {
	[Serializable]
	public class Equipment {
		protected Item helmet;
		protected Item shirt;
		protected Item pants;
		protected Item shoes;

		public Item Helmet {
			get { return this.helmet; }
		}
		public Item Shirt {
			get { return this.shirt; }
		}
		public Item Pants {
			get { return this.pants; }
		}
		public Item Shoes {
			get { return this.shoes; }
		}

		public Equipment() : this(null, null, null, null) {
		}

		public Equipment(Item helmet, Item shirt, Item pants, Item shoes) {
			this.helmet = helmet;
			this.shirt = shirt;
			this.pants = pants;
			this.shoes = shoes;
		}
	}
}

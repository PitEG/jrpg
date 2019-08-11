using System;
using System.Collections.Generic;

namespace JRPG {
	public class Inventory {

		private Item[] itemArray;

		public Item[] Items {
			get { return this.itemArray; }
		}

		public int Size {
			get { return this.itemArray.Length; }
		}

		public Inventory() : this(1) {
		}

		public Inventory(int size) {
			itemArray = new Item[size];
		}

		public Inventory(Item[] items) {
			this.itemArray = items;
		}

		/// <summary>
		/// Deep copy the inventory's original item array into a new one
		/// which will replace the old one. Items will be "squeezed"
		/// into the new array and any excess items will be returned
		/// as an array of Items
		/// </summary>
		/// <param name="size"></param>
		public Item[] ChangeSize(int size) {
			Item[] newItemArray = new Item[size];
			bool isBigger = size > this.Size;
			Item[] excessItemArray = new Item[ isBigger ? 1 : this.Size - size ] ;

			//moves items over as long as there is room. any excesss
			//is put into the excess item array
			for (
				int newIndex = 0, oldIndex = 0, excessIndex = 0; 
				oldIndex < this.Size; 
				oldIndex++) {

				if (this.Items[oldIndex] != null && newIndex < size) {
					newItemArray[newIndex++] = this.Items[oldIndex];
				} else if (this.Items[oldIndex] != null) {
					excessItemArray[excessIndex++] = this.Items[oldIndex];
				}
			}

			this.itemArray = newItemArray;
			return excessItemArray;
		}

		public bool AddItem(Item item) {
			for (int i = 0; i < itemArray.Length; i++) {
				if (itemArray[i] == null) {
					itemArray[i] = item;

					//return true for successful addition
					return true;
				}
			}

			//return false if all inventory slots are full
			return false;
		}

		public override string ToString() {
			string itemArrayString = "{Items: ";
			bool firstItem = true;
			for (int i = 0; i < itemArray.Length; i++) {
				if (itemArray[i] != null) {
					itemArrayString += (firstItem ? "" : ", ") +
						itemArray[i];
					firstItem = false;
				}
			}
			itemArrayString += "}";

			return itemArrayString;
		}
	}
}

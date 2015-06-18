using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Container : MonoBehaviour {
	
	private List<Item> myItems;

	public Container() {
		myItems = new List<Item>();
	}

	public void addItem(Item i) {
		myItems.Add(i);
	}

	public void removeItem(int index) {
		myItems.RemoveAt(index);
	}

	public void numItems(int index, int quantity) {
		myItems[index].Quantity = quantity;
	}
	public int getItemQuantity(int index) {
		return myItems[index].Quantity;
	}
	public int getItemQuality(int index) {
		return myItems[index].Quality;
	}
	public int getItemDurability(int index) {
		return myItems[index].Durability;
	}
	public string ToString() {
		return myItems.ToString();
	}
}

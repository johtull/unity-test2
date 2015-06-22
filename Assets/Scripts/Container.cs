using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Container : MonoBehaviour {
	
	private List<Item> myItems;

	public Container() {
		myItems = new List<Item>();
	}

	public Item getItem(int index) {
		return myItems [index];
	}

	public void addItem(Item i) {
		myItems.Add(i);
	}
	public void addItem(Item i, int quantity) {
		i.Quantity = quantity;
		myItems.Add(i);
	}
	public void removeItem(int index) {
		myItems.RemoveAt(index);
	}

	//returns -1 if not found
	public int hasItem(Item i) {
		if (isEmpty ()) {
			return -1;
		} else {
			return myItems.IndexOf(i);
		}
	}
	public bool isEmpty() {
		return myItems.Count < 1;
	}

	public void addQuantity(int index, int quan) {
		myItems [index].addQuantity (quan);
	}

	public void numItems(int index, int quantity) {
		myItems[index].Quantity = quantity;
	}
	public string getItemName(int index) {
		return myItems [index].Iname;
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
	public void print() {
		for (int i = 0; i < myItems.Count; ++i) {
			print ("Item " + i + ": " + getItemName(i) + " (" + getItemQuantity(i) + ")");
		}
	}
}

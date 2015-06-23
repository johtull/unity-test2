using UnityEngine;
using System.Collections;

public class Backpack : Container {
	private int capacity;
	private Container backpack;

	public Backpack() {
		capacity = 20;
		backpack = new Container ();
	}
	public Backpack(Container b) {
		backpack = b;
		capacity = 20;
	}

	//parse gameObject name, grab item from db, add to backpack
	public void addBackpackItem(string itemName) {
		Item myNewItem = null;
		try {
			//format: "Item (10)"
			int targetQuanIndexStart = itemName.IndexOf("(") + 1;
			int targetQuan = 0;
			if(targetQuanIndexStart > 0) {
				targetQuan = int.Parse(itemName.Substring(targetQuanIndexStart, (itemName.Length - targetQuanIndexStart - 1)));
			}
			//if contains quantity, parse out
			if(targetQuan != 0) {
				//grab item from db, update quantity
				myNewItem = Globals.getItemByName(itemName.Substring(0, targetQuanIndexStart - 2));
				myNewItem.Quantity = targetQuan;
				//if backpack already has item, update quantity
				int hasItemIndex = backpack.hasItem(myNewItem.Iname);
				if(hasItemIndex > -1) {
					//if item is stackable, increment item quantity
					if(backpack.getItem(hasItemIndex).Stackable) {
						//THIS WILL ADD NEGATIVE
						backpack.addQuantity(hasItemIndex, targetQuan);
					//if not stackable, add to inventory
					}else {
						backpack.addItem(myNewItem);
					}
				//else, add new item
				}else {
					backpack.addItem(myNewItem);
				}
				
			//else, item contains no quantity in name - grab by name, add to backpack
			}else {
				myNewItem = Globals.getItemByName(itemName);
				if(myNewItem.Iname != null) {
					//if backpack already has item, update quantity
					int hasItemIndex = backpack.hasItem(myNewItem.Iname);
					if(hasItemIndex > -1) {
						if(backpack.getItem(hasItemIndex).Stackable) {
							backpack.addQuantity(hasItemIndex, 1);
						}else {
							backpack.addItem(myNewItem);
						}
					//else, add new item
					}else {
						backpack.addItem(myNewItem);
					}
				}
			}
		}catch(System.Exception /*e*/) {
			print ("Invalid item.");
			//print (e);
		}
	}


	public void addBackpackItem(Item item) {
		try{
			int hasItemIndex = backpack.hasItem(item.Iname);
			if(hasItemIndex > -1) {
				//if item is stackable, increment item quantity
				if(backpack.getItem(hasItemIndex).Stackable) {
					//THIS WILL ADD NEGATIVE
					backpack.addQuantity(hasItemIndex, item.Quantity);
				//if not stackable, add to inventory
				}else {
					backpack.addItem(item);
				}
			//else, add new item
			}else {
				backpack.addItem(item);
			}
		}catch(System.Exception) {}
	}


	//there is a better way to call the base class methods...
	public void removeItem(int index) {
		backpack.removeItem (index);
	}

	public void print() {
		backpack.print ();
	}

	public bool isEmpty() {
		return backpack.isEmpty ();
	}

	public Item getItem(int index) {
		return backpack.getItem (index);
	}
}

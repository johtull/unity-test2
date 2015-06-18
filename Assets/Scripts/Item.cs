using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	//from db
	private int id;
	private string iname;
	private string description;
	private int use_level;
	private int weight;
	private bool equippable;
	private bool stackable;
	private int base_damage;
	private int base_price;
	private int quest;
	private string icon;
	private string model;
	//extras
	private int durability;
	private int quality;
	private int quantity;


	public Item (int id, string iname, string description, int use_level,
	             int weight, bool equippable, bool stackable, int base_damage,
	             int base_price, int quest, string icon, string model) {
		this.id = id;
		this.iname = iname;
		this.description = description;
		this.use_level = use_level;
		this.weight = weight;
		this.equippable = equippable;
		this.stackable = stackable;
		this.base_damage = base_damage;
		this.base_price = base_price;
		this.quest = quest;
		this.icon = icon;
		this.model = model;

		durability = 100;
		quality = 100;
		quantity = 1;
	}

	public Item (int id, string iname, string description, int use_level,
	             int weight, bool equippable, bool stackable, int base_damage,
	             int base_price, int quest, string icon, string model,
	             int durability, int quality, int quantity) {
		this.id = id;
		this.iname = iname;
		this.description = description;
		this.use_level = use_level;
		this.weight = weight;
		this.equippable = equippable;
		this.stackable = stackable;
		this.base_damage = base_damage;
		this.base_price = base_price;
		this.quest = quest;
		this.icon = icon;
		this.model = model;

		this.durability = durability;
		this.quality = quality;
		this.quantity = quantity;

	}




	public int Id {
		get {
			return id;
		}
		set {
			id = value;
		}
	}

	public string Iname {
		get {
			return iname;
		}
		set {
			iname = value;
		}
	}

	public string Description {
		get {
			return description;
		}
		set {
			description = value;
		}
	}

	public int Weight {
		get {
			return weight;
		}
		set {
			weight = value;
		}
	}

	public bool Equippable {
		get {
			return equippable;
		}
		set {
			equippable = value;
		}
	}

	public bool Stackable {
		get {
			return stackable;
		}
		set {
			stackable = value;
		}
	}

	public int Base_damage {
		get {
			return base_damage;
		}
		set {
			base_damage = value;
		}
	}

	public int Base_price {
		get {
			return base_price;
		}
		set {
			base_price = value;
		}
	}

	public int Quest {
		get {
			return quest;
		}
		set {
			quest = value;
		}
	}

	public string Icon {
		get {
			return icon;
		}
		set {
			icon = value;
		}
	}

	public string Model {
		get {
			return model;
		}
		set {
			model = value;
		}
	}

	public int Use_level {
		get {
			return use_level;
		}
		set {
			use_level = value;
		}
	}


	//set
	public int Durability {
		get {
			return durability;
		}
		set {
			durability = value;
		}
	}

	public int Quality {
		get {
			return quality;
		}
		set {
			quality = value;
		}
	}

	public int Quantity {
		get {
			return quantity;
		}
		set {
			quantity = value;
		}
	}
}

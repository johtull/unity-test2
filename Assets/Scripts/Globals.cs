using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.SqliteClient;
using System;
using System.IO;
using UnityEngine.UI;

public class Globals : MonoBehaviour {
	
	public static Hashtable skills;
	//public static Container backpack;
	public static Backpack myBackpack;

	public static Canvas canvas;
	//this is just here to test toggling the canvas in the inspector
	public bool on = true;

	// Use this for initialization
	void Start () {
		if (!initDB ()) {
			print ("DB CONNECTION ERROR");
			//TODO: display error popup, gracefully exit
			//Does this stop the application?
			//Application.Quit();
			//Debug.Break();
		}

		Skill skillFishing = new Skill (500, "fishing");
		//TODO: add more skills

		//add all skills to map
		skills = new Hashtable ();
		skills.Add ("Fishing", skillFishing);

		//backpack = new Container ();
		myBackpack = new Backpack ();
		//This will stop working properly if we put in multiple canvases
		canvas = (Canvas) FindObjectOfType(typeof(Canvas));
		//canvas = GetComponent<Canvas> ();
		//canvas.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		canvas.enabled = on;
	}

	// ESTABLISH DB CONNECTION
	private static SqliteConnection sql_con;
	//public string sql_db = "URI=Data Source=Assets/bt-test.db;Version=3;New=False;Compress=True;";
	private string sql_db = "URI=file:Assets/bt-test.db";

	private bool initDB() {
		//print("current directory: " + Environment.CurrentDirectory);
		try{
			sql_con = new SqliteConnection(sql_db);
			sql_con.Open();
		}catch {
			return false;
		}
		return true;
	}

	//http://forum.unity3d.com/threads/tutorial-how-to-integrate-sqlite-in-c.192282/
	public static Item getItemById(int id) {
		IDbCommand sql_cmd = sql_con.CreateCommand ();
		sql_cmd.CommandText = "select * FROM items WHERE id=" + id + ";";
		IDataReader sql_reader = sql_cmd.ExecuteReader ();
		Item myItem = null;
		while (sql_reader.Read()) {
			myItem = new Item(int.Parse(sql_reader["id"].ToString()), sql_reader["name"].ToString(),
			                  sql_reader["description"].ToString(), int.Parse(sql_reader["use_level"].ToString()),
			                  int.Parse(sql_reader["weight"].ToString()), bool.Parse(sql_reader["equippable"].ToString()), bool.Parse(sql_reader["stackable"].ToString()),
			                  int.Parse(sql_reader["base_damage"].ToString()), int.Parse(sql_reader["base_price"].ToString()),
			                  int.Parse(sql_reader["quest"].ToString()), sql_reader["icon"].ToString(),
			                  sql_reader["model"].ToString());
		}
		print("myItem: " + myItem.ToString ());
		return myItem;
	}

	public static Item getItemByName(string n) {
		IDbCommand sql_cmd = sql_con.CreateCommand ();
		sql_cmd.CommandText = "select * FROM items WHERE name='" + n + "';";
		IDataReader sql_reader = sql_cmd.ExecuteReader ();
		Item myItem = null;
		while (sql_reader.Read()) {
			myItem = new Item(int.Parse(sql_reader["id"].ToString()), sql_reader["name"].ToString(),
			                  sql_reader["description"].ToString(), int.Parse(sql_reader["use_level"].ToString()),
			                  int.Parse(sql_reader["weight"].ToString()), bool.Parse(sql_reader["equippable"].ToString()), bool.Parse(sql_reader["stackable"].ToString()),
                              int.Parse(sql_reader["base_damage"].ToString()), int.Parse(sql_reader["base_price"].ToString()),
                              int.Parse(sql_reader["quest"].ToString()), sql_reader["icon"].ToString(),
                              sql_reader["model"].ToString());
		}
		
		return myItem;
	}
}

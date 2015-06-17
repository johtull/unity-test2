using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.SqliteClient;
using System;
using System.IO;

public class Globals : MonoBehaviour {
	
	public static Hashtable skills;

	// Use this for initialization
	void Start () {
		if (!initDB ()) {
			print ("DB ERROR");
		}

		Skill skillFishing = new Skill (500, "fishing");
		//TODO: add more skills

		//add all skills to map
		skills = new Hashtable ();
		skills.Add ("Fishing", skillFishing);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// ESTABLISH DB CONNECTION
	private static SqliteConnection sql_con;
	//public string sql_db = "URI=Data Source=bt-test.db;Version=3;New=False;Compress=True;";
	private string sql_db = "URI=file:Assets/bt-test.db";

	private bool initDB() {
		//print (
		print("current directory: " + Environment.CurrentDirectory);
		try{
			sql_con = new SqliteConnection(sql_db);
			sql_con.Open();
		}catch {
			print ("something went wrong");
		}
		print ("state: " + sql_con.State.ToString ());
		print ("WE DID IT BOYS");
		return true;
	}
	//http://forum.unity3d.com/threads/tutorial-how-to-integrate-sqlite-in-c.192282/
	public static object select(string table, int id) {
		IDbCommand sql_cmd = sql_con.CreateCommand ();
		sql_cmd.CommandText = "select * FROM " + table + " WHERE id=" + id + ";";
		IDataReader sql_reader = sql_cmd.ExecuteReader ();
		while (sql_reader.Read()) {
			print ("name: " + sql_reader["name"]);
		}
		//SqliteCommand _dbcm=_dbc.CreateCommand();
		//_dbcm.CommandText="SELECT * FROM items WHERE id=" + id + ";";
		//IDataReader _dbr=_dbcm.ExecuteReader();
		//print ("break");
		return 5;
	}
}

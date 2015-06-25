using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class SaveLoadTest : MonoBehaviour {

	public float testHealth;

	// Use this for initialization
	void Start () {
		testHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("i"))
		{
			print("Trying to Save");
			Save();
		}
		if(Input.GetKeyDown("o"))
		{
			print("Trying to Load");
			Load();
		}
		if(Input.GetKeyDown("l"))
			testHealth += 1;
		if(Input.GetKeyDown("k"))
			testHealth -= 1;

		print ("Test Health: " + testHealth);
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.rob");
		PlayerData data = new PlayerData();
		data.health = testHealth;


		bf.Serialize(file, data);
		file.Close();
	}

	public void Load(){

		if(File.Exists(Application.persistentDataPath + "/playerInfo.rob"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.rob", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			testHealth = data.health;

		}


	}

}

[Serializable]
class PlayerData
{
	public float health;

}

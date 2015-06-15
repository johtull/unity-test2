using System.IO;
using UnityEngine;
using System.Collections;



public class Skill : MonoBehaviour {

	private float experience;
	private string skillName;
	private Hashtable abilities;



	public Skill(string n) {
		skillName = n;
		experience = 0;
		abilities = loadSkill(skillName);
		//UnityEngine.Debug.Log("level: " + getLevel ());
	}

	public Skill(float xp, string n) {
		experience = xp;
		skillName = n;
		abilities = loadSkill(skillName);
	}


	/*void Start () {
		//UnityEngine.Debug.Log("info");
		Skill mySkill = new Skill("fishing");
	}*/

	public float Experience {
		get {
			return experience;
		}
	}

	public void addXP(float xp) {
		experience += xp;
	}
	public void removeXP(float xp) {
		experience -= xp;
	}

	public bool canUse(string ab) {
		int skillLevel;
		try {
			skillLevel = int.Parse(abilities[ab].ToString());
		}catch(System.NullReferenceException) {
			return false;
		}
		return (getLevel () - skillLevel >= 0);
	}

	// Experience = Level^3 * 10
	// Level = experience^(1/3) / 10^(1/3)
	public int getLevel() {
		return (int)((float)System.Math.Pow(experience, (1.0)/(3.0)) / (float)System.Math.Pow(10, (1.0)/(3.0)));
	}

	public int getSpotLevel(string spt) {
		try {
			return int.Parse(abilities[spt].ToString());
		}catch(System.NullReferenceException) {
			return -1;
		}
	}

	// load skills from flat file
	private Hashtable loadSkill(string file) {
		Hashtable myAbilities = new Hashtable ();
		using (var sr = File.OpenText("Assets/Config/" + file + ".csv")) {
			string line;
			while ((line = sr.ReadLine()) != null)
			{
				var fields = line.Split(',');
				myAbilities.Add(fields[0].Trim(),fields[1].Trim());
			}
		}
		return myAbilities;
	}

}


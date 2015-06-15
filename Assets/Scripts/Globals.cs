using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {
	
	public static Hashtable skills;

	// Use this for initialization
	void Start () {

		Skill skillFishing = new Skill (500, "fishing");
		//TODO: add more skills

		//add all skills to map
		skills = new Hashtable ();
		skills.Add ("Fishing", skillFishing);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

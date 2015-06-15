using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {

	public static Skill skillFish;

	// Use this for initialization
	void Start () {
		skillFish = new Skill (100000, "fishing");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

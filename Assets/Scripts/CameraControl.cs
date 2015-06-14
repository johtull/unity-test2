using UnityEngine;
using System.Collections;

public class CameraControl : GlobalVars {

	public GameObject targetObject;
	public GameObject targetLook;
	public Vector3 targetPosition;

	public float phi= 45;
	public float theta = 90;
	public float di = 20; //distance

	//public int gamemode = gameMode;
	public bool focus = false;
	public bool pan = false;
	// Use this for initialization
	void Start () {
		 //di = 20; //distance
	}
	
	// Update is called once per frame
	void Update () {

		float dx = di*Mathf.Sin(phi*3.14f/180f)*Mathf.Cos(theta*3.14f/180f);
		float dz = di*Mathf.Sin(phi*3.14f/180f)*Mathf.Sin(theta*3.14f/180f);
		float dy = di*Mathf.Cos(phi*3.14f/180f);
		float tx = targetObject.transform.position.x - dx;
		float ty = targetObject.transform.position.y + dy;
		float tz = targetObject.transform.position.z + dz;

		transform.position = new Vector3(tx, ty, tz);
		//transform.position = new Vector3(targetObject.transform.position.x - 10, targetObject.transform.position.y + 10, targetObject.transform.position.z - 10);
		//transform.LookAt(targetLook.transform.position);
		if(!focus)
		{
			targetLook = targetObject;
			transform.LookAt(targetLook.transform.position);
		}
		else
			transform.LookAt(targetLook.transform.position);

		if(gameMode == 0)
		{
			if(Input.GetKey("up"))
				phi -=1f;
			if(Input.GetKey("down"))
				phi +=1f;
			if(Input.GetKey("right"))
				theta -=1f;
			if(Input.GetKey("left"))
				theta +=1f;

			if(Input.GetKey("q"))
				gameMode = 1;
			
		}

		else if(gameMode == 1)
		{

			if(Input.GetKey("up"))
				transform.Rotate(1,0,0);
			if(Input.GetKey("down"))
				transform.Rotate(-1,0,0);
			if(Input.GetKey("right"))
				transform.Rotate(0,1,0);
			if(Input.GetKey("left"))
				transform.Rotate(0,-1,0);
		}

	}
}

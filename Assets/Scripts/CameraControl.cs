using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject targetObject;

	public float phi= 45;
	public float theta = 90;
	public float di = 20; //distance

	public int gamemode = 0;
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
		transform.LookAt(targetObject.transform.position);

		if(gamemode == 0)
		{
			if(Input.GetKey("up"))
				phi -=1f;
			if(Input.GetKey("down"))
				phi +=1f;
			if(Input.GetKey("right"))
				theta -=1f;
			if(Input.GetKey("left"))
				theta +=1f;
			
		}

		else if(gamemode == 1)
		{
			if(Input.GetAxis("Mouse X")<0){
				theta -=1f;

				print("Mouse moved left");
			}
			if(Input.GetAxis("Mouse X")>0){
				theta +=1f;

				print("Mouse moved right");
			}
			if(Input.GetAxis("Mouse Y")<0){
				phi -=1f;
				print("Mouse moved down"); 
			}
			if(Input.GetAxis("Mouse Y")>0){
				phi +=1f;
				print("Mouse moved up");
			}

		}

	}
}

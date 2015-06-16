using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Camera mainCam;
	public GameObject targetObject;
	public GameObject targetLook;
	public Vector3 targetPosition;

	public LayerMask touchInputMask;

	public float phi= 45;
	public float theta = 90;
	public float di = 20; //distance

	public float dx;
	public float dz;
	public float dy;
	public float tx;
	public float ty;
	public float tz;

	public float mouseX;
	public float mouseY;

	//public int gamemode = gameMode;
	public bool focus = false;
	public bool rotate = false;
	public bool pan = false;
	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		//mouseX=0;
		//mouseY=0;

		if(Input.GetKeyDown ("c") && !pan)
		{
		//	targetLook = null;
		   pan = true;
		}
		else if(Input.GetKeyDown ("c") && pan)
			pan = false;

		if(Input.GetKeyDown ("v") && !rotate)
			rotate = true;
		else if(Input.GetKeyDown ("v") && rotate)
			rotate = false;

		if(Input.GetMouseButton(1))
		   rotate = true;
		else
		   rotate = false;
		
		//transform.position = new Vector3(targetObject.transform.position.x - 10, targetObject.transform.position.y + 10, targetObject.transform.position.z - 10);
		//transform.LookAt(targetLook.transform.position);

		//Focus Options
		/*if(focus)
		{

		}
		else
		{
			targetLook = targetObject;
		}*/



		//Panning Options
		if(!pan)
		{
			theta = targetObject.transform.eulerAngles.y - 90;
			dx = di*Mathf.Sin(phi*3.14f/180f)*Mathf.Cos(theta*3.14f/180f);
			dz = di*Mathf.Sin(phi*3.14f/180f)*Mathf.Sin(theta*3.14f/180f);
			dy = di*Mathf.Cos(phi*3.14f/180f);
			tx = targetObject.transform.position.x - dx;
			ty = targetObject.transform.position.y + dy;
			tz = targetObject.transform.position.z + dz;
			transform.position = new Vector3(tx, ty, tz);
			targetLook = targetObject;
			mainCam.gameObject.transform.LookAt(targetLook.transform.position);


		}
		else
		{

			dx = di*Mathf.Sin(phi*3.14f/180f)*Mathf.Cos(theta*3.14f/180f);
			dz = di*Mathf.Sin(phi*3.14f/180f)*Mathf.Sin(theta*3.14f/180f);
			dy = di*Mathf.Cos(phi*3.14f/180f);
			tx = targetObject.transform.position.x - dx;
			ty = targetObject.transform.position.y + dy;
			tz = targetObject.transform.position.z + dz;
			transform.position = new Vector3(tx, ty, tz);


			//transform.LookAt(targetLook.transform.position);
		}
		//mouseMove ();
		//mouseX = Input.mousePosition.x;
		//mouseY = Input.mousePosition.y;


		//Rotate Options
		if(rotate)
		{
			/*if(Input.GetKey("up"))
				transform.Rotate(1,0,0);
			if(Input.GetKey("down"))
				transform.Rotate(-1,0,0);
			if(Input.GetKey("right"))
				transform.Rotate(0,1,0);
			if(Input.GetKey("left"))
				transform.Rotate(0,-1,0);*/

			mouseMove ();
		}
		else
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
		mouseX = Input.mousePosition.x;
		mouseY = Input.mousePosition.y;
		

		//Click Something to refocus
		/*
		if(Input.GetMouseButtonDown(0))
		{
			//Find where the mouse is
			if(Physics.Raycast(ray,out hit, touchInputMask))
			{
				print("hurrduururur");
				Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
				print(hit.transform.gameObject.name);
				if(hit.transform.gameObject.name != "TestTerrain")
				targetLook = hit.transform.gameObject;
			}
		}*/


		//mostly just testing
		/*
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

			if(Input.GetKeyDown("q"))
				gameMode = 1;

			//if(Input.GetKeyDown("e"))
			//	focus = true;
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

			if(Input.GetKeyDown("q"))
				gameMode = 0;
		}*/

	}

	public void mouseMove()
	{
		float easeFactor = 10f;
		if(Input.GetMouseButton(1))
		{
			//Horizontal
			if(Input.mousePosition.x != mouseX)
			{
				float rotY = (Input.mousePosition.x - mouseX) * easeFactor * Time.deltaTime;
				this.transform.Rotate(0, rotY, 0);
			}

			//Vertical
			if(Input.mousePosition.y != mouseY)
			{

				float rotX = (mouseY - Input.mousePosition.y) * easeFactor * Time.deltaTime;

				mainCam.gameObject.transform.Rotate(rotX, 0, 0);
			}

		}
		
	}

}

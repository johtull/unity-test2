using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	//For Touch
	public LayerMask touchInputMask;

	public Vector3 mouseLoc;
	NavMeshAgent agent;
	//public GameObject playerChar;

	public int gamemode = 0;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		//agent.SetDestination (target);
	}
	
	//Click to Move Mode
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		///*
		if(Input.GetMouseButtonDown(0))
		{
		//Find where the mouse is
		if(Physics.Raycast(ray,out hit, touchInputMask))
		{
				Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
			Debug.DrawRay(transform.position, forward, Color.green);
			GameObject target = hit.transform.gameObject;
			mouseLoc = hit.point;
			print (hit.point);
			agent.SetDestination(hit.point);
		}
		}



	}//*/


}

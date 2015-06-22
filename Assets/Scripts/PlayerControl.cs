﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 100.0F;
	public float gravity = 200.0F;
	public LayerMask touchInputMask;

	public bool jumping = false;
	public bool jumping2 = false;
	public bool strafe = false;
	public bool running = false;
	public float turnSpeed = 180.0F;
	public bool swimming = false;
	public bool climbing = false;
	public Transform toDrop = null;

	private Vector3 moveDirection = Vector3.zero;
	private Vector3 crouch = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		//print (gameMode);
		

		if(running)
			speed = 25;
		else
			speed = 15;

		if(Input.GetKeyDown("z") && !running)
			running = true;
		else if(Input.GetKeyDown("z") && running)
			running = false;

		/*if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) {
			crouch = new Vector3(0, 20, 0);
			controller.Move(crouch * Time.deltaTime);
			print("hi" + crouch);
		}*/

		if(!strafe)
		{
			if(Input.GetKey("a"))
				transform.Rotate(0, Time.deltaTime * -turnSpeed, 0);
			else if(Input.GetKey("d"))
				transform.Rotate(0, Time.deltaTime * turnSpeed, 0);
		}

		if (controller.isGrounded) {
			if(strafe)
			moveDirection = new Vector3(Input.GetAxis("NewHor"), 0, Input.GetAxis("NewVert"));
			else
			{
				moveDirection = new Vector3(0, 0, Input.GetAxis("NewVert"));
			}

			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButtonDown("NewJump") && !swimming)
				moveDirection.y = jumpSpeed;
			jumping2 = false;
		}

		else{
			
			if (Input.GetButtonDown("NewJump") && !jumping2 && !swimming && !climbing)
			{
				moveDirection = new Vector3(Input.GetAxis("NewHor"), 0, Input.GetAxis("NewVert"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				moveDirection.y = jumpSpeed;
				if(!swimming)
				jumping2 = true;
			}
			
		}

		if(swimming)
		{
			speed = 15;

			//moveDirection = new Vector3(0, 0, Input.GetAxis("NewVert"));
			//moveDirection = transform.TransformDirection(moveDirection);
		//	moveDirection *= speed;
			if (Input.GetButton("NewJump"))
			{
				moveDirection = new Vector3(Input.GetAxis("NewHor"), 5, Input.GetAxis("NewVert"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				moveDirection.y = 15f;

			}
			
		}

		if(climbing)
		{
			if(!controller.isGrounded)
			moveDirection = new Vector3(0, Input.GetAxis("NewVert")*50, 0);
			if(controller.isGrounded && Input.GetAxis("NewVert") > 0)
			moveDirection = new Vector3(0, 3, 0);

			if (Input.GetButton("NewJump"))
			{
			/*	moveDirection = new Vector3(Input.GetAxis("NewHor"), 0, Input.GetAxis("NewVert"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				moveDirection.y = 10f;*/
				
			}
			
		}

		if(!climbing)
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	


		if(Input.GetMouseButtonDown(0))	{
			//Find where the mouse is
			if(Physics.Raycast(ray,out hit, touchInputMask)) {
				Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
				GameObject targetLook = hit.transform.gameObject;
				if(targetLook.tag.Contains("StaticResource")) {
					string mySkillName = targetLook.tag.Substring(14);
					print("Resource Clicked: " + targetLook.name);
					
					//print("test: " + ((Skill)Globals.skills[mySkillName]).test());
					//print("Your level: " + ((Skill)Globals.skills[mySkillName]).getLevel());
					//print("Spot level: " + ((Skill)Globals.skills[mySkillName]).getSpotLevel(targetLook.name));
					//print("canUse: " + ((Skill)Globals.skills[mySkillName]).canUse(targetLook.name));
				}
				switch(targetLook.tag) {
					//TODO: pickup item based on player location
				case "Item0"://can pickup
					print("Item Clicked: " + targetLook.name);
					WorldItem worldItem = targetLook.GetComponent("WorldItem") as WorldItem;
					Item myNewItem = worldItem.wItem;
					try{
						//if the worldItem exists, pull from it
						if(myNewItem.Iname != null) {
							Globals.myBackpack.addBackpackItem(myNewItem);
						}
					}catch(System.Exception) {
						//exception, worldItem does not exist
						Globals.myBackpack.addBackpackItem(targetLook.name);
					}
					//remove item from scene
					//if invalid item, remove from stage anyway
					Destroy(targetLook);
					break;
				case "Item1"://cannot pickup
					print ("You cannot pick up " + targetLook.name + ".");
					break;
				default:
					break;
				}
				
			}
		}
		
		if (Input.GetKey (KeyCode.B)) {
			//TODO: open backpack
			Globals.myBackpack.print();
		}
		if (Input.GetKeyDown("g")) {
			Vector3 placeLoc;
			Transform placedObject;

			//TODO: drop first item
			//if backpack is not empty, drop first item
			if(!Globals.myBackpack.isEmpty()) {
				//Globals.myBackpack.getItem(0);
				//instantiate item in WorldItem applied to scene object...?
				//toDrop.name = Globals.myBackpack.getItem(0).Iname + " (" + Globals.myBackpack.getItem(0).Quantity + ")";
				(toDrop.GetComponent("WorldItem") as WorldItem).wItem = Globals.myBackpack.getItem(0);
				placeLoc = transform.position +(transform.forward*5);
				//placeLoc *= speed;
				placedObject = Instantiate(toDrop, placeLoc, Quaternion.identity) as Transform;
				//GameObject placedObject = (GameObject)Instantiate(toDrop, placeLoc, Quaternion.identity);
				placedObject.name = Globals.myBackpack.getItem(0).Iname + " (" + Globals.myBackpack.getItem(0).Quantity + ")";
				print (placeLoc);

				//remove from inventory
				Globals.myBackpack.removeItem(0);
			}
		}


	}
	void OnTriggerEnter(Collider other) {
		
		//The Pool
		if (other.gameObject.tag == "Water")
		{
			moveDirection.y = moveDirection.y/5;
			swimming = true;
			gravity = 30f;
		}

		if (other.gameObject.tag == "ClimbZone")
		{
			climbing = true;
		}
	}

	void OnTriggerExit(Collider other) {
		
		//The Pool
		if (other.gameObject.tag == "Water")
		{
			swimming = false;
			gravity = 200f;
		}

		if (other.gameObject.tag == "ClimbZone")
		{
			climbing = false;
			moveDirection = new Vector3(Input.GetAxis("NewHor")*speed, 35, Input.GetAxis("NewVert")*speed);
			moveDirection = transform.TransformDirection(moveDirection);
		}
	}
}

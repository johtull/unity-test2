using UnityEngine;
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
			
			if (Input.GetButtonDown("NewJump") && !jumping2 && !swimming)
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
				moveDirection = new Vector3(Input.GetAxis("NewHor"), 0, Input.GetAxis("NewVert"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				moveDirection.y = 10f;

			}
			
		}

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
					case "Item":
						print("Item Clicked: " + targetLook.name);
						Item myNewItem = Globals.getItemByName(targetLook.name);
						print("Item Description: " + myNewItem.Description);
						Globals.backpack.addItem(myNewItem);
						Destroy(targetLook);
						print ("backpack: " + Globals.backpack.ToString());
						break;
					default:
						break;
				}
				
			}
		}
		if (Input.GetKey (KeyCode.B)) {
			//TODO: open backpack
		}


	}
	void OnTriggerEnter(Collider other) {
		
		//The Pool
		if (other.gameObject.tag == "Water")
		{
			swimming = true;
			gravity = 30f;
		}
	}

	void OnTriggerExit(Collider other) {
		
		//The Pool
		if (other.gameObject.tag == "Water")
		{
			swimming = false;
			gravity = 200f;
		}
	}
}

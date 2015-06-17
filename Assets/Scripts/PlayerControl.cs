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

	private Vector3 moveDirection = Vector3.zero;
	private Vector3 crouch = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		//print (gameMode);

		if(running)
			speed = 15;
		else
			speed = 6;

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
			if (Input.GetButtonDown("NewJump"))
				moveDirection.y = jumpSpeed;
			jumping2 = false;
		}

		else{
			
			if (Input.GetButtonDown("NewJump") && !jumping2)
			{
				moveDirection = new Vector3(Input.GetAxis("NewHor"), 0, Input.GetAxis("NewVert"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				moveDirection.y = jumpSpeed;
				jumping2 = true;
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
					print("test: " + ((Skill)Globals.skills[mySkillName]).test());
					//print("Your level: " + ((Skill)Globals.skills[mySkillName]).getLevel());
					//print("Spot level: " + ((Skill)Globals.skills[mySkillName]).getSpotLevel(targetLook.name));
					//print("canUse: " + ((Skill)Globals.skills[mySkillName]).canUse(targetLook.name));
				}
				
			}
		}


	}
}

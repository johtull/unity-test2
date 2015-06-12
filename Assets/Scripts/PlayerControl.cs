using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 20.0F;
	public float gravity = 20.0F;

	public bool jumping = false;
	public bool jumping2 = false;
	public bool strafe = false;

	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if(!strafe)
		{
		if(Input.GetKey("a"))
			transform.Rotate(0, Time.deltaTime * -90, 0);
		else if(Input.GetKey("d"))
			transform.Rotate(0, Time.deltaTime * 90, 0);
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
				print ("VDVD");
			}
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}

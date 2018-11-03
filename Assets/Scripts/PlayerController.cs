using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 1.0f;
	public float jumpForce = 1.0f;
	private Rigidbody rb;
	private bool isGrounded = false;
	private bool canJump = false;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// void GroundCheck() {
	// 	RaycastHit hit;
	// 	float distance = 1f;
	// 	Vector3 dir = new Vector3(0, -1);

	// 	if(Physics.Raycast(transform.position, dir, out hit, distance))	{
	// 		isGrounded = true;
	// 	} else {
	// 		isGrounded = false;
	// 	}
	// }
	void OnCollisionStay() {
		isGrounded = true;
	}

	void OnCollisionExit() {
		isGrounded = false;
	}

	void Update () {
		if (Input.GetButtonDown("Jump") && isGrounded) {
			canJump = true;
		}
	}

	void FixedUpdate () {
		/* Player movement */
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, rb.velocity.y/speed, moveVertical);
		rb.velocity = movement * speed;
		// Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		// rb.AddForce(movement * speed);

		/* Player jump */
		if (canJump) {
			Vector3 jump = new Vector3(0.0f, jumpForce, 0.0f);
			rb.AddForce(jump, ForceMode.Impulse);
			canJump = false;
		}
	}
}

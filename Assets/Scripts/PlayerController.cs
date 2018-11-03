using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 1.0f;
	public float jumpForce = 1.0f;
	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
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
		Vector3 jump = new Vector3(0.0f, jumpForce, 0.0f);
		if (Input.GetButtonDown("Jump")) {
			rb.AddForce(jump, ForceMode.Impulse);
		}
	}
}

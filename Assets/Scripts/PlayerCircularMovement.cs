using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCircularMovement : MonoBehaviour {
	[SerializeField]
	private GameObject boss;
	public float speed = 2.0f;
	public float jumpForce = 5.0f;
	private Rigidbody rb;
	private bool isGrounded = false;
	private bool canJump = false;

	void Start () {
		rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay() {
        isGrounded = true;
    }

    void OnCollisionExit() {
        isGrounded = false;
    }

	void Update () {
		if (Input.GetKeyDown(KeyCode.X) && isGrounded) {
			canJump = true;
		}
	}

	void FixedUpdate () {
        transform.LookAt(boss.transform.position);
        Vector3 tempvelocity = Vector3.zero;
        tempvelocity.y = rb.velocity.y;

		// Circular movement
		if (Input.GetKey(KeyCode.LeftArrow)) {
            tempvelocity -= transform.right * speed;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            tempvelocity += transform.right * speed;
        }

        // Forward and backward
        if (Input.GetKey(KeyCode.UpArrow)) {
            tempvelocity += transform.forward * speed;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            tempvelocity -= transform.forward * speed;
        }
        rb.velocity = tempvelocity;

        /* Player jump */
        if (canJump) {
			rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
			canJump = false;
		}
	}
}

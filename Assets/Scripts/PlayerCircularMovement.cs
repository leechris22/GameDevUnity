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
    private Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
    }

	void FixedUpdate () {
        transform.LookAt(boss.transform.position);
        Vector3 tempvelocity = Vector3.zero;

		// Circular movement
		if (Input.GetKey(KeyCode.LeftArrow)) {
            anim.SetBool("left", true);
            tempvelocity -= transform.right * speed;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            anim.SetBool("right", true);
            tempvelocity += transform.right * speed;
        } else
        {
            anim.SetBool("left", false);
            anim.SetBool("right", false);
        }

        // Forward and backward
        if (Input.GetKey(KeyCode.UpArrow)) {
            anim.SetBool("forward", true);
            tempvelocity += transform.forward * speed;
        } else if (Input.GetKey(KeyCode.DownArrow) && Vector3.Distance(transform.position, boss.transform.position) < 15) {
            anim.SetBool("backward", true);
            tempvelocity -= transform.forward * speed;
        } else {
            anim.SetBool("forward", false);
            anim.SetBool("backward", false);
        }
        tempvelocity.y = rb.velocity.y;
        rb.velocity = tempvelocity;

        /* Player jump */
        if (Input.GetKey(KeyCode.X) && isGrounded) {
			rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision) {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision) {
        isGrounded = false;
    }
}

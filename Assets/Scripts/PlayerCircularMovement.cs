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
	private Vector3 offset;
	private Vector3 normalizedOffset;
	private float distance;
	[SerializeField]
	private float safeDistance = 2.0f;   // safe distance between player and boss

	void Start () {
		rb = GetComponent<Rigidbody>();
		offset = transform.position - boss.transform.position;
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
		normalizedOffset = offset.normalized;
		distance = Vector3.Distance(transform.position, boss.transform.position);
		// Circular left
		if (Input.GetKey(KeyCode.LeftArrow)) {
			offset = Quaternion.AngleAxis(2, Vector3.up) * offset;
		}
		// Circular right
        if (Input.GetKey(KeyCode.RightArrow)) {
			offset = Quaternion.AngleAxis(-2, Vector3.up) * offset;
		}
		// Forward
		if (Input.GetKey(KeyCode.UpArrow) && distance >= safeDistance) {
			offset = offset - (normalizedOffset * 0.5f);
        }
		// Backward
        if (Input.GetKey(KeyCode.DownArrow)) {
            offset = offset + (normalizedOffset * 0.5f);
        }
		transform.position = new Vector3(boss.transform.position.x + offset.x, transform.position.y, boss.transform.position.z + offset.z);
		transform.LookAt(boss.transform.position);

		/* Player jump */
		if (canJump) {
			Vector3 jump = new Vector3(0.0f, jumpForce, 0.0f);
			rb.AddForce(jump, ForceMode.Impulse);
			canJump = false;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AI : MonoBehaviour {
    // Comparison NPCs
    private Rigidbody player;

    // Adjustable variables
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float maxAcceleration;
    [SerializeField]
    private float targetRadius;
    [SerializeField]
    private float slowRadius;
    [SerializeField]
    private float timeToTarget;


    // Holds the path to follow
    [SerializeField]
    private Vector3[] Path;
    [SerializeField]
    private int current = 0;

    protected void Start() {
        player = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if (Input.GetKey(KeyCode.Q)) {
            PathFollow();
        }
    }

    // Move towards the target
    public void Pursue(Vector3 target) {
        Vector3 steering = target - player.position;
        steering.y = 0;
        player.AddForce((steering.normalized * maxSpeed) - player.velocity, ForceMode.VelocityChange);
    }

    // Move away from the target
    public void Evade(Vector3 target) {
        Vector3 steering = player.position - target;
        steering.y = 0;
        player.AddForce((steering.normalized * maxSpeed) - player.velocity, ForceMode.VelocityChange);
    }
    
    // Move towards the target with slow down.
    public void Arrive(Vector3 target) {
        // Get the direction to the target
        Vector3 direction = target - player.position;
        float distance = direction.magnitude;

        // If we are there, stop
        if (distance < targetRadius) {
            player.velocity = Vector3.zero;
        } else {
            float targetSpeed = (distance > slowRadius ? maxSpeed : maxSpeed * distance / slowRadius);
            Vector3 steering = (direction.normalized * targetSpeed - player.velocity) / timeToTarget;
            player.AddForce(Vector3.ClampMagnitude(steering, maxAcceleration), ForceMode.VelocityChange);
        }
    }

    // Face towards the target
    public void Face(Vector3 target) {
        Vector3 direction = transform.InverseTransformPoint(target);
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        player.MoveRotation(player.rotation * Quaternion.Euler(new Vector3(0, angle, 0) * Time.deltaTime));
    }
    // Face away from the target
    public void FaceAway(Vector3 target) {
        Vector3 direction = -transform.InverseTransformPoint(target);
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        player.MoveRotation(player.rotation * Quaternion.Euler(new Vector3(0, angle, 0) * Time.deltaTime));
    }

    // Follow the path
    public void PathFollow() {
        if (current < 0 || Path.Length <= current) {
            current = 0;
        } else {
            if ((Path[current] - player.position).magnitude > targetRadius) {
                Arrive(Path[current]);
                Face(Path[current]);
            } else {
                current++;
            }
        }
    }
}

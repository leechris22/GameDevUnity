using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AI that moves the object towards the target with slow down.
public class Arrive : AI {
    // Initialize necessary variables
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

    // Override AI output
    override public void Output(Vector3 target) {
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
}

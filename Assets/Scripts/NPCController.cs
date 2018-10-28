﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores data for an object used in AI calculations
public class NPCController : MonoBehaviour {
    // Store variables for objects
    [HideInInspector]
    public Rigidbody rb;
    public GameObject target;
    [SerializeField]
    private AI ai;

    // Bounds linear changes
    public float maxSpeedL;
    public float maxAccelerationL;

    // Bounds angular changes
    public float maxSpeedA;
    public float maxAccelerationA;

    // On initialization
    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Update the movement
    private void FixedUpdate() {
        updateLinear(ai.Output(target));
        updateAngular(ai.Output(target));
    }

    protected void updateLinear(Steering steering) {
        // Bound the acceleration
        steering.linear = Vector2.ClampMagnitude(steering.linear, maxAccelerationL);
        float angularAcceleration = Mathf.Abs(steering.angular);
        if (angularAcceleration > maxAccelerationA) {
            steering.angular /= angularAcceleration;
            steering.angular *= maxAccelerationA;
        }

        // Bound the velocity
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeedL);
        if (rb.angularVelocity > maxSpeedA) {
            rb.angularVelocity = maxSpeedA;
        }

        // Update the position and rotation
        rb.AddForce(velocity - rb.velocity, ForceMode.VelocityChange);
        rb.angularVelocity += steering.angular;
    }

    private void update(Vector3 steeringlin, float steeringang, float time) {
        // Update the orientation, velocity and rotation
        orientation += rotation * time;
        velocity += steeringlin * time;
        rotation += steeringang * time;

        if (velocity.magnitude > maxSpeed) {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        rb.AddForce(velocity - rb.velocity, ForceMode.VelocityChange);
        position = rb.position;
        rb.MoveRotation(Quaternion.Euler(new Vector3(0, Mathf.Rad2Deg * orientation, 0)));
    }
}
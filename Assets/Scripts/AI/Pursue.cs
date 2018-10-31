using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AI that moves the object towards the target
public class Pursue : AI {
    // Initialize necessary variables
    [SerializeField]
    private float maxSpeed;

    // Override AI output
    override public void Output(Vector3 target) {
        Vector3 steering = target - player.position;
        steering.y = 0;
        player.AddForce((steering.normalized * maxSpeed) - player.velocity, ForceMode.VelocityChange);
    }
}

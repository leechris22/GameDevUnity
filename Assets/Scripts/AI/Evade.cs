using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AI that moves the object away from the target
public class Evade : AI {
    // Initialize necessary variables
    [SerializeField]
    private float maxSpeed;

    // Override AI output
    override public void Output(Vector3 target) {
        Vector3 steering = player.position - target;
        steering.y = 0;
        player.AddForce((steering.normalized * maxSpeed) - player.velocity, ForceMode.VelocityChange);
    }
}

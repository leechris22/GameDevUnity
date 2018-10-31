using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores data for an object used in AI calculations
public class NPCController : MonoBehaviour {
    // Store variables for objects
    [SerializeField]
    private Rigidbody target;
    [SerializeField]
    private AI[] ai;

    // Update the movement
    private void FixedUpdate() {
        foreach (AI ai in ai) {
            ai.Output(target.position);
        }
    }
}
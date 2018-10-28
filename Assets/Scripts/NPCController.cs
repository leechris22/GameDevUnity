using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores data for an object used in AI calculations
[RequireComponent(typeof (AI))]
public class NPCController : MonoBehaviour {
    // Store variables for objects
    [SerializeField]
    private Rigidbody target;
    public int state = 0;
    private AI ai;

    // On initialization
    private void Start() {
        ai = GetComponent<AI>();
    }
    // Update the movement
    private void FixedUpdate() {
        switch (state) {
            case 0:
                ai.Pursue(target.position);
                ai.Face(target.position);
                break;
            case 1:
                ai.Evade(target.position);
                ai.FaceAway(target.position);
                break;
            case 2:
                ai.PathFollow();
                break;
        }

    }
}
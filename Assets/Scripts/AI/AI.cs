using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base AI class
[RequireComponent(typeof(Rigidbody))]
public class AI : MonoBehaviour {
    // Set the object that contains this AI
    protected Rigidbody player;

    virtual protected void Start() {
        player = GetComponent<Rigidbody>();
    }

    // Base output function
    virtual public void Output(Vector3 target) {

    }
}

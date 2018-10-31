using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AI that makes object follow a path
[RequireComponent(typeof(Arrive))]
public class PathFollow : AI {
    // Initialize necessary variables
    [SerializeField]
    private Vector3[] Path;
    [SerializeField]
    private float targetRadius;
    private int current = 0;
    private Arrive arrive;

    override protected void Start() {
        player = GetComponent<Rigidbody>();
        arrive = GetComponent<Arrive>();
    }

    // Follow the path
    override public void Output(Vector3 target) {
        if (current < 0 || Path.Length <= current) {
            current = 0;
        } else {
            if ((Path[current] - player.position).magnitude > targetRadius) {
                arrive.Output(Path[current]);
            } else {
                current++;
            }
        }
    }
}

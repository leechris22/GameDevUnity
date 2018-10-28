using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController1 : MonoBehaviour {
    // Store variables for objects
    private AI ai;
    private Rigidbody rb;

    // For speed 
    public Vector3 position;
    public Vector3 velocity;

    // For rotation
    public float orientation;
    public float rotation;

    public float maxSpeed;

    public int state;

    private Vector3 linear;
    private float angular;

    public Text label;
    LineRenderer line;

    private void Start() {
        ai = GetComponent<AI>();
        rb = GetComponent<Rigidbody>();
        line = GetComponent<LineRenderer>();
        position = rb.position;
        orientation = transform.eulerAngles.y;
    }

    void FixedUpdate() {
        switch (state) {
            case 1:
                if (label) {
                    label.text = name.Replace("(Clone)","") + "\nAlgorithm: Dynamic Pursue";
                }
                linear = ai.Pursue();
                angular = ai.Face();
                break;
            case 2:
                if (label) {
                    label.text = name.Replace("(Clone)", "") + "\nAlgorithm: Dynamic Evade";
                }
                linear = ai.Evade();
                angular = ai.FaceAway();
                break;
            case 3:
                if (label) {
                    label.text = name.Replace("(Clone)", "") + "\nAlgorithm: Dynamic Arrive";
                }
                linear = ai.Arrive();
                angular = ai.Face();
                break;
            case 4:
                if (label) {
                    label.text = name.Replace("(Clone)", "") + "\nAlgorithm: Dynamic Wander";
                }
                angular = ai.Wander(out linear);
                break;
            case 5:
                if (label) {
                    label.text = name.Replace("(Clone)", "") + "\nAlgorithm: Path Finding";
                }
                linear = ai.PathFollow();
                angular = ai.pathFace();
                break;
        }
        update(linear, angular, Time.deltaTime);
        if (label) {
            label.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
        }
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

    public void CreatePoints(float radius) {
        line.positionCount = 51;
        line.useWorldSpace = false;
        float x;
        float z;
        float angle = 20f;

        for (int i = 0; i < 51; i++) {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, 0, z));
            angle += (360f / 51);
        }
    }

    public void DrawPoint(Vector3 position, float radius) {
        line.positionCount = 51;
        line.useWorldSpace = true;
        float x;
        float z;
        float angle = 20f;

        for (int i = 0; i < 51; i++) {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, 0, z)+position);
            angle += (360f / 51);
        }
    }

    public void DestroyPoints() {
        if (line) {
            line.positionCount = 0;
        }
    }
}

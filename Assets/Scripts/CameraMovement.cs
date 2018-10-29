using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    private int quadrant;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
        quadrant = 1;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        // Move the camera
        if (Input.GetKey(KeyCode.A)) { offset = Quaternion.AngleAxis(transform.eulerAngles.x * 0.05f, Vector3.up) * offset; }
        if (Input.GetKey(KeyCode.D)) { offset = Quaternion.AngleAxis(transform.eulerAngles.x * -0.05f, Vector3.up) * offset; }
        //if (Input.GetKey(KeyCode.W)) { offset = Quaternion.AngleAxis(transform.eulerAngles.x * 0.05f, Vector3.forward) * offset; }
        //if (Input.GetKey(KeyCode.S)) { offset = Quaternion.AngleAxis(transform.eulerAngles.x * -0.05f, Vector3.forward) * offset; }

        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }
}
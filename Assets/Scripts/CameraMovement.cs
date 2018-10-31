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
        /*if (Input.GetKey(KeyCode.A)) { offset = Quaternion.AngleAxis(5, Vector3.up) * offset; }
        if (Input.GetKey(KeyCode.D)) { offset = Quaternion.AngleAxis(-5, Vector3.up) * offset; }
        if (Input.GetKey(KeyCode.W)) {
            if (offset.y < player.transform.position.y + 10) { offset.y += 1; }
        }
        if (Input.GetKey(KeyCode.S)) {
            if (offset.y > 0) { offset.y -= 1; }
        }*/

        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }
}
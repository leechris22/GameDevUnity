using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    public GameObject boss;
    private Vector3 offset;
    private Vector3 normalizedOffset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        // Move the camera
        if (Input.GetKey(KeyCode.RightArrow)) { offset = Quaternion.AngleAxis(-1.655f, Vector3.up) * offset; }
        if (Input.GetKey(KeyCode.LeftArrow)) { offset = Quaternion.AngleAxis(1.655f, Vector3.up) * offset; }

        transform.position = player.transform.position + offset;
        transform.LookAt(boss.transform.position);
        transform.Rotate(new Vector3(10, 0));
    }
}
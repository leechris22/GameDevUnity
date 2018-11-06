using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    public GameObject boss;
    private Vector3 offset;
    float distance;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
        distance = offset.magnitude;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow)) { offset = Quaternion.AngleAxis(-distance / 6.5f, Vector3.up) * offset; }
        if (Input.GetKey(KeyCode.LeftArrow)) { offset = Quaternion.AngleAxis(distance / 6.5f, Vector3.up) * offset; }

        transform.position = player.transform.position - player.transform.forward * distance;
        transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        transform.LookAt(Vector3.Lerp(boss.transform.position, player.transform.position, 0.5f));
        transform.Rotate(new Vector3(10, 0));
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sends a mass of bullets around the object with a hole
public class ShockwaveHole : Attack {
    // Initialize necessary variables
    [SerializeField]
    private int size;
    [SerializeField]
    private float spacing;
    [SerializeField]
    private int hole;
    private GameObject[] notes;

    override public void Shoot(GameObject prefab) {
        // Initialize array and random number generator
        notes = new GameObject[size];
        int temphole = hole;
        if (hole == -1) {
            temphole = Random.Range(0, (int)Mathf.Floor(size / 4)) - (int)Mathf.Floor(size / 8);
            if (temphole < 0) {
                temphole += size;
            }
        }
        
        // Create a regular polygon with 'size' vertices and 'spacing' side length
        float radius = spacing / (2 * Mathf.Sin(Mathf.PI / size));
        float orientation = 0;
        for (int i = 0; i < size; i++) {
            if (i != temphole) {
                float x = Mathf.Sin(Mathf.Deg2Rad * orientation) * radius;
                float z = Mathf.Cos(Mathf.Deg2Rad * orientation) * radius;
                notes[i] = Instantiate<GameObject>(prefab);
                notes[i].transform.position = transform.TransformPoint(new Vector3(x, 0, z));
                notes[i].transform.rotation = transform.rotation;
                notes[i].transform.Rotate(new Vector3(0, orientation, 0));
                notes[i].GetComponent<Rigidbody>().AddForce(notes[i].transform.forward * 1000);
            }
            orientation += 360 / (float)size;
        }

    }
}
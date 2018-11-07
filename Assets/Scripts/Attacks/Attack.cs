using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base attack class, shoots forward
public class Attack : MonoBehaviour {
    // For all
    private GameObject note;
    [SerializeField]
    private GameObject prefab;
    private GameObject[] notes;

    // Base shoot class
    public void Shoot(int duration) {
        note = Instantiate<GameObject>(prefab);
        note.transform.position = transform.position;
        note.transform.rotation = transform.rotation;
        note.GetComponent<Rigidbody>().AddForce(note.transform.forward * 1000);
        if (duration != -1) {
            Destroy(note, duration);
        }
    }

    public void Shockwave(int size) {
        // Initialize array
        notes = new GameObject[size];

        // Create a regular polygon with 'size' vertices and 'spacing' side length
        float orientation = 0;
        for (int i = 0; i < size; i++) {
            notes[i] = Instantiate<GameObject>(prefab);
            notes[i].transform.position = transform.position;
            notes[i].transform.rotation = transform.rotation;
            notes[i].transform.Rotate(new Vector3(0, orientation, 0));
            notes[i].GetComponent<Rigidbody>().AddForce(notes[i].transform.forward * 1000);
            orientation += 360 / (float)size;
        }
    }

    public void Wall(int size, int hole) {
        // Initialize array
        notes = new GameObject[size];
        if (hole == -1) {
            hole = Random.Range(0, (int)Mathf.Floor(size / 4)) - (int)Mathf.Floor(size / 8);
            if (hole < 0) {
                hole += size;
            }
        }

        // Create a regular polygon with 'size' vertices and 'spacing' side length
        float orientation = 0;
        for (int i = 0; i < size; i++) {
            if (i != hole && i != hole - 1 && i != hole + 1) {
                notes[i] = Instantiate<GameObject>(prefab);
                notes[i].transform.position = transform.position;
                notes[i].transform.rotation = transform.rotation;
                notes[i].transform.Rotate(new Vector3(0, orientation, 0));
                notes[i].GetComponent<Rigidbody>().AddForce(notes[i].transform.forward * 1000);
                Destroy(notes[i], 3);
            }
            orientation += 360 / (float)size;
        }
    }
}

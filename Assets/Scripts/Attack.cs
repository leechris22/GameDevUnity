using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base attack class, shoots forward
public class Attack : MonoBehaviour {
    // For all
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Rigidbody player;
    private GameObject note;
    private GameObject[] notes;

    // Base shoot class
    public void Shoot(int duration) {
        note = Instantiate<GameObject>(prefab);
        note.transform.position = transform.position + transform.forward * 3;
        Quaternion direction = transform.rotation * Quaternion.LookRotation(transform.InverseTransformPoint(player.position + player.velocity));
        direction = Quaternion.Euler(0, direction.eulerAngles.y, direction.eulerAngles.z);
        note.transform.rotation = direction;
        note.GetComponent<Rigidbody>().AddForce(note.transform.forward * 1000);
        if (duration != -1) {
            Destroy(note, duration);
        }
    }

    // Creates a shockwave of size bullets
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
    
    // Creates a shockwave with size bullets and hole as the wall door
    // Rotation determines if the wall rotates with the player
    public void Wall(int size, int hole, bool rotation) {
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
                if (rotation) {
                    notes[i].transform.rotation = transform.rotation;
                }
                notes[i].transform.Rotate(new Vector3(0, orientation, 0));
                notes[i].GetComponent<Rigidbody>().AddForce(notes[i].transform.forward * 1000);
                Destroy(notes[i], 3);
            }
            orientation += 360 / (float)size;
        }
    }

    // Shoots ammount bullets of angle1 horizontal and angle2 vertical and speed
    public void Shotgun(int amount, int angle1, int angle2, int speed) {
        notes = new GameObject[amount];

        for (int i = 0; i < amount; i++) {
            notes[i] = Instantiate<GameObject>(prefab);
            notes[i].transform.position = transform.position;
            Quaternion upward = Quaternion.AngleAxis(Random.Range(-angle1, angle1), transform.up);
            Quaternion rightward = Quaternion.AngleAxis(Random.Range(-angle2, angle2), transform.right);
            notes[i].transform.rotation = transform.rotation * upward * rightward;
            notes[i].GetComponent<Rigidbody>().AddForce(notes[i].transform.forward * Random.Range(speed, speed+500));
        }
    }
}

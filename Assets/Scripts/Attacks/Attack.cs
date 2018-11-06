using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base attack class, shoots forward
public class Attack : MonoBehaviour {
    // Initialize necessary variables
    private GameObject note;

    // Base shoot class
    virtual public void Shoot(GameObject prefab) {
        note = Instantiate<GameObject>(prefab);
        note.transform.position = transform.position;
        note.transform.rotation = transform.rotation;
        note.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        Destroy(note, 3);
    }
}

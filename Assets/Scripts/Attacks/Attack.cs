using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base attack class, shoots forward
public class Attack : MonoBehaviour {
    // Initialize necessary variables
    private GameObject note;
    [SerializeField]
    private GameObject player;

    // Base shoot class
    virtual public void Shoot(GameObject prefab, int hole_center) {
        note = Instantiate<GameObject>(prefab);
        note.transform.position = transform.position;
        note.transform.rotation = transform.rotation;
        note.transform.LookAt(player.transform.position);
        note.GetComponent<Rigidbody>().AddForce(note.transform.forward * 1000);
        Destroy(note, 3);
    }
}

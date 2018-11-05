using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroys all game objects
public class BoundingBox : MonoBehaviour {
    // On collision with bullet, take damage
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerHealth>().Death();
        } else {
            Destroy(collision.gameObject);
        }
    }
}

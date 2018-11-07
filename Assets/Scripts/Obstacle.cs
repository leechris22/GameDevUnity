using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroys bullets
public class Obstacle : MonoBehaviour {
    // On collision with bullet, take damage
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("EnemyBullet")) {
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AI that makes the object face towards the target.
public class Face : AI {
    // Override AI output
    override public void Output(Vector3 target) {
        Vector3 direction = transform.InverseTransformPoint(target);
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        player.MoveRotation(player.rotation * Quaternion.Euler(new Vector3(0, angle, 0) * Time.deltaTime * 50));
    }
}

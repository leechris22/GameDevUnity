using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern : MonoBehaviour {
    [SerializeField]
    protected GameObject noteprefab;
    [SerializeField]
    private Attack attack;

	// Use this for initialization
	private void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) {
            attack.Shoot(noteprefab);
        }
    }
}

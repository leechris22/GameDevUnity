using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJCHILL : MonoBehaviour {
    [SerializeField]
    private Attack attack;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
            attack.Shotgun(20, 15, 15, 1000);
        }
	}
}

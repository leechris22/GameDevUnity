using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mprojectile : MonoBehaviour {

    Rigidbody rb;

    // Use this for initialization
    void Start () {
        Invoke("DestroyFamilier", 3);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, 1000));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void DestroyFamilier()
    {
        Destroy(gameObject);
    }
}
    
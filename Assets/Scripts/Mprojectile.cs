using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mprojectile : MonoBehaviour {

    Rigidbody rb;

    // Use this for initialization
    void Start () {
        Invoke("DestroyFamilier", 5);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(1, 0, 0));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void DestroyFamilier()
    {
        Destroy(gameObject);
    }
}
    
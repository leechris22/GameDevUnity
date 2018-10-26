using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manages Level 1
public class LevelManagerLevel1 : MonoBehaviour {
    // Add important gameobjects
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy;
    // By default, private variables are hidden on the inspector and public variables are shown
    // SerializeField is used to show a private variable on the inspector
    // [HideInInspector] can be used to hide a public variable on the inspector

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Reset the scene on key down R
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(1);
        }
    }
}

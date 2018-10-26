using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the Menu
public class LevelManagerMenu : MonoBehaviour {
	// Sets the default volume to half at startup
	private void Awake() {
        AudioListener.volume = 0.09f;
    }
}

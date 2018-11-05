using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Controls the Menu
public class LevelManagerMenu : MonoBehaviour {
    [SerializeField]
    private GameObject level2;
    [SerializeField]
    private GameObject level3;

    // Sets the default volume to half at startup
    private void Awake() {
        AudioListener.volume = 0.09f;
        level2.SetActive(Data.level2);
        level3.SetActive(Data.level3);
    }
}

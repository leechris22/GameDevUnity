using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Manages Level 3
public class LevelManagerLevel3 : LevelManager {
    // UI transitions
    [SerializeField]
    private GameObject ending;

    // Use this for initialization
    void Start() {

    }

    // Events when the game ends
    override public void NextLevel() {
        playerUI.SetActive(false);
        enemyUI.SetActive(false);
        ending.SetActive(true);
    }
}

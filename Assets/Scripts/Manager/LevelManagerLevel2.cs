using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Manages Level 2
public class LevelManagerLevel2 : LevelManager {
    // UI transitions
    [SerializeField]
    private GameObject nextLevel;

    // Use this for initialization
    void Start() {

    }

    // Events when the game ends
    override public void NextLevel() {
        playerUI.SetActive(false);
        enemyUI.SetActive(false);
        nextLevel.SetActive(true);
        Data.level3 = true;
    }
}

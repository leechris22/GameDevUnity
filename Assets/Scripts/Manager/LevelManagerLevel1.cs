using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Manages Level 1
public class LevelManagerLevel1 : LevelManager {
    // UI transitions
    [SerializeField]
    private GameObject nextLevel;

    // Use this for initialization
    void Start () {
        if (Story.level1_intro) {
            story.SetActive(true);
        }
        if (!story.activeSelf) {
            player.SetActive(true);
            enemy.SetActive(true);
        }
	}

    private void Update() {
        if (story.activeSelf && Input.GetKeyDown(KeyCode.Space)) {
            story.SetActive(false);
            Story.level1_intro = false;
            player.SetActive(true);
            enemy.SetActive(true);
        }
    }

    // Events when the game ends
    override public void NextLevel() {
        playerUI.SetActive(false);
        enemyUI.SetActive(false);
        nextLevel.SetActive(true);
        Data.level2 = true;
        player.SetActive(false);
        enemy.SetActive(false);
    }
}

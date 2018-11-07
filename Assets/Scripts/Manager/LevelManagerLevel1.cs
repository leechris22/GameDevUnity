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
    [SerializeField]
    private Image story;


    // Use this for initialization
    void Start () {
        if (Story.level1_intro) {
            story.enabled = true;
            player.SetActive(false);
            enemy.SetActive(false);
        }
	}

    override protected void Update() {
        if (story.enabled && Input.GetKeyDown(KeyCode.V)) {
            story.enabled = false;
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
        Story.level1_intro = false;
    }
}

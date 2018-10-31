using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Manages Level 1
public class LevelManagerLevel1 : MonoBehaviour {
    // Add important gameobjects
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy;

    // UI transitions
    [SerializeField]
    private GameObject playerUI;
    [SerializeField]
    private GameObject enemyUI;
    [SerializeField]
    private GameObject nextLevel;
    [SerializeField]
    private GameObject gameOver;

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

    // Events when the game ends
    public void NextLevel() {
        playerUI.SetActive(false);
        enemyUI.SetActive(false);
        nextLevel.SetActive(true);

    }

    // Events when the game ends
    public void GameOver() {
        playerUI.SetActive(false);
        enemyUI.SetActive(false);
        gameOver.SetActive(true);
    }
}

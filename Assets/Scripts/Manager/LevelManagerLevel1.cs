﻿using System.Collections;
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
    // By default, private variables are hidden on the inspector and public variables are shown
    // SerializeField is used to show a private variable on the inspector
    // [HideInInspector] can be used to hide a public variable on the inspector

    // Scoring
    private int currScore = 0;
    [SerializeField]
    private Text scoretext;

    // Game Over
    [SerializeField]
    private GameObject playerUI;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private Text highScoreText;
    [SerializeField]
    private Text currScoreText;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Reset the scene on key down R
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            AddScore(1);
        }
    }

    // Increases the current score by score
    private void AddScore(int score) {
        currScore += score;
        scoretext.text = "Score: " + currScore;
    }

    // Events when the game ends
    public void GameOver() {
        playerUI.SetActive(false);
        gameOver.SetActive(true);
        if (currScore > Data.highscore) {
            Data.highscore = currScore;
        }
        highScoreText.text = "High Score: " + Data.highscore;
        currScoreText.text = "Current Score: " + currScore;
    }
}
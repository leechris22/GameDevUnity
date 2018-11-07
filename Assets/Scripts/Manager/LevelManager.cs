using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Base class
public class LevelManager : MonoBehaviour {
    // Add important gameobjects
    [SerializeField]
    protected GameObject player;
    [SerializeField]
    protected GameObject enemy;

    // UI transitions
    [SerializeField]
    protected GameObject playerUI;
    [SerializeField]
    protected GameObject enemyUI;
    [SerializeField]
    protected GameObject gameOver;
    [SerializeField]
    protected GameObject story;

    // Events when the game ends
    virtual public void NextLevel() {}

    // Events when the game ends
    public void GameOver() {
        playerUI.SetActive(false);
        enemyUI.SetActive(false);
        gameOver.SetActive(true);
    }
}

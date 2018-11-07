using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Base class
public class LevelManager : MonoBehaviour {
    // UI transitions
    [SerializeField]
    protected GameObject playerUI;
    [SerializeField]
    protected GameObject enemyUI;
    [SerializeField]
    protected GameObject gameOver;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    virtual protected void Update () {
        // Reset the scene on key down R
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(1);
        }
    }

    // Events when the game ends
    virtual public void NextLevel() {}

    // Events when the game ends
    public void GameOver() {
        playerUI.SetActive(false);
        enemyUI.SetActive(false);
        gameOver.SetActive(true);
    }
}

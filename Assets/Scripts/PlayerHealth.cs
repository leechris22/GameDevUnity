﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    [SerializeField]
    private int maxHealth;
    private int currHealth;
    [SerializeField]
    private Slider healthbar;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private LevelManager levelManager;

    // Set current health to max health
    private void Start () {
        currHealth = maxHealth;
        healthbar.minValue = 0;
        healthbar.maxValue = maxHealth;
        healthbar.wholeNumbers = true;
        UpdateUI();
	}

    private void UpdateUI() {
        healthbar.value = currHealth;
        healthText.text = currHealth + " / " + maxHealth;
    }

    // Lower current health by damage
    public void Damaged(int damage) {
        currHealth -= damage;
        UpdateUI();

        if (currHealth <= 0) {
            Death();
        }
    }

    // Initialize death event when health reaches 0
    public void Death() {
        levelManager.GameOver();
        this.gameObject.SetActive(false);
    }

    // On collision with bullet, take damage
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("EnemyBullet")) {
            Damaged(1);
            Destroy(collision.gameObject);
        }
    }
}

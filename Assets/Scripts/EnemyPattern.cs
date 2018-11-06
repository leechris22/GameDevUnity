using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern : MonoBehaviour {
    [SerializeField]
    protected GameObject noteprefab;
    [SerializeField]
    private Attack attack;
    [SerializeField]
    private Shockwave shockwave;
    [SerializeField]
    private ShockwaveHole wall;
    private int enemyHealth;
    private int enemyMaxHealth;
    private int phase;
    AudioSource[] music;
    AudioSource activeMusic;

    private void Start() {
        phase = 1;
        activeMusic = null;
        music = GetComponents<AudioSource>();
        Invoke("starterBeat", 3);
        Invoke("startMusic", 3);
        enemyMaxHealth = GetComponent<EnemyHealth>().getMaxHealth();
    }

    // Use this for initialization
    private void Update()
    {
        enemyHealth = GetComponent<EnemyHealth>().getHealth();
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            attack.Shoot(noteprefab);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            shockwave.Shoot(noteprefab);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            wall.Shoot(noteprefab);
        }*/

        if (activeMusic != null) { print(activeMusic.time); }
        if (enemyHealth <= (enemyMaxHealth * 2 / 3) && activeMusic != null && activeMusic.time >= 13.69f && phase == 1) {
            phase = 2;
            startMusic();
            secondLayer();
            Invoke("secondLayer", 0.1f);
            Invoke("secondLayer", 0.2f);
        } else if (enemyHealth <= (enemyMaxHealth / 3) && activeMusic != null && activeMusic.time >= 13.69f && phase == 2) {
            phase = 3;
            thirdLayer();
            for (float i = 1; i < 20; i++) {
                Invoke("thirdLayer", i / 10f);
            }
            startMusic();
        }
    }

    private void startMusic() {
        if (phase == 1) {
            music[0].Play();
            activeMusic = music[0];
        } else if (phase == 2) {
            music[0].Stop();
            music[1].Play();
            activeMusic = music[1];
        } else if (phase == 3) {
            music[1].Stop();
            music[2].Play();
            activeMusic = music[2];
        }
    }

    private void starterBeat() {
        attack.Shoot(noteprefab);
        if (phase != 3) { Invoke("starterBeat", 1.7f); }
    }

    private void secondLayer() {
        shockwave.Shoot(noteprefab);
        Invoke("secondLayer", 1.7f);
    }

    private void thirdLayer()
    {
        attack.Shoot(noteprefab);
        Invoke("thirdLayer", 3.4f);
    }
}

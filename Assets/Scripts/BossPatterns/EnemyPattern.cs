using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern : MonoBehaviour {
    Animator anim;
    [SerializeField]
    private Attack attack;
    private int enemyHealth;
    private int enemyMaxHealth;
    private int phase;
    AudioSource[] music;
    AudioSource activeMusic;
    float pt1_rate;
    float pt2_rate;
    float pt3_rate;
    bool firstAttack=false;
    bool secondAttack=false;

    private void Start() {
        phase = 1;
        activeMusic = null;
        music = GetComponents<AudioSource>();
        Invoke("firstLayer", 3);
        Invoke("startMusic", 3);
        enemyMaxHealth = GetComponent<EnemyHealth>().getMaxHealth();
        anim = GetComponentInChildren<Animator>();
    }

    // Use this for initialization
    private void Update()
    {
        enemyHealth = GetComponent<EnemyHealth>().getHealth();
        if (enemyHealth <= 0) {
            CancelInvoke();
        }
        if (firstAttack)
        {
            anim.SetTrigger("shotattack");
            firstAttack = false;
        }
        if (secondAttack)
        {
            anim.SetTrigger("waveattack");
            secondAttack = false;
        }
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
            pt1_rate = music[0].clip.length / 8f;
        } else if (phase == 2) {
            music[0].Stop();
            music[1].Play();
            activeMusic = music[1];
            pt2_rate = music[1].clip.length / 8f;
        } else if (phase == 3) {
            music[1].Stop();
            music[2].Play();
            activeMusic = music[2];
            pt3_rate = music[2].clip.length / 4f;
        }
    }

    private void firstLayer() {
        attack.Shoot(-1);
        firstAttack = true;
        if (phase == 1) { Invoke("firstLayer", pt1_rate); }
    }

    private void secondLayer() {
        attack.Shockwave(50);
        secondAttack = true;
        Invoke("secondLayer", pt2_rate);
    }

    private void thirdLayer()
    {
        attack.Shoot(-1);
        firstAttack = true;
        Invoke("thirdLayer", pt3_rate);
    }
}

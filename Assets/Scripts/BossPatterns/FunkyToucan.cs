using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunkyToucan : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    protected GameObject noteprefab;
    [SerializeField]
    private Attack attack;
    private int enemyHealth;
    private int enemyMaxHealth;
    private int phase;
    AudioSource[] music;
    AudioSource activeMusic;
    float pt1_rate;
    float pt1_rate2;
    float pt2_rate;
    float pt3_rate;
    bool firstAttack = false;
    bool secondAttack = false;

    private void Start()
    {
        phase = 1;
        activeMusic = null;
        music = GetComponents<AudioSource>();
        Invoke("firstLayer", 3);
        Invoke("firstLayer2", 3.63f);
        Invoke("firstLayer2", 4.74f);
        Invoke("firstLayer2", 5.12f);
        Invoke("startMusic", 3);
        enemyMaxHealth = GetComponent<EnemyHealth>().getMaxHealth();
        anim = GetComponentInChildren<Animator>();
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
        if (activeMusic != null) { print(activeMusic.time); }
        if (enemyHealth <= (enemyMaxHealth * 2 / 3) && activeMusic != null && activeMusic.time >= 5.99f && phase == 1)
        {
            phase = 2;
            startMusic();
            secondLayer();
            Invoke("secondLayer", 0.36f);
            Invoke("secondLayer", 0.74f);
            Invoke("secondLayer2", 0.95f);
            Invoke("secondLayer3", 1.35f);
            Invoke("secondLayer3", 1.73f);
            Invoke("secondLayer4", 2.27f);
            Invoke("secondLayer4", 2.62f);
        }
        else if (enemyHealth <= (enemyMaxHealth / 3) && activeMusic != null && activeMusic.time >= 5.99f && phase == 2)
        {
            phase = 3;
            thirdLayer();
            Invoke("thirdLayer", 1.74f);
            Invoke("thirdLayer", 2.12f);
            startMusic();
        }
    }

    private void startMusic()
    {
        if (phase == 1)
        {
            music[0].Play();
            activeMusic = music[0];
            pt1_rate = music[0].clip.length / 24f;
            pt1_rate2 = music[0].clip.length / 2f;
        }
        else if (phase == 2)
        {
            music[0].Stop();
            music[1].Play();
            activeMusic = music[1];
            pt2_rate = music[1].clip.length / 2f;
        }
        else if (phase == 3)
        {
            music[1].Stop();
            music[2].Play();
            activeMusic = music[2];
            pt3_rate = music[2].clip.length / 4f;
        }
    }

    private void firstLayer()
    {
        attack.Shoot(-1);
        firstAttack = true;
        Invoke("firstLayer", pt1_rate);
    }

    private void firstLayer2()
    {
        attack.Shockwave(50);
        secondAttack = true;
        if (phase == 1) { Invoke("firstLayer2", pt1_rate2); }
    }

    private void secondLayer()
    {
        attack.Wall(50, 24, false);
        secondAttack = true;
        Invoke("secondLayer", pt2_rate);
    }

    private void secondLayer2()
    {
        attack.Wall(50, 26, false);
        secondAttack = true;
        Invoke("secondLayer2", pt2_rate);
    }

    private void secondLayer3()
    {
        attack.Wall(50, 28, false);
        secondAttack = true;
        Invoke("secondLayer3", pt2_rate);
    }

    private void secondLayer4()
    {
        attack.Shockwave(50);
        secondAttack = true;
        Invoke("secondLayer4", pt2_rate);
    }

    private void thirdLayer()
    {
        attack.Shotgun(15, 15, 15, 1000);
        firstAttack = true;
        Invoke("thirdLayer", pt3_rate);
    }
}
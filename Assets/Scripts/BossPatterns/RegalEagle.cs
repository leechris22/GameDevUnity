using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegalEagle : MonoBehaviour {
    [SerializeField]
    protected GameObject noteprefab;
    [SerializeField]
    private Attack attack;
    [SerializeField]
    private Shockwave shockwave;
    [SerializeField]
    private ShockwaveHole wall;
    [SerializeField]
    private GameObject player;
    private int enemyHealth;
    private int enemyMaxHealth;
    private int phase;
    private AudioSource[] music;
    private AudioSource activeMusic;
    private float pt1_rate;
    private float pt2_rate;
    private float pt3_rate;
    private float starting_dir;

    private void Start()
    {
        phase = 1;
        Invoke("startphasethreeeee", 1);
        activeMusic = null;
        /*music = GetComponents<AudioSource>();
        Invoke("firstLayer", 3);
        Invoke("firstLayer", 4.1f);
        Invoke("firstLayer", 4.6f);
        Invoke("firstLayer", 5.8f);
        Invoke("firstLayer", 7);
        Invoke("firstLayer", 7.4f);
        Invoke("firstLayer", 7.8f);
        Invoke("firstLayer", 8.2f);
        Invoke("firstLayer", 8.4f);
        Invoke("startMusic", 3);
        enemyMaxHealth = GetComponent<EnemyHealth>().getMaxHealth();*/
    }

    // Use this for initialization
    private void Update()
    {
        enemyHealth = GetComponent<EnemyHealth>().getHealth();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attack.Shoot(noteprefab, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            shockwave.Shoot(noteprefab, 1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            wall.Shoot(noteprefab, 0);
        }

        /*if (activeMusic != null) { print(activeMusic.time); }
        if (enemyHealth <= (enemyMaxHealth * 2 / 3) && activeMusic != null && activeMusic.time >= 5.75f && phase == 1)
        {
            phase = 2;
            startMusic();
            Invoke("secondLayer", 0.65f);
            Invoke("secondLayer", 2.41f);
            Invoke("secondLayer", 3.52f);
            Invoke("secondLayer", 5.3f);
        }
        else if (/*enemyHealth <= (enemyMaxHealth / 3) && activeMusic != null && activeMusic.time >= 5.75f &&*/if (phase == 2)
        {
            phase = 3;
            starting_dir = Mathf.Atan2(Mathf.Abs(player.transform.position.x - transform.position.x), Mathf.Abs(player.transform.position.z - transform.position.z)) * Mathf.Rad2Deg % 50;
            print(starting_dir);
            thirdLayer();
            for (float i = 1; i < 20; i++)
            {
                Invoke("thirdLayer", i / 10f);
            }
            startMusic();
        }
    }

    private void startMusic()
    {
        if (phase == 1)
        {
            music[0].Play();
            activeMusic = music[0];
            pt1_rate = music[0].clip.length;
        }
        else if (phase == 2)
        {
            music[0].Stop();
            music[1].Play();
            activeMusic = music[1];
            pt2_rate = music[1].clip.length;
        }
        else if (phase == 3)
        {
            music[1].Stop();
            music[2].Play();
            activeMusic = music[2];
            pt3_rate = 5.75f;//music[2].clip.length / 8f;
        }
    }

    private void firstLayer()
    {
        shockwave.Shoot(noteprefab, 0);
        Invoke("firstLayer", pt1_rate);
    }

    private void secondLayer()
    {
        attack.Shoot(noteprefab, 0);
        Invoke("secondLayer", pt2_rate);
    }

    private void thirdLayer()
    {
        wall.Shoot(noteprefab, (int)starting_dir);
        //Invoke("thirdLayer", 5.75f);
    }

    private void startphasethreeeee()
    {
        phase = 2;
    }
}

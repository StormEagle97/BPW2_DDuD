using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class ZombieWaves : MonoBehaviour
{
    public GameObject[] spawns;
    public GameObject[] Zombies;

    public PointScript pointScript;
    public SoundManagerScript soundManager;

    public GunController gunScript;

    public InGameMenu menu;

    private GameObject spawn;
    public GameObject[] enemy;

    public Vector3 m_Size = new Vector3(80.0f, 20.0f, 80.0f);

    public bool ZombieSpawns = true;

    public int WaveNr = 1;

    private int index = 0;
    public int ZombiesAWave = 6;
    public int Zombieskilled = 0;
    public int ZombiesSpawned = 0;

    public float spawnDelay;

    void Start() {
        pointScript = FindObjectOfType<PointScript>();
        soundManager = FindObjectOfType<SoundManagerScript>();
        menu = FindObjectOfType<InGameMenu>();
        gunScript = FindObjectOfType<GunController>();

    }

    void Update ()
    {
        Zombies = GameObject.FindGameObjectsWithTag("Enemy");
        if (menu.paused)  {
            ZombieSpawns = false;
        }
        else if (!menu.paused) {
            ZombieSpawns = true;
        }

    }

    void FixedUpdate()
    {
        if (!menu.paused)
            index++;

        Wave();
    }

   public void Wave()
    {
        if (ZombiesSpawned < ZombiesAWave)
        {
            if (index >= Seconds(spawnDelay) && Zombies.Length < 40 && spawns.Length > 0 && ZombieSpawns)
            {
                GameObject NewEnemy = enemy[Random.Range(0, enemy.Length)];
                int Chosen = Random.Range(0, spawns.Length); // creates a number between 1 and the amount of spawns
                spawn = GameObject.Find(spawns[Chosen].name);
                NewEnemy.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z);
                Instantiate(NewEnemy);
                ZombiesSpawned++;
                index = 0;
            }
        }
        else
        {
            if (Zombies.Length == 0)
            {
                pointScript.Wave = pointScript.Wave + 1;
                WaveNr++;

                if(spawnDelay >= 0.75)
                    {
                        spawnDelay = spawnDelay - 0.15f;
                    }

                soundManager.addWaveSound = true;
                soundManager.StartWaveSound();
                ZombiesAWave = ZombiesAWave + (3 * WaveNr);
                Zombieskilled = 0;
                pointScript.ZombiesLeftDisplay.text = ZombiesAWave.ToString();
                ZombiesSpawned = 0;

                gunScript.nadesLeft = 4;

                index = 0;
            }
        }
    }
    float Seconds(float seconds){
        return seconds * 60;
    }
}
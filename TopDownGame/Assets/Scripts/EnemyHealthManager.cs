using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int health;
    private int currentHealth;
    private Rigidbody myRB;

    private int zombiesleft;

    public GameObject BodyParts;
    public GameObject EnemyModel;
    public GameObject HurtZone;

    private bool isDying = false;


    public PointScript pointScript;

    private EnemyController Controller;
    private ZombieWaves ZombieWavesController;

    void Start () {
        currentHealth = health;
        BodyParts.SetActive(false);
        EnemyModel.SetActive(true);
        Controller = gameObject.GetComponent<EnemyController>();
        ZombieWavesController = FindObjectOfType<ZombieWaves>();
        myRB = GetComponent<Rigidbody>();
        pointScript = FindObjectOfType<PointScript>();

    }
    void Update () {
		if(currentHealth <= 0)
        {
            StartCoroutine(Despawn());
            BodyParts.SetActive(true);
            EnemyModel.SetActive(false);
            HurtZone.SetActive(false);
            Controller.isDead = true;
            Destroy(GetComponent<CapsuleCollider>());
            myRB.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        }
    }

    public void HurtEnemy (int damage)
    {
        currentHealth -= damage;
        pointScript.Score = pointScript.Score += 10;
    }

    IEnumerator Despawn()
    {
        if (!isDying)
        {
            isDying = true;
            pointScript.Score = pointScript.Score += 50;
            ZombieWavesController.Zombieskilled++; 
            zombiesleft = ZombieWavesController.ZombiesAWave - ZombieWavesController.Zombieskilled;
            pointScript.ZombiesLeftDisplay.text = zombiesleft.ToString();
            yield return new WaitForSeconds(8);
            isDying = false;
            Destroy(gameObject);
        }

    }
}

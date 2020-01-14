using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float bulletSpeed;
    public GameObject BloodEffect;
    public GameObject WallHit;
    public float lifeTime;

    public PlayerController playerController;

    public SoundManagerScript soundManager;

    public int damageToGive;

	void Start () {
        playerController = FindObjectOfType<PlayerController>();
        soundManager = FindObjectOfType<SoundManagerScript>();
    }

    void Update () {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)   {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision collission)
    {

        if(collission.gameObject.tag == "Enemy")
        {
            soundManager.zombieHit = true;
            soundManager.ZombieHit();
            Destroy(gameObject);
            ContactPoint contact = collission.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(BloodEffect, pos, rot);

            collission.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }

        if (collission.gameObject.tag == "Scenery")
        {

            ContactPoint contact = collission.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(WallHit, pos, rot);
        }
    }
}

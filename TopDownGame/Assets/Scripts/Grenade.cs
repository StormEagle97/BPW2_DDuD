using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    public float explosionTimer = 2;
    float countdown;
    public float radius = 200;
    public float force = 750;
    public int damageToGive;
    public int damageToGivePlayer;
    public bool toxicNade;

    public GameObject BloodEffectBoosted;

    public bool explosionSign;

    public int throwSpeed = 1400;
    public GunController guncontrol;
    private Rigidbody rigid;

    [SerializeField] GameObject exploParticle;

    public bool hasExploded = false;

	void Start ()
    {
        countdown = explosionTimer;
        explosionSign = false;
//        rigid = GetComponent<Rigidbody>();
//        rigid.AddForce(PlayerRotation1*50, 130, PlayerRotation2*50);

        guncontrol = FindObjectOfType<GunController>();
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded)
        {
            Explode();
        }
	}

    public void Explode()
    {
        if (!toxicNade)

        {
            guncontrol.ExplosionSoundPlayer();
        }

        GameObject spawnedParticle = Instantiate(exploParticle, transform.position, transform.rotation);
        Destroy(spawnedParticle, 4);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliders)
        {

            EnemyHealthManager HP = nearbyObject.GetComponent<EnemyHealthManager>();
            if (HP != null)
            {
                HP.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
                Instantiate(BloodEffectBoosted, transform.position, transform.rotation);
            }
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius, 2);
            }
            PlayerHealthManager Health = nearbyObject.GetComponent<PlayerHealthManager>();
            if (Health != null)
            {
                Health.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGivePlayer);
                Instantiate(BloodEffectBoosted, transform.position, transform.rotation);
            }
        }
        hasExploded = true;
        Destroy(gameObject);
    }
}

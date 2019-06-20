using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody myRB;
    public float moveSpeed;

    public bool isDead = false;

    public PlayerController thePlayer;

	void Start () {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
	}
	
    void FixedUpdate ()   {
        if (!isDead)
        {
            myRB.velocity = (transform.forward * moveSpeed);
        }
    }

	void Update () {
        if (!isDead)
        {
            transform.LookAt(thePlayer.transform.position);
        }
	}
}

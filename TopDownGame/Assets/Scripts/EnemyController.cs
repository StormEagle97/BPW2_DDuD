using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour {

    private Rigidbody myRB;
    public float moveSpeed;

    public bool isDead = false;

    public PlayerController thePlayer;

    private NavMeshAgent agent;

	void Start () {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
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
            agent.SetDestination(thePlayer.transform.position);
            transform.LookAt(thePlayer.transform.position);
        }
	}
}

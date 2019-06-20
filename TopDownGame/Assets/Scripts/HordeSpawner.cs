using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeSpawner : MonoBehaviour {

    public bool spawned = false;

    public GameObject horde;

	void Start () {
        horde.SetActive(false);
    }

    void Update()
    {

    }

    private void OnTriggerEnter (Collider col) {
        if (!spawned && col.tag == "Player")
        {
            horde.SetActive(true);
        }
    }
}

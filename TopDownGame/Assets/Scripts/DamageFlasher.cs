using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlasher : MonoBehaviour {

    public float flashLength;
    private float flashCounter;

    public PlayerController playerController;

    private SkinnedMeshRenderer rend;
    private Color storedColor;

	void Start () {
        rend = GetComponent<SkinnedMeshRenderer>();
        storedColor = rend.material.GetColor("_Color");
	}
	
	void Update () {
        if(flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }
	}

    public void Flasher()
    {
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.red);
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {

    public int startingHealth;
    private int currentHealth;

    public float flashLength;
    private float flashCounter;
    public float backBlow;
    public PointScript pointScript;

    public PlayerController playerController;
    public SoundManagerScript soundManager;
    private Renderer rend;
    private Color storedColor;

    public DamageFlasher flasher;

	void Start () {
        playerController = FindObjectOfType<PlayerController>();
        currentHealth = startingHealth;
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
        flasher = GetComponentInChildren<DamageFlasher>();
        pointScript = FindObjectOfType<PointScript>();
        soundManager = FindObjectOfType<SoundManagerScript>();
    }

    void Update () {
		if(currentHealth <-0)
        {
            int tmpScore = PlayerPrefs.GetInt("HighScoreWave");
            if (tmpScore == null)
                tmpScore = 0;
            if (pointScript.Wave > tmpScore)
            {
                Globals<int>.OnHighScoreChangedHandler(pointScript.Wave);
                Globals<int>.OnHighScorePointsChangedHandler(pointScript.Score);
            }
            SceneManager.LoadScene(2);
        }

        if(flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }
	}

    public void HurtPlayer(int damageAmount)
    {
        flasher.Flasher();
        currentHealth -= damageAmount;
        soundManager.PlayerDamageSound();
        pointScript.Lives = pointScript.Lives - damageAmount;
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.red);
//        Rigidbody a = playerController.GetComponent<Rigidbody>();
//        a.AddForce(new Vector3(backBlow, 0, backBlow), ForceMode.Impulse);
    }

}


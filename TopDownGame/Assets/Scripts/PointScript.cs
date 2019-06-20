using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointScript : MonoBehaviour
{

    public ZombieWaves waves;
    public GunController nades;

    public int Score = 0;
    public Text PointsDisplay;
    public int Wave = 1;
    public Text WaveDisplay;
    public int Lives = 10;
    public Text LivesDisplay;
    public int NadeLeft = 4;
    public Text NadeLeftDisplay;
    public int ZombiesLeft = 0;
    public Text ZombiesLeftDisplay;

    void Start()    {
        waves = FindObjectOfType<ZombieWaves>();
        nades = FindObjectOfType<GunController>();
        ZombiesLeftDisplay.text = waves.ZombiesAWave.ToString();
    }

    void Update()
    {
        PointsDisplay.text = Score.ToString();
        WaveDisplay.text = Wave.ToString();
        LivesDisplay.text = Lives.ToString();
        NadeLeftDisplay.text = nades.nadesLeft.ToString();
    }
}

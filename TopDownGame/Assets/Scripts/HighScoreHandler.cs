using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreHandler : MonoBehaviour
{
    public TextMeshProUGUI HighScoreWaveText;
    public TextMeshProUGUI HighScorePointsText;

    private int waveScore = 0;
    private int pointsScore = 0;

    private void Start()
    {
        waveScore = PlayerPrefs.GetInt("HighScoreWave");
        pointsScore = PlayerPrefs.GetInt("HighScorePoints");

        HighScoreWaveText.text = "High Score Wave: " + waveScore;
        HighScorePointsText.text = "High Score Points: " + pointsScore;
    }

}

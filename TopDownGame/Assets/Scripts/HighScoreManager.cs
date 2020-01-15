using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zombies.Score
{
    public class HighScoreManager : MonoBehaviour
    {
        private int highScore = 0;

        private void Start()
        {
            Globals<int>.OnHighScoreChangedHandler += SetHighScore;
            Globals<int>.OnHighScorePointsChangedHandler += SetPointsScore;
        }

        public void SetHighScore(int score)
        {
            PlayerPrefs.SetInt("HighScoreWave", score);
        }

        public void SetPointsScore(int score)
        {
            PlayerPrefs.SetInt("HighScorePoints", score);
        }
    }
}

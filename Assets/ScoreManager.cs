using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("HighScore", 0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = $"SCORE: {PlayerPrefs.GetInt("Score")}";
        highscoreText.text = $"HIGHSCORE: {PlayerPrefs.GetInt("Score")}";
    }
}

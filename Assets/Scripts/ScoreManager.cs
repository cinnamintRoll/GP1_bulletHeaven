using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    int score = 0;
    int highscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " Points";
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int scoreValue;
     public static ScoreUI scoreUI { get; private set; }

    void Awake()
    {
        SetupScoreUIController();
    }

    void Start()
    {
        scoreText=GetComponent<TextMeshProUGUI>();
        scoreValue=0;
        AddScore(0);
    }

    private void SetupScoreUIController()
    {
        if (scoreUI != null && scoreUI != this)
        {
            Destroy(this);
        }
        else
        {
            scoreUI = this;
        }
    }

    private void UpdateScore(string _scoreValue)
    {
       scoreText.text =_scoreValue;
    }

    public void AddScore(int _scoreIncrement)
    {
        scoreValue+=_scoreIncrement;
        UpdateScore(scoreValue.ToString());
    }
}
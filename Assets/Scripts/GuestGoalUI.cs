using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GuestGoalUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int scoreValue;

    void Start()
    {
        scoreText=GetComponent<TextMeshProUGUI>();
        scoreValue=0;
        AddScore(0);
    }

    private void UpdateScore(string _scoreValue)
    {
       scoreText.text ="Guests: "+_scoreValue +"/3";
    }

    public void AddScore(int _scoreIncrement)
    {
        scoreValue+=_scoreIncrement;
        UpdateScore(scoreValue.ToString());
        if(scoreValue>=3)
            PalaceController.palaceController.LoadFinalScene();
    }
}

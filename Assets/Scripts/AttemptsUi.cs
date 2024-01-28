using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttemptsUi : MonoBehaviour
{
    private TextMeshProUGUI attemptsText;
    private int attemptsValue;

    void Start()
    {
        attemptsText=GetComponent<TextMeshProUGUI>();
        attemptsValue=0;
        AddScore(0);
    }

    private void UpdateScore(string _scoreValue)
    {
       attemptsText.text ="Próby: "+_scoreValue +"/10";
    }

    public void AddScore(int _scoreIncrement)
    {
        attemptsValue+=_scoreIncrement;
        UpdateScore(attemptsValue.ToString());
        if(attemptsValue>10)
            PalaceController.palaceController.ShowEndScreen();
    }
}

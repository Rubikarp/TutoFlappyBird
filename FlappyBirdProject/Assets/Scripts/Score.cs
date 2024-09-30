using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int _score = 0;
    public int MyScore
    {
        get => _score;
        set
        {
            _score = value;
            scoreSlot.text = prefix + _score.ToString();
        }
    }


    public TextMeshProUGUI scoreSlot;
    public string prefix = "Score : ";
    private void Awake()
    {
        MyScore = 0;
    }

    public void AddScore(int pScore = 1)
    {
        MyScore += pScore;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;

    public TextMeshProUGUI scoreSlot;
    public string prefix = "Score : ";
    private void Awake()
    {
        scoreSlot.text = prefix + score.ToString();
    }

    public void AddScore(int pScore = 1)
    {
        score += pScore;
        scoreSlot.text = prefix + score.ToString();
    }
}

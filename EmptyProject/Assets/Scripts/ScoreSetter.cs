using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSetter : MonoBehaviour
{
    [SerializeField] Text scoreLabel;
    [SerializeField] Text bestScoreLabel;
    

    public void setScore(float score, float bestScore)
    {
        scoreLabel.text = score.ToString();
        bestScoreLabel.text = bestScore.ToString();
    }
}

using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private float score;

    private void OnEnable()
    {
        Enemy.DestroyEnemy += IncreasingScore;
    }

    private void OnDisable()
    {
        Enemy.DestroyEnemy -= IncreasingScore;
    }

    private void IncreasingScore(object sender, EventArgs args)
    {
        if(sender is Enemy)
        {
            score += ((Enemy)sender).Cost;
            scoreText.text = score.ToString();
        }
    }
}

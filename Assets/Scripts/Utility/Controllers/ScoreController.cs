using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    public int score;

    public int scoreMin = 0;
    public int scoreMax = 9999;

    public static ScoreController instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScore();
    }

    public void GainScore(int amount)
    {
        score += amount;
        score = Mathf.Clamp(score, scoreMin, scoreMax);
        UpdateScore();
    }

    public void LoseScore(int amount)
    {
        score -= amount;
        score = Mathf.Clamp(score, scoreMin, scoreMax);
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}

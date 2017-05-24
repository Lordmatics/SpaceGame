using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    public int score;

    public Text hiscoreText;
    public int hiscore;

    public int scoreMin = 0;
    public int scoreMax = 9999;

    public static ScoreController instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LoadHiScore();
    }

    public void LoadHiScore()
    {
        if(PlayerPrefs.HasKey("HiScore"))
        {
            int temp = PlayerPrefs.GetInt("HiScore");
            hiscore = temp;
        }
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
        if(score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetInt("HiScore", hiscore);
        }
        hiscoreText.text = "Hi-Score: " + hiscore.ToString();
    }
}

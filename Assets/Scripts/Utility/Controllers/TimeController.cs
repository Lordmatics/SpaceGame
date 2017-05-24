using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    //public Timer timer;

    public float secondsPassed;

    public static TimeController instance;

    public bool bTimerTicking = false;

    public float customSeconds = 0.0f;

    // Every 60 seconds empower enemies
    public float refreshRate = 60.0f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GameController.instance.timeText.text = customSeconds.ToString("00");
    }

    public void StartTimer()
    {
        //timer = new Timer();
        //timer.ResetToZero();
        bTimerTicking = true;
    }

    void Update()
    {
        UpdateTimeText();
    }

    public void UpdateTimeText()
    {
        if (!bTimerTicking) return;

        customSeconds += Time.deltaTime;

        //secondsPassed = timer.GetElapsedTime();
        GameController.instance.timeText.text = customSeconds.ToString("00");
    }
}

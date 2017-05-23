using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer 
{

    [SerializeField][Header("Value to track timer")]
    private float lastTimeRecorded = 0.0f;

    public Timer()
    {
        lastTimeRecorded = 0.0f;
    }

    // Update timer to match game time
    public void ResetTimer()
    {
        lastTimeRecorded = Time.time;
    }

    // Subtract custom timer from game time to return difference
    public float GetElapsedTime()
    {
        return Time.time - lastTimeRecorded;
    }
}

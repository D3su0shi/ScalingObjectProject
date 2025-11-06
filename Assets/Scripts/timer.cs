using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Scripting;

[Preserve]
public class Timer : MonoBehaviour
{
    private float timerDuration;
    private float elapsedTime = 0.0f;
    private bool isRunning = false;
    private bool isFinishedFlag = false;

    public float Duration
    {
        get { return timerDuration; }
        set
        {
            timerDuration = value;
            elapsedTime = 0.0f;
            isRunning = false;
            isFinishedFlag = false;
        }
    }
    public bool Finished
    {
        get { return isFinishedFlag; }
    }


    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= timerDuration && timerDuration > 0.0f)
            {
                elapsedTime = timerDuration;
                isFinishedFlag = true;
                stop();
            }
        }
    }

    public void Run()
    {
        if (timerDuration > 0.0f)
        {
            elapsedTime = 0.0f;
            isFinishedFlag = false;

            isRunning = true;
            Debug.Log("Timer started.");
        }
        else
        {
            Debug.LogWarning("Timer cannot run: Duration is 0 or less.");
        }
    }

    public void stop()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        elapsedTime = 0.0f;
        isRunning = false;
        isFinishedFlag = false;
        Debug.Log("Timer reset.");
    }


    public float getCurrentTime()
    {
        float remaining = timerDuration - elapsedTime;
        return Mathf.Max(0.0f, remaining);
    }

    public bool IsRunning()
    {
        return isRunning;
    }


    public void displayTime()
    {
        float remainingSeconds = getCurrentTime();
        int totalSeconds = Mathf.FloorToInt(remainingSeconds);
        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;

        string timeString = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        Debug.Log("Time Left: " + timeString);
    }
}
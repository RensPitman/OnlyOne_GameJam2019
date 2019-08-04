using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [Header("Timer")]
    public int MaxTime;
    [HideInInspector]
    public float currentTime;

    public int Minutes;
    public int Seconds;

    [HideInInspector]
    public bool timerIsOn;

    public bool GameHasStarted;

    private void Start()
    {
        currentTime = MaxTime;
        timerIsOn = true;
    }


    public void UpdateLevelTimer(float totalSeconds)
    {
        Minutes = Mathf.FloorToInt(totalSeconds / 60f);
        Seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = Seconds.ToString();

        if (Seconds == 60)
        {
            Seconds = 0;
            Minutes += 1;
        }

        //timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }


    private void Update()
    {
        if (timerIsOn)
        {
            Timer();
        }

    }

    void Timer()
    {
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            UpdateLevelTimer(currentTime);
        }
        else
        {
            timerIsOn = false;
            currentTime = 0;
            Minutes = 0;
            Seconds = 0;
            print("DONE");
        }
    }
}

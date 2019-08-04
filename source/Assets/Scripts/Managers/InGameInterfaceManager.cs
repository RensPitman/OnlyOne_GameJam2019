using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameInterfaceManager : MonoBehaviour
{
    [Header("Counter")]
    public Text CounterText;

    [Header("Timer")]
    public Text TimerText;
    public Image FillCirlce;

    private void Update()
    {
        UpdateCounter();
        UpdateTimer();
    }

    void UpdateCounter()
    {
        CounterText.text = GameManager.Player.AllAgents.Count.ToString();
    }

    void UpdateTimer()
    {
        TimerText.text = GameManager.Gameplay.Minutes.ToString("00") + ":" + GameManager.Gameplay.Seconds.ToString("00");

        // Timer Circle
        FillCirlce.fillAmount = Custom.map(GameManager.Gameplay.currentTime, 0, GameManager.Gameplay.MaxTime, 0, 1);
    }
}

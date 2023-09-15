using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TextMeshProUGUI TimerTxt;

    void Start()
    {
        TimerOn = true;
    }

    void Update()
    {
        if (TimerOn)
        {
            TimeLeft += Time.deltaTime;
            updateTimer(TimeLeft);
            updateTimer(TimeLeft);
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.Floor(currentTime / 60);
        float secondes = Mathf.Floor(currentTime % 60);
        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, secondes);
    }
}
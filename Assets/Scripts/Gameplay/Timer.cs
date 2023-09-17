using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    public float TimeLeft;

    public TextMeshProUGUI TimerTxt;
    
    
    void Update()
    {
        if (GameManager.instance.canBug)
        {
            TimeLeft += Time.deltaTime;
            UpdateTimer(TimeLeft);
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.Floor(currentTime / 60);
        float secondes = Mathf.Floor(currentTime % 60);
        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, secondes);
    }
}
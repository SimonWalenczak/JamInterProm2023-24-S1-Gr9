using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public List<ScreenObject> Screens;
    public List<Alarm> Alarms;

    private void Start()
    {
        for (int i = 0; i < Screens.Count; i++)
        {
            if(Screens[i].GetComponentInChildren<KeyboardManager>() != null)
                Screens[i].GetComponentInChildren<KeyboardManager>().SetupKeyCode();
                
            Alarms.Add(Screens[i].GetComponent<Alarm>());
        }
    }

    private void Update()
    {
        for (int i = 0; i < Alarms.Count; i++)
        {
            if (GameManager.instance.canBug && !Screens[i].IsBugged)
            {
                Alarms[i].ActualTimer -= Time.deltaTime;

                if (Alarms[i].ActualTimer <= 0)
                {
                    if (Screens[i].ChanceBug())
                    {
                        Screens[i].LaunchBug();
                    }

                    Alarms[i].MakeTimer();
                }
            }
        }
    }
}
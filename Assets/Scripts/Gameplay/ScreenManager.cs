using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public List<ScreenObject> Screens;
    [HideInInspector] public List<Alarm> Alarms;
    

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
        foreach (var alarm in Alarms)
        {
            switch (alarm.Type)
            {
                case TypeOfTimer.Easy:
                    alarm.GetComponent<ScreenObject>().FirstTimerSet = true;
                    break;
                case TypeOfTimer.Medium:
                    if (GameManager.instance.MULTI2Unlock)
                        alarm.GetComponent<ScreenObject>().FirstTimerSet = true;
                    break;
                case TypeOfTimer.Hard:
                    if (GameManager.instance.MULTI3Unlock)
                        alarm.GetComponent<ScreenObject>().FirstTimerSet = true;
                    break;
            }
        }
        
        for (int i = 0; i < Alarms.Count; i++)
        {
            if (GameManager.instance.canBug && !Screens[i].IsBugged && !Screens[i].IsBroken && Screens[i].FirstTimerSet)
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

            if (Screens[i].IsBroken)
            {
                if (Screens[i].GetComponentInChildren<Keyboard>() != null)
                {
                    Screens[i].GetComponentInChildren<Keyboard>().touch.SetActive(false);
                }
                
                Screens[i].gameObject.SetActive(false);
            }
        }
    }
}
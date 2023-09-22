using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen6Manager : MonoBehaviour
{
    public ScreenObject screen6;

    public Keypad Digicode;
    public GameObject DisplayDigicode;

    public static Screen6Manager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There is already a Screen6Manager in this scene !");
        }
    }

    private void Update()
    {
        if (screen6.IsBroken)
            DisplayDigicode.SetActive(false);
        else
        {
            if (screen6.IsBugged)
            {
                DisplayDigicode.SetActive(true);
            }
            else
            {
                DisplayDigicode.SetActive(false);
            }
        }
    }
}
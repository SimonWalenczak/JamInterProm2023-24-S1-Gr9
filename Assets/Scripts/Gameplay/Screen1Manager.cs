using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class Screen1Manager : MonoBehaviour
{
    public int StartValue;
    public int TargetValue;
    public int ActualValue;

    public int MinValue;
    public int MaxValue;

    public static Screen1Manager Instance;

    public ScreenObject Screen1;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        ActualValue = StartValue;
    }

    private void Update()
    {
        if (ActualValue > MaxValue)
        {
            ActualValue = MaxValue;
            if(ActualValue == TargetValue)
                ResetScreen();
        }

        if (ActualValue < MinValue)
        {
            ActualValue = MinValue;
            if(ActualValue == TargetValue)
                ResetScreen();
        }
    }
    
    public void ResetScreen()
    {
        Screen1.IsBugged = false;
        gameObject.SetActive(false);
    }

    public void ChooseFrequency()
    {
        Random rnd = new Random();
        
        TargetValue = rnd.Next(MinValue, MaxValue);
        
        print("TargetValue : " + TargetValue);
        
        if(TargetValue == ActualValue)
            ChooseFrequency();
    }
}
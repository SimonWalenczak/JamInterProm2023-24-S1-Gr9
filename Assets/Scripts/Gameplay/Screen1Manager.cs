using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Screen1Manager : MonoBehaviour
{
    public int TargetValue;
    public int ActualValue;

    public int MinValue;
    public int MaxValue;

    public static Screen1Manager Instance;
    
    
    public GameObject buggedScreen1;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        ActualValue = 0;
    }

    private void Update()
    {
        if (ActualValue >= MaxValue)
            ActualValue = MaxValue;
        if (ActualValue <= MinValue)
            ActualValue = MinValue;

        /*if (ActualValue == TargetValue)
        {
            ResetScreen();
        }*/
        print(ActualValue);
    }
    
    public void ResetScreen()
    {
        print("screen 1 reset");
        buggedScreen1.SetActive(false);
    }

    public void ChooseFrequency()
    {
        TargetValue = Random.Range(MinValue, MaxValue);
    }
}
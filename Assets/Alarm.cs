using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public enum TypeOfTimer
{
    Easy,
    Medium,
    Hard
}

public class Alarm : MonoBehaviour
{
    [HideInInspector] public float ActualTimer;
    [SerializeField] private int _minTimerValue;
    [SerializeField] private int _maxTimerValue;

    private float _timeMultiplicator;
    public TypeOfTimer Type;

    private void Start()
    {
        DefineTimeMultiplicator();
        MakeTimer();
    }

    private void Update()
    {
        DefineTimeMultiplicator();
    }

    private void DefineTimeMultiplicator()
    {
        switch (Type)
        {
            case TypeOfTimer.Easy:
                _timeMultiplicator = GameManager.instance.TimeMultiplicator1;
                break;
            case TypeOfTimer.Medium:
                _timeMultiplicator = GameManager.instance.TimeMultiplicator2;
                break;
            case TypeOfTimer.Hard:
                _timeMultiplicator = GameManager.instance.TimeMultiplicator3;
                break;
        }
    }

    public void MakeTimer()
    {
        Random random = new Random();
        double _startingTimer =
            random.NextDouble() * (_timeMultiplicator * (_maxTimerValue - _minTimerValue)) +
            _minTimerValue * _timeMultiplicator;

        ActualTimer = (float) _startingTimer;
    }
}
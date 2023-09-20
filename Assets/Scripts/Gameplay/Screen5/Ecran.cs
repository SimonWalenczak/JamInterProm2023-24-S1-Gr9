using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class Ecran : MonoBehaviour
{
    private float _startingTimer;
    private float _actualTimer;

    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    public Interactable interactable;

    private float TimeBeforeStartBug;
    private bool FirstTimerSet;
    
    private void Start()
    {
        TimeBeforeStartBug = GameManager.instance.startTimerMulti2;
    }

    public void MakeTimer()
    {
        Random random = new Random();
        double _startingTimer =
            random.NextDouble() * (_maxValue * GameManager.instance.TimeMultiplicator2 -
                                   _minValue * GameManager.instance.TimeMultiplicator2) +
            _minValue * GameManager.instance.TimeMultiplicator2;

        _actualTimer = (float) _startingTimer;
    }

    private void Update()
    {
        if (FirstTimerSet && interactable.IsActive == false)
        {
            _actualTimer -= Time.deltaTime;

            if (_actualTimer <= 0)
            {
                interactable.IsActive = true;
                gameObject.SetActive(!gameObject.activeSelf);
            }
        }

        if (GameManager.instance.canBug)
        {
            TimeBeforeStartBug -= Time.deltaTime;

            if (TimeBeforeStartBug <= 0)
            {
                MakeTimer();
                FirstTimerSet = true;
            }
        }
    }
}
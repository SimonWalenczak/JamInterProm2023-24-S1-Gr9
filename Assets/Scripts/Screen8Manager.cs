using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Screen8Manager : MonoBehaviour
{
    public float _actualTimerBugScreen;
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    public float ActualTimer;
    public GameObject video1;
    public GameObject video2;

    public bool IsAlien;

    public GameObject screen;

    private void Start()
    {
        MakeTimer();
    }

    public void MakeTimer()
    {
        Random random = new Random();
        double _startingTimer =
            random.NextDouble() * (_maxValue * GameManager.instance.TimeMultiplicator1 -
                                   _minValue * GameManager.instance.TimeMultiplicator1) +
            _minValue * GameManager.instance.TimeMultiplicator1;

        _actualTimerBugScreen = (float) _startingTimer;
    }

    private void Update()
    {
        if (IsAlien == false)
        {
            ActualTimer -= Time.deltaTime;
            if (ActualTimer <= 0)
            {
                IsAlien = true;
                ActualTimer = 5;
                video1.SetActive(false);
                video2.SetActive(true);
            }
        }

        if (screen.activeSelf == false)
        {
            _actualTimerBugScreen -= Time.deltaTime;

            if (_actualTimerBugScreen <= 0)
            {
                MakeTimer();
                screen.SetActive(true);
                screen.GetComponent<KeyboardManager>().ChooseKeyboard();
            }
        }
    }

    public void OnMouseDown()
    {
        if (screen.activeSelf == false && GameManager.instance.desactivSystem == false)
        {
            video1.SetActive(true);
            video2.SetActive(false);
            IsAlien = false;
        }
    }
}
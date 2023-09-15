using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Screen8Manager : MonoBehaviour
{
    [SerializeField] private float invasionTimer;
    public float _actualTimerBugScreen;
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    public float ActualTimer;
    public GameObject video1;
    public GameObject video2;

    public bool IsAlien;

    public GameObject screen;

    [SerializeField] private int minChanceValue;
    [SerializeField] private int maxChanceValue;
    private void Start()
    {
        MakeTimer();
        ActualTimer = invasionTimer;
    }

    public void MakeTimer()
    {
        Random random = new Random();
        double _startingTimer =
            random.NextDouble() * (_maxValue * GameManager.instance.TimeMultiplicator1 -
                                   _minValue * GameManager.instance.TimeMultiplicator1) +
            _minValue * GameManager.instance.TimeMultiplicator1;

        _actualTimerBugScreen = (float)_startingTimer;
    }

    private void Update()
    {
        if (IsAlien == false)
        {
            ActualTimer -= Time.deltaTime;
            if (ActualTimer <= 0)
            {
                IsAlien = true;
                ActualTimer = invasionTimer;
                video1.SetActive(false);
                video2.SetActive(true);
            }
        }

        if (screen.activeSelf == false)
        {
            _actualTimerBugScreen -= Time.deltaTime;

            if (_actualTimerBugScreen <= 0)
            {
                Random random = new Random();
                int chance = random.Next(minChanceValue, maxChanceValue + 1);

                if (chance == minChanceValue)
                {
                    MakeTimer();
                    screen.SetActive(true);
                    screen.GetComponent<KeyboardManager>().ChooseKeyboard();
                }
            }
        }
    }

    public BigButton BigButton;

    public void OnMouseDown()
    {
        if (screen.activeSelf == false && GameManager.instance.desactivSystem == false)
        {
            video1.SetActive(true);
            video2.SetActive(false);
            IsAlien = false;
            BigButton.canResetScreen = true;
        }
    }
}
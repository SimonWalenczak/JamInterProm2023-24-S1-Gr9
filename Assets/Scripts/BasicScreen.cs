using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BasicScreen : MonoBehaviour
{
    public GameObject screenBugged;

    public float actualTimer;
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

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

        actualTimer = (float) _startingTimer;
    }

    private void Update()
    {
        if (screenBugged.activeSelf == false && GameManager.instance.canBug)
        {
            actualTimer -= Time.deltaTime;

            if (actualTimer <= 0)
            {
                Random random = new Random();
                int chance = random.Next(1, 4);

                if (chance == 1)
                {
                    if (GameManager.instance.isFirstScreen == false)
                    {
                        MakeTimer();
                        screenBugged.SetActive(true);
                        screenBugged.GetComponent<KeyboardManager>().ChooseKeyboard();
                    }
                }
                else
                {
                    MakeTimer();
                }
            }
        }
    }
}
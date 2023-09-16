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

    [SerializeField] private int minChanceValue;
    [SerializeField] private int maxChanceValue;

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
                int chance = random.Next(minChanceValue, maxChanceValue + 1);

                if (chance == minChanceValue)
                {
                    if (GameManager.instance.isFirstScreen == false)
                    {
                        MakeTimer();
                        GetComponent<AudioSource>().Play();
                        screenBugged.SetActive(true);
                        //screenBugged.GetComponent<KeyboardManager>().ChooseKeyboard();
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
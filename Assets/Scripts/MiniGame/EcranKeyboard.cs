using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class EcranKeyboard : MonoBehaviour
{
    private float _startingTimer;
    private float _actualTimer;
    public GameObject ScreenPlay;
    public GameObject ScreenBug;

    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    public Interactable interactable;
    

    private void Start()
    {
        MakeTimer();
    }
    
    public void MakeTimer()
    { 
        Random random = new Random();
        double _startingTimer = random.NextDouble() * (_maxValue - _minValue) + _minValue;
        
        _actualTimer = (float) _startingTimer;
    }
    
    private void Update()
    {
        _actualTimer -= Time.deltaTime;

        if (_actualTimer <= 0)
        {
            interactable.IsActive = true;
            gameObject.SetActive(false);
        }
    }
}
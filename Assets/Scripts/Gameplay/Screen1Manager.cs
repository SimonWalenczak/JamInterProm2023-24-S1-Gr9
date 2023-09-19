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

    private SpriteRenderer _spriteRenderer;
    private Color _color;

    private bool _wasOn;

    public bool _canRefresh;

    [SerializeField] private int difference;

    private int lastValue;
    Quaternion targetRotation;
    public Transform spriteRoulette;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _color = _spriteRenderer.color;
        lastValue = ActualValue;
    }

    private void Update()
    {
        if (lastValue != ActualValue)
        {
            if (lastValue < ActualValue)
                targetRotation = Quaternion.Euler(0, 0, spriteRoulette.transform.rotation.eulerAngles.z - 10);
            else
                targetRotation = Quaternion.Euler(0, 0, spriteRoulette.transform.rotation.eulerAngles.z + 10);

            lastValue = ActualValue;
            spriteRoulette.transform.rotation = targetRotation;
            spriteRoulette.gameObject.GetComponent<AudioSource>().Play();
        }
        
        if (ActualValue > MaxValue)
        {
            ActualValue = MaxValue;
            if (ActualValue == TargetValue)
                ResetScreen();
        }

        if (ActualValue < MinValue)
        {
            ActualValue = MinValue;
            if (ActualValue == TargetValue)
                ResetScreen();
        }

        if (_canRefresh && ActualValue == TargetValue)
            ResetScreen();
    }

    public void CalculateDiff()
    {
        difference = Mathf.Abs(TargetValue - ActualValue);

        if (difference > 10)
            difference = 10;

        _color.a = 0.1f * difference;

        _spriteRenderer.color = _color;
    }

    public void ResetScreen()
    {
        Screen1.IsBugged = false;
        gameObject.SetActive(false);
    }

    public void ChooseFrequency()
    {
        if (!_wasOn)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _color = _spriteRenderer.color;
            ActualValue = StartValue;
            _wasOn = true;
        }

        Random rnd = new Random();

        TargetValue = rnd.Next(MinValue, MaxValue);

        print("TargetValue : " + TargetValue);

        if (TargetValue == ActualValue)
            ChooseFrequency();

        CalculateDiff();
    }
}
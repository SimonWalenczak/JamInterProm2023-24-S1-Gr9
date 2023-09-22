using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[RequireComponent(typeof(AudioSource))]
public class ScreenObject : MonoBehaviour
{
    [SerializeField] private int minChanceValue;
    [SerializeField] private int maxChanceValue;

    [Space(10)] [Header("Bugged Screen")] public bool IsBroken;
    public bool IsBugged;
    public GameObject ScreenBugged;

    [Space(10)] [Header("Audio")] [HideInInspector]
    public AudioSource _audioSource;

    public int clipToPlay;
    public List<AudioClip> Clips;

    public float _startBuggedTimer;
    private float buggedTimer;

    public AudioSource OffTV;

    [HideInInspector] public bool FirstTimerSet;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public bool ChanceBug()
    {
        Random random = new Random();
        int chance = random.Next(minChanceValue, maxChanceValue + 1);

        return chance == minChanceValue;
    }

    public void LaunchBug()
    {
        IsBugged = true;
        _audioSource.clip = Clips[clipToPlay];
        _audioSource.Play();
        ScreenBugged.SetActive(true);

        if (ScreenBugged.GetComponent<Screen1Manager>() != null)
        {
            ScreenBugged.GetComponent<Screen1Manager>().ChooseFrequency();
        }

        if (ScreenBugged.GetComponent<Keyboard>() != null)
        {
            if (!ScreenBugged.GetComponent<Keyboard>()._wasOn)
                ScreenBugged.GetComponent<Keyboard>().keyCodes = KeyboardManager._instance.KeyCodes;

            ScreenBugged.GetComponent<Keyboard>().ChooseKeyboard();
        }
        
        if (gameObject.GetComponent<Screen6Manager>() != null)
        {
            gameObject.GetComponent<Screen6Manager>().Digicode.DefineCode();
        }
    }

    public void BrokeTV()
    {
        OffTV.Play();
        IsBroken = true;
    }
    
    private void Update()
    {
        if (IsBugged)
        {
            buggedTimer -= Time.deltaTime;

            if (buggedTimer <= 0)
            {
               BrokeTV();
            }
        }
        else
        {
            buggedTimer = _startBuggedTimer;
        }
    }
}
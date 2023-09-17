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

    [Space(10)] [Header("Bugged Screen")] public bool IsBugged;
    public GameObject ScreenBugged;

    [Space(10)] [Header("Audio")] [HideInInspector]
    public AudioSource _audioSource;

    public int clipToPlay;
    public List<AudioClip> Clips;

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

        if (ScreenBugged.GetComponent<Keyboard>() != null)
        {
            if (!ScreenBugged.GetComponent<Keyboard>()._wasOn)
                ScreenBugged.GetComponent<Keyboard>().keyCodes = KeyboardManager._instance.KeyCodes;

            ScreenBugged.GetComponent<Keyboard>().ChooseKeyboard();
        }
    }
}
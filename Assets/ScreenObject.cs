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

    [Space(10)] [Header("Debug")]
    public bool IsBugged;
    public GameObject ScreenBugged;
    
    [Space(10)]
    [HideInInspector] public AudioSource _audioSource;
    public List<AudioClip> Clips;
    public int clipToPlay;

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
        ScreenBugged.GetComponent<KeyboardManager>().ChooseKeyboard();
    }
}
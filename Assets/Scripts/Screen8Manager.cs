using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Screen8Manager : MonoBehaviour
{
    [SerializeField] private float invasionTimer;
    
    public float ActualTimer;
    public GameObject video1;
    public GameObject video2;

    public bool IsAlien;

    public BigButton BigButton;
    public GameObject BuggedScreen;

    public AudioSource _audioSource;
    
    private void Start()
    {
        ActualTimer = invasionTimer;
    }
    
    private void Update()
    {
        if (IsAlien == false)
        {
            _audioSource.mute = true;
            
            ActualTimer -= Time.deltaTime;
            if (ActualTimer <= 0)
            {
                IsAlien = true;
                ActualTimer = invasionTimer;
                video1.SetActive(false);
                video2.SetActive(true);
            }
        }
        else
        {
            _audioSource.mute = false;
            _audioSource.Play();
        }
    }

    public void OnMouseDown()
    {
        if (BuggedScreen.activeSelf == false && GameManager.instance.desactivSystem == false)
        {
            video1.SetActive(true);
            video2.SetActive(false);
            IsAlien = false;
            BigButton.CanResetScreen = true;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public enum TypeOfSwitcher
{
    Lever,
    MusicButton
}

public class Switcher : MonoBehaviour
{
    public TypeOfSwitcher SwitcherType;

    [Space(10)] public List<Sprite> LeverSprites;

    [Space(10)] public List<Sprite> MusicButtonSprites;

    [Space(10)] public List<Sprite> ActualSprites;

    [Space(20)] private bool IsLever;
    private bool IsMusicButton;

    private float timerRnd;

    private SpriteRenderer _spriteRenderer;


    [HideInInspector] public bool _isUsing;
    public bool IsRed;

    private AudioSource _audioSource;

    void Start()
    {
        switch (SwitcherType)
        {
            case TypeOfSwitcher.Lever:
                ActualSprites = LeverSprites;
                IsLever = true;
                break;
            case TypeOfSwitcher.MusicButton:
                ActualSprites = MusicButtonSprites;
                IsMusicButton = true;
                break;
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnMouseDown()
    {
        if (GameManager.instance.canBug)
        {
            _spriteRenderer.sprite = ActualSprites[0];
            
            if (IsMusicButton && GameManager.instance.desactivSystem)
                return;

            _isUsing = true;
            
            if (IsLever)
                _audioSource.Play();
            else if (IsMusicButton && GetComponent<Screen8Manager>().IsAlien )
            {
                GetComponent<Screen8Manager>().IsAlien = false;
                _audioSource.Play();
            }
        }
    }

    public void OnMouseUp()
    {
        _isUsing = false;
        _spriteRenderer.sprite = ActualSprites[1];

        if (IsRed)
        {
            GameManager.instance.desactivSystem = false;
            IsRed = false;
        }
    }
}
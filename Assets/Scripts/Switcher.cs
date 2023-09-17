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

    [Space(10)] public List<Sprite> SpritesList;

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
                SpritesList = SwitcherManager._instance.listOfListsOfSprites[0].spriteList;
                IsLever = true;
                break;
            case TypeOfSwitcher.MusicButton:
                SpritesList = SwitcherManager._instance.listOfListsOfSprites[1].spriteList;
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
            _spriteRenderer.sprite = SpritesList[0];

            if (IsMusicButton && GameManager.instance.desactivSystem)
                return;

            _isUsing = true;

            if (IsLever)
                _audioSource.Play();
            else if (IsMusicButton && GetComponent<Screen8Manager>().IsAlien &&
                     GetComponent<Screen8Manager>().BuggedScreen.activeSelf == false &&
                     GameManager.instance.desactivSystem == false)
            {
                _audioSource.Play();
                GetComponent<Screen8Manager>().KillAliens();
            }
        }
    }

    public void OnMouseUp()
    {
        _isUsing = false;
        _spriteRenderer.sprite = SpritesList[1];

        if (IsRed)
        {
            GameManager.instance.desactivSystem = false;
            IsRed = false;
        }
    }
}
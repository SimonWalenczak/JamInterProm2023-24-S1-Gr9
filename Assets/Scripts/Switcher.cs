using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Switcher : MonoBehaviour
{
    public bool IsLever;
    public bool IsOutsideScreen;
    public Sprite LevierSprite1;
    public Sprite LevierSprite2;

    public Sprite LampSprite1;
    public Sprite LampSprite2;
    private float timerRnd;

    public SpriteRenderer _spriteRendererLevier;
    public SpriteRenderer _spriteRendererLamp;

    public int MinTimer;
    public int MaxTimer;

    public bool IsRed;
    public bool IsStarting;


    void Start()
    {
        if (IsLever)
            MakeTimer();

        _spriteRendererLevier = GetComponent<SpriteRenderer>();
    }

    public void MakeTimer()
    {
        timerRnd = Random.Range(MinTimer, MaxTimer);
        IsStarting = true;
    }

    private void Update()
    {
        if (IsStarting && IsLever)
        {
            timerRnd -= Time.deltaTime;

            if (timerRnd <= 0)
            {
                _spriteRendererLamp.sprite = LampSprite2;
                IsStarting = false;
                IsRed = true;
                GameManager.instance.desactivSystem = true;
            }
        }
    }

    public void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = LevierSprite2;
    }

    public void OnMouseUp()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = LevierSprite1;

        if (IsRed)
        {
            GameManager.instance.desactivSystem = false;
            IsRed = false;
            _spriteRendererLamp.sprite = LampSprite1;
            MakeTimer();
        }
    }
}
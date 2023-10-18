using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LampDesktop : MonoBehaviour
{
    public Switcher switcher;
    //private SpriteRenderer _spriteRenderer;

    [SerializeField] private List<Sprite> _sprites;

    [Space(10)] [Header("Lever Timer")] public int MinTimer;
    public int MaxTimer;
    private float timerRnd;

    private void Start()
    {
        //_spriteRenderer = GetComponent<SpriteRenderer>();

        MakeLeverTimer();
    }

    private void MakeLeverTimer()
    {
        timerRnd = Random.Range(MinTimer, MaxTimer);
    }

    private void Update()
    {
        if (GameManager.instance.canBug)
        {
            if (!switcher.IsRed)
            {
                timerRnd -= Time.deltaTime;

                if (timerRnd <= 0)
                {
                    //_spriteRenderer.sprite = _sprites[1];
                    GetComponent<Animator>().SetBool("LightOn", false);
                    switcher.IsRed = true;
                    GameManager.instance.desactivSystem = true;
                }
            }
        }

        if (switcher._isUsing)
        {
            MakeLeverTimer();
           //_spriteRenderer.sprite = _sprites[0];
            GetComponent<Animator>().SetBool("LightOn", true);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SliderManager : MonoBehaviour
{
    public Interactable interactable;

    public List<Sprite> ModelForms;
    public List<Sprite> PlayerForms;

    public List<SpriteRenderer> ModelsSprites;
    public List<SpriteRenderer> ActualSprites;

    public List<Slider> Sliders;

    private int nbSucces;

    public float _startBuggedTimer;
    private float buggedTimer;
    
    public GameObject Screen5;
    public AudioSource OffTV;

    [Header("Score")] public int ScoreIncreased;
    public void StartChallenge()
    {
        foreach (var modelSprite in ModelsSprites)
        {
            modelSprite.sprite = ModelForms[Random.Range(0, 3)];
        }
    }

    private void Update()
    {
        if (interactable.IsActive)
        {
            buggedTimer -= Time.deltaTime;

            if (buggedTimer <= 0)
            {
                OffTV.Play();
                Screen5.SetActive(false);
            }
        }
        else
        {
            buggedTimer = _startBuggedTimer;
        }

        if (GameManager.instance.desactivSystem)
        {
            foreach (var slider in Sliders)
            {
                slider.interactable = false;
            }
        }
        else
        {
            foreach (var slider in Sliders)
            {
                slider.interactable = true;
            }
        }

        for (int i = 0; i < Sliders.Count; i++)
        {
            ActualSprites[i].sprite = PlayerForms[(int)Sliders[i].value];
        }

        for (int i = 0; i < Sliders.Count; i++)
        {
            if (ModelsSprites[i].sprite == ActualSprites[i].sprite)
            {
                nbSucces++;
            }
        }

        if (nbSucces == 3)
        {
            StartChallenge();
            GameData.ActualScore += ScoreIncreased;
            interactable.ResetScreen();
        }

        nbSucces = 0;
    }

    private void Start()
    {
        interactable = GetComponent<Interactable>();
        StartChallenge();
    }
}
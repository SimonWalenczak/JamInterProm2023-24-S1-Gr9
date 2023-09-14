using System;
using System.Collections;
using System.Collections.Generic;
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
    public void StartChallenge()
    {
        foreach (var modelSprite in ModelsSprites)
        {
            modelSprite.sprite = ModelForms[Random.Range(0, 3)];
        }
        
    }

    private void Update()
    {
        for (int i = 0; i < Sliders.Count; i++)
        {
            ActualSprites[i].sprite = PlayerForms[(int)Sliders[i].value];
        }
    }

    private void Start()
    {
        StartChallenge();
    }
}
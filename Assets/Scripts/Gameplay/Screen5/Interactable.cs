using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
    public Ecran ecran;
    public bool IsActive;

    public List<Sprite> LoupiotteScreenSprites;
    public SpriteRenderer LoupiotteScreen;
    
    public void ResetScreen()
    {
        if (GameManager.instance.canBug)
        {
            ecran.gameObject.SetActive(gameObject.activeSelf);
            ecran.MakeTimer();
            IsActive = false;
        }
    }

    private void Update()
    {
        LoupiotteScreen.sprite = IsActive ? LoupiotteScreenSprites[1] : LoupiotteScreenSprites[0];
    }
}
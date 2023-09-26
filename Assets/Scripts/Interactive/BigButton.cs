using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigButton : MonoBehaviour
{
    public List<Keyboard> Keyboards;
    public Screen1Manager Screen1Manager;
    public Ecran screen5;
    public Keypad Keypad;
    
    public bool CanResetScreen;

    public Sprite BigButtonUnarmedSprite;
    public Sprite BigButtonArmedSprite;
    public Sprite BigButtonActiveSprite;

    private SpriteRenderer _spriteRenderer;
    private bool _isUsing;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        CanResetScreen = false;
    }

    private void Update()
    {
        if (!CanResetScreen)
        {
            _spriteRenderer.sprite = BigButtonUnarmedSprite;
        }
        else if (!_isUsing)
        {
            _spriteRenderer.sprite = BigButtonArmedSprite;
        }
        else
            _spriteRenderer.sprite = BigButtonActiveSprite;
    }

    private void OnMouseDown()
    {
        if (CanResetScreen && GameManager.instance.canBug)
        {
            _isUsing = true;
            GetComponent<AudioSource>().Play();

            foreach (var keyboard in Keyboards)
            {
                if (!keyboard._wasOn)
                {
                    keyboard.keyCodes = KeyboardManager._instance.KeyCodes;
                }

                keyboard.RestoreSignal();
            }
            
            Screen1Manager.ResetScreen();
            screen5.interactable.ResetScreen();
            Keypad.ResetScreen();
        }
    }

    private void OnMouseUp()
    {
        CanResetScreen = false;
        _isUsing = false;
    }
}
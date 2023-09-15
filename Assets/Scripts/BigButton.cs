using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigButton : MonoBehaviour
{
    public List<KeyboardManager> KeyboardManagers;
    
    public bool canResetScreen;

    private void Start()
    {
        canResetScreen = true;
    }
    

    private void OnMouseDown()
    {
        if (GameManager.instance.isFirstScreen == false && canResetScreen)
        {
            canResetScreen = false;
            foreach (var keyboardManager in KeyboardManagers)
            {
                keyboardManager.gameObject.SetActive(false);
            }
        }
    }
}

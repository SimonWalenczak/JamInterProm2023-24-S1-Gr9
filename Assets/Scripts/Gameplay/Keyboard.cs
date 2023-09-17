using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public List<KeyCode> keyCodes = new List<KeyCode>();
    public int randIndex;

    public GameObject touch;
    public TMP_Text KeyboardTouch;
    
    [HideInInspector] public bool _wasOn;
    
    void Update()
    {
        if (Input.GetKeyDown(keyCodes[randIndex]))
        {
            RestoreSignal();
        }
    }

    public void RestoreSignal()
    {
        touch.SetActive(false);
        GetComponentInParent<ScreenObject>().IsBugged = false;
        gameObject.SetActive(false);
    }
    
    public void ChooseKeyboard()
    {
        randIndex = Random.Range(0,21);
        print(randIndex);
        KeyCode random = keyCodes[randIndex];
        KeyboardTouch.text = random.ToString().Replace("KeyCode.", "");
        touch.SetActive(true);
    }
}

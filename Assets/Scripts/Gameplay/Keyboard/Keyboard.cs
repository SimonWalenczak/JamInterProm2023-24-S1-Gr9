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

    [Header("Score")] public int ScoreIncreased;

    void Update()
    {
        if (Input.GetKeyDown(keyCodes[randIndex]))
        {
            RestoreSignal();
        }
    }

    public void RestoreSignal()
    {
        if (GetComponent<Keyboard>() != null)
        {
            touch.SetActive(false);
        }

        if (GetComponentInParent<ScreenObject>() != null)
            GetComponentInParent<ScreenObject>().IsBugged = false;

        GameData.ActualScore += ScoreIncreased;

        gameObject.SetActive(false);
    }

    public void ChooseKeyboard()
    {
        randIndex = Random.Range(0, 21);
        KeyCode random = keyCodes[randIndex];
        KeyboardTouch.text = random.ToString().Replace("KeyCode.", "");
        touch.SetActive(true);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardManager : MonoBehaviour
{
    public TMP_Text KeyboardTouch;
    private List<KeyCode> KeyCodes = new List<KeyCode>();
    private int randIndex;

    // Start is called before the first frame update
    void Start()
    {
        KeyCodes.Add((KeyCode)'a');
        KeyCodes.Add((KeyCode)'b');
        KeyCodes.Add((KeyCode)'c');
        KeyCodes.Add((KeyCode)'d');
        KeyCodes.Add((KeyCode)'e');
        KeyCodes.Add((KeyCode)'f');
        KeyCodes.Add((KeyCode)'g');
        KeyCodes.Add((KeyCode)'h');
        KeyCodes.Add((KeyCode)'i');
        KeyCodes.Add((KeyCode)'j');
        KeyCodes.Add((KeyCode)'k');
        KeyCodes.Add((KeyCode)'l');
        KeyCodes.Add((KeyCode)'m');
        KeyCodes.Add((KeyCode)'n');
        KeyCodes.Add((KeyCode)'o');
        KeyCodes.Add((KeyCode)'p');
        KeyCodes.Add((KeyCode)'q');
        KeyCodes.Add((KeyCode)'r');
        KeyCodes.Add((KeyCode)'s');
        KeyCodes.Add((KeyCode)'t');
        KeyCodes.Add((KeyCode)'u');
        KeyCodes.Add((KeyCode)'v');
        KeyCodes.Add((KeyCode)'w');
        KeyCodes.Add((KeyCode)'x');
        KeyCodes.Add((KeyCode)'y');
        KeyCodes.Add((KeyCode)'z');
        ChooseKeyboard();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCodes[randIndex]))
        {
            gameObject.SetActive(false);
        }
    }
    public void ChooseKeyboard()
    {
        randIndex = Random.Range(0,27);
        KeyCode random = KeyCodes[randIndex];
        KeyboardTouch.text = random.ToString().Replace("KeyCode.", "");
    }
}
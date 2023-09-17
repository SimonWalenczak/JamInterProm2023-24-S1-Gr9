using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigiCodeTouch : MonoBehaviour
{
    public Sprite TouchReleased;
    public Sprite TouchPressed;

    public void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = TouchPressed;
        }
    }
}

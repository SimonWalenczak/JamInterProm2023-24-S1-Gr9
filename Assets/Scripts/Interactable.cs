using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
    public Ecran ecran;
    public bool IsActive;
    
    public void ResetScreen()
    {
        ecran.gameObject.SetActive(true);
        ecran.MakeTimer();
        IsActive = false;
    }
}

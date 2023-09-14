using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool desactivSystem;

    public float TimeMultiplicator;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}

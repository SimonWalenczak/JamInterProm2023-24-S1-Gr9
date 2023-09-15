using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool desactivSystem;

    public float TimeMultiplicator1 = 1;
    public float TimeMultiplicator2 = 1;
    public float TimeMultiplicator3 = 1;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}

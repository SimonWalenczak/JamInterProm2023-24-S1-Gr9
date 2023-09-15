using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool desactivSystem;

    #region TimerBasicScreen
    public float TimeMultiplicator1 = 1;
    public float TimeMultiplicator2 = 1;
    public float TimeMultiplicator3 = 1;

    [Header ("Start Timer")]
    [SerializeField] private float startTimerMulti1 = 30;
    [SerializeField] private float startTimerMulti2 = 60;
    [SerializeField] private float startTimerMulti3 = 180;
    
    [Space (10)][Header ("First Reduce")]
    [SerializeField] private float firstReduceMulti1 = 0.1f;
    [SerializeField] private float firstReduceMulti2 = 0.5f;
    [SerializeField] private float firstReduceMulti3 = 0.5f;
    
    [Space (10)][Header ("Recursive Timer")]
    [SerializeField] private float RepetTimerMulti1 = 30;
    [SerializeField] private float RepetTimerMulti2 = 60;
    [SerializeField] private float RepetTimerMulti3 = 60;
    
    [Space (10)][Header ("Other Reduce")]
    [SerializeField] private float otherReduceMulti1 = 0.1f;
    [SerializeField] private float otherReduceMulti2 = 0.1f;
    [SerializeField] private float otherReduceMulti3 = 0.1f;
    
    private float actualTimerMULTI1;
    private float actualTimerMULTI2;
    private float actualTimerMULTI3;

    private bool MULTI2Unlock;
    private bool MULTI3Unlock;
    #endregion

    public bool isFirstScreen;
    public bool canBug;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        Cursor.visible = false;
    }

    private void Start()
    {
        isFirstScreen = true;
        canBug = true;
        
        actualTimerMULTI1 = startTimerMulti1;
        actualTimerMULTI2 = startTimerMulti2;
        actualTimerMULTI3 = startTimerMulti3;
    }

    private void Update()
    {
        //Change Multiplicator 1
        actualTimerMULTI1 -= Time.deltaTime;

        if (actualTimerMULTI1 <= 0)
        {
            TimeMultiplicator1 -= otherReduceMulti1;
            actualTimerMULTI1 = RepetTimerMulti1;
        }
        
        //Change Multiplicator 2

        if (MULTI2Unlock)
        {
            if (actualTimerMULTI2 <= 0)
            {
                TimeMultiplicator2 -= otherReduceMulti2;
                actualTimerMULTI2 = RepetTimerMulti2;
            }
        }
        else
        {
            TimeMultiplicator2 -= firstReduceMulti2;
            actualTimerMULTI2 = startTimerMulti2;
            MULTI2Unlock = true;
        }

        //Change Multiplicator 3
        
        if (MULTI3Unlock)
        {
            if (actualTimerMULTI3 <= 0)
            {
                TimeMultiplicator3 -= otherReduceMulti3;
                actualTimerMULTI3 = RepetTimerMulti3;
            }
        }
        else
        {
            TimeMultiplicator3 -= firstReduceMulti3;
            actualTimerMULTI3 = startTimerMulti3;
            MULTI3Unlock = true;
        }
    }
}

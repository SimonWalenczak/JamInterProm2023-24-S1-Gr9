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

    [Header("Start Timer")] [SerializeField]
    private float startTimerMulti1 = 30;

    [SerializeField] private float startTimerMulti2 = 60;
    [SerializeField] private float startTimerMulti3 = 180;

    [Space(10)] [Header("First Reduce")] [SerializeField]
    private float firstReduceMulti2 = 0.5f;

    [SerializeField] private float firstReduceMulti3 = 0.5f;

    [Space(10)] [Header("Recursive Timer")] [SerializeField]
    private float RepeatTimerMulti1 = 30;

    [SerializeField] private float RepeatTimerMulti2 = 60;
    [SerializeField] private float RepeatTimerMulti3 = 60;

    [Space(10)] [Header("Other Reduce")] [SerializeField]
    private float otherReduceMulti1 = 0.1f;

    [SerializeField] private float otherReduceMulti2 = 0.1f;
    [SerializeField] private float otherReduceMulti3 = 0.1f;

    private float actualTimerMULTI1;
    private float actualTimerMULTI2;
    private float actualTimerMULTI3;

    [SerializeField] private float _maxReduceMulti1;
    [SerializeField] private float _maxReduceMulti2;
    [SerializeField] private float _maxReduceMulti3;

    private bool MULTI2Unlock;
    private bool MULTI3Unlock;

    #endregion

    public bool isFirstScreen;
    public bool canBug;

    public List<GameObject> GameSounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Cursor.visible = true;
    }

    private void Start()
    {
        isFirstScreen = false;
        canBug = false;

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
            if (TimeMultiplicator1 <= _maxReduceMulti1)
                TimeMultiplicator1 = _maxReduceMulti1;
            else
                TimeMultiplicator1 -= otherReduceMulti1;

            actualTimerMULTI1 = RepeatTimerMulti1;
        }

        //Change Multiplicator 2

        if (MULTI2Unlock)
        {
            if (actualTimerMULTI2 <= 0)
            {
                if (TimeMultiplicator2 <= _maxReduceMulti2)
                    TimeMultiplicator2 = _maxReduceMulti2;
                else
                    TimeMultiplicator2 -= otherReduceMulti2;

                actualTimerMULTI2 = RepeatTimerMulti2;
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
                if (TimeMultiplicator3 <= _maxReduceMulti3)
                    TimeMultiplicator3 = _maxReduceMulti3;
                else
                    TimeMultiplicator3 -= otherReduceMulti3;

                actualTimerMULTI3 = RepeatTimerMulti3;
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
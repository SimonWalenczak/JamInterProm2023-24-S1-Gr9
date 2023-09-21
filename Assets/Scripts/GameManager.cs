using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public float startTimerMulti2 = 60;
    [SerializeField] private float startTimerMulti3 = 180;

    [Space(10)] [Header("First Multiplicator")] [SerializeField]
    private float firstMultiplicator2 = 1f;

    [SerializeField] private float firstMultiplicator3 = 1f;

    [Space(10)] [Header("Recursive Timer")] [SerializeField]
    private float RepeatTimerMulti1 = 30;

    [SerializeField] private float RepeatTimerMulti2 = 60;
    [SerializeField] private float RepeatTimerMulti3 = 60;

    [Space(10)] [Header("Other Reduce")] [SerializeField]
    private float otherReduceMulti1 = 0.1f;

    [SerializeField] private float otherReduceMulti2 = 0.1f;
    [SerializeField] private float otherReduceMulti3 = 0.1f;

    [Space(10)] [Header("Max Reduce")]
    [SerializeField] private float _maxReduceMulti1;
    [SerializeField] private float _maxReduceMulti2;
    [SerializeField] private float _maxReduceMulti3;
    
    [Space(10)] [Header("Debug")]
    public bool MULTI2Unlock;
    public bool MULTI3Unlock;

    [ReadOnly] [SerializeField] private float actualTimerMULTI1;
    [ReadOnly] [SerializeField] private float actualTimerMULTI2;
    [ReadOnly] [SerializeField] private float actualTimerMULTI3;

    #endregion

    [Header("Autres Variables")] public bool canBug;

    public List<GameObject> GameSounds;

    public List<GameObject> ScreenActive;
    public int TotalScreenActive;
    public int NbScreenForDefeat;

    public void CheckActiveScreen()
    {
        TotalScreenActive = ScreenActive.Count;

        foreach (var screen in ScreenActive)
        {
            if (screen.activeSelf == false)
            {
                TotalScreenActive--;
            }
        }
    }

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
        canBug = false;

        actualTimerMULTI1 = startTimerMulti1;
        actualTimerMULTI2 = startTimerMulti2;
        actualTimerMULTI3 = startTimerMulti3;

        TotalScreenActive = ScreenActive.Count;
    }

    private void Update()
    {
        CheckActiveScreen();
        if (TotalScreenActive <= NbScreenForDefeat)
        {
            Cursor.visible = true;
            SceneManager.LoadScene(1);
        }

        if (canBug)
        {
            actualTimerMULTI1 -= Time.deltaTime;
            actualTimerMULTI2 -= Time.deltaTime;
            actualTimerMULTI3 -= Time.deltaTime;
        }
        //Change Multiplicator 1

        if (actualTimerMULTI1 <= 0)
        {
            if (TimeMultiplicator1 <= _maxReduceMulti1)
                TimeMultiplicator1 = _maxReduceMulti1;
            else
                TimeMultiplicator1 -= otherReduceMulti1;

            actualTimerMULTI1 = RepeatTimerMulti1;
        }

        //Change Multiplicator 2
        
        if (actualTimerMULTI2 <= 0)
        {
            if (MULTI2Unlock)
            {
                if (TimeMultiplicator2 <= _maxReduceMulti2)
                    TimeMultiplicator2 = _maxReduceMulti2;
                else
                    TimeMultiplicator2 -= otherReduceMulti2;

                actualTimerMULTI2 = RepeatTimerMulti2;
            }
            else
            {
                TimeMultiplicator2 = firstMultiplicator2;
                actualTimerMULTI2 = RepeatTimerMulti2;
                MULTI2Unlock = true;
            }
        }

        //Change Multiplicator 3
        
        if (actualTimerMULTI3 <= 0)
        {
            if (MULTI3Unlock)
            {
                if (TimeMultiplicator3 <= _maxReduceMulti3)
                    TimeMultiplicator3 = _maxReduceMulti3;
                else
                    TimeMultiplicator3 -= otherReduceMulti3;

                actualTimerMULTI3 = RepeatTimerMulti3;
            }
            else
            {
                TimeMultiplicator3 = firstMultiplicator3;
                actualTimerMULTI3 = RepeatTimerMulti3;
                MULTI3Unlock = true;
            }
        }
    }
}
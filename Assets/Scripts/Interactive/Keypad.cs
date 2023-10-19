using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Keypad : MonoBehaviour
{
    [SerializeField] private string Ans;
    [SerializeField] private string Answer = "";

    [SerializeField] private TMP_Text AwnserText;

    public List<Image> Checkers;
    [SerializeField] private int indexTry;


    [Header("Time Before between code")] public float TimerBetweenCodes;

    [HideInInspector] public float actualTimerBetweenCodes;

    [HideInInspector] public bool CanCreateCode;

    private void Start()
    {
        indexTry = 0;
        actualTimerBetweenCodes = TimerBetweenCodes;
    }

    public void DefineCode()
    {
        AwnserText.color = Color.white;

        indexTry = 0;
        Answer = "";
        Ans = "";

        foreach (var checker in Checkers)
        {
            checker.color = Color.white;
        }

        for (int i = 0; i < 4; i++)
        {
            int rnd = Random.Range(0, 9);
            Answer += rnd.ToString();
        }
    }

    public void Number(int number)
    {
        if (Screen6Manager.Instance.screen6.IsBugged && Screen6Manager.Instance.screen6.IsBroken == false &&
            GameManager.instance.MULTI3Unlock && GameManager.instance.desactivSystem == false)
        {
            Ans += number.ToString();

            if (Ans[indexTry] == Answer[indexTry])
            {
                indexTry++;
                Checkers[indexTry - 1].color = Color.green;
            }
            else
            {
                indexTry = 0;
                Ans = "";

                foreach (var checker in Checkers)
                {
                    checker.color = Color.white;
                }

                StartCoroutine(CheckCode());
            }
        }
    }

    private void Update()
    {
        //Display
        AwnserText.text = Answer;

        //Check Code
        if (Ans.Length == Answer.Length)
        {
            StartCoroutine(CheckCode());

            Ans = "";
        }
    }

    public IEnumerator CheckCode()
    {
        CanCreateCode = false;

        if (Ans == Answer)
        {
            print("Correct");
            AwnserText.color = Color.green;

            yield return new WaitForSeconds(1);

            ResetScreen();
            CanCreateCode = true;
        }
        else
        {
            print("Invalid");
            AwnserText.color = Color.red;

            yield return new WaitForSeconds(1);

            actualTimerBetweenCodes = TimerBetweenCodes;

            DefineCode();
            CanCreateCode = true;
        }
    }

    public void ResetScreen()
    {
        actualTimerBetweenCodes = TimerBetweenCodes;
        Screen6Manager.Instance.screen6.ScreenBugged.SetActive(false);
        Screen6Manager.Instance.screen6.IsBugged = false;
    }
}
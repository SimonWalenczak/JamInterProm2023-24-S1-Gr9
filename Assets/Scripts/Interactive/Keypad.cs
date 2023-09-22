using System;
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

    private void Start()
    {
        indexTry = 0;
    }

    public void DefineCode()
    {
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
        }
    }

    private void Update()
    {
        //Display
        AwnserText.text = Answer;

        //Check Code
        if (Ans.Length == Answer.Length)
        {
            if (Ans == Answer)
            {
                print("Correct");
                Screen6Manager.Instance.screen6.ScreenBugged.SetActive(false);
                Screen6Manager.Instance.screen6.IsBugged = false;
            }
            else
            {
                print("Invalid");
            }

            Ans = "";
        }
    }
}
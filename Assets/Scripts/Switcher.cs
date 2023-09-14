using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class Switcher : MonoBehaviour
{
    public bool IsLever;
    public Sprite LevierSprite1;
    public Sprite LevierSprite2;
    private float timerRnd;

    public SpriteRenderer _spriteRendererLevier;
    public SpriteRenderer _spriteRendererLamp;

    public int MinTimer;
    public int MaxTimer;

    public bool IsRed;

    void Start()
    {
        if (IsLever)
            StartCoroutine(DesactivSystem());

        _spriteRendererLevier = GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = LevierSprite2;

        if (IsRed)
        {
            _spriteRendererLamp.color = Color.white;
            GameManager.instance.desactivSystem = false;

            StartCoroutine(DesactivSystem());
        }
    }

    public void OnMouseUp()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = LevierSprite1;
        _spriteRendererLevier.color = Color.white;
    }

    private IEnumerator DesactivSystem()
    {
        Random random = new Random();
        double timerRnd =
            random.NextDouble() * (MaxTimer * GameManager.instance.TimeMultiplicator -
                                   MinTimer * GameManager.instance.TimeMultiplicator) +
            MinTimer * GameManager.instance.TimeMultiplicator;

        timerRnd -= Time.deltaTime;

        if (timerRnd <= 0)
        {
            _spriteRendererLamp.color = Color.red;
            IsRed = true;
            GameManager.instance.desactivSystem = true;
        }
        
        yield return null;
    }
}
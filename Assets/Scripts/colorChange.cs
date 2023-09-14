using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class colorChange : MonoBehaviour
    
{
    public Sprite triangle_2ieme_sprite;
    public Sprite Triangle;
    private int monAleatoire;

    public SpriteRenderer _spriteRendererTriangle;
    public SpriteRenderer _spriteRendererCircle;

    public bool IsRed;

    void Start()
    {
        StartCoroutine(MaCoroutine());
        _spriteRendererTriangle = GetComponent<SpriteRenderer>();

    }

    public void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = triangle_2ieme_sprite;
           

        if (IsRed)
        {
            _spriteRendererCircle.color = Color.white;
            StartCoroutine(MaCoroutine());

        }

    }

    public void OnMouseUp()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Triangle;
        _spriteRendererTriangle.color = Color.white;
    }
    private IEnumerator MaCoroutine()
    {
        monAleatoire = Random.Range(1,3);// Pour changer la frequence de l'evenement il faut augmenter ou diminué ces valeurs
        Debug.Log(monAleatoire);
        yield return new WaitForSeconds((float)monAleatoire);
        _spriteRendererCircle.color = Color.red;
        IsRed = true;
        Debug.Log("monAleatoire");


        // D'autres actions peuvent être exécutées ici
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpriteListContainer
{
    public string _name;
    public List<Sprite> spriteList = new List<Sprite>();
}

public class SwitcherManager : MonoBehaviour
{
    public static SwitcherManager _instance;
    
    public List<SpriteListContainer> listOfListsOfSprites;
    
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }
}

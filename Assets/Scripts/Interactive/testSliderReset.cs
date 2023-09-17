using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class testSliderReset : Slider
{
    private Slider slider;

    protected override void Start()
    {
        slider = GetComponent<Slider>();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        slider.value = 0;
    }
}

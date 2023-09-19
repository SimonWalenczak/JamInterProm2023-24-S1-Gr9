using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class testSliderReset : Slider
{
    public Slider Slider;

    public int lastValue;

    protected override void Start()
    {
        Slider = GetComponent<Slider>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        Screen1Manager.Instance._canRefresh = false;

        lastValue = Screen1Manager.Instance.ActualValue;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        Screen1Manager.Instance.ActualValue = lastValue + (int) Slider.value;

        Screen1Manager.Instance.CalculateDiff();
    }


    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        Screen1Manager.Instance._canRefresh = true;

        Slider.value = 0;
    }
}
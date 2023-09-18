using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class testSliderReset : Slider
{
    public Slider Slider;

    protected override void Start()
    {
        Slider = GetComponent<Slider>();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        Screen1Manager.Instance.ActualValue += (int)Slider.value;

        Slider.value = 0;
    }
}

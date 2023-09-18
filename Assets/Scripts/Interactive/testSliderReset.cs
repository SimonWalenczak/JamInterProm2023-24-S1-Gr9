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

    public override void OnDrag (PointerEventData eventData)
    {
        base.OnDrag(eventData);

        Screen1Manager.Instance.CalculateDiff((int)Slider.value);
    }
    
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        Screen1Manager.Instance.ActualValue += (int)Slider.value;

        Slider.value = 0;
        
        if(Screen1Manager.Instance.TargetValue == Screen1Manager.Instance.ActualValue)
            Screen1Manager.Instance.ResetScreen();
    }
}
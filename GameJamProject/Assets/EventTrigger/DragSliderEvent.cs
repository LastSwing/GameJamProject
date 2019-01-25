using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragSliderEvent : EventTriggerListener
{
    new public static DragSliderEvent Get(GameObject go)
    {
        DragSliderEvent listener = go.GetComponent<DragSliderEvent>();
        if (listener == null) listener = go.AddComponent<DragSliderEvent>();
        return listener;
    }
    [SerializeField]
    Slider sliderView;

    void OnEnable()
    {
        if(sliderView==null)
        sliderView = GetComponent<Slider>();
    }
    public override void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (onDrag != null) { onDrag(gameObject); }
        sliderView.OnDrag(eventData);
    }
    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (onDrag != null) { onDrag(gameObject); }
        sliderView.OnPointerDown(eventData);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class EventTriggerListener : UnityEngine.EventSystems.EventTrigger
{
    public delegate void VoidDelegate(GameObject go);
    public VoidDelegate onClick;
    public VoidDelegate onDown;
    public VoidDelegate onEnter;
    public VoidDelegate onExit;
    public VoidDelegate onUp;
    public VoidDelegate onSelect;
    public VoidDelegate onDeselect;
    public VoidDelegate onUpdateSelect;
    public VoidDelegate onDrag;
    public VoidDelegate onDrop;
    public VoidDelegate onCancel;
    public VoidDelegate onBeginDrag;
    public VoidDelegate onEndDrag;
    public VoidDelegate onInitializePotentialDrag;
    public VoidDelegate onScroll;
    public VoidDelegate onMove;
    public VoidDelegate onSubmit;
    static public EventTriggerListener Get(GameObject go)
    {
        EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
        if (listener == null) listener = go.AddComponent<EventTriggerListener>();
        return listener;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onClick != null) { onClick(gameObject);}
        base.OnPointerClick(eventData);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (onDown != null) { onDown(gameObject); }
        base.OnPointerDown(eventData);
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (onEnter != null) { onEnter(gameObject); }
        base.OnPointerEnter(eventData);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (onExit != null) { onExit(gameObject); }
        base.OnPointerExit(eventData);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (onUp != null) { onUp(gameObject); }
        base.OnPointerUp(eventData);
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (onSelect != null) { onSelect(gameObject); }
        base.OnSelect(eventData);
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (onUpdateSelect != null) { onUpdateSelect(gameObject); }
        base.OnUpdateSelected(eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (onDrag != null) { onDrag(gameObject); }
        base.OnDrag(eventData);
    }

    public override void OnDrop(PointerEventData eventData)
    {
        if (onDrop != null) { onDrop(gameObject); }
        base.OnDrop(eventData);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (onBeginDrag != null) { onBeginDrag(gameObject); }
        base.OnBeginDrag(eventData);
    }

    public override void OnCancel(BaseEventData eventData)
    {
        if (onCancel != null) { onCancel(gameObject); }
        base.OnCancel(eventData);
    }

    public override void OnScroll(PointerEventData eventData)
    {
        if (onScroll != null) { onScroll(gameObject); }
        base.OnScroll(eventData);
    }
  
    public override void OnDeselect(BaseEventData eventData)
    {
        if (onDeselect != null) { onDeselect(gameObject); }
        base.OnDeselect(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (onEndDrag != null) { onEndDrag(gameObject); }
        base.OnEndDrag(eventData);
    }

    public override void OnMove(AxisEventData eventData)
    {
        if (onMove != null) { onMove(gameObject); }
        base.OnMove(eventData);
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        if (onSubmit != null) { onSubmit(gameObject); }
        base.OnSubmit(eventData);
    }

    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        if (onInitializePotentialDrag != null) { onInitializePotentialDrag(gameObject); }
        base.OnInitializePotentialDrag(eventData);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IEventSystemHandler
{
    public Action hoverAction;
    public Action exitAction;
    public Action downAction;
    public Action upAction;
    public Action clickAction;

    public UnityEvent OnHover = new UnityEvent();
    public UnityEvent OnExit = new UnityEvent();
    public UnityEvent OnDown = new UnityEvent();
    public UnityEvent OnUp = new UnityEvent();
    public UnityEvent OnClick = new UnityEvent();

    public void OnPointerEnter(PointerEventData eventData) 
    {
        OnHover?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        OnExit?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnUp?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        OnClick?.Invoke();
    }
}

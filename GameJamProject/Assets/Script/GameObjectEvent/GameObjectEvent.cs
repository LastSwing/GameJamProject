using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using HighlightingSystem;

public class GameObjectEvent : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler
{
    public int ID;
    private bool isClick;

	public void Start()
    {
        isClick = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClick) {
            isClick = true;

        }
    }

	public void OnPointerEnter(PointerEventData eventData) {

	}
}

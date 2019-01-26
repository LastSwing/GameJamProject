﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using HighlightingSystem;

public class GameObjectEvent : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public int ID;
	private bool isEnter = false;
	private bool isClock = false;
	private Highlighter _hightLight;
	private GameObjectEventManager _manager;

	public void init(GameObjectEventManager manager) {
		_hightLight = GetComponent<Highlighter>();
		_manager = manager;
	}

    public void OnPointerClick(PointerEventData eventData) {
		isClock = true;
		_manager.startEvent(this);
	}
	// show the scrollview
	public void OnPointerEnter(PointerEventData eventData) {
		Debug.Log("enter");
		_hightLight.ConstantOn(new Color(244.0f / 255.0f, 208.0f / 255.0f, 63.0f / 255.0f));
	}

	public void OnPointerExit(PointerEventData eventData) {
		_hightLight.ConstantOff();
	}

	public void setClock(bool value)
	{
		isClock = true;
	}

	public void setEnter(bool value)
	{
		isEnter = value;
	}

}

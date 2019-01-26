using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using HighlightingSystem;

public class GameObjectEvent : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler
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
		
	}

	public void setHightLight(Highlighter lighter = null) {
	}

	public void setClock(bool value) {
		isClock = true;
	}

	public void setEnter(bool value) {
		isEnter = value;
	}

	// show the scrollview
	public void OnPointerEnter(PointerEventData eventData) {
		if (isEnter)
		{
			Debug.Log("enter");
			isClock = true;
			_hightLight.ConstantOn(new Color(244.0f / 255.0f, 208.0f / 255.0f, 63.0f / 255.0f));
			_manager.startEvent(this);
		}
		else
		{
			_hightLight.ConstantOff();
		}
	}
}

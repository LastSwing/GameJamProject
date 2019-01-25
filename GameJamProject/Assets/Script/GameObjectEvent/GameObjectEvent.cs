using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameObjectEvent : MonoBehaviour, IPointerClickHandler
{

    public int ID;
    private bool isClick;
    public void Start()
    {
        isClick = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClick)
        {
            isClick = true;
            //todo
            //展开剧情

        }
    }
}

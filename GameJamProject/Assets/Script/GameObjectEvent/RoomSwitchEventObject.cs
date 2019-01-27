using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoomSwitchEventObject : MonoBehaviour, IPointerClickHandler
{
	public int ID = 0;

	// id 对应 Camera 的 index

	public void OnPointerClick(PointerEventData eventData)
	{
		RuntimeData.instance.getCameraCtrl().switchCamera(ID);
	}
}

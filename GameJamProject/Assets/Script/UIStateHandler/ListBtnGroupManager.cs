
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListBtnGroupManager : MonoBehaviour
{

    List<StateHandlerManager> SHMList;
    int _curSelectIndex;
    private void Awake()
    {
        this.InitBtnEvent();
    }
    private void Start()
    {
        _curSelectIndex = 0;
//        if(SHMList.Count>0)
//        this.BtnClick(0); 默认不选择

    }
    public void InitBtnEvent()
    {


        SHMList = new List<StateHandlerManager>(GetComponentsInChildren<StateHandlerManager>());
        for (int i = 0; i < SHMList.Count; i++)
        {
            SHMList[i].Init();
            int index = i;
           // EventTriggerListener.Get(SHMList[i].gameObject).onClick += (go) =>
            DragScrollView.Get(SHMList[i].gameObject).onClick += (go) =>
            {
                BtnClick(index);
            };

           // EventTriggerListener.Get(SHMList[i].gameObject).onEnter += (go) =>
            DragScrollView.Get(SHMList[i].gameObject).onEnter += (go) =>
            {
                OnPointEnter(index);
            };

           // EventTriggerListener.Get(SHMList[i].gameObject).onExit += (go) =>
            DragScrollView.Get(SHMList[i].gameObject).onExit += (go) =>
            {
                OnPointExit(index);
            };
        }
    }
    protected void OnPointEnter(int index)
    {
        if (_curSelectIndex != index)
            SHMList[index].OnHoverState();

    }

    protected void OnPointExit(int index)
    {
        if (_curSelectIndex != index)
            SHMList[index].OnNormalState();
    }

    public void BtnClick(int index)
    {
        if (_curSelectIndex != index)
        {
            SHMList[_curSelectIndex].OnNormalState();
        }
        _curSelectIndex = index;
        if(index<SHMList.Count) SHMList[index].OnHighLightState();
    }
}
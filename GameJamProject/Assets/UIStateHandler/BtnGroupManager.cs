using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnGroupManager : MonoBehaviour
{

    List<StateHandlerManager> SHMList;
    int _curSelectIndex;
    public int DefaltSelect;
    public bool IsDefaltSelect = true;
    private void Awake()
    {
        this.InitBtnEvent();
    }
    private void Start()
    {

        if (IsDefaltSelect)
        {
            this.BtnClick(DefaltSelect);
        }
           
        
    }
    public void InitBtnEvent()
    {


        SHMList =new List<StateHandlerManager>(GetComponentsInChildren<StateHandlerManager>());
        for (int i = 0; i < SHMList.Count; i++)
        {
            SHMList[i].Init();
            int index = i;
            EventTriggerListener.Get(SHMList[i].gameObject).onClick += (go) =>
            //DragScrollView.Get(_btnList[i].gameObject).onClick += (go) =>
            {
                BtnClick(index);
            };

            EventTriggerListener.Get(SHMList[i].gameObject).onEnter += (go) =>
            //DragScrollView.Get(_btnList[i].gameObject).onEnter += (go) =>
            {
                OnPointEnter(index);
            };

            EventTriggerListener.Get(SHMList[i].gameObject).onExit += (go) =>
            //DragScrollView.Get(_btnList[i].gameObject).onExit += (go) =>
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
        if(_curSelectIndex != index)
        {
            SHMList[_curSelectIndex].OnNormalState();
        }
        _curSelectIndex = index;
        SHMList[index].OnHighLightState();

    }
}

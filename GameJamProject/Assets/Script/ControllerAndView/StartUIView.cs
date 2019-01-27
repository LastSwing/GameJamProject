using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUIView : BaseUIView
{
    public GameObject StartGameBtn, SettingBtn, ExitBtn;
    public StartUIView(string UIViewName, Transform parent) : base(UIViewName, parent){}
    protected override void Init()
    {
        base.Init();
        StartGameBtn = GetGameObjectByName("StartGame");
        SettingBtn = GetGameObjectByName("Setting");
        ExitBtn = GetGameObjectByName("Exit");
    }
    protected override void InitEvent()
    {
        base.InitEvent();
        EventTriggerListener.Get(StartGameBtn).onClick = StartBtnClick;
    }
    private void StartBtnClick(GameObject go)
    {

        StartUIController.Instance.HideView();

        RuntimeData.instance.setGameState(GameState.Child);
        MusicManager.instance.SetBgm(PathManager.son_Bgm);

        BottomFrameController.Instance.HideView();
        HomeStateController.Instance.ShowView();
        OwnStateController.Instance.HideView();
        OtherStateController.Instance.HideView();
    }
}

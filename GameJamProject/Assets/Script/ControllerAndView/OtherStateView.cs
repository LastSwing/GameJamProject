using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherStateView : BaseUIView
{
    public Text PressureText, HealthyText, Name;
    public OtherStateView(string UIViewName, Transform parent) : base(UIViewName, parent)
    {

    }
    public override void ShowUIView()
    {
        base.ShowUIView();
        
    }
    public void CheckActor()
    {
        Debug.Log(RuntimeData.instance.getGameState());
        switch (RuntimeData.instance.getGameState())
        {
            case GameState.Child:
                Name.text = RuntimeData.instance.name[2];
                break;
            case GameState.Father:
                Name.text = RuntimeData.instance.name[1];
                break;
        }
    }
    protected override void Init()
    {
        base.Init();
        PressureText = GetGameObjectByName("PressureText").GetComponent<Text>();
        HealthyText = GetGameObjectByName("HealthyText").GetComponent<Text>();
        Name = GetGameObjectByName("Name").GetComponent<Text>();
    }
    public void UpdateState(string p,string h)
    {
        PressureText.text = p;
        HealthyText.text = h;
    }
}


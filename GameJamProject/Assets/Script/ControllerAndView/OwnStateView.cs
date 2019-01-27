using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnStateView : BaseUIView
{
    public Text PressureText, HealthyText,Name;
    public OwnStateView(string UIViewName, Transform parent) : base(UIViewName, parent)
    {

    }
    protected override void Init()
    {
        base.Init();
        PressureText = GetGameObjectByName("PressureText").GetComponent<Text>();
        HealthyText = GetGameObjectByName("HealthyText").GetComponent<Text>();
        Name = GetGameObjectByName("Name").GetComponent<Text>();
    }
    public override void ShowUIView()
    {
        base.ShowUIView();
        
        
       // Name.text=RuntimeData.instance.
    }
    public void CheckActor()
    {
        switch (RuntimeData.instance.getGameState())
        {
            case GameState.Child:
                Name.text = RuntimeData.instance.name[1];
                break;
            case GameState.Father:
                Name.text = RuntimeData.instance.name[2];
                break;
        }
    }
    public void UpdateState(string p, string h)
    {
        PressureText.text = p;
        HealthyText.text = h;
    }
}
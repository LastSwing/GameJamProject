using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherStateView : BaseUIView
{
    public Text PressureText, HealthyText;
    public OtherStateView(string UIViewName, Transform parent) : base(UIViewName, parent)
    {

    }
    protected override void Init()
    {
        base.Init();
        PressureText = GetGameObjectByName("PressureText").GetComponent<Text>();
        HealthyText = GetGameObjectByName("HealthyText").GetComponent<Text>();
    }
    public void UpdateState(string p,string h)
    {
        PressureText.text = p;
        HealthyText.text = h;
    }
}


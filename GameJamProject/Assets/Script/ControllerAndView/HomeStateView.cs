using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeStateView : BaseUIView
{
    public Text HomeHappyState, HomeRichState;
    public HomeStateView(string UIViewName, Transform parent) : base(UIViewName, parent)
    {

    }
    protected override void Init()
    {
        base.Init();
        HomeHappyState = GetGameObjectByName("HomeHappyState").GetComponent<Text>();
        HomeRichState = GetGameObjectByName("HomeRichState").GetComponent<Text>();
    }
    public void UpdateState(string h, string r)
    {
        HomeHappyState.text = h;
        HomeRichState.text = r;
    }
}

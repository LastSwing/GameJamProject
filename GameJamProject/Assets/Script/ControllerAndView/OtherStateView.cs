using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherStateView : BaseUIView
{
    public Text PressureText, HealthyText, Name;
	private RuntimeData _runtime;

    public OtherStateView(string UIViewName, Transform parent) : base(UIViewName, parent) {}

	protected override void Init()
	{
		base.Init();
		PressureText = GetGameObjectByName("PressureText").GetComponent<Text>();
		HealthyText = GetGameObjectByName("HealthyText").GetComponent<Text>();
		Name = GetGameObjectByName("Name").GetComponent<Text>();
		_runtime = RuntimeData.instance;
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
                Name.text = _runtime.getFather().getName();
                break;
            case GameState.Father:
				Name.text = _runtime.getChild().getName();
                break;
        }
    }
    
    public void UpdateState(string p,string h)
    {
        PressureText.text = p;
        HealthyText.text = h;
    }
}


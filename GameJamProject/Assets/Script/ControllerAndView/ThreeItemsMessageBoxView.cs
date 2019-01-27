using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeItemsMessageBoxView : BaseUIView
{
    GameObject Button1, Button2, Button3;
    Text Button1_Text, Button2_Text, Button3_Text;
    OptionList option1, option2, option3;
    public ThreeItemsMessageBoxView(string UIViewName, Transform parent) : base(UIViewName, parent){}

    public void InitData(List<OptionList> options)
    {
        option1 = options[0];
        option2 = options[1];
        option3 = options[2];
        Button1_Text.text = option1.OptionsText;
        Button2_Text.text = option2.OptionsText;
        Button3_Text.text = option3.OptionsText;

    }
    protected override void Init()
    {
        base.Init();
        Button1 = GetGameObjectByName("Button1");
        Button2 = GetGameObjectByName("Button2");
        Button3 = GetGameObjectByName("Button3");
        Button1_Text = GetGameObjectByName("Button1_Text").GetComponent<Text>();
        Button2_Text = GetGameObjectByName("Button2_Text").GetComponent<Text>();
        Button3_Text = GetGameObjectByName("Button3_Text").GetComponent<Text>();
    }
	protected override void InitEvent()
	{
		base.InitEvent();
		EventTriggerListener.Get(Button1).onClick = Btn1Click;
		EventTriggerListener.Get(Button2).onClick = Btn2Click;
		EventTriggerListener.Get(Button3).onClick = Btn3Click;
	}
    public void Btn1Click(GameObject go)
    {
		BottomFrameController.Instance.View.UpdateFatherText();
		BottomFrameController.Instance.View.setTalkListStage(option1.Index);
		BottomFrameController.Instance.View.UpdateText();
		ThreeItemsMessageBoxController.Instance.HideView();
    }
    public void Btn2Click(GameObject go)
    {
		BottomFrameController.Instance.View.UpdateFatherText();
		BottomFrameController.Instance.View.setTalkListStage(option2.Index);
		BottomFrameController.Instance.View.UpdateText();
		ThreeItemsMessageBoxController.Instance.HideView();
	}
    public void Btn3Click(GameObject go)
    {
		BottomFrameController.Instance.View.UpdateFatherText();
		BottomFrameController.Instance.View.setTalkListStage(option3.Index);
		BottomFrameController.Instance.View.UpdateText();
		ThreeItemsMessageBoxController.Instance.HideView();
	}
}

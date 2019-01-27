using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomFrameView : BaseUIView
{
    public Text ContentText;
    Dictionary<int, List<TalkList>> talkDic;
    Dictionary<int, List<OptionList>> optionDic;
    public int nowStage=1,nowCount = 0;
    bool isChooseState = false;
    string[] name = { "","我:","父亲:"};

    public BottomFrameView(string UIViewName, Transform parent) : base(UIViewName, parent)
    {

    }
    protected override void Init()
    {
        base.Init();
        ContentText = GetGameObjectByName("ContentText").GetComponent<Text>();
    }
    public void StartUpdateContent(Dictionary<int/*stage*/, List<TalkList>> talkDic, Dictionary<int/*stage,从1开始*/, List<OptionList>> optionDic)
    {
        this.talkDic = talkDic;
        this.optionDic = optionDic;
        UpdateText();
    }
    public void UpdateText()
    {
        if(nowCount< talkDic[nowStage].Count-1)
        {
            nowCount++;
            isChooseState = false;
            ContentText.text = name[talkDic[nowStage][nowCount].Object] + talkDic[nowStage][nowCount].TalkText;
        }
        else
        {
            if (talkDic[nowStage][nowCount].ItemSchedule > 0)
            {
                isChooseState = true;
                nowCount = 0;
                UpdateChoose(optionDic[talkDic[nowStage][nowCount].Index]);

            }
            else
            {
                GameObjectEventManager.instance.stopConvercation();
            }
        }
    }
    public void UpdateChoose(List<OptionList> content)
    {

    }
    public override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0)&&isChooseState==false)
        {
            UpdateText();
        }
    }
}

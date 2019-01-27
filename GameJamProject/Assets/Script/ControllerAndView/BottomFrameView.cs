using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomFrameView : BaseUIView
{
    public Text ContentText;
    private Dictionary<int, List<TalkList>> _talkDic;
    private Dictionary<int, List<OptionList>> _optionDic;
	private List<OptionList> _fatherOpts;
	// keep the talkDic stage and count
	private int _nowStage = 1, _nowCount = 0;
	// 记录当前 optionList 对象
	private List<OptionList> _curOptionList;

	public GameObject threeOptionPrefab;
	public GameObject twoOptionPrefab;

    public bool isChooseState = false;
    string[] name = {"","我:","父亲:"};

    public BottomFrameView(string UIViewName, Transform parent) : base(UIViewName, parent){}

    protected override void Init()
    {
        base.Init();
        ContentText = GetGameObjectByName("ContentText").GetComponent<Text>();
    }

    public void StartUpdateContent(Dictionary<int/*stage*/, List<TalkList>> talkDic, Dictionary<int/*stage,从1开始*/, List<OptionList>> optionDic, List<OptionList> fatherOpts)
    {
		_talkDic = talkDic;
		_optionDic = optionDic;
		_fatherOpts = fatherOpts;
		BottomFrameController.Instance.ShowView();
        UpdateText();
    }

    public void UpdateText() {
		_nowCount = 0;
		isChooseState = false;
		List<TalkList> groupList = _talkDic[_nowStage];
		NextText();
    }
	// 这里调用的时候 Stage 还没有更新
	public void UpdateFatherText() {
		//ContentText.text = name[text.Object] + text.TalkText;
		UpdateText();
	}

	// 只提供 2 / 3 个选项的选择框
    public void UpdateChoose(List<OptionList> optionList) {
		if (optionList.Count == 2)
		{
			// create new Object with 3 option
			createTreeItemMessageBox(optionList);
		}
		else
		{
			// create new Object with 2 option
			createTwoItemMessageBox(optionList);
		}
	}

	public void setTalkListStage(int value) {
		_nowStage = value;
	}

	private void createTreeItemMessageBox(List<OptionList> optionList) {
		ThreeItemsMessageBoxController instance =  ThreeItemsMessageBoxController.Instance;
		instance.ShowView();
		instance.View.InitData(optionList);
	}

	private void createTwoItemMessageBox(List<OptionList> optionList) {
		TwoItemsMessageBoxController instance = TwoItemsMessageBoxController.Instance;
		instance.ShowView();
		instance.View.InitData(optionList);
	}

	public override void Update()
	{ 
		if (Input.GetMouseButtonDown(0) && isChooseState == false)
		{
			NextText();
		}
    }

	private void NextText() {
		List<TalkList> groupList = _talkDic[_nowStage];
		if (hasNext(groupList))
		{
			TalkList text = groupList[_nowCount];
			ContentText.text = name[text.Object] + text.TalkText;
			_nowCount++;
		}
		else
		{
			// enter the options
			TalkList text = groupList[_nowCount-1];
			if (text.Index > 0)
			{
				_curOptionList = _optionDic[text.Index];
				isChooseState = true;
				UpdateChoose(_curOptionList);
			}
			else {
				resetConver();
				Debug.Log("Conversation Over");
				RuntimeData.instance.passDay();
			}
		}
	}
	// 清理
	private void resetConver() {
		GameObjectEventManager.instance.clearDicGroup();
		_nowStage = 1;
		_nowCount = 0;
	}

	private bool hasNext(List<TalkList> groupList)
	{
		int tempCount = _nowCount + 1;
		if (tempCount <= groupList.Count)
		{
			return true;
		}
		return false;
	}
}

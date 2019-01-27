using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomFrameView : BaseUIView
{
    public Text ContentText;
	#region privData
	private Dictionary<int, List<TalkList>> _talkDic;
    private Dictionary<int, List<OptionList>> _optionDic;
	private List<OptionList> _fatherOpts = null;
	private List<string> fatherEventList = null;
	#endregion
	// keep the talkDic stage and count
	private int _nowStage = 1, _nowCount = 0;
	// 记录当前 optionList 对象
	private List<OptionList> _curOptionList;

	public GameObject threeOptionPrefab;
	public GameObject twoOptionPrefab;

    public bool isChooseState = false;
	private bool isFatherEvent = false;
    string[] name = {"","我:","父亲:"};

    public BottomFrameView(string UIViewName, Transform parent) : base(UIViewName, parent){}

    protected override void Init()
    {
        base.Init();
        ContentText = GetGameObjectByName("ContentText").GetComponent<Text>();
    }
	// 从GameObjectEventManager 中获取初始化的对象数据
    public void StartUpdateContent(Dictionary<int/*stage*/, List<TalkList>> talkDic, Dictionary<int/*stage,从1开始*/, List<OptionList>> optionDic, List<OptionList> fatherOpts)
    {
		_talkDic = talkDic;
		_optionDic = optionDic;
		if (_fatherOpts == null) _fatherOpts = fatherOpts;
		BottomFrameController.Instance.ShowView();
        UpdateText();
    }
	// 更新交流数据，依赖于 _nowStage, _nowStage 在 ItemMessageBox 那里做的修改。
    public void UpdateText() {
		_nowCount = 0;
		isChooseState = false;
		List<TalkList> groupList = _talkDic[_nowStage];
		NextText();
    }

	public void NewDayEvent() {
		if (fatherEventList == null) {
			fatherEventList = GameObjectEventManager.instance.getFatherEventList();
		}
		// 通过 storage id content 展示 event
		string eventObj = fatherEventList[fatherEventList.Count - RuntimeData.instance.rounds];

		showNewDayEvent(eventObj);
	}
	// 这里调用的时候 Stage 还没有更新，调用在 stage 之前，这里是用于记录 stuffer 的 stage， 
	public void UpdateFatherText() {
		// ContentText.text = name[text.Object] + text.TalkText;
		// UpdateText();
	}
	// 展示父亲每一天的事件, 使用 isFatherEvent 做标记
	private void showNewDayEvent(string content) {
		isFatherEvent = true;
		ContentText.text = content;
		BottomFrameController.Instance.ShowView();
	}
	#region create ItemMessageBox
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
	#endregion
	public override void Update()
	{
		if (Input.GetMouseButtonDown(0) && isChooseState == false)
		{
			NextText();
		}
		else if (Input.GetMouseButtonDown(0) && isFatherEvent) {
			isFatherEvent = false;
			BottomFrameController.Instance.HideView();
			// 执行当天的对话内容，存储的数据
			triggerTalkEvent();
		}
    }

	private void triggerTalkEvent() {

	}
	// 下一个交流数据判断
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
				BottomFrameController.Instance.HideView();
				Debug.Log("Conversation Over");
				RuntimeData.instance.passDay();
			}
		}
	}
	// 是否还有下句
	private bool hasNext(List<TalkList> groupList)
	{
		int tempCount = _nowCount + 1;
		if (tempCount <= groupList.Count)
		{
			return true;
		}
		return false;
	}
	// 清理
	private void resetConver()
	{
		GameObjectEventManager.instance.clearDicGroup();
		_nowStage = 1;
		_nowCount = 0;
	}
}

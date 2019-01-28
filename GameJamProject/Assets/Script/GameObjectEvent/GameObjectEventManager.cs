using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
using System;

public class GameObjectEventManager : SingletonMonoBehaviour<GameObjectEventManager> {

	#region paths
	[Tooltip("Please input the Stuff json relative path.")]
	public string stuffJsonPath;
	[Tooltip("Please input the Prop json relative path.")]
	public string propJsonPath;
	[Tooltip("Please input the father option json relative path.")]
	public string fatherOptionsPath;
	[Tooltip("Please input the father event json relative path.")]
	public string fatherEventPath;
	#endregion
	// json loader
	private JsonLoader _loader;
	private RuntimeData runtime;

	#region record the data
	private List<StuffGroup> stuffs = new List<StuffGroup>();
	private List<fatherEventObj> _fatherEvent = new List<fatherEventObj>();// 暂时没用
	#endregion
	#region currentStuffEvent
	private Dictionary<int, List<TalkList>> talkDic = new Dictionary<int, List<TalkList>>();
	private Dictionary<int, List<OptionList>> optionDic = new Dictionary<int, List<OptionList>>();
	#endregion
	private Dictionary<int, List<SquireObj>> SquirefatherOpts = new Dictionary<int, List<SquireObj>>();
	private Dictionary<KindOfState, List<PropObj>> propDic = new Dictionary<KindOfState, List<PropObj>>();
	// 记录当前被点击物体
	private GameObject currentForceObj = null;
	private SquireObj[] _fatherOpts;

	[Tooltip("All stuff in the Scene")]
	public GameObjectEvent[] stuffList;
	public GameObject testObj;

	public void Init() {
        for(int i=0;i< stuffList.Length; i++)
        {
            stuffList[i].init(this);
        }
		runtime = RuntimeData.instance;
		testObj.AddComponent<Highlighter>();
		testObj.GetComponent<GameObjectEvent>().init(this);

		FirstDay();
	}

	public void InitData() {
		_loader = JsonLoader.getInstance();
		loadStuffJson();
		loadPropJson();
		loadFatherOptionsJson();
		loadFatherEventJson();
	}
	// 开始对话
	public void startEvent(GameObjectEvent obj) {
		// get the TextList
		int id = obj.ID;
		currentForceObj = obj.gameObject;

		StuffGroup group = stuffs.Find(ele => ele.Id == id);
		if (group == null) {
			Debug.LogError("GameObjectEventManager: Stuff Id get error.");
			return;
		}
		TalkList[] talkLists = group.TalkList;
		OptionList[] optionList = group.OptionList;
		// update the dic
		analysisStuffTalkList(talkLists);
		analysisStuffOptionList(optionList);
		// start convercation
		convercation();
	}

	// 对话进行时,
	public void convercation() {
        BottomFrameController.Instance.View.StartUpdateContent(talkDic,optionDic, SquirefatherOpts);
        OwnStateController.Instance.ShowView();
		OwnStateController.Instance.View.CheckActor();
		OtherStateController.Instance.ShowView();
        OtherStateController.Instance.View.CheckActor();
    }

    public void stopConvercation() {
		clearDicGroup();
		runtime.passDay();
	}
	// 重置场景所有 stuff
	public void resetAllStuff() {
		for (int i = 0; i < stuffs.Count; i++) {
			StuffGroup stuff = stuffs[i];
			for (int j = 0; j < stuffList.Length; j++)
			{
				GameObject obj = stuffList[j].gameObject;
				GameObjectEvent gbEvent = stuffList[j];
				obj.SetActive(stuff.KeyName.Equals("1"));
				gbEvent.setClock(false);
			}
		}
	}
	// 清空临时 dictionary
	public void clearDicGroup()
	{
		talkDic.Clear();
		optionDic.Clear();
	}
	// 第一天数据
	private void FirstDay() {
		Debug.Log("First day");
		// show play animation
	}

	public void FatherNextDayEvent() {
		BottomFrameController.Instance.View.NewDayEvent();
	}

	public List<string> getFatherEventList() {
		List<int> stuffIdList = StorageManager.getInstance().getStuffId();
		if (_fatherEvent.Count > 0 && stuffIdList.Count > 0) {
			List<string> lists = new List<string>();
			for (int i = 0; i < stuffIdList.Count; i++)
			{
				int index = stuffIdList[i];
				for (int j = 0; j < _fatherEvent.Count; j++)
				{
					lists.Add(_fatherEvent[j].content);
				}
			}
			return lists;
		}
		else {
			Debug.LogWarning("GameObjectEventManager: FatherEvent List error");
			return null;
		}	
	}

	private void analysisStuffTalkList(TalkList[] talkLists) {
		// create the talkDic
		for (int i = 0; i < talkLists.Length; i++)
		{
			TalkList talk = talkLists[i];
			int stage = talk.TalkStage;
			if (!talkDic.ContainsKey(stage))
			{
				List<TalkList> lists = new List<TalkList>();
				lists.Add(talk);
				talkDic.Add(talk.TalkStage, lists);
			}
			else
			{
				talkDic[stage].Add(talk);
			}
		}
	}

	private void analysisStuffOptionList(OptionList[] optionList) {
		// create the optionDic
		for (int i = 0; i < optionList.Length; i++)
		{
			OptionList talk = optionList[i];
			int stage = talk.OptionsStage;
			if (!optionDic.ContainsKey(stage))
			{
				List<OptionList> lists = new List<OptionList>();
				lists.Add(talk);
				optionDic.Add(talk.OptionsStage, lists);
			}
			else
			{
				optionDic[stage].Add(talk);
			}
		}
	}

	// load Stuff Data
	private void loadStuffJson()
	{
		if (String.IsNullOrEmpty(stuffJsonPath))
		{
			Debug.LogWarning("stuffJsonPath is empty");
			return;
		}
		try
		{
			_loader.setPath(stuffJsonPath);
			string content = _loader.getJsonData();
			stuffs = _loader.parseStuffJsonData(content);
		}
		catch (Exception e)
		{
			Debug.LogException(e);
		}
	}
	// load prop data
	private void loadPropJson()
	{
		if (String.IsNullOrEmpty(propJsonPath))
		{
			Debug.LogWarning("propJsonPaths is empty");
			return;
		}
		// have four prop data
		try
		{
			_loader.setPath(propJsonPath);
			string content = _loader.getJsonData();
			PropObj[] props = _loader.parsePropJsonData(content);

			List<PropObj> healthy = new List<PropObj>();
			List<PropObj> harmony = new List<PropObj>();
			List<PropObj> pressure = new List<PropObj>();
			List<PropObj> riches = new List<PropObj>();

			foreach (PropObj p in props)
			{
				switch ((KindOfState)p.Type)
				{
					case KindOfState.Healthy:
						healthy.Add(p);
						break;
					case KindOfState.Harmony:
						harmony.Add(p);
						break;
					case KindOfState.Pressure:
						pressure.Add(p);
						break;
					case KindOfState.Riches:
						riches.Add(p);
						break;
				}
			}

			propDic.Add(KindOfState.Healthy, healthy);
			propDic.Add(KindOfState.Pressure, pressure);
			propDic.Add(KindOfState.Riches, riches);
			propDic.Add(KindOfState.Harmony, harmony);
		}
		catch (Exception e)
		{
			Debug.LogException(e);
		}
	}

	private void loadFatherOptionsJson()
	{
		if (String.IsNullOrEmpty(fatherOptionsPath))
		{
			Debug.LogWarning("fatherOptionsPath is empty");
			return;
		}
		try
		{
			_loader.setPath(fatherOptionsPath);
			string content = _loader.getJsonData();
			_fatherOpts = _loader.parseSquireOptionsData(content);

			for (int i = 0; i < _fatherOpts.Length; i++)
			{
				SquireObj obj = _fatherOpts[i];
				if (!SquirefatherOpts.ContainsKey(obj.Id))
				{
					List<SquireObj> lists = new List<SquireObj>();
					lists.Add(obj);
					SquirefatherOpts.Add(obj.Id, lists);
				}
			}
		}
		catch (Exception e)
		{
			Debug.LogException(e);
			return;
		}
	}

	private void loadFatherEventJson() {
		if (String.IsNullOrEmpty(fatherEventPath))
		{
			Debug.LogWarning("fatherOptionsPath is empty");
			return;
		}
		try
		{
			_loader.setPath(fatherEventPath);
			string content = _loader.getJsonData();
			_fatherEvent = _loader.parseFatherEventData(content);
		}
		catch (Exception e)
		{
			Debug.LogException(e);
			return;
		}
	}
	// test method
	void RandomTriggerEvent() {
		int count = stuffList.Length;
		int index = (int)UnityEngine.Random.Range(0, count);
		StuffGroup group = stuffs[index];
		BottomFrameController.Instance.View.UpdateText();
	}
}

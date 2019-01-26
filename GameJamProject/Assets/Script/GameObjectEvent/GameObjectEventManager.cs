using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
using System;

public class GameObjectEventManager : SingletonMonoBehaviour<GameObjectEventManager> {

	[Tooltip("Please input the Stuff json relative path.")]
	public string stuffJsonPath;
	[Tooltip("Please input the Prop json relative path.")]
	public string propJsonPath;
	[Tooltip("Please input the father json relative path.")]
	public string fatherOptionsPath;
	// json loader
	private JsonLoader _loader;
	private RuntimeData runtime;
	#region record the data
	private List<StuffGroup> stuffs = new List<StuffGroup>();
	private Dictionary<KindOfState, List<PropObj>> propDic = new Dictionary<KindOfState, List<PropObj>>();
	private List<OptionList> fatherOpts = new List<OptionList>();
	#endregion
	#region currentStuffEvent
	private Dictionary<int, List<TalkList>> talkDic = new Dictionary<int, List<TalkList>>();
	private Dictionary<int, List<OptionList>> optionDic = new Dictionary<int, List<OptionList>>();
	#endregion
	// 记录当前被点击物体
	private GameObject currentForceObj = null;

	[Tooltip("All stuff in the Scene")]
	public GameObjectEvent[] stuffList;
	public GameObject testObj;

	public void Init() {
		runtime = RuntimeData.instance;
		testObj.AddComponent<Highlighter>();
		testObj.GetComponent<GameObjectEvent>().init(this);
		FirstDay();
	}

	public void InitData() {
		_loader = JsonLoader.getInstance();
		loadStuffJson();
		loadPropJson();
		//loadFatherJson();
	}
	// 开始对话
	public void startEvent(GameObjectEvent obj) {
		// get the TextList
		int id = obj.ID;
		currentForceObj = obj.gameObject;

		StuffGroup group = stuffs.Find(ele => ele.ItemId == id);
		if (group == null) {
			Debug.LogError("GameObjectEventManager: Stuff Id get error.");
			return;
		}
		TalkList[] talkLists = group.TalkList;
		OptionList[] optionList = group.OptionList;
		// update the dic
		analysisTalkList(talkLists);
		analysisOptionList(optionList);
		// start convercation
		convercation();
	}

	// 对话进行时,
	public void convercation() {
		//BottomFrameController.Instance.XX(talkList);
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
				gbEvent.setEnter(false);
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
		// show scrollView block
	}

	private void analysisTalkList(TalkList[] talkLists) {
		// create the talkDic
		for (int i = 0; i < talkLists.Length; i++)
		{
			TalkList talk = talkLists[i];
			int stage = talk.TalkStage;
			if (talkDic.ContainsKey(stage))
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

	private void analysisOptionList(OptionList[] optionList) {
		// create the optionDic
		for (int i = 0; i < optionList.Length; i++)
		{
			OptionList talk = optionList[i];
			int stage = talk.OptionsStage;
			if (talkDic.ContainsKey(stage))
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
			string name = _loader.getJsonName();
			string content = _loader.getJsonData();
			PropObj[] props = _loader.parsePropJsonData(content);

			List<PropObj> healthy = new List<PropObj>();
			List<PropObj> harmony = new List<PropObj>();
			List<PropObj> pressure = new List<PropObj>();
			List<PropObj> riches = new List<PropObj>();

			foreach (PropObj p in props)
			{
				KindOfState state;
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

	private void loadFatherJson()
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
			fatherOpts = _loader.parseOptionJsonData(content);
		}
		catch (Exception e)
		{
			Debug.LogException(e);
			return;
		}

	}
}

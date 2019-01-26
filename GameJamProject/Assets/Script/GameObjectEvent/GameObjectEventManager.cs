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

	#region record the data
	private List<StuffGroup> stuffs = new List<StuffGroup>();
	private Dictionary<KindOfState, List<PropObj>> propDic = new Dictionary<KindOfState, List<PropObj>>();
	private List<OptionList> fatherOpts = null;
	#endregion

	[Tooltip("All stuff in the Scene")]
	public GameObject[] stuffList;

	public GameObject testObj;

	public void Init() {
		//createStuff();
		testObj.AddComponent<Highlighter>();
		testObj.GetComponent<GameObjectEvent>().init(this);
		FirstDay();
	}
	// 重置对象，比如去除所有高亮
	public void resetStuffHightLight() {}

	public void InitData()
	{
		_loader = JsonLoader.getInstance();
		loadStuffJson();
		loadPropJson();
		//loadFatherJson();
	}

	public void startEvent(GameObjectEvent obj) {
		// get id
	}

	public void resetAllStuff() {}

	// 第一天数据
	private void FirstDay() {
		Debug.Log("First day");
		// show scrollView block
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

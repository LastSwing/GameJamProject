using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState {
	Menu,
	Child,
	Father,
	GameOver
}

public enum KindOfState {
	Pressure = 1,
	Healthy = 2,
	Harmony = 3,
	Riches = 4
}

public class RuntimeData : SingletonMonoBehaviour<RuntimeData> {

    public Transform SceneRoot,UIRoot,OtherRoot;
	[Tooltip("Please input the Stuff json relative path.")]
	public string stuffJsonPath;
	[Tooltip("Please input the Prop json relative path.")]
	public string propJsonPath;
	[Tooltip("Please input the father json relative path.")]
	public string fatherOptionsPath;
	#region ActionProp
	public float childPressValue = 0;
	public float childHarmonyValue = 0;
	public float childMoneyValue = 0;
	public float childHealthyValue = 0;

	public float fatherPressValue = 0;
	public float fatherHarmonyValue = 0;
	public float fatherMoneyValue = 0;
	public float fatherHealthyValue = 0;
	#endregion
	private Child _child;
	private Father _father;
	private JsonLoader _loader;
	private GameState _state;

	// record the data
	private List<StuffGroup> stuffs = new List<StuffGroup>();
	private Dictionary<KindOfState, List<PropObj>> propDic = new Dictionary<KindOfState, List<PropObj>>();
	private List<OptionList> fatherOpts = null;
	// development
	public bool isDevelop = true;

	private void Start () {
		Init();
		InitData();
	}

	public void Init () {
        SceneRoot = GameObject.Find("SceneRoot").transform;
        UIRoot = GameObject.Find("UIRoot").transform;
        OtherRoot = GameObject.Find("OtherRoot").transform;
		StartUIController.Instance.ShowView();
		_child = new Child(childPressValue, childHarmonyValue, childMoneyValue, childHealthyValue);
		_father = new Father(fatherPressValue, fatherHarmonyValue, fatherMoneyValue, fatherHealthyValue);
		_loader = JsonLoader.getInstance();

		_state = GameState.Menu;
	}

	private void InitData () {
		loadStuffJson();
		loadPropJson();
		//loadFatherJson();
	}
	// load Stuff Data
	private void loadStuffJson () {
		if (String.IsNullOrEmpty(stuffJsonPath)) {
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
	private void loadPropJson () {
		if (String.IsNullOrEmpty(propJsonPath)) {
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
			List<PropObj> riches =  new List<PropObj>();

			foreach (PropObj p in props)
			{
				KindOfState state;
				switch ( (KindOfState)p.Type ) {
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

	private void loadFatherJson () {
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
		catch (Exception e) {
			Debug.LogException(e);
			return;
		}
		
	}
}

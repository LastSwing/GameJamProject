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

public class RuntimeData : SingletonMonoBehaviour<RuntimeData> {

    public Transform SceneRoot,UIRoot,OtherRoot;
	[Tooltip("Please input the Stuff json relative path.")]
	public string stuffJsonPath;
	[Tooltip("Please input the Prop json relative path.")]
	public string[] propJsonPaths;
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
	private StuffGroup[] stuffs = null;
	private Dictionary<string, propObj[]> propDic = new Dictionary<string, propObj[]>();
	private optionObj[] fatherOpts = null;
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

		_child = new Child(childPressValue, childHarmonyValue, childMoneyValue, childHealthyValue);
		_father = new Father(fatherPressValue, fatherHarmonyValue, fatherMoneyValue, fatherHealthyValue);
		_loader = JsonLoader.getInstance();
	}

	private void InitData () {
		loadStuffJson();
		loadPropJson();
		loadFatherJson();
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
		if (propJsonPaths.Length <= 0) {
			Debug.LogWarning("propJsonPaths is empty");
			return;
		}
		// have four prop data
		foreach (string path in propJsonPaths) {
			try
			{
				_loader.setPath(path);
				string name = _loader.getJsonName();
				string content = _loader.getJsonData();
				propObj[] prop = _loader.parsePropJsonData(content);
				propDic.Add(name, prop);
				
			}
			catch (Exception e) {
				Debug.LogException(e);
			}
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

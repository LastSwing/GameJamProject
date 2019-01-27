using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JsonLoader {

	private string _path = "";

	private static JsonLoader _instance = null;

	public static JsonLoader getInstance() {
		if (_instance == null) {
			_instance = new JsonLoader();
			return _instance;
		}
		return _instance;
	}
	// 切换 path
	public void setPath(string value) {
		_path = value;
	}

	// 初始化物品数据,通过切换 path
	public string getJsonData() {
		string content = "";
		if (String.IsNullOrEmpty(_path)) {
			Debug.Log("JsonLoader: Path is undefined.");
			return null;
		}
		StreamReader reader = new StreamReader(Application.dataPath + _path);
		while (!reader.EndOfStream) {
			string line = reader.ReadLine();
			content += line;
		}
		reader.Close();
		return content;
	}

	public string getJsonName() {
		if (_path.Equals("")) {
			Debug.LogWarning("JsonLoader: _path doesn't setting.");
			return null;
		}
		return Path.GetFileName(_path);
	}

	public List<fatherEventObj> parseFatherEventData(string json) {
		return JsonUtility.FromJson<List<fatherEventObj>>(json);
	}

	// 解析 stuff json 数据
	public List<StuffGroup> parseStuffJsonData(string json) {
		try
		{
			StuffGroup[] stuffArray = JsonHelper.FromJson<StuffGroup>(json);
			List<StuffGroup> tempList = new List<StuffGroup>();
			foreach (StuffGroup group in stuffArray) {
				tempList.Add(group);
			}
			return tempList;
		}
		catch (Exception e) {
			Debug.LogWarning(e);
		}
		return null;
	}

	public PropObj[] parsePropJsonData(string json) {
		return JsonHelper.FromJson<PropObj>(json);
	}

	public SquireObj[] parseSquireOptionsData(string json) {
		return JsonHelper.FromJson<SquireObj>(json);
	}

}

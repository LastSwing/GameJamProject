using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
	public void switchPath(string value) {
		_path = value;
	}

	// 初始化物品数据,通过切换 path
	public string initJsonData() {
		string content = "";
		if (!_path.Equals("")) {
			Debug.Log("Path is undefined.");
			return null;
		}
		StreamReader reader = new StreamReader(_path);
		while (!reader.EndOfStream) {
			string line = reader.ReadLine();
			content += line;
		}

		return content;
	}

	// 解析 stuff json 数据
	public StuffGroup[] parseStuffJsonData(string json) {
		StuffGroup[] dataGroups = JsonHelper.FromJson<StuffGroup>(json);
		return dataGroups;
	}

	public PropGroup[] parsePropJsonData(string json) {
		PropGroup[] dataGroup = JsonHelper.FromJson<PropGroup>(json);
		return dataGroup;
	}
}

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
	public void setPath(string value) {
		_path = value;
	}

	// 初始化物品数据,通过切换 path
	public string getJsonData() {
		string content = "";
		if (!_path.Equals("")) {
			Debug.Log("JsonLoader: Path is undefined.");
			return null;
		}
		StreamReader reader = new StreamReader(_path);
		while (!reader.EndOfStream) {
			string line = reader.ReadLine();
			content += line;
		}

		return content;
	}

	public string getJsonName() {
		if (_path.Equals("")) {
			Debug.LogWarning("JsonLoader: _path doesn't setting.");
			return null;
		}
		return Path.GetFileName(_path);
	}

	// 解析 stuff json 数据
	public StuffGroup[] parseStuffJsonData(string json) {
		return JsonHelper.FromJson<StuffGroup>(json); ;
	}

	public propObj[] parsePropJsonData(string json) {
		return JsonHelper.FromJson<propObj>(json);
	}

	public optionObj[] parseOptionJsonData(string json) {
		return JsonHelper.FromJson<optionObj>(json);
	}
}

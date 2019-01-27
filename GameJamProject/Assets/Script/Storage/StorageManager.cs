using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager {

	private List<int> childOptionId = new List<int>();	// record optionsId1, optionId2 
	private List<int> stuffId = new List<int>(); // record ItemId

	private static StorageManager _instance = null;
	public static StorageManager getInstance() {
		if (_instance == null) {
			_instance = new StorageManager();
			Debug.Log("StorageManager init");
		}
		return _instance;
	}

	public void saveStuffId(int id) {
		stuffId.Add(id);
	}


	public void saveId(int optionId) {
		childOptionId.Add(optionId);
	}

	public List<int> getOptionStorage() {
		return childOptionId;
	}

	public List<int> getStuffId() {
		return stuffId;
	}
}

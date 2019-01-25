using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        RuntimeData.instance.Init();
        StartUIController.Instance.ShowView();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

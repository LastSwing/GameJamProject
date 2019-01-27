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
	private GameState _state;
	private CameraController _camCtrl;
	// 回合日期
	public int rounds = 0;
	// development
	public bool isDevelop = true;

    public string[] name = { "", "Hughes:", "Squire:", "Peill", "Alice" };
    void Start () {
		Init();
	}
	public void Update()
	{
		UpdateManager.Instance.myUpdate();
	}

	public void Init () {
        SceneRoot = GameObject.Find("SceneRoot").transform;
        UIRoot = GameObject.Find("UIRoot").transform;
        OtherRoot = GameObject.Find("OtherRoot").transform;
		StartUIController.Instance.ShowView();

		_child = new Child(childPressValue, childHarmonyValue, childMoneyValue, childHealthyValue);
		_father = new Father(fatherPressValue, fatherHarmonyValue, fatherMoneyValue, fatherHealthyValue);
		
		_state = GameState.Menu;
		_camCtrl = GetComponent<CameraController>();

		GameObjectEventManager.instance.Init();
		GameObjectEventManager.instance.InitData();
	}

	public void setGameState(GameState value) {
		_state = value;
	}

	public GameState getGameState() {
		return _state;
	}
	// 
	public void passDay() {
		rounds--;
		if (rounds <= 0 && _state == GameState.Father)
		{
			GameOver();
		}
		else if (rounds <= 0 && _state != GameState.Father)
		{
			// state = GameState.Child
			SwitchRoundTwo();
		}
		else if (rounds > 0 && _state == GameState.Father) {
			// play the new event
			GameObjectEventManager.instance.FatherNextDayEvent();
		}
	}

	public CameraController getCameraCtrl() {
		return _camCtrl;
	}

	// show scrollView, and many event summary
	public void GameOver() {
		// playAnimation
	}

	public void SwitchRoundTwo() {
		// 刷新物体状态，不刷物体位置，不切换移动了
		GameObjectEventManager.instance.resetAllStuff();
		// 重置摄像机
		_camCtrl.resetAll();
		// 更换游戏状态
		_state = GameState.Father;
        MusicManager.instance.SetBgm(PathManager.father_Bgm);

		// 播放一个转场

	}
    public void UpdateState(int Pressure,int Healthy,int Happiness, int Riches)
    {
        //OtherStateController.Instance.View.UpdateState(压力,健康);
        //OwnStateController.Instance.View.UpdateState(压力,健康);
        //HomeStateController.Instance.View.UpdateState(和睦,财富);
    }
}

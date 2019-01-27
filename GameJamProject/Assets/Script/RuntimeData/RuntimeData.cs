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
	// 回合日期
	public int rounds = 0;
	// development
	public bool isDevelop = true;

	// Controller Camera -> Room Switch

	void Start () {
		Init();
	}

	public void Init () {
        SceneRoot = GameObject.Find("SceneRoot").transform;
        UIRoot = GameObject.Find("UIRoot").transform;
        OtherRoot = GameObject.Find("OtherRoot").transform;
		StartUIController.Instance.ShowView();
		_child = new Child(childPressValue, childHarmonyValue, childMoneyValue, childHealthyValue);
		_father = new Father(fatherPressValue, fatherHarmonyValue, fatherMoneyValue, fatherHealthyValue);
		
		_state = GameState.Menu;

		GameObjectEventManager.instance.Init();
		GameObjectEventManager.instance.InitData();
	}

	public void setGameState(GameState value) {
		_state = value;
	}
	// 
	public void passDay() {
		rounds--;
		if (rounds <= 0 && _state == GameState.Father)
		{
			GameOver();
		}
		else if (rounds <= 0){
			// state = GameState.Child
			SwitchRoundTwo();
		}
	}

	// show scrollView, and many event summary
	public void GameOver() {

	}

	public void SwitchRoundTwo() {
		// 刷新物体状态，不刷物体位置，不切换移动了
		GameObjectEventManager.instance.resetAllStuff();
	}
    public void UpdateState(int Pressure,int Healthy,int Happiness, int Riches)
    {
        //todo,计算函数
        //判断周目
        //OtherStateController.Instance.View.UpdateState(压力,健康);
        //OwnStateController.Instance.View.UpdateState(压力,健康);
        //HomeStateController.Instance.View.UpdateState(和睦,财富);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private void Start()
	{
		Init();
	}

	public void Init()
    {
        SceneRoot = GameObject.Find("SceneRoot").transform;
        UIRoot = GameObject.Find("UIRoot").transform;
        OtherRoot = GameObject.Find("OtherRoot").transform;

		_child = new Child(childPressValue, childHarmonyValue, childMoneyValue, childHealthyValue);
		_father = new Father(fatherPressValue, fatherHarmonyValue, fatherMoneyValue, fatherHealthyValue);
    }
}

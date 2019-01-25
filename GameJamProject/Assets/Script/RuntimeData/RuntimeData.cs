using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeData : SingletonMonoBehaviour<RuntimeData> {

    public Transform SceneRoot,UIRoot,OtherRoot;
    public int pressurePoint;//压力
    public int harmonyPoint;//和睦值
    public int healthPoint;//健康
    public void Init()
    {
        SceneRoot = GameObject.Find("SceneRoot").transform;
        UIRoot = GameObject.Find("UIRoot").transform;
        OtherRoot = GameObject.Find("OtherRoot").transform;
    }
    

}

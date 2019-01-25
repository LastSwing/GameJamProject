using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UIView基类
/// </summary>
public class BaseUIView : IUpdate
{
    public GameObject m_UIObject;//UI视图实例物体
    protected List<Coroutine> m_CoroutineList;

    public BaseUIView(string UIViewName, Transform parent)
    {
        m_UIObject = UIViewPool.FindGameObject(UIViewName, parent);
        Init();
        InitEvent();
        this.ShowUIView();
        m_CoroutineList = new List<Coroutine>();
    }

    /// <summary>
    /// FixedUpdate方法 只在View出现的时候执行 
    /// 当View 隐藏的时候 不运行
    /// </summary>

    public virtual void FixedUpdate() { }

    /// <summary>
    /// Update方法 只在View出现的时候执行 
    /// 当View 隐藏的时候 不运行
    /// </summary>
    public virtual void Update() { }

    protected virtual void Init() { }

    protected virtual void InitEvent() { }

    public virtual void HideView()
    {
        UpdateManager.Instance.RemoveUpdate(this);
        UpdateManager.Instance.RemoveFixedUpdate(this);
        if (m_UIObject != null)
            m_UIObject.SetActive(false);
    }

    public virtual void ShowUIView()
    {
        UpdateManager.Instance.AddFixedUpdate(this);
        UpdateManager.Instance.AddUpdate(this);

        if (m_UIObject != null)
            m_UIObject.SetActive(true);
    }

    public virtual void DestoryView()
    {
        UpdateManager.Instance.RemoveUpdate(this);
        UpdateManager.Instance.RemoveFixedUpdate(this);
        GameObject.Destroy(m_UIObject);
    }

    protected virtual GameObject GetGameObjectByName(string name)
    {
        return GameUtils.GetGameObjectByName(name, this.m_UIObject);
    }
    
}

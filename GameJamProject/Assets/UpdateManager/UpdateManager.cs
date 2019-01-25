using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于全局控制视图的更新速度
/// </summary>
public class UpdateManager : MySingleton<UpdateManager>
{
    private List<IUpdate> fixedUpdateList = new List<IUpdate>(); // FixedUpdate
    private List<IUpdate> updateList = new List<IUpdate>(); // Update

    /// <summary>
    /// 注意！！继承IUpdate接口，需要用到Update函数的时候需要调用一次AddFixedUpdate方法
    /// </summary>
    /// <param name="updateObject"></param>
    public void AddFixedUpdate(IUpdate updateObject)
    {
        fixedUpdateList.Add(updateObject);
    }

    /// <summary>
    /// 注意！！继承IUpdate接口，需要用到Update函数的时候需要调用一次AddUpdate方法
    /// </summary>
    /// <param name="updateObject"></param>
    public void AddUpdate(IUpdate updateObject)
    {
        updateList.Add(updateObject);
    }

    public void RemoveFixedUpdate(IUpdate updateObject)
    {
        fixedUpdateList.Remove(updateObject);
    }

    public void RemoveUpdate(IUpdate updateObject)
    {
        updateList.Remove(updateObject);
    }

    public void myFixedUpdate()
    {
        for (int i = 0; i < fixedUpdateList.Count; i++)
        {
            fixedUpdateList[i].FixedUpdate();
        }
    }

    public void myUpdate()
    {
        for (int i = 0; i < updateList.Count; i++)
        {
            updateList[i].Update();
        }
    }

    public void ClearUpdate()
    {
        updateList.Clear();
    }
    public void ClearFixUpdate()
    {
        fixedUpdateList.Clear();
    }

}

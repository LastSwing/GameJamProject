using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VA.UI;
/// <summary>
/// UI状态处理管理类
/// </summary>
public class StateHandlerManager : MonoBehaviour, IStateHandler
{
    [SerializeField]
    private List<BaseStateHandler> _stateHandlers = new List<BaseStateHandler>();


    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        _stateHandlers = gameObject.GetComponentsInChildren<BaseStateHandler>().ToList();
    }
    public void OnNormalState()
    {
        foreach (var baseStateHandler in _stateHandlers)
        {
            baseStateHandler.OnNormalState();
        }
    }

    public void OnHighLightState()
    {
        foreach (var baseStateHandler in _stateHandlers)
        {
            baseStateHandler.OnHighLightState();
        }
    }

    public void OnDisableState()
    {
        foreach (var baseStateHandler in _stateHandlers)
        {
            baseStateHandler.OnDisableState();
        }
    }

    public void OnHoverState()
    {
        foreach (var baseStateHandler in _stateHandlers)
        {
            baseStateHandler.OnHoverState();
        }
    }

    public void OnSelectState()
    {
        foreach (var baseStateHandler in _stateHandlers)
        {
            baseStateHandler.OnSelectState();
        }
    }
    public void OnPressDownState()
    {
        foreach (var baseStateHandler in _stateHandlers)
        {
            baseStateHandler.OnPressDownState();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateHandler : MonoBehaviour
{
    /// <summary>
    /// 常规状态
    /// </summary>
    public abstract void OnNormalState();

    /// <summary>
    /// 高亮状态
    /// </summary>
    public abstract void OnHighLightState();

    /// <summary>
    /// 不可用状态
    /// </summary>
    public abstract void OnDisableState();

    /// <summary>
    /// 悬停状态
    /// </summary>
    public abstract void OnHoverState();

    /// <summary>
    /// 选中状态
    /// </summary>
    public abstract void OnSelectState();

    /// <summary>
    /// 按下状态
    /// </summary>
    public abstract void OnPressDownState();

}
public enum UIState
{
    Normal,
    HighLight,
    Disable,
    Hover,
    Select,
}

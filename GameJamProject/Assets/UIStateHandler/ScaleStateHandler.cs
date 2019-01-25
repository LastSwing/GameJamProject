using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleStateHandler : BaseStateHandler
{
    public Vector3 NormalValue;
    public Vector3 HoverValue;
    public Vector3 HighLightValue;
    public Vector3 SelectValue;
    public Vector3 DisableValue;
    public Vector3 PressDownValue;
    public override void OnNormalState()
    {
        transform.localScale = NormalValue;
    }

    public override void OnHighLightState()
    {
        transform.localScale = HighLightValue;
    }

    public override void OnDisableState()
    {
        transform.localScale = DisableValue;
    }

    public override void OnHoverState()
    {
        transform.localScale = HoverValue;
    }

    public override void OnSelectState()
    {
        transform.localScale = SelectValue;
    }

    public override void OnPressDownState()
    {
        transform.localScale = PressDownValue;
    }
}
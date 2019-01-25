using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionStateHandler : BaseStateHandler
{
    public Vector3 NormalValue;
    public Vector3 HoverValue;
    public Vector3 HighLightValue;
    public Vector3 SelectValue;
    public Vector3 DisableValue;
    public Vector3 PressDownValue;
    public override void OnNormalState()
    {
        transform.localPosition = NormalValue;
    }

    public override void OnHighLightState()
    {
        transform.localPosition = HighLightValue;
    }

    public override void OnDisableState()
    {
        transform.localPosition = DisableValue;
    }

    public override void OnHoverState()
    {
        transform.localPosition = HoverValue;
    }

    public override void OnSelectState()
    {
        transform.localPosition = SelectValue;
    }

    public override void OnPressDownState()
    {
        transform.localPosition = PressDownValue;
    }
}

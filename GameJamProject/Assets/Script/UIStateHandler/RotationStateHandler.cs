using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationStateHandler : BaseStateHandler
{
    public Vector3 NormalValue;
    public Vector3 HoverValue;
    public Vector3 HighLightValue;
    public Vector3 SelectValue;
    public Vector3 DisableValue;
    public Vector3 PressDownValue;
    public override void OnNormalState()
    {
        transform.localEulerAngles = NormalValue;
    }

    public override void OnHighLightState()
    {
        transform.localEulerAngles = HighLightValue;
    }

    public override void OnDisableState()
    {
        transform.localEulerAngles = DisableValue;
    }

    public override void OnHoverState()
    {
        transform.localEulerAngles = HoverValue;
    }

    public override void OnSelectState()
    {
        transform.localEulerAngles = SelectValue;
    }

    public override void OnPressDownState()
    {
        transform.localEulerAngles = PressDownValue;
    }
}
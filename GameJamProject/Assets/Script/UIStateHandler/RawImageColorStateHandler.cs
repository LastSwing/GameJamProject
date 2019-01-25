using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageColorStateHandler : BaseStateHandler
{
    public RawImage TargetImage;
    public Color NormalColor;
    public Color HoverColor;
    public Color HighLightColor;
    public Color SelectColor;
    public Color DisableColor;
    public Color PressDownColor;

    private void Awake()
    {
        TargetImage=GetComponent<RawImage>();
    }
    public override void OnNormalState()
    {
        TargetImage.color = NormalColor;
    }

    public override void OnHighLightState()
    {
        TargetImage.color = HighLightColor;
    }

    public override void OnDisableState()
    {
        TargetImage.color = DisableColor;
    }

    public override void OnHoverState()
    {
        TargetImage.color = HoverColor;
    }

    public override void OnSelectState()
    {
        TargetImage.color = SelectColor;
    }

    public override void OnPressDownState()
    {
        TargetImage.color = PressDownColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorStateHandler : BaseStateHandler
{
    [SerializeField]
    private Graphic _target;
    public Color NormalColor;
    public Color HoverColor;
    public Color HighLightColor;
    public Color SelectColor;
    public Color DisableColor;
    public Color PressDownColor;

    public Graphic Target
    {
        get
        {
            if (_target == null)
            {
                _target = GetComponent<Graphic>();
            }
            return _target;
        }
    }

    public override void OnNormalState()
    {
        Target.color = NormalColor;
    }

    public override void OnHighLightState()
    {
        Target.color = HighLightColor;
    }

    public override void OnDisableState()
    {
        Target.color = DisableColor;
    }

    public override void OnHoverState()
    {
        Target.color = HoverColor;
    }

    public override void OnSelectState()
    {
        Target.color = SelectColor;
    }

    public override void OnPressDownState()
    {
        Target.color = PressDownColor;
    }
}

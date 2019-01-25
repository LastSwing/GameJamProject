using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class TextColorStateHandler : BaseStateHandler
{
    [SerializeField]
    private Text _targetText;
    public Color NormalColor;
    public Color HoverColor;
    public Color HighLightColor;
    public Color SelectColor;
    public Color DisableColor;
    public Color PressDownColor;

    public Text TargetText
    {
        get
        {
            if (_targetText == null)
            {
                _targetText = GetComponent<Text>();
            }
            return _targetText;
        }
    }

    public override void OnNormalState()
    {
        TargetText.color = NormalColor;
    }

    public override void OnHighLightState()
    {
        TargetText.color = HighLightColor;
    }

    public override void OnDisableState()
    {
        TargetText.color = DisableColor;
    }

    public override void OnHoverState()
    {
        TargetText.color = HoverColor;
    }

    public override void OnSelectState()
    {
        TargetText.color = SelectColor;
    }

    public override void OnPressDownState()
    {
        TargetText.color = PressDownColor;
    }
}

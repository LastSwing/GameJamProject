using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextFontStateHandler : BaseStateHandler
{
    [SerializeField]
    private Text _targetText;
    public Font NormalFont;
    public Font HoverFont;
    public Font HighLightFont;
    public Font SelectFont;
    public Font DisableFont;
    public Font PressDownFont;
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
        TargetText.font = NormalFont;
    }

    public override void OnHighLightState()
    {
        TargetText.font = HighLightFont;
    }

    public override void OnDisableState()
    {
        TargetText.font = DisableFont;
    }

    public override void OnHoverState()
    {
        TargetText.font = HoverFont;
    }

    public override void OnSelectState()
    {
        TargetText.font = SelectFont;
    }

    public override void OnPressDownState()
    {
        TargetText.font = PressDownFont;

    }
}

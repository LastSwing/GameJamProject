using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class ImageColorStateHandler : BaseStateHandler
{
    [SerializeField]
    private Image _targetImage;
    public Color NormalColor;
    public Color HoverColor;
    public Color HighLightColor;
    public Color SelectColor;
    public Color DisableColor;
    public Color PressDownColor;
    public Image TargetImage
    {
        get
        {
            if (_targetImage == null)
            {
                _targetImage = GetComponent<Image>();
            }
            return _targetImage;
        }
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

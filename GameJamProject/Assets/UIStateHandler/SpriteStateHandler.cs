using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SpriteStateHandler : BaseStateHandler
{
    [SerializeField]
    private Image _targetImage;
    public Sprite NormalSprite;
    public Sprite HoverSprite;
    public Sprite HighLightSprite;
    public Sprite SelectSprite;
    public Sprite DisableSprite;
    public Sprite PressDownSprite;
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
        TargetImage.sprite = NormalSprite;
    }

    public override void OnHighLightState()
    {
        TargetImage.sprite = HighLightSprite;
    }

    public override void OnDisableState()
    {
        TargetImage.sprite = DisableSprite;
    }

    public override void OnHoverState()
    {
        TargetImage.sprite = HoverSprite;
    }

    public override void OnSelectState()
    {
        TargetImage.sprite = SelectSprite;
    }

    public override void OnPressDownState()
    {
        TargetImage.sprite = PressDownSprite;
    }
}

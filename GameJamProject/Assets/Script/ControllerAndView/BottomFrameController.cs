using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomFrameController : MySingleton<BottomFrameController>
{
    private BottomFrameView _view;

    public BottomFrameView View
    {
        get
        {
            if (_view == null || _view.m_UIObject == null)
            {
                _view = new BottomFrameView("BottomFrame", RuntimeData.instance.UIRoot);
            }
            return _view;
        }
    }

    public void ShowView()
    {
        View.ShowUIView();
    }

    public void HideView()
    {
        View.HideView();
    }

}

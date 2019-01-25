using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUIController : MySingleton<StartUIController>
{
    private StartUIView _view;

    public StartUIView View
    {
        get
        {
            if (_view == null || _view.m_UIObject == null)
            {
                _view = new StartUIView("StartUIView", RuntimeData.instance.UIRoot);
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

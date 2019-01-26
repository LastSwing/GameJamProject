using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnStateController : MySingleton<OwnStateController>
{
    private OwnStateView _view;

    public OwnStateView View
    {
        get
        {
            if (_view == null || _view.m_UIObject == null)
            {
                _view = new OwnStateView("OwnState", RuntimeData.instance.UIRoot);
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
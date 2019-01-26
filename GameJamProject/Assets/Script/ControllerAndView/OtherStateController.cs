using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherStateController : MySingleton<OtherStateController>
{
    private OtherStateView _view;

    public OtherStateView View
    {
        get
        {
            if (_view == null || _view.m_UIObject == null)
            {
                _view = new OtherStateView("OtherState", RuntimeData.instance.UIRoot);
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

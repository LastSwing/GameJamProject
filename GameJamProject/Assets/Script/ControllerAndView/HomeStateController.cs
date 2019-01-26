using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeStateController : MySingleton<HomeStateController>
{
    private HomeStateView _view;

    public HomeStateView View
    {
        get
        {
            if (_view == null || _view.m_UIObject == null)
            {
                _view = new HomeStateView("HomeState", RuntimeData.instance.UIRoot);
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

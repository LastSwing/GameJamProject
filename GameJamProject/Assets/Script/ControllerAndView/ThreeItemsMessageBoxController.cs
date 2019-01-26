using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeItemsMessageBoxController : MySingleton<ThreeItemsMessageBoxController>
{
    private ThreeItemsMessageBoxView _view;

    public ThreeItemsMessageBoxView View
    {
        get
        {
            if (_view == null || _view.m_UIObject == null)
            {
                _view = new ThreeItemsMessageBoxView("ThreeItemsMessageBox", RuntimeData.instance.OtherRoot);
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
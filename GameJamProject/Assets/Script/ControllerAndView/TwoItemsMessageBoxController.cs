using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoItemsMessageBoxController : MySingleton<TwoItemsMessageBoxController>
{
    private TwoItemsMessageBoxView _view;

    public TwoItemsMessageBoxView View
    {
        get
        {
            if (_view == null || _view.m_UIObject == null)
            {
                _view = new TwoItemsMessageBoxView("TwoItemsMessageBox", RuntimeData.instance.OtherRoot);
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
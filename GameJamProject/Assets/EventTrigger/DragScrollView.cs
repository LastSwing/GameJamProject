using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 滑动列表元素事件监听器
/// </summary>
public class DragScrollView : EventTriggerListener
{

    new public static DragScrollView Get(GameObject go)
    {
        DragScrollView listener = go.GetComponent<DragScrollView>();
        if (listener == null) listener = go.AddComponent<DragScrollView>();
        return listener;
    }
    /// <summary>
    /// Reference to the scroll view that will be dragged by the script.
    /// </summary>

    public ScrollRect scrollView;

    // Legacy functionality, kept for backwards compatibility. Use 'scrollView' instead.
    [HideInInspector]
    [SerializeField]
    ScrollRect draggablePanel;

    Transform mTrans;
    ScrollRect mScroll;
    bool mAutoFind = false;
    bool mStarted = false;

    /// <summary>
    /// Automatically find the scroll view if possible.
    /// </summary>

    void OnEnable()
    {
        mTrans = transform;

        // Auto-upgrade
        if (scrollView == null && draggablePanel != null)
        {
            scrollView = draggablePanel;
            draggablePanel = null;
        }

        if (mStarted && (mAutoFind || mScroll == null))
            FindScrollView();
    }


    /// <summary>
    /// Find the scroll view.
    /// </summary>

    void Start()
    {
        mStarted = true;
        FindScrollView();
    }

    /// <summary>
    /// Find the scroll view to work with.
    /// </summary>

    void FindScrollView()
    {
        // If the scroll view is on a parent, don't try to remember it (as we want it to be dynamic in case of re-parenting)
        ScrollRect sv = mTrans.GetComponentInParent<ScrollRect>();


        if (scrollView == null)
        {
            scrollView = sv;
            mAutoFind = true;
        }
        else if (scrollView == sv)
        {
            mAutoFind = true;
        }
        mScroll = scrollView;
    }
    public override void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (onDrag != null) { onDrag(gameObject); }
        scrollView.OnDrag(eventData);
    }
    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        if (onInitializePotentialDrag != null){ onInitializePotentialDrag(gameObject); }
        scrollView.OnInitializePotentialDrag(eventData);
    }
    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (onBeginDrag != null) { onBeginDrag(gameObject); }
        scrollView.OnBeginDrag(eventData);
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (onEndDrag != null) { onEndDrag(gameObject); }
        scrollView.OnEndDrag(eventData);
    }
}

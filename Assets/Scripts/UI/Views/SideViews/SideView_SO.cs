using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Side View", menuName = "ScriptableObjects/UI/Views/Side View")]
public class SideView_SO : View_SO
{
    public event Func<bool> SideViewState;
    public event Action OnSideViewShow;
    public event Action OnSideViewHide;

    public event Action OnSideViewShow_RequestEvent;
    public event Action OnSideViewHide_RequestEvent;

    public event EventHandler onInitializeSubPanels;

    public void InitializeSubComponents()
    {
        onInitializeSubPanels?.Invoke(this, EventArgs.Empty);
    }

    public void TriggerSideViewShowEvent()
    {
        OnSideViewShow?.Invoke();
    }

    public void TriggerSideViewHideEvent()
    {
        OnSideViewHide?.Invoke();
    }

    public bool GetSideViewState()
    {
       return SideViewState.Invoke();
    }

    public void ShowSideView_Request()
    {
        OnSideViewShow_RequestEvent?.Invoke();
    }

    public void HideSideView_Request()
    {
        OnSideViewHide_RequestEvent?.Invoke();
    }
}

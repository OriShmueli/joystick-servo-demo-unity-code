using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "View", menuName = "ScriptableObjects/UI/Views/View")]
public class View_SO : ScriptableObject
{
    public event Func<bool> ViewState;
    public event Action OnViewShow;
    public event Action OnViewHide;

    public void TriggerViewShowEvent()
    {
        OnViewShow?.Invoke();
    }

    public void TriggerViewHideEvent()
    {
        OnViewHide?.Invoke();
    }

    public bool GetViewState()
    {
        return ViewState.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ControlPanelView_SO", menuName = "ScriptableObjects/UI/Views/Control Panel")]
public class ControlPanelView_SO : View_SO
{
    public event Action OnControlPanelShow;
    public event Action OnControlPanelHide;
    
    public void TriggerOnControlPanelShowEvent()
    {
        OnControlPanelShow?.Invoke();
    }

    public void TriggerOnControlPanelHideEvent()
    {
        OnControlPanelHide?.Invoke();
    }
}

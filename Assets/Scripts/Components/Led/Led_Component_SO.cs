using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/Led_Component_SO")]
public class Led_Component_SO : Component_SO
{
    [SerializeField] private Color32 _colorOn;
    [SerializeField] private Color32 _colorOff;

    public Color32 ColorOn => _colorOn;
    public Color32 ColorOff => _colorOff;

    public event EventHandler<bool> OnLightSwitch;

    void LedOn(bool Switch)
    {
        OnLightSwitch?.Invoke(this, Switch);
    }
}

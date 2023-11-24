using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelView : View
{
    private ControlPanelView_SO _controlPanelView_SO;  

    public override void Init() //its ok to call it later because it called after the show (awake) method.
    {
        _controlPanelView_SO = (ControlPanelView_SO)view_SO;
    }  
}

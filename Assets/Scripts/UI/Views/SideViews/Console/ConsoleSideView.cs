using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleSideView : SideView
{
    [SerializeField]
    private ConsoleSideView_SO _consoleSideView_SO;

    private void Start()
    {
        _consoleSideView_SO = (ConsoleSideView_SO)_sideView_SO;
    }
}

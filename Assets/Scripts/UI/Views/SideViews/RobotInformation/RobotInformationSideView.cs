using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotInformationSideView : SideView
{
    public Button HideButtonMotorInformation;

    [SerializeField]
    private RobotInformationSideView_SO _robotInformationSideView_SO;

    private void OnEnable()
    {
        _robotInformationSideView_SO = (RobotInformationSideView_SO)_sideView_SO;
    }

    public override void Init()
    {
        HideButtonMotorInformation.onClick.AddListener(Hide);
        base.Init();
    }
}

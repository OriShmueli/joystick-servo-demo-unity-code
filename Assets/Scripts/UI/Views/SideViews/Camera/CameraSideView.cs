using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSideView : SideView
{
    public Button increaseSize;
    public Button decreaseSize;
    public RawImage rawImage;

    [SerializeField]
    private CameraSideView_SO _cameraSideView_SO;

    private void Start()
    {
        _cameraSideView_SO = (CameraSideView_SO)_sideView_SO;
    }

    //public override void Init()
    //{
    //    //ShowHideButton.onClick.AddListener(() => {
    //    //    if (IsShowen)
    //    //    {
    //    //        ViewsManager.HideView<CameraView>();
    //    //    }
    //    //    else
    //    //    {
    //    //        ViewsManager.ShowView<CameraView>();
    //    //    }
    //    //});
    //}
}

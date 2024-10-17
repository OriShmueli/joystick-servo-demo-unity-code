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

    public override void Init()
    {
        base.Init();
        _cameraSideView_SO = (CameraSideView_SO)_sideView_SO;
        _cameraSideView_SO.onRequestCameraRawImage += _cameraSideView_SO_onRequestCameraRawImage;
    }

    private void _cameraSideView_SO_onRequestCameraRawImage(object sender, System.EventArgs e)
    {
        _cameraSideView_SO.OnCameraRawImageChanged(rawImage);
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

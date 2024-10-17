using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CameraSideView_SO", menuName = "ScriptableObjects/UI/Views/Side Views/Camera")]
public class CameraSideView_SO : SideView_SO
{
    public event EventHandler onRequestCameraRawImage;

    public void OnRequestCameraRawImage()
    {
        onRequestCameraRawImage?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler<RawImage> onCameraRawImageChanged;

    public void OnCameraRawImageChanged(RawImage newRawImage)
    {
        onCameraRawImageChanged?.Invoke(this, newRawImage);
    }
}
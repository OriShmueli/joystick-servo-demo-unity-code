using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraView : SideView
{
    public Button increaseSize;
    public Button decreaseSize;
    public RawImage rawImage;

    public override void Init()
    {
        ShowHideButton.onClick.AddListener(() => {
            if (IsShowen)
            {
                ViewsManager.HideView<CameraView>();
            }
            else
            {
                ViewsManager.ShowView<CameraView>();
            }
        });
    }

    public override void Show()
    {
        transform.position = new Vector3(0, transform.position.y, 0); //x = 300
        base.Show();
    }

    public override void Hide()
    {
        transform.position = new Vector3(-538, transform.position.y, 0);
        base.Hide();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SideView : View
{
    public Button ShowHideButton;
    public Sprite ShowSprite;
    public Sprite HideSprite;
    public bool IsShowen = false;

    public override void Init()
    {
        
    }

    public override void Show()
    {
        IsShowen = true;
        ShowHideButton.image.sprite = HideSprite;
        Debug.Log("Side View");
    }

    public override void Hide()
    {
        ShowHideButton.image.sprite = ShowSprite;
        IsShowen = false;
    }
}

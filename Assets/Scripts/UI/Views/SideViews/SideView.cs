using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SideView : View
{
    //public Button ShowHideButton;
    //public Sprite ShowSprite;
    //public Sprite HideSprite;
    //i dont see a reson to use this 5/11/2023

    public Button ShowButton;
    public Button HideButton;

    [SerializeField]
    private bool IsSideViewShown = false;

    //[SerializeField]
    protected SideView_SO _sideView_SO;

    //private void OnEnable()
    //{
    //    Debug.Log("OnEnableSideView");
    //}   

    private void OnDisable()
    {
        _sideView_SO.OnSideViewShow_RequestEvent -= _sideView_SO_ShowSideViewEvent;
        _sideView_SO.OnSideViewHide_RequestEvent -= _sideView_SO_HideSideViewEvent;
        _sideView_SO.SideViewState -= _sideView_SO_SideViewState;
    }

    private void _sideView_SO_HideSideViewEvent()
    {
        //Debug.Log("phone mode hide side view");
        if (IsSideViewShown)
        {            
            Hide();
        }
    }

    private void _sideView_SO_ShowSideViewEvent()
    {
        if (!IsSideViewShown)
        {
            Show();
        }
    }

    private bool _sideView_SO_SideViewState()
    {
        return IsSideViewShown;
    }

    public override void Init()
    {
        _sideView_SO = (SideView_SO)view_SO;
        _sideView_SO.OnSideViewShow_RequestEvent += _sideView_SO_ShowSideViewEvent;
        _sideView_SO.OnSideViewHide_RequestEvent += _sideView_SO_HideSideViewEvent;
        _sideView_SO.SideViewState += _sideView_SO_SideViewState;
        ShowButton.gameObject.SetActive(false);
        HideButton.gameObject.SetActive(true);
        
        //No need for this. ViewManager calling the show of all classes
        ShowButton.onClick.AddListener(Show); //Show();
        HideButton.onClick.AddListener(Hide); //Hide(); //This also works but for all of them: ViewsManager.HideView<SideView>();
        _sideView_SO.InitializeSubComponents();
    }

    public override void Show() //Show is called first on the awake (awake befor enable)
    {
        
        IsSideViewShown = true;
        GetComponent<CanvasGroup>().alpha = 1.0f;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        //ShowHideButton.image.sprite = HideSprite;

        try
        {
            ShowButton.gameObject.SetActive(false);
            HideButton.gameObject.SetActive(true);
        }
        catch(NullReferenceException nre)
        {
            Debug.LogError(nre.Message);
        }

        if(_sideView_SO != null)
        {
            _sideView_SO.TriggerSideViewShowEvent();
            Debug.Log("showing side view");
        }
        else
        {
            Debug.Log("Side View is null");
        }        

        //Debug.Log("Side View");
        //Debug.Log("Calling SideView show");
    }

    public override void Hide()
    {
        Debug.Log("[Side View] Hide(): hiding view");
        GetComponent<CanvasGroup>().alpha = 0f;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        IsSideViewShown = false;
        try
        {
            ShowButton.gameObject.SetActive(true);
            HideButton.gameObject.SetActive(false);
        }
        catch (NullReferenceException nre)
        {
            Debug.LogError(nre.Message);
        }
        //Debug.Log("Calling SideView hide");
       
        _sideView_SO.TriggerSideViewHideEvent();
       
        //ShowHideButton.image.sprite = ShowSprite;

    }

    //public void HideOrShowAllItems(GameObject[] items, bool showState)
    //{
    //    for(int i = 0; i < items.Length; i++)
    //    {
    //        items[i].gameObject.SetActive(showState);
    //    }
    //}
}

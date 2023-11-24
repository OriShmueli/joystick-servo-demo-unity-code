using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DialogView : View, IPointerDownHandler
{
    public Button YesButton;
    public Button NoButton;
    public Button BackButton;
    public TextMeshProUGUI TitleText;    
    public TextMeshProUGUI MessageText;
    private DialogView_SO _dialogView_SO;  
    //public MenuDialogView_SO MenuDialogView_SO;
    //public StopProgramDialogView_SO StopProgramDialogView_SO;

    private DialogView_SO currentDialogView;

    public override void Init()
    {
        _dialogView_SO = (DialogView_SO)view_SO;
        _dialogView_SO.ShowDialogViewEvent += _dialogView_SO_ShowDialogViewEvent;
        //_dialogView_SO.ShowDialogView += _dialogView_SO_ShowDialogView;
        YesButton.onClick.AddListener(_onYesButtonClicked);
        NoButton.onClick.AddListener(_onNoButtonClicked);        
        BackButton.onClick.AddListener(_backButton);        
    }

    private void _dialogView_SO_ShowDialogViewEvent(DialogView_SO obj)
    {
        MessageText.text = obj.MainMessage;
        TitleText.text = obj.Title;
        currentDialogView = obj;
        Show();
        //ViewsManager.ShowView<DialogView>();
    }

    public override void Show()
    {
        GetComponent<CanvasGroup>().alpha = 1.0f;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public override void Hide()
    {
        GetComponent<CanvasGroup>().alpha = 0f;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    private void _onYesButtonClicked()
    {
        if(currentDialogView != null)
        {
            currentDialogView?.OnYesButtonClicked();
        }
    }

    private void _onNoButtonClicked()
    {
        if (currentDialogView != null)
        {
            currentDialogView?.OnNoButtonClicked();
        }
    }

    //private void _dialogView_SO_ShowDialogView(string arg1, string arg2)
    //{
    //    MessageText.text = arg1;
    //    TitleText.text = arg2;
    //}

    private void OnDisable()
    {
        _dialogView_SO.ShowDialogViewEvent -= _dialogView_SO_ShowDialogViewEvent;

        //_dialogView_SO.ShowDialogView -= _dialogView_SO_ShowDialogView;
        BackButton?.onClick.RemoveListener(_backButton);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject == gameObject)
        {
            //ViewsManager.HideView<DialogView>();
            Hide();
        }
    }

    private void _backButton()
    {
        Hide();
        //ViewsManager.HideView<DialogView>();
    }
}
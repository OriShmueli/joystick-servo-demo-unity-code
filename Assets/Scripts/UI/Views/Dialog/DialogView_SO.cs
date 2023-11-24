using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogView_SO", menuName = "ScriptableObjects/UI/Views/Dialog View")]
public class DialogView_SO : View_SO
{
    [SerializeField] private string mainMessage;
    [SerializeField] private string title;

    public string MainMessage => mainMessage;
    public string Title => title;

    public event Action OnYesButtonClickedEvent;
    public event Action OnNoButtonClickedEvent;

    public event Action<DialogView_SO> ShowDialogViewEvent;

    public void OnShowDialogView(DialogView_SO dialogView_SO)
    {
        ShowDialogViewEvent?.Invoke(dialogView_SO);
    }

    public void OnYesButtonClicked()
    {
        OnYesButtonClickedEvent?.Invoke();
    }

    public void OnNoButtonClicked()
    {
        OnNoButtonClickedEvent?.Invoke();
    }

    //public event Action<string, string> ShowDialogView;

    //public void OnShowDialogView(string mainMessage, string title)
    //{
    //    ShowDialogView?.Invoke(mainMessage, title);
    //}
}

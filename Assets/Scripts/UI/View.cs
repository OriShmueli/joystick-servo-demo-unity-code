using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    public bool IsViewActivated = false;
    public View_SO view_SO;

    private void OnEnable()
    {
        view_SO.ViewState += View_SO_ViewState;
    }

    private void OnDisable()
    {
        view_SO.ViewState -= View_SO_ViewState;
    }

    private bool View_SO_ViewState()
    {
        return IsViewActivated;
    }

    public abstract void Init();

    public virtual void Hide()
    {
        GetComponent<CanvasGroup>().alpha = 0f;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //gameObject.SetActive(false);
    }

    public virtual void Show()
    {
        GetComponent<CanvasGroup>().alpha = 1.0f;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        //gameObject.SetActive(true);
    }

    public void TriggerViewShowState()
    {
        view_SO.TriggerViewShowEvent();
        IsViewActivated = true;
        Show();
    }

    public void TriggerViewHideState()
    {
        view_SO.TriggerViewHideEvent();
        IsViewActivated = false;
        Hide();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    public Button TabButton;
    //public List<CanvasGroup> UIComponenets;

    public virtual void Init()
    {

    }

    public virtual void HideContent()
    {
        GetComponent<CanvasGroup>().alpha = 0f;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        //if(UIComponenets != null)
        //{
        //    foreach (CanvasGroup item in UIComponenets)
        //    {
        //        item.alpha = 0f;
        //        item.blocksRaycasts = false;
        //    }           
        //}

        //Content.SetActive(false); //delete this
    }

    public virtual void ShowContent()
    {
        GetComponent<CanvasGroup>().alpha = 1.0f;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        //if (UIComponenets != null)
        //{
        //    foreach (CanvasGroup item in UIComponenets)
        //    {
        //        item.alpha = 1.0f;
        //        item.blocksRaycasts = true;
        //    }
        //}

        //Content.SetActive(true); //delete this
    }
}

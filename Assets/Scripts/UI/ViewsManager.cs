using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewsManager : MonoBehaviour
{
    public List<View> StartingView;
    public List<View> Views;
    public static ViewsManager s_instance;

    public Canvas MenuCanvas;
    public Canvas AppCanvas;

    private void Awake()
    {
        if(s_instance == null)
        {
            s_instance = this;
        }


        //s_instance.MenuCanvas.gameObject.SetActive(false);
        //s_instance.AppCanvas.gameObject.SetActive(true);


        if (s_instance.Views.Count > 0)
        {
            for (int i = 0; i < s_instance.Views.Count; i++)
            {
                s_instance.Views[i].Init();
            }
        }

        if (s_instance.StartingView.Count > 0)
        {
            for (int i = 0; i < s_instance.Views.Count; i++)
            {
                //StartingView[i].Show();
                s_instance.Views[i].TriggerViewHideState();
            }
        }

        if (s_instance.StartingView.Count > 0)
        {
            for (int i = 0; i < s_instance.StartingView.Count; i++)
            {
                //StartingView[i].Show();
                s_instance.StartingView[i].TriggerViewShowState();
            }
        }
    }

    public static void ShowMenuCanvas()
    {
        s_instance.MenuCanvas.gameObject.SetActive(true);
        s_instance.AppCanvas.gameObject.SetActive(false);
    }

    //public static void ShowApplicationCanvas()
    //{
        
    //}

    public static void ShowView<T>() where T : View
    {
        for (int i = 0; i < s_instance.Views.Count; i++)
        {
            if (s_instance.Views[i] is T t)
            {
                t.TriggerViewShowState();
            }
        }
    }

    public static void HideView<T>() where T : View
    {
        for (int i = 0; i < s_instance.Views.Count; i++)
        {
            if (s_instance.Views[i] is T t)
            {
                t.TriggerViewHideState();
            }
        }
    }

    public static T GetView<T>() where T : View
    {
        for (int i = 0; i < s_instance.Views.Count; i++)
        {
            if(s_instance.Views[i] is T t)
            {
                return (T)s_instance.Views[i];
            }
        }

        return null;
    }
}

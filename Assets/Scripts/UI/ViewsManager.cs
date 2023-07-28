using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewsManager : MonoBehaviour
{
    public List<View> StartingView;
    public List<View> Views;
    public static ViewsManager s_instance;

    private void OnEnable()
    {
        if(s_instance == null)
        {
            s_instance = this;
        }

        if(Views.Count > 0) { 
            for(int i = 0; i < Views.Count; i++)
            {
                Views[i].Init();
            }
        }

        if(StartingView.Count > 0)
        {
            for(int i = 0; i < StartingView.Count; i++)
            {
                StartingView[i].Show();
            }
        }
    }

    public static void ShowView<T>() where T : View
    {
        for (int i = 0; i < s_instance.Views.Count; i++)
        {
            if (s_instance.Views[i] is T t)
            {
                t.Show();
            }
        }
    }

    public static void HideView<T>() where T : View
    {
        for (int i = 0; i < s_instance.Views.Count; i++)
        {
            if (s_instance.Views[i] is T t)
            {
                t.Hide();
            }
        }
    }

    private void OnDisable()
    {
        
    }
}

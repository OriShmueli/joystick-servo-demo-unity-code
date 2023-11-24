using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabsSystem : MonoBehaviour
{
    //public List<Button> TabButton;
    public List<Tab> Tabs;
    public Color EnabledButtonColor;
    private Tab CurrentTab; //This is all ways set to the first tab. It will be assign to the local one.

    private void OnEnable()
    {
        if (Tabs == null)
        {
            Debug.Log("Error there are no tabs");
            return;
        }

        //for (int i = 0; i < Tabs.Count; i++)
        //{
        //    Tabs[i].TabButton.onClick.AddListener(delegate { OnTabEnter(Tabs[i]); });
        //}

        for (int i = 0; i < Tabs.Count; i++)
        {
            Tabs[i].GetComponent<Image>().raycastTarget = false;
            Tabs[i].HideContent();
        }

        Tabs[0].TabButton.onClick.AddListener(delegate { OnTabEnter(Tabs[0]); });
        Tabs[1].TabButton.onClick.AddListener(delegate { OnTabEnter(Tabs[1]); });
        Tabs[2].TabButton.onClick.AddListener(delegate { OnTabEnter(Tabs[2]); });

        CurrentTab = Tabs[0];
        OnTabEnter(Tabs[0]);

        //for (int i = 0; i < TabButton.Count; i++)
        //{
        //     _DisableButtonVisual(TabButton[i]);
        //}

        //_EnableButtonVisual(TabButton[0]);
    }

    private void _disableButtonTabVisual(Button button)
    {
        button.enabled = false;
        button.GetComponent<Image>().color = Color.clear;
    }

    private void _enableButtonTabVisual(Button button, Color color)
    {
        button.enabled = true;
        button.GetComponent<Image>().color = color;
    }

    //public void Subscribe(Tab tabButton)
    //{
    //    if (tabButton == null)
    //    {
    //        Tabs = new List<Tab>();
    //    }

    //    Tabs.Add(tabButton);
    //}

    public void OnTabEnter(Tab tab)
    {
        
        for (int i = 0; i < Tabs.Count; i++)
        {
            if(Tabs[i] == tab)
            {
                if(CurrentTab != null)
                {
                    CurrentTab.HideContent();
                    
                }
                CurrentTab = tab;
                CurrentTab.ShowContent();
                
                _disableButtonTabVisual(Tabs[i].TabButton);
                
            }
            else
            {
                _enableButtonTabVisual(Tabs[i].TabButton, EnabledButtonColor);
            }
        }
    }

    public void OnTabExit(Tab tab)
    {

    }

    public void OnTabSelected(Tab tab)
    {

    }
}

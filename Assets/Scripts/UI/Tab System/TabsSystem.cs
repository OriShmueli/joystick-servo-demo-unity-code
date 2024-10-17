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
    //[SerializeField] private SettingsSideView_SO _settingsSideView_SO;
    [SerializeField] private SideView_SO _sideView_SO;

    private void OnEnable()
    {
        _sideView_SO.onInitializeSubPanels += _sideView_SO_onInitializeSubPanels;
    }

    private void OnDisable()
    {
        _sideView_SO.onInitializeSubPanels -= _sideView_SO_onInitializeSubPanels;
    }

    private void _sideView_SO_onInitializeSubPanels(object sender, System.EventArgs e)
    {

        if (Tabs == null)
        {
            Debug.Log("Error there are no tabs");
            return;
        }

        for (int i = 0; i < Tabs.Count; i++)
        {
            Tabs[i].GetComponent<Image>().raycastTarget = false;
            Tabs[i].HideContent();
            int copy = i;
            Tabs[i].TabButton.onClick.AddListener(delegate { OnTabEnter(Tabs[copy]); });
        }

        CurrentTab = Tabs[0];
        CurrentTab.Init();
        OnTabEnter(Tabs[0]);
    }

    private void _disableButtonTabVisual(Button button, Color color)
    {
        button.enabled = false;
        button.GetComponent<Image>().color = color; //Color.clear
    }

    private void _enableButtonTabVisual(Button button, Color color)
    {
        button.enabled = true;
        button.GetComponent<Image>().color = Color.clear; //color
    }

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
                
                _disableButtonTabVisual(Tabs[i].TabButton, EnabledButtonColor);                
            }
            else
            {
                _enableButtonTabVisual(Tabs[i].TabButton, EnabledButtonColor);
            }
        }
    }

    //public void OnTabExit(Tab tab)
    //{

    //}

    //public void OnTabSelected(Tab tab)
    //{

    //}
}

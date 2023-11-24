using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingView : View
{
    public Image ProgressBar;
    public TextMeshProUGUI LoadingText;
    private LoadingView_SO _loadingView_SO;

    private IProgress<int> _progress = null;

    public override void Init()
    {
        _loadingView_SO = (LoadingView_SO)view_SO;
        _loadingView_SO.OnLoadingRequest += _loadingView_SO_OnLoadingRequest;
        _loadingView_SO.OnProgress += _loadingView_SO_OnProgress;
    }

    private void _loadingView_SO_OnProgress(Dictionary<IProgress<int>, string> obj)
    {
        for (int i = 0; i < obj.Count; i++)
        {
            
        }
    }

    private void _loadingView_SO_OnLoadingRequest(LoadingView_SO obj)
    {
        
    }

    public override void Show()
    {
        ProgressBar.fillAmount = 0;
        base.Show();
    }

    private void OnDisable()
    {
        _loadingView_SO.OnLoadingRequest -= _loadingView_SO_OnLoadingRequest;
    }
}

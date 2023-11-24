using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LoadingView_SO", menuName = "ScriptableObjects/UI/Views/Loading View")]
public class LoadingView_SO : View_SO
{
    public event Action<Dictionary<IProgress<int>, string>> OnProgress;
    public event Action<LoadingView_SO> OnLoadingRequest;

    public void OnLoading(LoadingView_SO loadingView_SO)
    {
        OnLoadingRequest?.Invoke(loadingView_SO);
    }

    public void TriggerProgress(Dictionary<IProgress<int>, string> progress)
    {
        OnProgress?.Invoke(progress);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ConsoleSideView_SO", menuName = "ScriptableObjects/UI/Views/Side Views/Console")]
public class ConsoleSideView_SO : SideView_SO
{
    [SerializeField] private new string name;
    [SerializeField] private Color error;
    [SerializeField] private Color green;
    [SerializeField] private Color yellow;
    [SerializeField] private Color normal;
    [SerializeField] private Color warning;
    
    public string Name => name;
    public Color Error => error;
    public Color Green => green;
    public Color Yellow => yellow;
    public Color Normal => normal;
    public Color Warning => warning;

    //unessery
    public event EventHandler<WriteToConsole> onConsoleWrite;

    public void WriteToConsole(WriteToConsole writeToConsole)
    {
        onConsoleWrite?.Invoke(this, writeToConsole);
        
    }
}
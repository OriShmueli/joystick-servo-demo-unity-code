using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleSideView : SideView
{
    //unnessery to make [SerializeField] //we have in [View: class] a public view_SO. 
    [SerializeField] private ConsoleSideView_SO _consoleSideView_SO;

    public TMPro.TextMeshProUGUI consoleText;
    
    private void Start()
    {
        
    }

    public override void Init()
    {
        base.Init();
        _consoleSideView_SO.onConsoleWrite += _consoleSideView_SO_onConsoleWrite;
        _consoleSideView_SO = (ConsoleSideView_SO)_sideView_SO;
    }

    private void _consoleSideView_SO_onConsoleWrite(object sender, WriteToConsole writeToConsole)
    {
        switch (writeToConsole.consoleColor)
        {
            case ConsoleColor.Error:
                _writeToConsole(_consoleSideView_SO.Error, writeToConsole);
                break;
            case ConsoleColor.Green:
                _writeToConsole(_consoleSideView_SO.Green, writeToConsole);
                break;
            case ConsoleColor.Yellow:
                _writeToConsole(_consoleSideView_SO.Yellow, writeToConsole);
                break;
            case ConsoleColor.Warning:
                _writeToConsole(_consoleSideView_SO.Warning, writeToConsole);
                break;
            case ConsoleColor.Normal:
                _writeToConsole(_consoleSideView_SO.Normal, writeToConsole);
                break;
        }
    }

    private void _writeToConsole(Color color, WriteToConsole writeToConsole)
    {
        consoleText.text = consoleText.text + "\n <color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + writeToConsole.message + "</color>";
    }

    private void OnDisable()
    {
        _consoleSideView_SO.onConsoleWrite -= _consoleSideView_SO_onConsoleWrite;
    }
}

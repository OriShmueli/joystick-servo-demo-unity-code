using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsolePanel : MonoBehaviour
{
    public TMPro.TextMeshProUGUI consoleText;
    [SerializeField] private ConsoleSideView_SO _consoleSideView_SO;

    private void Start()
    {
        ConsoleWriteEvent.OnWriteToConsole += ConsoleWriteEvent_OnWriteToConsole;
    }

    private void ConsoleWriteEvent_OnWriteToConsole(object sender, WriteToConsole writeToConsole)
    {
        _writeToConsole(writeToConsole);
    }

    protected void _writeToConsole(WriteToConsole writeToConsole) {
        
        switch (writeToConsole.consoleColor)
        {
            case ConsoleColor.Error:
                _writeToTextComponent(_consoleSideView_SO.Error, writeToConsole);
                break;
            case ConsoleColor.Green:
                _writeToTextComponent(_consoleSideView_SO.Green, writeToConsole);
                break;
            case ConsoleColor.Yellow:
                _writeToTextComponent(_consoleSideView_SO.Yellow, writeToConsole);
                break;
            case ConsoleColor.Warning:
                _writeToTextComponent(_consoleSideView_SO.Warning, writeToConsole);
                break;
            case ConsoleColor.Normal:
                _writeToTextComponent(_consoleSideView_SO.Normal, writeToConsole);
                break;
        }

    }

    private void _writeToTextComponent(Color color, WriteToConsole writeToConsole)
    {
        consoleText.text = consoleText.text + "\n <color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + writeToConsole.message + "</color>";
    }

}

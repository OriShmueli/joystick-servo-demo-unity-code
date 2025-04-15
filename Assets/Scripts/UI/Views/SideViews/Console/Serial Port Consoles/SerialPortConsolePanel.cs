using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerialPortConsolePanel : ConsolePanel
{
    //[SerializeField] private ScrollRect scrollRect;

    //private void Awake()
    //{
    //    scrollRect.verticalNormalizedPosition = 0.5f;
    //}

    public void ReceiveMessage(SerialPortConsoleMessage newMessage)
    {
        _writeToConsole(newMessage);
    }
}

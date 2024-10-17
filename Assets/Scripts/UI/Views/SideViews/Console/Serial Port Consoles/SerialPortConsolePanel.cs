using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialPortConsolePanel : ConsolePanel
{
    public void ReceiveMessage(SerialPortConsoleMessage newMessage)
    {
        _writeToConsole(newMessage);
    }
}

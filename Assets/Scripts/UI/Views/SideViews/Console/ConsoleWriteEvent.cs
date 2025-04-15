using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsoleColor
{
    Error,
    Green,
    Yellow,
    Warning,
    Normal
}

public class WriteToConsole
{
    public string message { get; set; }
    public ConsoleColor consoleColor { get; set; }
}

public static class ConsoleWriteEvent //write to all console (bluetooth, serial port, server)
{
    public static event EventHandler<WriteToConsole> OnWriteToConsole;
    public static event EventHandler<List<SettingsView_Local_SerialPort>> OnInitConsole;

    public static void WriteMessage(string newMessage, ConsoleColor newConsoleColor)
    {
        WriteToConsole writeToConsole = new WriteToConsole();
        writeToConsole.message = newMessage;
        writeToConsole.consoleColor = newConsoleColor;

        OnWriteToConsole?.Invoke(null, writeToConsole);
    }

    public static void WriteMessage(string newMessage)
    {
        WriteMessage(newMessage, ConsoleColor.Normal);
    }
    
    public static void InitConsole(List<SettingsView_Local_SerialPort> _availableSerialPorts)
    {
        OnInitConsole?.Invoke(null, _availableSerialPorts);
    }
}

public class SerialPortConsoleMessage : WriteToConsole
{
    public SettingsView_Local_SerialPort id { get; set; }
}

public static class SerialPortConsole //based on serial port ID.
{
    public static event EventHandler<SerialPortConsoleMessage> OnWriteToConsole;
    public static void ConsoleMessage(string newMessage, ConsoleColor newConsoleColor, SettingsView_Local_SerialPort id)
    {
        SerialPortConsoleMessage writeToConsole = new SerialPortConsoleMessage();
        writeToConsole.message = newMessage;
        writeToConsole.consoleColor = newConsoleColor;
        writeToConsole.id = id;
        OnWriteToConsole?.Invoke(null, writeToConsole);
    }

    public static void ConsoleMessage(string newMessage, SettingsView_Local_SerialPort id)
    {
        ConsoleMessage(newMessage, ConsoleColor.Normal, id);
    }

    public static void ConsoleErrorMessage(string newMessage, SettingsView_Local_SerialPort id)
    {
        ConsoleMessage(newMessage, ConsoleColor.Error, id);
    }

    public static void ConsoleSuccessMessage(string newMessage, SettingsView_Local_SerialPort id)
    {
        ConsoleMessage(newMessage, ConsoleColor.Green, id);
    }
}

public class BluetoothConsole : WriteToConsole
{

}

public class ServerConsole : WriteToConsole
{

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO.Ports;
using System.Linq;
using System;

public class SerialPortConsoleTab : Tab
{
    private Dictionary<SettingsView_Local_SerialPort, SerialPortConsolePanel>
        _serialPortsNameAndPanels = new Dictionary<SettingsView_Local_SerialPort, SerialPortConsolePanel>();
    public TMPro.TMP_Dropdown SerialPortsTMPDropdown;
    [SerializeField] private Transform _consolesParentTransform;
    [SerializeField] private SerialPortConsolePanel _serialPortConsolePanelPrefab;
    private SerialPortConsolePanel _current;

    private void OnEnable() //all tabs initialized and then. initialize console
    {//awake -> tabs(careating serial ports and then wating for event -> onEnable()
        ConsoleWriteEvent.OnInitConsole += ConsoleWriteEvent_OnInitConsole;
        SerialPortConsole.OnWriteToConsole += SerialPortConsole_OnWriteToConsole;
    }

    private void SerialPortConsole_OnWriteToConsole(object sender, SerialPortConsoleMessage newSerialPortConsoleMessage)
    {
        Debug.Log(_serialPortsNameAndPanels.Keys.Count);
        SerialPortConsolePanel consolePanel = _serialPortsNameAndPanels[newSerialPortConsoleMessage.id];
        consolePanel.ReceiveMessage(newSerialPortConsoleMessage);        
    }

    private void ConsoleWriteEvent_OnInitConsole(object sender, List<SettingsView_Local_SerialPort> SettingsView_Local_SerialPort_List)
    {
        Debug.Log("init console");
        for (int i = 0; i < SettingsView_Local_SerialPort_List.Count; i++)
        {
            SerialPortConsolePanel newPanel = Instantiate(_serialPortConsolePanelPrefab, _consolesParentTransform);
            _hide(newPanel);
            _serialPortsNameAndPanels.Add(SettingsView_Local_SerialPort_List[i], newPanel);
        }

        _current = _serialPortsNameAndPanels[SettingsView_Local_SerialPort_List[0]];
        _show(_current);

        SerialPortsTMPDropdown.AddOptions(new List<string>(SerialPort.GetPortNames()));

        SerialPortsTMPDropdown.onValueChanged.AddListener(delegate
        {
            int index = SerialPortsTMPDropdown.value;
            string portName = SerialPortsTMPDropdown.options[index].text;
            SettingsView_Local_SerialPort[] keys = _serialPortsNameAndPanels.Keys.Select(x => x).ToArray();
            
            if (keys.Length > 0)
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys[i].PortName == portName)
                    {
                        _changeSerialPortPanel(_serialPortsNameAndPanels[keys[i]]);
                        break;
                    }
                }
            }
        });
    }

    private void _changeSerialPortPanel(SerialPortConsolePanel newSerialPortConsolePanel)
    {
        if (newSerialPortConsolePanel != _current)
        {
            _hide(_current);
            _current = newSerialPortConsolePanel;
            _show(_current);
        }
        else
        {
            return;
        }
    }

    private void _hide(SerialPortConsolePanel newSerialPortConsolePanel)
    {
        newSerialPortConsolePanel.GetComponent<CanvasGroup>().alpha = 0f;
        newSerialPortConsolePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        newSerialPortConsolePanel.GetComponent<CanvasGroup>().interactable = false;
    }

    private void _show(SerialPortConsolePanel newSerialPortConsolePanel)
    {
        newSerialPortConsolePanel.GetComponent<CanvasGroup>().alpha = 1f;
        newSerialPortConsolePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        newSerialPortConsolePanel.GetComponent<CanvasGroup>().interactable = true;
    }

    public override void Init()
    {
                
    }
}

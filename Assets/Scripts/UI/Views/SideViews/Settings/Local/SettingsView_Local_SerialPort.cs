using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsView_Local_SerialPort : MonoBehaviour
{

    [SerializeField] private Button _connectButton;
    [SerializeField] private Button _disconnectButton;
    [SerializeField] private TMP_Dropdown _portsDropDown;
    [SerializeField] private TMP_Dropdown _baudRateDropDown;
    [SerializeField] private TextMeshProUGUI _connectionStatusText;
    [SerializeField] private List<string> _baudRates;
    [SerializeField] private Color _availableForConnectionColor; //yello wating to first connection
    [SerializeField] private Color _connectedColor; //yello wating to first connection
    [SerializeField] private Color _disconnectedColor; //yello wating to first connection
    [SerializeField] private Color _defaultColor; //yello wating to first connection
    [SerializeField] private ConsoleSideView_SO _consoleSideView_SO; //can delete im using static event for this
    //private SerialPort _currentSerialPort;
    
    private string _portName = string.Empty;
    public string PortName => _portName;

    public void Init(string name)
    {
        _portName = name;
        _connectionStatusText.color = _availableForConnectionColor;
        _connectionStatusText.text = "Available";

        //TODO: put this in json settings
        _baudRates = new List<string>();
        _baudRates.Add("9600");
        _baudRates.Add("57600");
        _baudRates.Add("115200");
        _baudRates.Add("1000000");

        //set baud rates to the dropdown
        _baudRateDropDown.options.Clear();
        _baudRateDropDown.AddOptions(_baudRates);

        //set available serial port names to dropdown
        _portsDropDown.options.Clear();
        List<string> ports = new List<string>(SerialPort.GetPortNames());
        _portsDropDown.AddOptions(ports);
        for(int i = 0; i < ports.Count; i++)
        {
            if(name == ports[i])
            {
                _portsDropDown.value = i;
                break;
            }
        }

        //set up new serial posrt instance, and assign default values to it. 
        int index = _baudRateDropDown.value;
        SerialPortManager.AddNewSerialPortConnection(this, name, int.Parse(_baudRateDropDown.options[index].text));
        
        //events to update serialport instance when the baud rate / serial port changes.
        _baudRateDropDown.onValueChanged.AddListener(delegate {
            int index = _baudRateDropDown.value;
            SerialPortManager.SetNewSerialPortBaudRate(this, int.Parse(_baudRateDropDown.options[index].text));
        });

        _portsDropDown.onValueChanged.AddListener(delegate {
            int index = _portsDropDown.value;
            SerialPortManager.SetNewSerialPortName(this, _portsDropDown.options[index].text);
            _portName = _portsDropDown.options[index].text;
        });

        _disconnectButton.interactable = false;

        _connectButton.onClick.AddListener(_connectToSerialPortButton);
        _disconnectButton.onClick.AddListener(_disconnectFromSerialPortButton);
        

    }

    private async void _connectToSerialPortButton()
    {
        _connectButton.interactable = false;
        _portsDropDown.enabled = false;
        _baudRateDropDown.enabled = false;

        _connectionStatusText.text = "Connecting...";
        _connectionStatusText.color = _defaultColor;
        if (await SerialPortManager.ConnectToSerialPort(this))
        {
            _connectionStatusText.text = "Connected";
            _connectionStatusText.color = _connectedColor;
            _disconnectButton.interactable = true;
        }
        else
        {
            _portsDropDown.enabled = true;
            _baudRateDropDown.enabled = true;
            _connectButton.interactable = true;
            //send connection error event
            _connectionStatusText.text = "Error Connecting";
            _connectionStatusText.color = _disconnectedColor;
        }
    }

    private void _disconnectFromSerialPortButton()
    {

    }
}
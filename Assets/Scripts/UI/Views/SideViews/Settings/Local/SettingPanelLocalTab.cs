using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class SettingPanelLocalTab : Tab
{
    [SerializeField] private CameraSideView_SO _cameraSideView_SO;

    private List<SettingsView_Local_SerialPort> _availableSerialPorts = new List<SettingsView_Local_SerialPort>();
    [SerializeField] private Transform _serialPortPanelPrefab;
    [SerializeField] private Transform _serialPortPanelContainer;

    [SerializeField] private SettingsView_Local_Cameras _camerasPanel;

    public override void Init()
    {
        _cameraSideView_SO.onCameraRawImageChanged += _cameraSideView_SO_onCameraRawImageChanged;
        _camerasPanel.Init();
        for (int i = 0; i < SerialPort.GetPortNames().Length; i++)
        {
            Transform newSerialPortPanelTransform = Instantiate(_serialPortPanelPrefab, _serialPortPanelContainer);
            SettingsView_Local_SerialPort newSerialPortPanel;
            if (newSerialPortPanelTransform.GetComponent<SettingsView_Local_SerialPort>() != null)
            {
                newSerialPortPanel = newSerialPortPanelTransform.GetComponent<SettingsView_Local_SerialPort>();
                newSerialPortPanel.Init(SerialPort.GetPortNames()[i]);
                _availableSerialPorts.Add(newSerialPortPanel);
            }
            else
            {
                Debug.Log("newSerialPortPanelTransform.GetComponent<SettingsView_Local_SerialPort>() == null");
                //continue;
            }
        }
    }

    private void _cameraSideView_SO_onCameraRawImageChanged(object sender, UnityEngine.UI.RawImage e)
    {
        //TODO: Add logic of camera inside camera class
        //e = the ubs and every thisg
        _camerasPanel.UpdateImage(e);
    }

    private void Start()
    {
        _cameraSideView_SO.OnRequestCameraRawImage();
        //send to console
        ConsoleWriteEvent.InitConsole(_availableSerialPorts);


        //init is calling befor start. start here conversation with camera. 
        //start -> calling camera -> event to here
        //settings local tab
        //  -> local camera class
        //  -> local serial port class 
        //  -> local bluetooth class
    }

    private void OnDisable()
    {
        _cameraSideView_SO.onCameraRawImageChanged -= _cameraSideView_SO_onCameraRawImageChanged;
    }

    public override void ShowContent()
    {   
        base.ShowContent();
    }

    public override void HideContent()
    {
        base.HideContent();
    }
}

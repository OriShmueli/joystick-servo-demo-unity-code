using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO.Ports;
using System.Management;
using UnityEngine.InputSystem.HID;
using UnityEditor.Hardware;
using System;
using System.Linq;
using System.Threading.Tasks;

public class SettingsSideView : SideView
{
    [SerializeField]
    private SettingsSideView_SO _settingsSideView_SO;

    public Button ConnectButton;
    public Button DisconnectButton;
    public Button StartCamera;
    public Button StopCamera;
    //public Button HideButton;
    //public Button ShowButton;

    public GameObject CamerasDropDown;
    public GameObject PortsDropDown;
    public GameObject BaudRateDropDown;

    public TextMeshProUGUI ConnectionStatus;

    private TMP_Dropdown _camerasDropDown;
    private TMP_Dropdown _portsDropDown;
    private TMP_Dropdown _baudRateDropDown;

    public RawImage rawImage;
    
    private WebCamTexture _camTexture;
    private string _serilaPortName = "";
    private int _baudRate = 0;
    
    private bool _isCameraconnected = false;
    private bool _isSerialPortConnected = false;

    private string _currentDevice = "null";
    
    public static Transform showPosition;

    public override void Init()
    {
        
        ////getting the panel position for the first time. 
        ////TODO: for camera scripts
        //ConnectButton.enabled = false;
        //DisconnectButton.enabled = false;
        //StartCamera.enabled = false;
        //StopCamera.enabled = false;

        ////TODO: for camera scripts
        //_camerasDropDown = CamerasDropDown.GetComponent<TMP_Dropdown>();
        //_portsDropDown = PortsDropDown.GetComponent<TMP_Dropdown>();
        //_baudRateDropDown = BaudRateDropDown.GetComponent<TMP_Dropdown>();

        //_chackCameras(); //TODO: undo this

        //_camerasDropDown.onValueChanged.AddListener(delegate { _onCameraDropDownSelected(_camerasDropDown); });

        //_CheckSerialPort();

        //_portsDropDown.onValueChanged.AddListener(delegate { _onSerialPortDropDownSelected(_camerasDropDown); });

        //_onBaudRateChanged(_baudRateDropDown);
        //_baudRateDropDown.onValueChanged.AddListener(delegate { _onBaudRateChanged(_baudRateDropDown); });
        //SerialPortManager.init(_serilaPortName, _baudRate);


        base.Init();
        //_sideView_SO.InitializeSubComponents();
        _settingsSideView_SO = (SettingsSideView_SO)_sideView_SO;
        //_settingsSideView_SO.InitializeSubComponents();
    }

    #region events
    private void OnEnable()
    {
        //somehow works
        //_settingsSideView_SO = (SettingsSideView_SO)_sideView_SO; //working
        //Usb.DevicesChanged += Usb_DevicesChanged; //undo if not woriking


        //delete? 01/11/2023
        //HideButton.onClick.AddListener(delegate { _hideOrShowPanelComponents(false); });
        //ShowButton.onClick.AddListener(delegate { _hideOrShowPanelComponents(true); });
    }

    //delete? 01/11/2023
    //private void _hideOrShowPanelComponents(bool show) {
    //    foreach (var item in transform.c)
    //    {

    //    }
    //}

    
    private void Usb_DevicesChanged(UsbDevice[] devices)
    {
        //if(_camTexture != null)
        //{
        //    _camTexture.Stop();
        //}
        //else
        //{
        //    _camTexture = new WebCamTexture();
        //}
        
        _camerasDropDown.options.Clear();
        WebCamDevice[] webdevices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            bool currentDeviceDisconnected = false;
            bool searchForDiconnectedDevice = true;
            for (int i = 0; i < webdevices.Length; i++)
            {
                _camerasDropDown.options.Add(new TMP_Dropdown.OptionData() { text = webdevices[i].name });
                if (searchForDiconnectedDevice)
                {
                    if (_currentDevice == devices[i].name)
                    {
                        currentDeviceDisconnected = false;
                        searchForDiconnectedDevice = false;
                    }
                    else
                    {
                        currentDeviceDisconnected = true;
                    }
                }                
            }
           
            if(currentDeviceDisconnected)
            {
                //_camTexture = new WebCamTexture();
                //_camTexture = new WebCamTexture();
                _camTexture.deviceName = _camerasDropDown.options[0].text;
                //_currentDevice = _camerasDropDown.options[0].text;

                //_startVideoStream(_camTexture);
                //TODO: write that the camera disconnected...
            }
               
        }
        else
        {
            //err no camera connected
        }
        _CheckSerialPort();
    }

    private void OnDisable()
    {
        Usb.DevicesChanged -= Usb_DevicesChanged;
    }
    #endregion

    private void _chackCameras()
    {        
        
        //_camerasDropDown.options.Clear();
        WebCamDevice[] devices = WebCamTexture.devices;
        if(devices.Length > 0)
        {
            for (int i = 0; i < devices.Length; i++)
                _camerasDropDown.options.Add(new TMP_Dropdown.OptionData() { text = devices[i].name });

            _camTexture = new WebCamTexture();
            _camTexture.deviceName = devices[0].name;
            _currentDevice = devices[0].name;
            //StartCamera.enabled = true;
           
           _startVideoStream(_camTexture);
           
            
            StopCamera.enabled = true;
        }
        else
        {
            StartCamera.enabled = false;
        }
       
    }

    private void _CheckSerialPort()
    {
        _portsDropDown.options.Clear();
        if(SerialPort.GetPortNames().Length > 0 )
        {
            for (int i = 0; i < SerialPort.GetPortNames().Length; i++)
            {
                Debug.Log(SerialPort.GetPortNames()[i]);
                _portsDropDown.options.Add(new TMP_Dropdown.OptionData() { text = SerialPort.GetPortNames()[i] });
            }
            ConnectButton.enabled = true;
        }
        else
        {
            ConnectButton.enabled= false;
        }
        
    }

    private void _onCameraDropDownSelected(TMP_Dropdown dropDown)
    {
        if(_camTexture != null)
        {
            _camTexture.Stop();
            
        }

        int index = dropDown.value;
        if(dropDown.options.Count > 0)
        {
            //_camTexture = new WebCamTexture();
            _camTexture.deviceName = dropDown.options[index].text;
            _currentDevice = dropDown.options[index].text;
            Debug.Log("selected index[" + index + "], name: " + dropDown.options[index].text);
            _startVideoStream(_camTexture);
        }
    }

    private void _onSerialPortDropDownSelected(TMP_Dropdown dropDown)
    {
        int index = dropDown.value;
        if (dropDown.options.Count > 0)
        {
            _serilaPortName = dropDown.options[index].text;
        }
    }

    private void _onBaudRateChanged(TMP_Dropdown dropDown)
    {
        int index = dropDown.value;
        if (dropDown.options.Count > 0)
        {
            _baudRate = int.Parse(dropDown.options[index].text);
        }
    }

    //public override void Init()
    //{
    //    Debug.Log("Camera init");
    //    //ShowHideButton.onClick.AddListener(() => {
    //    //    if (IsShowen)
    //    //    {
    //    //        ViewsManager.HideView<SettingsView>();
    //    //    }
    //    //    else
    //    //    {
    //    //        ViewsManager.ShowView<SettingsView>();
    //    //    }
    //    //});

    //    //TODO: this is under the serial port scripts
    //    //ConnectButton.onClick.AddListener(() => { _connectToSerialPort(); });
    //    //DisconnectButton.onClick.AddListener(() => { _disconnectFromSerialPort(); });
    //    //StartCamera.onClick.AddListener(() => { _startVideoStream(_camTexture); });
    //    //StopCamera.onClick.AddListener(() => { _stopVideoStream(_camTexture); });
    //    base.Init();
    //}

    private void _connectToSerialPort()
    {
        Task.Run(async () => {  
            if(await SerialPortManager.ConnectToSerialPort())
            {
                ConnectionStatus.text = "Connected";
                ConnectionStatus.color = Color.green;
                ColorBlock DisconnectedColorBlock = DisconnectButton.colors;
                DisconnectedColorBlock.normalColor = Color.red;
                ColorBlock ConnectedColorBlock = ConnectButton.colors;
                ConnectedColorBlock.normalColor = Color.white;
                ConnectButton.enabled = false;
                DisconnectButton.enabled = true;
            }
            else
            {
                ConnectionStatus.text = "Problem Connecting";
                ConnectionStatus.color = Color.red;

            }                
         }); 
    }

    private void _disconnectFromSerialPort()
    {
        Task.Run(async () => {
            if (await SerialPortManager.DisconnectFromSerialPort())
            {
                ConnectionStatus.text = "Disconnected";
                ConnectionStatus.color = Color.black;
                ColorBlock DisconnectedColorBlock = DisconnectButton.colors;
                DisconnectedColorBlock.normalColor = Color.white;
                ColorBlock ConnectedColorBlock = ConnectButton.colors;
                ConnectedColorBlock.normalColor = Color.green;
                ConnectButton.enabled = true;
                DisconnectButton.enabled = false;
            }
            else
            {
                ConnectionStatus.text = "Problem Disconnecting";
                ConnectionStatus.color = Color.red;
            }
        });
    }

    private void _startVideoStream(WebCamTexture webCamTexture)
    {
        if(webCamTexture != null)
        {
            webCamTexture.Stop();
            Debug.Log("playing Camera: " + webCamTexture.deviceName);
            //rawImage.material.mainTexture = webCamTexture;
            StopCamera.enabled = true;
            StartCamera.enabled = false;
            rawImage.texture = webCamTexture;
            try
            {
                webCamTexture.Play();
            }catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
            
        }
        else
        {
            //err
        }
        
    }

    private void _stopVideoStream(WebCamTexture webCamTexture)
    {
        if (webCamTexture != null)
        {
            StopCamera.enabled = false;
            StartCamera.enabled = true;
            webCamTexture.Stop();
        }
        else
        {
            //err
        }
    }

    //public override void Show()
    //{
    //    Debug.Log("Calling Settings View show");
    //    //GetComponent<CanvasGroup>().enabled = true;
        
    //    //transform.position = new Vector3(0, transform.position.y, 0); //undo after sinishing tab system  //x =300
    //    base.Show();
    //}

    //public override void Hide()
    //{
    //    Debug.Log("Calling Settings View hide");
    //    //GetComponent<CanvasGroup>().enabled = false;
      
    //    //transform.position = new Vector3(-1* GetComponent<RectTransform>().rect.size.x, transform.position.y, 0); //-538
    //    base.Hide();
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Hardware;
using TMPro;

public class SettingsView_Local_Cameras : MonoBehaviour
{
    private WebCamTexture _camTexture;
    [SerializeField] private TMP_Dropdown _camerasDropDown;
    string _currentWebCamDeviceName = string.Empty;

    public void Init()
    {
        _updateCamerasInDropDown();

        _camerasDropDown.onValueChanged.AddListener(delegate {
            
            int index = _camerasDropDown.value;
           
            if (_currentWebCamDeviceName == _camerasDropDown.options[index].text)
            {
                return;
            }
            
            if (_camTexture != null)
            {
                _camTexture.Stop();
                
                if (_camerasDropDown.options.Count > 0)
                {
                    
                    _camTexture.deviceName = _camerasDropDown.options[index].text;
                    _currentWebCamDeviceName = _camTexture.deviceName;
                    _camTexture.Play();
                }
            }
            else
            {
                Debug.LogError("_camTexure is null");
            }
        });

        Usb.DevicesChanged += Usb_DevicesChanged;
        
    }

    private void Usb_DevicesChanged(UsbDevice[] devices)
    {
        _camerasDropDown.options.Clear();
        WebCamDevice[] webdevices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            for (int i = 0; i < webdevices.Length; i++)
            {
                _camerasDropDown.options.Add(new TMP_Dropdown.OptionData() { text = webdevices[i].name });
                
            }

            if(_currentWebCamDeviceName != string.Empty)
            {
                if(_camerasDropDown.options.FindIndex(x => x.text == _currentWebCamDeviceName) == -1)
                {
                    _camTexture.deviceName = _camerasDropDown.options[0].text;
                }
                return;
            }

        }
        else
        {
            //TODO: create event that show picture: "no data available"
        }
    }

    public void UpdateImage(RawImage rawImage)
    {
        if(_camTexture != null)
        {
            rawImage.texture = _camTexture;
            _camTexture.Play();
        }
    }

    private void _updateCamerasInDropDown()
    {
        _camerasDropDown.enabled = true;
        _camerasDropDown.options.Clear();
        WebCamDevice[] devices = WebCamTexture.devices;
        
        if (devices.Length > 0)
        {
            for (int i = 0; i < devices.Length; i++)
                _camerasDropDown.options.Add(new TMP_Dropdown.OptionData() { text = devices[i].name });

            _camTexture = new WebCamTexture();
            _currentWebCamDeviceName = devices[0].name;
            _camTexture.deviceName = _currentWebCamDeviceName;
            
        }
        else
        {
            _camerasDropDown.enabled = false;
        }
    }
}

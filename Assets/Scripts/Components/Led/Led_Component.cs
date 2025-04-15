using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Led_Component : Component
{
    private Led_Component_SO _led_Component_SO;
    private Renderer _renderer;

    [SerializeField] private GameObject _ledText;
    [SerializeField] private GameObject _ledHead;
    [SerializeField] private Camera _camera;

    private void OnEnable()
    {
        if(_component_SO != null)
        {
            _led_Component_SO = (Led_Component_SO)_component_SO;
        }
        else
        {
            Debug.LogError("_component_SO is NULL");
            return;
        }

        _led_Component_SO.OnLightSwitch += _led_Component_SO_OnLightSwitch;
        _renderer = _ledHead.gameObject.GetComponent<Renderer>();
        _renderer.material.SetColor("_Color", _led_Component_SO.ColorOff);
        //_ledText.transform.LookAt(_camera.transform);
        _ledText.SetActive(false);
    }

    private void OnDisable()
    {
        _led_Component_SO.OnLightSwitch -= _led_Component_SO_OnLightSwitch;
    }

    private void _led_Component_SO_OnLightSwitch(object sender, bool SwitchState)
    {
        if (SwitchState)
        {
            _renderer.material.SetColor("_Color", _led_Component_SO.ColorOn);
            Debug.Log("Color On");
        }
        else
        {
            _renderer.material.SetColor("_Color", _led_Component_SO.ColorOff);
            Debug.Log("Color Off");
        }
    }

    public override void OnInteraction()
    {
        Debug.Log("led interacted");
        _ledText.SetActive(true);
    }

    public override void OnSideClick()
    {
        Debug.Log("led side interacted");
        _ledText.SetActive(false);
    }

}

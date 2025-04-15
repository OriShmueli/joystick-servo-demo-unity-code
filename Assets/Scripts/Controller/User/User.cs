using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{

    private Controller _controller;
    [SerializeField] private Camera _camera;
    private IInteractable _interactable = null;
    //private IInteractable _lastInteractable = null;
    private void OnEnable()
    {
        _controller = new Controller();
        _controller.Enable();
        _controller.Computer.Interaction.started += Interaction_started;
    }

    private void Interaction_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("click");
        //Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f))        
        {
            
            if (hit.collider.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                Debug.Log("hit: " + hit.collider.gameObject.name);
                if(_interactable != null)
                {
                    if(interactable == _interactable)
                    {
                        _interactable.OnSideClick();
                        //_lastInteractable = interactable;
                        _interactable = null;
                        return;
                    }
                    else
                    {
                        _interactable.OnSideClick();
                        _interactable = interactable;
                        _interactable.OnInteraction();
                    }
                }
                else
                {
                    _interactable = interactable;
                    _interactable.OnInteraction();
                }                
            }
            else
            {
                //Debug.Log("no object interacted");
                //if (_lastInteractable != null)
                //{
                //    _lastInteractable.OnSideClick();
                //}
                
            }
        }
        else
        {
            Debug.Log("no object interacted");
            if (_interactable != null)
            {
                _interactable.OnSideClick();
                _interactable = null;
            }
        }
    }

    private void OnDisable()
    {        
        if (_controller != null)
        {
            _controller.Computer.Interaction.started -= Interaction_started;
            _controller.Disable();
        }
    }
}
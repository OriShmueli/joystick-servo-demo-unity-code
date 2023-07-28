using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class JoyStick : MonoBehaviour
{
    private Controller _controller;
    public GameObject body;
    public GameObject arm;

    public int speed = 20;

    private void OnEnable()
    {
        _controller = new Controller();
        _controller.Enable();
        //_controller.JoyStick.Left.performed += Left_performed;
        // _controller.JoyStick.Right.performed += Right_performed;
        //_controller.JoyStick.l.performed += L_performed;
        // _controller.JoyStick.l.started += L_started;
        //_controller.JoyStick.l.canceled += L_canceled;
       
    }

   /* private void Right_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Right");
        body.transform.Rotate(0, speed*Time.deltaTime, 0);
    }*/

    /*private void Left_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Left");
        body.transform.Rotate(0, (-1) * speed * Time.deltaTime, 0);
    }*/

    private void OnDisable()
    {
        _controller.Disable();
        //_controller.JoyStick.Left.performed -= Left_performed;
        // _controller.JoyStick.Right.performed -= Right_performed;
       
    }

  

    void Start()
    {
        
    }

    void Update()
    {
        float move = _controller.JoyStick.Horizontal.ReadValue<float>();
        if (move > 0.5)
        {
            body.transform.Rotate(0, speed * Time.deltaTime * move, 0);
        } else if (move < -0.5)
        {
            body.transform.Rotate(0, speed * Time.deltaTime * move, 0);
        }
        

        float armUp = _controller.JoyStick.Up.ReadValue<float>();
        if(armUp > 0.5)
        {
            arm.transform.Rotate( speed * Time.deltaTime * armUp, 0, 0);
        }

        float armDown = _controller.JoyStick.Down.ReadValue<float>();
        if (armDown > 0.5)
        {
            arm.transform.Rotate(speed * Time.deltaTime * armDown * -1, 0, 0);
        }
        //  arm.transform.Rotate(0, 0, speed * Time.deltaTime * armUp);
        //Debug.Log("arm UP: " + armUp);
        //Debug.Log("arm DOWN: " + armDown);
    }
}

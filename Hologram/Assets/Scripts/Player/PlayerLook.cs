using System.Threading;
using System.Runtime.CompilerServices;
//using System.Reflection.PortableExecutable;
using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerLook : MonoBehaviour
{

    [SerializeField] private string mouseXInputName, mouseYInputName; // guarda nomes do input (X , Y)
    [SerializeField] private float mouseSensivity;

    [SerializeField] private Transform playerBody;

    private float lifeTimer;
    public float lifeTime = 5f;
    private float xAxisClamp; // limiting the position to an area (-90 to 90)

    public Camera playerCamera;
   

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
        
    }

    //lock cursor in middle of the screen
    private void LockCursor()
    {
        
        Cursor.lockState = CursorLockMode.Locked;

    }


    private void Update()
    {
        
       

        CameraRotation();

        //check if player alreadt hit Esc
        if (Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.None)
        {

            LockCursor();


        }
    }

     

    private void CameraRotation()
    {
        //GET INPUTS 
      
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensivity * Time.deltaTime;

        xAxisClamp += mouseY; //get the rotation  +90 up , -90 down

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0; // stop mouse from moving above
            ClampxAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0; // stop mouse from moving above
            ClampxAxisRotationToValue(90.0f);
        }
        //rotation (Y)
        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);

    }

    // clamp
    private void ClampxAxisRotationToValue(float value)
    {
        Vector3 euLerRot = transform.eulerAngles; 
        euLerRot.x = value;
        transform.eulerAngles = euLerRot;
    }

}

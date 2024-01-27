using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraAroundTarget : MonoBehaviour
{
    [SerializeField] 
        private Transform poznanski;
    [SerializeField] 
        private Vector3 lookVector = new(-1, 1, 0);
    [SerializeField] 
        private float distance = 10;
    [SerializeField]
        private Transform targetTransform;
    [SerializeField]
    float mouseSensitivity;
    float mouseInput;

    bool aimState;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        aimState=true;
    }


    void Update()
    {
        if(aimState)
        {
            mouseInput=Input.GetAxis("Mouse X")*mouseSensitivity/Time.deltaTime;
            mouseInput=Mathf.Clamp(mouseInput, -90f,90f);


            Debug.Log(transform.rotation.y);
            transform.RotateAround(targetTransform.position, transform.up, mouseInput);
        }
        else
        {
            transform.position = poznanski.position + lookVector * distance;
            transform.LookAt(poznanski);
        }
        
    }
}

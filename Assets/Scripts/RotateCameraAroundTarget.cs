using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraAroundTarget : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;
    [SerializeField]
    float mouseSensitivity;
    float mouseInput;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        mouseInput=Input.GetAxis("Mouse X")*mouseSensitivity/Time.deltaTime;
        mouseInput=Mathf.Clamp(mouseInput, -90f,90f);


        Debug.Log(transform.rotation.y);
        transform.RotateAround(targetTransform.position, transform.up, mouseInput);
    }
}

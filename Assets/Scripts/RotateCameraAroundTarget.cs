using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraAroundTarget : MonoBehaviour
{
    [SerializeField]
    private Catapult catapult;
    [SerializeField] public Transform poznanski;
    [SerializeField]
    private Vector3 lookVector = new(-1, 1, 0);
    [SerializeField]
    private float distance = 10;
    [SerializeField]
    public Transform targetTransform;
    [SerializeField]
    float mouseSensitivity;
    float mouseInput;
    [SerializeField]
    private Transform catapultCameraPosition;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        TeleportToCatapult();
    }


    void Update()
    {
        if (catapult.GetShootingState() == Catapult.AimingState.Idle)
        {
            transform.position = poznanski.position + lookVector * distance;
            transform.LookAt(poznanski);
        }
        else
        {
            mouseInput = Input.GetAxis("Mouse X") * mouseSensitivity / Time.deltaTime;
            mouseInput = Mathf.Clamp(mouseInput, -90f, 90f);

            //Debug.Log(transform.rotation.y);
            transform.RotateAround(targetTransform.position, transform.up, mouseInput);
        }
    }

    public void TeleportToCatapult()
    {
        transform.position = catapultCameraPosition.position;
        transform.rotation = catapultCameraPosition.rotation;
    }
}

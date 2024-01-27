using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraAroundTarget : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;
    [SerializeField]
    float mouseSensitivity;
    void FixedUpdate()
    {
        transform.RotateAround(targetTransform.position, transform.up, Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime);
    }
}

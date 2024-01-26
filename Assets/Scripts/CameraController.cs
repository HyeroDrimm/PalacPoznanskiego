using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    [SerializeField]
    public Transform characterTransform;

    Vector3 cameraOffset;

    private float mouseX;
    private float mouseY;

    private float xRotation;
    private float yRotation;

    [SerializeField]
    private float mouseSesitivity;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        cameraOffset = new Vector3(0, 1f, 0);

        xRotation = 0f;
        yRotation = 0f;

        mouseSesitivity = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        MoveCamera();
    }

    private void RotateCamera()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * mouseSesitivity / Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * mouseSesitivity / Time.deltaTime;


        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        characterTransform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void MoveCamera()
    {
        transform.position = characterTransform.transform.position + cameraOffset;
    }
}

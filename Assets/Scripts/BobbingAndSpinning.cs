using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingAndSpinning : MonoBehaviour
{
    [SerializeField] private float bobbingDistance;
    [SerializeField] private float spinSpeed;

    void Update()
    {
        transform.localPosition = Vector3.up * Mathf.Sin(Time.time) * bobbingDistance;
        transform.Rotate(Vector3.up, spinSpeed);
    }
}

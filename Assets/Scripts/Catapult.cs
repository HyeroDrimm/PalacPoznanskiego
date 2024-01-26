using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private CatapultUI catapultUi;
    [SerializeField] private Rigidbody poznanski;
    [SerializeField] private Transform reloadPoint;
    [SerializeField] private float rotationChange = 1;
    [SerializeField] private float stengthChange = 0.01f;
    [SerializeField] private float angleChange;
    [SerializeField] private float strengthMultiplier = 10;

    private AimingState aimingState = AimingState.Shooting;
    private float angle = 0.5f;
    private float strength = 1;
    private Rigidbody rb;

    void Start()
    {
        catapultUi.UpdateAngle(angle);
        catapultUi.UpdateStrength(strength);
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (aimingState == AimingState.Shooting)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.up, -rotationChange * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up, rotationChange * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                angle = Math.Clamp(angle + angleChange * Time.deltaTime, 0.1f, 0.9f);
                catapultUi.UpdateAngle(angle);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                angle = Math.Clamp(angle - angleChange * Time.deltaTime, 0.1f, 0.9f);
                catapultUi.UpdateAngle(angle);
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                aimingState = AimingState.SetingStrength;
            }
        }
        else if (aimingState == AimingState.SetingStrength)
        {
            strength = (Mathf.Sin(Time.time * stengthChange) + 1) / 2;
            print(strength);
            catapultUi.UpdateStrength(strength);
            if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Space))
            {
                catapultUi.SetVisibility(false);
                aimingState = AimingState.Idle;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        var aimVector = Quaternion.AngleAxis(angle * 90, Vector3.forward) * Vector3.right;
        poznanski.AddForce(transform.TransformDirection(aimVector) * Mathf.Clamp01(strength + 0.1f) * strengthMultiplier);
    }

    public void Reload()
    {
        poznanski.rotation = Quaternion.identity;
        poznanski.angularVelocity = Vector3.zero;
        poznanski.velocity = Vector3.zero;
        poznanski.position = reloadPoint.position;
    }

    public void SetShootingState(AimingState aimingState)
    {
        this.aimingState = aimingState;
    }

    public enum AimingState
    {
        Idle,
        Shooting,
        SetingStrength,
    }
}

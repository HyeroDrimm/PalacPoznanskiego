using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private CatapultUI catapultUi;
    [SerializeField] private float rotationAngle = 1;
    [SerializeField] private float stengthDelta = 0.01f;
    [SerializeField] private float catapultStrength = 10;
    [SerializeField] private Rigidbody poznanski;
    [SerializeField] private Transform reloadPoint;
    private AimingState aimingState = AimingState.Shooting;

    private float strength = 1;
    private Vector3 aimVector = new(1, 1, 0);

    // Update is called once per frame
    private void Update()
    {
        if (aimingState == AimingState.Shooting)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up, -rotationAngle * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                strength = Math.Clamp(strength + stengthDelta * Time.deltaTime, 0, 1);
                print(strength);
                catapultUi.UpdateStrength(strength);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                strength = Math.Clamp(strength - stengthDelta * Time.deltaTime, 0, 1);
                catapultUi.UpdateStrength(strength);
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                catapultUi.SetVisibility(false);
                aimingState = AimingState.Idle;
                Shoot();

            }
        }
    }

    private void Shoot()
    {
        poznanski.AddRelativeForce(aimVector * Mathf.Clamp01(strength + 0.1f) * catapultStrength);
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
    }
}

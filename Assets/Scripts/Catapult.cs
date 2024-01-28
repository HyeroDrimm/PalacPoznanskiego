using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Catapult : MonoBehaviour
{
    [SerializeField] private CatapultUI catapultUi;
    [SerializeField] private Rigidbody poznanski;
    [SerializeField] private Poznanski poznanskiPrefab;
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private RotateCameraAroundTarget rotateCameraAroundTarget;
    [SerializeField] private Transform reloadPoint;
    [SerializeField] private Animator catapultAnimator;
    [SerializeField] private Collider lyzkaCollider;
    [SerializeField] private FollowPoznanski moneyFollowPoznanski;
    [SerializeField] private float rotationChange = 1;
    [SerializeField] private float stengthChange = 0.01f;
    [SerializeField] private float angleChange;
    [SerializeField] private float strengthMultiplier = 10;
      [SerializeField]
    public AttemptsUi attemptsUi;

    private AimingState aimingState = AimingState.Shooting;
    private float angle = 0.5f;
    private float strength = 1;
    private Rigidbody rb;

    private bool isLunched;
    private bool animationEnded = true;

    void Start()
    {
        isLunched = false;
        catapultUi.UpdateAngle(angle);
        catapultUi.UpdateStrength(strength);
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (aimingState == AimingState.Shooting)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 1, 0) * -rotationChange * Time.fixedDeltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 1, 0) * rotationChange * Time.fixedDeltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                angle = Math.Clamp(angle + angleChange * Time.deltaTime, 0.1f, 0.9f);
                catapultUi.UpdateAngle(angle);
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
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
            catapultUi.UpdateStrength(strength);
            if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Space))
            {
                Shoot();
            }
        }
        else if (aimingState == AimingState.Idle)
        {
            if (Input.GetKeyDown(KeyCode.R) && animationEnded)
            {
                Reload();
            }
        }
    }

    private void Shoot()
    {
        moneyFollowPoznanski.SetEffectStatus(true);
        lyzkaCollider.enabled = false;
        catapultAnimator.SetTrigger("DoIt");
        catapultUi.SetVisibility(false);
        aimingState = AimingState.Idle;
        isLunched = true;
        var aimVector = Quaternion.AngleAxis(angle * 90, Vector3.forward) * Vector3.right;
        poznanski.AddForce(transform.TransformDirection(aimVector) * Mathf.Clamp01(strength + 0.1f) * strengthMultiplier);
        SFXController.specialEffects.PlayRandomVoiceSFX(transform);
        attemptsUi.AddScore(1);

    }

    public void Reload()
    {
        if(aimingState==AimingState.Idle)
        {
            animationEnded = false;
            lyzkaCollider.enabled = true;
            catapultUi.SetVisibility(true);
            moneyFollowPoznanski.SetEffectStatus(false);
            var newPoznanski = Instantiate(poznanskiPrefab, reloadPoint.position, reloadPoint.rotation);
            poznanski = newPoznanski.Spine1;
            rotateCameraAroundTarget.poznanski = newPoznanski.Spine1.transform;
            rotateCameraAroundTarget.TeleportToCatapult();
            scoreCounter.rb = newPoznanski.Spine1;
            moneyFollowPoznanski.poznanski = newPoznanski.Spine1.transform;
            aimingState = AimingState.Shooting;
        }
    }

    public void SetShootingState(AimingState aimingState)
    {
        this.aimingState = aimingState;
    }

    public AimingState GetShootingState()
    {
        return aimingState;
    }

    public enum AimingState
    {
        Idle,
        Shooting,
        SetingStrength,
    }

    public bool GetIsLunched()
    {
        return isLunched;
    }

    public void SetAnimationEnded(bool state)
    {
        animationEnded = state;
    }
}

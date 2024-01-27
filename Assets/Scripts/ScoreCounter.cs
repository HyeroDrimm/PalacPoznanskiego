using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private Catapult catapult;
    [SerializeField]
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(catapult.GetShootingState()==Catapult.AimingState.Idle)
            IncrementScore();
    }

    void IncrementScore()
    {
        if(rb.velocity.magnitude>1f)
        {
            ScoreUI.scoreUI.AddScore(Mathf.RoundToInt(100*Time.deltaTime));
        }    
           
    }
}

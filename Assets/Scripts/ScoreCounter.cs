using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        IncrementScore();
        Debug.Log(rb.velocity.magnitude);
    }

    void IncrementScore()
    {
        if(rb.velocity.magnitude>1f)
        {
            ScoreUI.scoreUI.AddScore(Mathf.RoundToInt(100*Time.deltaTime));
        }    
           
    }
}

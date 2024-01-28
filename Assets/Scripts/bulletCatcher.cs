using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletCatcher : MonoBehaviour
{
    [SerializeField]
    private GameObject planks;
    [SerializeField]
    private GuestGoalUI guestGoalUI;
    [SerializeField]
    private Catapult catapult;
    private bool isHit;
    private void Start()
    {
        isHit=true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.tag="Untagged";
            catapult.Reload();
            if(this.gameObject.CompareTag("Goal")&&!isHit)
            {
                Destroy(other.gameObject.transform.root.gameObject);
                guestGoalUI.AddScore(1);
                //gameObject.SetActive(false);
                isHit=true;
                planks.SetActive(true);
            }
        }
    }
}

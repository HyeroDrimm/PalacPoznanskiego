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
        isHit=false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided1");
            other.gameObject.tag="Untagged";
            catapult.Reload();
            if(this.gameObject.CompareTag("Goal")&&!isHit)
            {
                Debug.Log("Collided");
                planks.SetActive(true);
                Destroy(other.gameObject.transform.root.gameObject);
                guestGoalUI.AddScore(1);
                //gameObject.SetActive(false);
                isHit=true;
                SFXController.specialEffects.CreateSFX("glass", transform, false);
                
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletCatcher : MonoBehaviour
{
    [SerializeField]
    private GuestGoalUI guestGoalUI;
    [SerializeField]
    private Catapult catapult;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.tag="Untagged";
            catapult.Reload();
            if(this.gameObject.CompareTag("Goal"))
            {
                guestGoalUI.AddScore(1);
                gameObject.SetActive(false);
            }
        }
    }
}

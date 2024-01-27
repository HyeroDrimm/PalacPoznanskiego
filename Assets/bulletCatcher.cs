using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletCatcher : MonoBehaviour
{
    [SerializeField]
    private Catapult catapult;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(this.gameObject.CompareTag("Goal"))
            {

            }
            Debug.Log("cought");
            other.gameObject.tag="Untagged";
            catapult.Reload();
        }
    }
}

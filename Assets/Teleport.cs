using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Transform teleportTo;

    private void TeleportThis(GameObject player)
    {
        transform.position=teleportTo.position;
        Physics.SyncTransforms();
        
    }

    void CollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            TeleportThis(collision.gameObject);
        }
    }
}

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
        Debug.Log("teleport");
        player.gameObject.GetComponent<Rigidbody>().Move(teleportTo.position, Quaternion.identity);
        Physics.SyncTransforms();

    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            TeleportThis(collision.gameObject);
        }
    }
}

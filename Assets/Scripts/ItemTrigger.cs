using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    [SerializeField] private ItemShowUi itemShowUi;
    [SerializeField] private Catapult catapult;
    [SerializeField] private GameObject root;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.tag = "Untagged";
            catapult.Reload();

            Destroy(other.transform.root.gameObject);
            itemShowUi.gameObject.SetActive(true);
            root.SetActive(false);
        }
    }
}

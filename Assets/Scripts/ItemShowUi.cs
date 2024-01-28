using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShowUi : MonoBehaviour
{
    [SerializeField] private Catapult catapult;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            catapult.isInMenu = false;
            gameObject.SetActive(false);
        }
    }
}

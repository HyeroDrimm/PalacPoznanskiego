using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShowUi : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false);
        }
    }
}

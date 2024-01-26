using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MorrisController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PalaceController.palaceController.UpdateStatus(other.gameObject.name);
    }
}

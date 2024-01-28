using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poznanski : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private Material[] materials;
    
    public Rigidbody Spine1;

    void Start()
    {
        if (materials.Length != 0)
        {
            skinnedMeshRenderer.material = materials[Random.Range(0, materials.Length)];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lyzka : MonoBehaviour
{
    [SerializeField] private Catapult catapult;
    private void AnimationEnd()
    {
        print("hello");
        catapult.SetAnimationEnded(true);
    }
}

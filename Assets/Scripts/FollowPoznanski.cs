using UnityEngine;

public class FollowPoznanski : MonoBehaviour
{
    [SerializeField] private Transform poznanski;
    [SerializeField] private Vector3 lookVector = new(-1, 1, 0);
    [SerializeField] private float distance = 10;
    void Update()
    {
        transform.position = poznanski.position + lookVector * distance;
        transform.LookAt(poznanski);
    }
}

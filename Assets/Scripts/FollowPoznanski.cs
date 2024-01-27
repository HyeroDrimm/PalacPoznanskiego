using UnityEngine;

public class FollowPoznanski : MonoBehaviour
{
    [SerializeField] private Catapult catapult;
    [SerializeField] private Transform poznanski;
    [SerializeField] private Vector3 lookVector = new(-1, 1, 0);
    [SerializeField] private float distance = 10;

    void Update()
    {
        //transform.position = poznanski.position + lookVector * distance;
        //transform.LookAt(poznanski);
        transform.position=poznanski.position;

        if(catapult.GetIsLunched())
        {
            foreach (Transform child in transform)
            {
                Debug.Log("activate vfx");
                child.gameObject.SetActive(true);
            }
        }
    }
}

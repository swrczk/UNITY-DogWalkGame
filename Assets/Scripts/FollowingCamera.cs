using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public GameObject Target;
    public float smothTime;
    Vector3 currVelocity;

    void Update()
    {
        var newPosition = new Vector3(Target.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currVelocity, smothTime);
    }
}
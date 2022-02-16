using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    public Transform CameraTransform;
    public float ParallaxFactor;

    Vector3 prevCameraPosition;
    Vector3 deltaCameraPosition;

    void Start()
    {
        prevCameraPosition = CameraTransform.position;
    }

    void Update()
    {
        deltaCameraPosition = prevCameraPosition - CameraTransform.position;
        var parallaxPosition = new Vector3(transform.position.x + deltaCameraPosition.x * ParallaxFactor,
            transform.position.y, transform.position.z);
        transform.position = parallaxPosition;
        prevCameraPosition = CameraTransform.position;
    }
}
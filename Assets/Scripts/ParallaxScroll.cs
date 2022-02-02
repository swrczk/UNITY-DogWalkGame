using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    public Transform CameraTransform;
    public float ParallaxFactor;

    Vector3 prevCameraPosition;
    Vector3 deltaCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        prevCameraPosition = CameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        deltaCameraPosition = prevCameraPosition - CameraTransform.position;
        var parallaxPosition = new Vector3(transform.position.x + deltaCameraPosition.x * ParallaxFactor,
            transform.position.y, transform.position.z);
        transform.position = parallaxPosition;
        prevCameraPosition = CameraTransform.position;
    }
}
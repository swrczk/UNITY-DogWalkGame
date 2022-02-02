using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingHero : MonoBehaviour
{
    public GameObject Hero;
    public float smothTime;

    private Vector3 currVelocity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var newPosition = new Vector3(Hero.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currVelocity, smothTime) ;
    }
}
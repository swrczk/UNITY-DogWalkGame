using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MovingPlatform : MonoBehaviour
{
    public float Speed;
    public Transform startPoint;
    public Transform endPoint;
    Vector3 currentPosition;
    Vector3 startVector;
    Vector3 endVector;

    // Start is called before the first frame update
    void Start()
    {
        startVector = startPoint.position;
        endVector = endPoint.position;
        Destroy(startPoint.gameObject);
        Destroy(endPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = Vector3.Lerp(startVector, endVector, Mathf.PingPong(Time.time * Speed, 1));
        transform.position = currentPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
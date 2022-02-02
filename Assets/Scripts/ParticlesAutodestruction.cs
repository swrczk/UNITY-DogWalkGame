using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ParticlesAutodestruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Autodestruction", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Autodestruction()
    {
        Destroy(gameObject);
    }
}

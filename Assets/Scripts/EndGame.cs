using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public AudioClip EndClip;
    public GameObject Particles;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(EndClip, transform.position);
            Instantiate(Particles, transform.position, Particles.transform.rotation);
            other.gameObject.GetComponent<PlayerController>().EndGame();
        }
    }
}
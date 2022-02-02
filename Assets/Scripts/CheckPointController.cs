using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public AudioClip CheckpointClip;
    public GameObject Particles;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().StartPoint = this.transform;
            spriteRenderer.color = Color.white;
            AudioSource.PlayClipAtPoint(CheckpointClip, transform.position);
            Instantiate(Particles, transform.position, Particles.transform.rotation);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
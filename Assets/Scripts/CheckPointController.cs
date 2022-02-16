using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckPointController : MonoBehaviour
{
    public AudioClip CheckpointClip;
    public GameObject Particles;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ExecuteEvents.Execute<IHealth>(EventManager.Instance.GetEventSystem(), null, (x, y) => x.SetCheckPoint(this.transform));
            CheckPointEffect();
        }
    }

    void CheckPointEffect()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        spriteRenderer.color = Color.white;
        AudioSource.PlayClipAtPoint(CheckpointClip, transform.position);
        Instantiate(Particles, transform.position, Particles.transform.rotation);
    }
}
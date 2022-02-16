using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Meta : MonoBehaviour
{
    public AudioClip EndClip;
    public GameObject Particles;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(EndClip, transform.position);
            Instantiate(Particles, transform.position, Particles.transform.rotation);
            other.gameObject.GetComponent<PlayerController>().NextLevelReaction();
            ExecuteEvents.Execute<IScene>(EventManager.Instance.GetEventSystem(), null, (x, y) => x.FinishGame(true));
        }
    }
}
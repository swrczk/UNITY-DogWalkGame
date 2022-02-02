using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{
    public AudioClip Clip;
    GameObject hero;
    CounterController manager;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hero = GameObject.Find("Dog");
        manager = GameObject.Find("Manager").GetComponent<CounterController>();
        if (manager == null)
        {
            Debug.LogError("Counter Controller not found.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == hero.name)
        {
            animator.Play("Crate Destroy");
            AudioSource.PlayClipAtPoint(Clip, transform.position);
        }
    }

    void RemoveCrate()
    {
        Destroy(this.gameObject);
        manager.IncrementCounter();
    }
}

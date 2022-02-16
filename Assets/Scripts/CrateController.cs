using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CrateController : MonoBehaviour
{
    [SerializeField] AudioClip Clip;
    GameObject hero;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hero = GameObject.Find("Dog");
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
        ExecuteEvents.Execute<IScore>(EventManager.Instance.GetEventSystem(), null, (x,y)=>x.IncrementScore());
    }
}

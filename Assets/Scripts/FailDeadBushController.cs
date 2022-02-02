using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailDeadBushController : MonoBehaviour
{
    public AudioClip DeadClip;
    public AudioClip FailGameClip;
    GameObject hero;
    LifesManager lifesManager;

    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.Find("Dog");
        lifesManager = GameObject.Find("Manager").GetComponent<LifesManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == hero.name)
        {
            if (lifesManager.CurrLifes > 0)
            {
                AudioSource.PlayClipAtPoint(DeadClip, hero.gameObject.transform.position);
                other.gameObject.GetComponent<Animator>().SetTrigger("fail");
            }
            else
            {
                AudioSource.PlayClipAtPoint(FailGameClip, hero.gameObject.transform.position);
                other.gameObject.GetComponent<Animator>().SetTrigger("failGame");
            }
        }
    }
}
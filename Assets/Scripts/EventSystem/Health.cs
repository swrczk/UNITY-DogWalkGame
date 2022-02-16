using UnityEngine.EventSystems;
using UnityEngine;
using System;

public interface IHealth : IEventSystemHandler
{
    void HurtPlayer();
    void SetCheckPoint(Transform checkPoint);
}


public class Health : MonoBehaviour, IHealth
{
    [SerializeField] Transform CheckPoint;
    [SerializeField] int MaxPoints = 3;
    [SerializeField] int CurrPoints = 3;
    [SerializeField] AudioClip DeadClip;
    [SerializeField] AudioClip FailClip;
    GameObject hero;

    void Start()
    {
        RefreshText();
        hero = GameObject.FindWithTag("Player");
    }
    public void SetCheckPoint(Transform checkPoint)
    {
        CheckPoint = checkPoint;
    }

    public void HurtPlayer()
    {
        if (CurrPoints > 0)
        {
            DealDamage();
        }
        else
        {
            KillPlayer();
        }
    }

    void DealDamage()
    {
        CurrPoints--;
        RefreshText();
        AudioSource.PlayClipAtPoint(DeadClip, hero.gameObject.transform.position);
        hero.gameObject.GetComponent<Animator>().SetTrigger("fail");
        Invoke("RestartHero", 0.5f);
    }

    void RestartHero()
    {
        hero.transform.position = CheckPoint.position;
        RefreshText();
    }

    void RefreshText()
    {
        var state = Math.Max(CurrPoints, 0) + "/" + MaxPoints;
        ExecuteEvents.Execute<IDisplay>(EventManager.Instance.GetEventSystem(), null, (x, y) => x.DisplayHealth(state));
    }

    void KillPlayer()
    {
        AudioSource.PlayClipAtPoint(FailClip, hero.gameObject.transform.position);
        hero.gameObject.GetComponent<Animator>().SetTrigger("failGame");
        ExecuteEvents.Execute<IScene>(EventManager.Instance.GetEventSystem(), null, (x, y) => x.FinishGame(false));
    }
}

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

interface IEventManager
{
    GameObject GetEventSystem();
}
public class EventManager : MonoBehaviour, IEventManager
{
    private static EventManager _instance;
    private static GameObject _eventSystem;

    public static EventManager Instance { get { return _instance; } }

    public GameObject GetEventSystem()
    {
        if (_eventSystem == null)
        {
            _eventSystem = GameObject.Find("EventSystem");
        }
        return _eventSystem;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

}
using UnityEngine;
using UnityEngine.EventSystems;

public class DeadBush : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ExecuteEvents.Execute<IHealth>(EventManager.Instance.GetEventSystem(), null, (x, y) => x.HurtPlayer());
        }
    }
}
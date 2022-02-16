using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface IScore : IEventSystemHandler
{
    void IncrementScore();
}

public class Score : MonoBehaviour, IScore
{
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        RefreshText();
    }

    public void IncrementScore()
    {
        Debug.Log("score inrement");
        score++;
        RefreshText();
    }

    void RefreshText()
    {
        ExecuteEvents.Execute<IDisplay>(EventManager.Instance.GetEventSystem(), null, (x, y) => x.DisplayCounter(score.ToString()));
    }
}

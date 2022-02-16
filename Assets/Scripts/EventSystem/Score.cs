using UnityEngine;
using UnityEngine.EventSystems;

public interface IScore : IEventSystemHandler
{
    void IncrementScore();
}

public class Score : MonoBehaviour, IScore
{
    int score = 0;

    void Start()
    {
        RefreshText();
    }

    public void IncrementScore()
    {
        score++;
        RefreshText();
    }

    void RefreshText()
    {
        ExecuteEvents.Execute<IDisplay>(EventManager.Instance.GetEventSystem(), null, (x, y) => x.DisplayCounter(score.ToString()));
    }
}

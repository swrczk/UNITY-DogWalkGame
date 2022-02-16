using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public interface IDisplay : IEventSystemHandler
{
    void DisplayCounter(string value);
    void DisplayHealth(string value);
}

public class DisplayState : MonoBehaviour, IDisplay
{
    [SerializeField] Text CounterView;
    [SerializeField] Text HealthView; 
    [SerializeField] Text FinishGameScore; 


    public void DisplayCounter(string value)
    {
        CounterView.text = value;
        FinishGameScore.text = value;
    }

    public void DisplayHealth(string value)
    {
        HealthView.text = value;
    }
}

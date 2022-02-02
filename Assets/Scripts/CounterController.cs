using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour
{
    public Text counterView;
    private int amount = 0;

    // Start is called before the first frame update
    void Start()
    {
        counterView.text = amount.ToString();
    }

    public void IncrementCounter()
    {
        amount++;
        counterView.text = amount.ToString();
    }

    public int GetScore()
    {
        return amount;
    }
}

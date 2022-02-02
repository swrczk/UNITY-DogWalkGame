using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesManager : MonoBehaviour
{
    public int Lifes;
    public Text LifesView;
    public int CurrLifes;

    // Start is called before the first frame update
    void Start()
    {
        RefreshText();
    }

    // Update is called once per frame
    public void LoseLife()
    {
        CurrLifes--;
        RefreshText();
    }

    void RefreshText()
    {
        LifesView.text = Math.Max(CurrLifes, 0) + "/" + Lifes;
    }
}

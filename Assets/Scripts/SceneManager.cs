using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public Canvas StartCanvas;
    public Canvas TutorialCanvas;
    public Canvas EndCanvas;
    public Text FinishGameMsg;
    public Text FinishGameScore;
    public string FailMsg;
    public string SuccessMsg;

    private bool tutorial = false;

    private CounterController manager;


    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<CounterController>();
    }

    void Update()
    {
        if (tutorial)
        {
            if (Input.anyKey)
            {
                Destroy(TutorialCanvas.gameObject);
                tutorial = true;
            }
        }
    }

    public void StartGame()
    {
        Destroy(StartCanvas.gameObject);
        EndCanvas.enabled = false;
        tutorial = true;
    }

    public void FinishGame(bool msg)
    {
        EndCanvas.enabled = true;
        FinishGameMsg.text = msg ? SuccessMsg : FailMsg;
        FinishGameScore.text = "Your score : " + manager.GetScore();
    }

    public void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);
        // UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
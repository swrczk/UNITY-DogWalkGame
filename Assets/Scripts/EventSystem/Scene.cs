using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

interface IScene : IEventSystemHandler
{
    void StartGame();
    void FinishGame(bool msg);
}

public class Scene : MonoBehaviour, IScene
{
    [SerializeField] Canvas StartCanvas;
    [SerializeField] Canvas TutorialCanvas;
    [SerializeField] Canvas EndCanvas;
    [SerializeField] Text FinishGameMsg;
    [SerializeField] string FailMsg;
    [SerializeField] string SuccessMsg;

    bool tutorial = false;

    void Update()
    {
        if (tutorial)
        {
            if (Input.anyKey)
            {
                Destroy(TutorialCanvas.gameObject);
                tutorial = false;
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
    }

    public void ResetGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}

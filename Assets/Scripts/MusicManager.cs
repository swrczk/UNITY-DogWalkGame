using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public Button MuteButton;
    public AudioSource ThemeMusic;
    public Sprite MuteImg;
    public Sprite UnMuteImg;

    private bool muted = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void TaskOnClick()
    {
        if (muted)
        {
            ThemeMusic.volume = 0.7f;
            MuteButton.image.sprite = UnMuteImg;
        }
        else
        {
            ThemeMusic.volume = 0f;
            MuteButton.image.sprite = MuteImg;
        }

        muted = !muted;
    }
}
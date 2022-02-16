using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public Button MuteButton;
    public AudioSource ThemeMusic;
    public Sprite MuteImg;
    public Sprite UnMuteImg;

    private bool muted = false;

    void Start()
    {
    }

    public void ToogleMusic()
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
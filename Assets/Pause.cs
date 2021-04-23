using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseUI;
    public Button pauseButton;
    public AudioSource backgroundMusic;
    public static bool isPaused = false;

    void Start()
    {
        pauseUI.SetActive(false);
        
    }

    public void switchPauseState()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            pauseUI.SetActive(true);
            backgroundMusic.Pause();
            Time.timeScale = 0f;
        }
        else
        {
            pauseUI.SetActive(false);
            backgroundMusic.Play(0);
            Time.timeScale = 1f;
        }
    }

   
}

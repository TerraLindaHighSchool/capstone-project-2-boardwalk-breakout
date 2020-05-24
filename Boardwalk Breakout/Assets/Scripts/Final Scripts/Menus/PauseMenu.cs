using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject howToPlayUI;
    public GameObject gotItUI;

    void Start()
    {
        gotItUI.SetActive(true);    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void HowToPlay()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        howToPlayUI.SetActive(true);
    }

    public void returnToPauseMenu()
    {
        howToPlayUI.SetActive(false);
        Pause();
    }

    public void gotIt()
    {
        gotItUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}

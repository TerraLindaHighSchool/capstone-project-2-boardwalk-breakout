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

    public GameObject loseUI;
    public GameObject winUI;
  
    public AudioSource pause;
    public AudioSource confirm;
    public AudioSource menuSound;

    void Start()
    {
        gotItUI.SetActive(true);
        pause.GetComponent<AudioSource>();
        confirm.GetComponent<AudioSource>();
        menuSound.GetComponent<AudioSource>();
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
                pause.Play();
                Pause(); 
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        confirm.Play();
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
        confirm.Play();
        SceneManager.LoadScene("Menu");
    }

    public void HowToPlay()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        howToPlayUI.SetActive(true);
        menuSound.Play();
    }

    public void returnToPauseMenu()
    {
        howToPlayUI.SetActive(false);
        Pause();
        confirm.Play();
    }

    public void gotIt()
    {
        gotItUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        confirm.Play();
    }


}

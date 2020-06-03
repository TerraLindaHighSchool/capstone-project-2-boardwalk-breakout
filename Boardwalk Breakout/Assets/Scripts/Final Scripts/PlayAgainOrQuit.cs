using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainOrQuit : MonoBehaviour
{
    public AudioSource confirm;
    public GameObject playAgainUI;

    private void Start()
    {
        confirm.GetComponent<AudioSource>();
    }

    public void returnToMenu()
    {
        Time.timeScale = 0f;
        confirm.Play();
        SceneManager.LoadScene("Menu");
    }

    public void playAgain()
    {
        playAgainUI.SetActive(false);
        Time.timeScale = 1f;
        confirm.Play();
        //SceneManager.LoadScene("Level Design"); 
    }


    /*public void gotIt()
    {
        gotItUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        confirm.Play();
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainOrQuit : MonoBehaviour
{
    public AudioSource confirm;
    public GameObject endingUI;

    private void Start()
    {
        confirm.GetComponent<AudioSource>();
    }

    public void returnToMenu()
    {
        endingUI.SetActive(false);
        Time.timeScale = 0f;
        confirm.Play();
        SceneManager.LoadScene("Menu");
    }

    public void playAgain()
    {
        endingUI.SetActive(false);
        Time.timeScale = 0f;
        confirm.Play();
        SceneManager.LoadScene("Level Design");
    }
}

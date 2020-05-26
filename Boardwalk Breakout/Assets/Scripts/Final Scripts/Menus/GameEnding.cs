using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    public AudioSource confirm;
    public GameObject loseUI;
    public GameObject winUI;

    void Start()
    {
        confirm.GetComponent<AudioSource>();
    }

    public void youLose()
    {
        loseUI.SetActive(false);
        Time.timeScale = 1f;
        confirm.Play();
        SceneManager.LoadScene("Menu");
    }

    public void youWin()
    {
        //
    }

    /*public GameObject winUI;
    public GameObject loseUI;

    public void playAgain()
    {
        winUI.SetActive(false);
        loseUI.SetActive(false);
        SceneManager.LoadScene(1);
        //Application.LoadLevel(Application.loadedLevel);
        //Time.timeScale = 1f;
    }

    */
}

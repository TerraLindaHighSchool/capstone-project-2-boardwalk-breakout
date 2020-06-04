using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource confirm;
    public AudioSource menuSound;
    //public GameObject loseUI;

    void Start()
    {
       confirm.GetComponent<AudioSource>();
       menuSound.GetComponent<AudioSource>();
    }

    public void startGame()
    {
        confirm.Play();
        Application.LoadLevel(1);
        //SceneManager.LoadScene(1);
        //loseUI.SetActive(false);

    }

    public void howToPlayGame()
    {
       menuSound.Play();
       SceneManager.LoadScene("How To Play");
    }

    public void credits()
    {
        menuSound.Play();
        SceneManager.LoadScene("Credit Page");
    }

    public void exitGame()
    {
        confirm.Play();
        Application.Quit(); 
    }
}
